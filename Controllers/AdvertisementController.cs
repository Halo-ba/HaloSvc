using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Dtos.Advertisement;
using Backend.Interfaces;
using Backend.Mappers;
using Backend.QueryObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/advertisement")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IAdvertisementRepository _advertisementRepo;
        public AdvertisementController(ApplicationDbContext context, IAdvertisementRepository advertisementRepo)
        {
            _advertisementRepo = advertisementRepo;
            _context = context;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] AdvertisementQueryObject query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var advertisements = await _advertisementRepo.GetAllAsync(query);

            var advertisementDto = advertisements.Select(s => s.ToAdvertisementDto()).ToList();

            return Ok(advertisementDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var advertisement = await _advertisementRepo.GetByIdAsync(id);

            if (advertisement == null)
            {
                return NotFound();
            }

            return Ok(advertisement.ToAdvertisementDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AdvertisementDto advertisementDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var advertisementModel = advertisementDto.ToAdvertisementFromCreateDTO();

            await _advertisementRepo.CreateAsync(advertisementModel);

            return CreatedAtAction(nameof(GetById), new { id = advertisementModel.Id }, advertisementModel.ToAdvertisementDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] AdvertisementDto advertisementDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var advertisementModel = await _advertisementRepo.UpdateAsync(id, advertisementDto);

            if (advertisementModel == null)
            {
                return NotFound();
            }

            return Ok(advertisementModel.ToAdvertisementDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var advertisementModel = await _advertisementRepo.DeleteAsync(id);

            if (advertisementModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}