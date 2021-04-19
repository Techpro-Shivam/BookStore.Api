using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Api.Data
{
	public class BookContext : DbContext
	{
		public BookContext(DbContextOptions<BookContext> options) : base(options)
		{

		}
		public DbSet<Books> Books { get; set; }



		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//	optionsBuilder.UseSqlServer("Server=.;Database=BookStoreApi;Integrated Security=True");
		//	base.OnConfiguring(optionsBuilder);
		//}
	}
}
