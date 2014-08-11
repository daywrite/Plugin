using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElementsPlugin.Models
{
    public class Account
    {
        [Display(Name = "姓名"),Required(ErrorMessage = "姓名不能为空"), MaxLength(30, ErrorMessage="姓名长度不能超过30")]
        public string Name { get; set; }
        [Display(Name = "密码"), Required(ErrorMessage = "密码不能为空"), MinLength(6), MaxLength(30)]
        public string Password { get; set; }
        [Display(Name = "记住密码")]
        public bool RememberMe { get; set; }
    }
}