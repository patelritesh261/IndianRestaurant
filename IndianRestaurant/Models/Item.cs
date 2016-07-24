using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndianRestaurant.Models
{
    public class Item
    {
        public Item()
        {

        }
        public int ItemId { get; set; }
        public int MenuId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string OriginalImageUrl { get; set; }
        public string ThumbImageUrl { get; set; }
        public Menu Menu { get; set; }

    }
}