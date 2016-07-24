using System;
using System.Collections.Generic;
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
        public string Name { get; set; }
        public List<Item> Item { get; set; }
    }
}