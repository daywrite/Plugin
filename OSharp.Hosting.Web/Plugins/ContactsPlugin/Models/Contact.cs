using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Web;

namespace ContactsPlugin.Models
{
    public class Contact
    {
        private static int _autoId;
        public int Id { get; set; }
        [Display(Name = "姓名"), Required(ErrorMessage = "姓名不能为空"), MaxLength(50, ErrorMessage = "姓名长度不能超过50")]
        public string Name { get; set; }
        [Display(Name = "电话"), Required(ErrorMessage = "电话不能为空"), Phone]
        public string Phone { get; set; }
        [Display(Name = "邮箱"), EmailAddress(ErrorMessage = "邮箱格式不正确"), Required(ErrorMessage = "邮箱不能为空")]
        public string Email { get; set; }

        public static Contact New()
        {
            return new Contact { Id = Interlocked.Increment(ref _autoId) };
        }

        public static int NewId()
        {
            return Interlocked.Increment(ref _autoId);
        }
    }
}