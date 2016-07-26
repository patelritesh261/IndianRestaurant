using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IndianRestaurant.Models
{
    public class Menu
    {
        public Menu()
        {

        }
        public int MenuId { get; set; }
        [Display(Name="Menu")]
        public string Name { get; set; }
        public List<Item> Item { get; set; }
    }
}