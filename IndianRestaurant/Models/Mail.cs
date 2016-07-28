using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/*
 * @File name : Mail Model
 * @Author : Ritesh Patel and Parvati Patel
 * @Website name : Taj Mahel(http://indianrestaurant.azurewebsites.net/)
 * @File description : This model use for contact me
 */

namespace IndianRestaurant.Models
{
    public class Mail
    {
        //property of mail model
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
    }
}