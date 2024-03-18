using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Dtos.NewsReport;
using Backend.Interfaces;
using Backend.Mappers;
using Backend.QueryObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/newsreport")]
    [ApiController]
    public class NewsReportController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly INewsReportRepository _newsReportRepo;
        public NewsReportController(ApplicationDbContext context, INewsReportRepository newsReportRepo)
        {
            _newsReportRepo = newsReportRepo;
            _context = context;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] NewsReportQueryObject query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newsReports = await _newsReportRepo.GetAllAsync(query);

            var newsReportDto = newsReports.Select(s => s.ToNewsReportDto()).ToList();

            return Ok(newsReportDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newsReport = await _newsReportRepo.GetByIdAsync(id);

            if (newsReport == null)
            {
                return NotFound();
            }

            return Ok(newsReport.ToNewsReportDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NewsReportDto newsReportDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newsReportModel = newsReportDto.ToNewsReportFromCreateDTO();

            await _newsReportRepo.CreateAsync(newsReportModel);

            return CreatedAtAction(nameof(GetById), new { id = newsReportModel.Id }, newsReportModel.ToNewsReportDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] NewsReportDto newsReportDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newsReportModel = await _newsReportRepo.UpdateAsync(id, newsReportDto);

            if (newsReportModel == null)
            {
                return NotFound();
            }

            return Ok(newsReportModel.ToNewsReportDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newsReportModel = await _newsReportRepo.DeleteAsync(id);

            if (newsReportModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
//