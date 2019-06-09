using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NITBook.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; } // 账户主键

        [Required(ErrorMessage ="必须输入用户名")]
        [Display(Name ="用户名")]
        [MaxLength(12,ErrorMessage ="用户名不能超过 12 个有效字符")]
        [MinLength(6,ErrorMessage ="用户名不能少于 6 个有效字符")]
        public string userName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="必须输入密码")]
        [Display(Name = "密码")]
        [MaxLength(12, ErrorMessage = "密码长度不能多于 12 个字符")]
        [MinLength(6, ErrorMessage = "用户名不能少于 6 个字符")]
        public string password { get; set; }

        [Display(Name ="最新登录时间")]
        public DateTime? LoginTime { get; set; }

        [Display(Name ="创建时间")]
        public DateTime createTime { get; set; }

        [Required]
        [Display(Name = "是否拥有管理员权限")]
        public bool isAdmin { get; set; }
    }
}