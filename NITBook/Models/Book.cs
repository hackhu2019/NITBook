using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NITBook.Models
{
    public class Book
    {
        public int bookID { get; set; }

        [Required(ErrorMessage ="必须图书名")]
        [Display(Name ="书名")]
        public string bookName { get; set; }

        [Display(Name ="图片路径")]
        public string imageUrl { get; set; }

        [Required(ErrorMessage ="必须输入图书编号")]
        [Display(Name ="图书ISBN")]
        public string ISBN { get; set; }

        [Display(Name ="出版社")]
        public string publicName { get; set; }

        [Display(Name ="出版时间")]
        public DateTime publicTime { get; set; }

        [Required(ErrorMessage ="必须填写书籍作者名称")]
        [Display(Name ="作者")]
        public string author { get; set; }

        [Required(ErrorMessage ="必须选择图书分类")]
        [Display(Name ="分类")]
        public string sort { get; set; }

        [Required(ErrorMessage ="必须填写库存数量")]
        [Display(Name ="库存")]
        [Range(0,10,ErrorMessage ="图书库存范围为 0~10")]
        public int number { get; set; }

        [Display(Name ="借出数量")]
        public int borrowNumber { get; set; }

        [Display(Name ="内容简介")]
        public string info { get; set; }
    }
}