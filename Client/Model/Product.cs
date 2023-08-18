﻿using EFarm.Client.Model;

namespace EFarm.Client.Model
{
	public class Product
    {
        public int Id { get; set; }
        public string Name { get;  set; }
        public string? Description { get;  set; }
        public decimal? OldPrice { get;  set; }
        public decimal Price { get;  set; }
        public string? PictureUri { get;  set; }
		

    }

}
