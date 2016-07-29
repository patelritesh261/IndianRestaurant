namespace IndianRestaurant.Models
{
    /*
    * @File name : RestuarantModel
    * @Author : Ritesh Patel and Parvati Patel
    * @Website name : Taj Mahel(http://indianrestaurant.azurewebsites.net/)
    * @File description : This is model of project which contain  schema of project
    */
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
