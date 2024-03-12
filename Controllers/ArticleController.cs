using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Dtos.Article;
using Backend.Interfaces;
using Backend.Mappers;
using Backend.QueryObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/article")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IArticleRepository _articleRepo;
        public ArticleController(ApplicationDbContext context, IArticleRepository articleRepo)
        {
            _articleRepo = articleRepo;
            _context = context;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] ArticleQueryObject query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var articles = await _articleRepo.GetAllAsync(query);

            var articleDto = articles.Select(s => s.ToArticleDto()).ToList();

            return Ok(articleDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var article = await _articleRepo.GetByIdAsync(id);

            if (article == null)
            {
                return NotFound();
            }

            return Ok(article.ToArticleDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ArticleDto articleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var articleModel = articleDto.ToArticleFromCreateDTO();

            await _articleRepo.CreateAsync(articleModel);

            return CreatedAtAction(nameof(GetById), new { id = articleModel.Id }, articleModel.ToArticleDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ArticleDto articleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var articleModel = await _articleRepo.UpdateAsync(id, articleDto);

            if (articleModel == null)
            {
                return NotFound();
            }

            return Ok(articleModel.ToArticleDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var articleModel = await _articleRepo.DeleteAsync(id);

            if (articleModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}