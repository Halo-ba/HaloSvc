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
    [Route("api/Article")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IArticleRepository _ArticleRepo;
        public ArticleController(ApplicationDbContext context, IArticleRepository ArticleRepo)
        {
            _ArticleRepo = ArticleRepo;
            _context = context;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] ArticleQueryObject query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Articles = await _ArticleRepo.GetAllAsync(query);

            var ArticleDto = Articles.Select(s => s.ToArticleDto()).ToList();

            return Ok(ArticleDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Article = await _ArticleRepo.GetByIdAsync(id);

            if (Article == null)
            {
                return NotFound();
            }

            return Ok(Article.ToArticleDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ArticleDto articleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var articleModel = articleDto.ToArticleFromCreateDTO();

            await _ArticleRepo.CreateAsync(articleModel);

            return CreatedAtAction(nameof(GetById), new { id = articleModel.Id }, articleModel.ToArticleDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ArticleDto articleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var articleModel = await _ArticleRepo.UpdateAsync(id, articleDto);

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

            var articleModel = await _ArticleRepo.DeleteAsync(id);

            if (articleModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}