using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
/*
 * @File name : Item Model
 * @Author : Ritesh Patel and Parvati Patel
 * @Website name : Taj Mahel(http://indianrestaurant.azurewebsites.net/)
 * @File description : This model has defination of item model
 */
namespace IndianRestaurant.Models
{
    public class Item
    {
        public Item()
        {

        }
        //property of item models
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