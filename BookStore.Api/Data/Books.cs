﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Api.Data
{
	public class Books
	{
		public int Id { get; set; }
		
		public string Title { get; set; }
		public string Description { get; set; }
	}
}
