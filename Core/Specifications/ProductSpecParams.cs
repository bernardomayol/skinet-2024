﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductSpecParams
    {
		private List<string> _brands = [];
		private List<string> _types = [];

        public int PageIndex { get; set; } = 1;
        private const int MaxPageSize = 50;

        private int _pageSize = 6;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public List<string> Brands
		{
			get => _brands;
			set 
			{ 
				_brands = value.SelectMany(x => x.Split(',', StringSplitOptions.RemoveEmptyEntries)).ToList(); 
			}
		}
		public List<string> Types
		{
			get => _types;
			set 
			{ 
				_types = value.SelectMany(x => x.Split(',', StringSplitOptions.RemoveEmptyEntries)).ToList(); 
			}
		}
		public string? Sort { get; set; } = "name";
		private string? _search;

		public string Search
		{
			get => _search ?? "";
			set => _search = value.ToLower();
		}



	}
}
