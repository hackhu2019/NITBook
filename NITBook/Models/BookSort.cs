using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NITBook.Models
{
    public class BookSort
    {
        [Key]
        [Required]
        [Display(Name = "图书类别编号")]
        public int SortId { get; set; }

        [Required]
        [MaxLength(10,ErrorMessage ="图书类别不能超过 10 个字符")]
        [MinLength(1,ErrorMessage ="图书类别长度不能少于 1 个字符")]
        [Display(Name = "图书类别")]
        public string Name { get; set; }
    }
}