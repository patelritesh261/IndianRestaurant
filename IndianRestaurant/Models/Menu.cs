using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
/*
 * @File name : Menu Model
 * @Author : Ritesh Patel and Parvati Patel
 * @Website name : Taj Mahel(http://indianrestaurant.azurewebsites.net/)
 * @File description : This model has defination of menu model
 */
namespace IndianRestaurant.Models
{
    public class Menu
    {
        public Menu()
        {

        }
        //property of menu model
        public int MenuId { get; set; }
        [Display(Name="Menu")]
        public string Name { get; set; }
        public List<Item> Item { get; set; }
    }
}