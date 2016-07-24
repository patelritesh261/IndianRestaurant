namespace IndianRestaurant.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RestuarantModel : DbContext
    {
        public RestuarantModel()
            : base("name=RestuarantConnection")
        {
        }



        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Item> Items { get; set; }
    }
}
