using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Menu")]
        public int MenuId { get; set; }
        [Display(Name="Item")]
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        [Display(Name="Image")]
        public string OriginalImageUrl { get; set; }
        public string ThumbImageUrl { get; set; }
        public Menu Menu { get; set; }

    }
}