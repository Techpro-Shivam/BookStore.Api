using AutoMapper;
using BookStore.Api.Data;
using BookStore.Api.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Api.Repository
{
	public class BookRepository : IBookRepository
	{
		private readonly BookContext _context;
		private readonly IMapper _mapper;

		public BookRepository(BookContext context,IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}
		public async Task<List<BookModels>> GetAllBooks()
		{
			//var records = await _context.Books.Select(x => new BookModels()
			//{
			//	Id = x.Id,
			//	Title = x.Title,
			//	Description = x.Description
			//}).ToListAsync();
			var datalist = await _context.Books.ToListAsync();
			
			// using AutoMapper
			return _mapper.Map<List<BookModels>>(datalist);
		}
		public async Task<BookModels> GetBookById(int bookid)
		{
			var data = await _context.Books.FindAsync(bookid);
			
			//var records = await _context.Books.Where(x=>x.Id==bookid).Select(x => new BookModels()
			//{   
			//	Id = x.Id,
			//	Title = x.Title,
			//	Description = x.Description
			//}).FirstOrDefaultAsync();
			return _mapper.Map<BookModels>(data);
		}
		public async Task<int> AddBook(BookModels _model)
		{
			var books = new Books()
			{				
				Title = _model.Title,
				Description = _model.Description
			};
			_context.Books.Add(books);
			 await _context.SaveChangesAsync();
			return books.Id;
		}
		public async Task UpdateBook(BookModels _model)
		{
			// In this approach we are hitting database at only one time 
			var books = new Books()
			{
				Id = _model.Id,
				Title = _model.Title,
				Description = _model.Description
			};
			_context.Books.Update(books);
			await _context.SaveChangesAsync();

			// In this approach we are hitting database at two times which is not good
			//var data = _context.Books.Find(_model.Id);
			//data.Title = _model.Title;
			//data.Description = _model.Description;
			//_context.Books.Update(data);
			//await _context.SaveChangesAsync();

		}
		public async Task UpdateBookByPatch(int id ,JsonPatchDocument _model)
		{
			var data = await _context.Books.FindAsync(id);
			_model.ApplyTo(data);
			await  _context.SaveChangesAsync();

		}
		public async Task DeleteById(int bookid)
		{
			var records = await _context.Books.Where(x => x.Id == bookid).FirstOrDefaultAsync();
			_context.Books.Remove(records);
	        await _context.SaveChangesAsync();
		}
	}
}
