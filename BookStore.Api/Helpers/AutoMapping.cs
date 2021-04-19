using AutoMapper;
using BookStore.Api.Data;
using BookStore.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Api.Helpers
{
	public class AutoMapping:Profile
	{
		public AutoMapping()
		{
			CreateMap<Books,BookModels>();
		}
	}
}
