using BookStore.Api.Models;
using BookStore.Api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookApiController : ControllerBase
	{
		private readonly IBookRepository _bookRepository;

		public BookApiController(IBookRepository bookRepository)
		{
			_bookRepository = bookRepository;
		}

		[HttpGet("")]
		public async Task<IActionResult> GetAllBooks()
		{
			var records = await _bookRepository.GetAllBooks();
			return Ok(records);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetBookById([FromRoute] int id)
		{
			var records = await _bookRepository.GetBookById(id);
			if(records==null)
			{
				return NotFound();
			}
			return Ok(records);
		}
		[HttpPost("")]
		public async Task<IActionResult> AddBook([FromBody] BookModels _model)
		{
			var id = await _bookRepository.AddBook(_model);
			return Ok(id);
			//return CreatedAtAction("GetBookById",new { id = id,Controller = "BookApi" } , id);
		}
		[HttpPut("")]
		public async Task<IActionResult> UpdateBook([FromBody] BookModels _model)
		{
			await _bookRepository.UpdateBook(_model);
			return Ok();
			
		}
		[HttpPatch("{id}")]
		public async Task<IActionResult> UpdateBookByPatch([FromRoute] int id ,[FromBody] JsonPatchDocument _model)
		{
			await _bookRepository.UpdateBookByPatch(id,_model);
			return Ok();

		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteById([FromRoute] int id)
		{
			await _bookRepository.DeleteById(id);
			return Ok();

		}
	}
}
