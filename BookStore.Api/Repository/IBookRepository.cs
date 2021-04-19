using BookStore.Api.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Api.Repository
{
	public interface IBookRepository
	{
		Task<List<BookModels>> GetAllBooks();
		Task<BookModels> GetBookById(int bookid);
		Task<int> AddBook(BookModels _model);
	    Task UpdateBook(BookModels _model);
		Task UpdateBookByPatch(int id, JsonPatchDocument _model);
		Task DeleteById(int bookid);
	}
}
