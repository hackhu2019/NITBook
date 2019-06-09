using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NITBook.Models
{
    public class BorrowInfo
    {
        [Key]
        [Display(Name = "借阅编号")]
        [Required]
        public int borrow_Id { get; set; }

        [Display(Name ="书名")]
        [Required(ErrorMessage ="必须输入借阅书名")]
        public string bookName { get; set; }

        [Display(Name ="借阅者编号")]
        [Required(ErrorMessage ="必须输入借阅者编号")]
        public int readerId { get; set; }

        [Display(Name = "借阅时间")]
        [Required(ErrorMessage = "必须输入借阅时间")]
        public DateTime borrowTime { get; set; }

        [Display(Name ="还书时间")]
        public DateTime? backTime { get; set; }

        [Display(Name ="是否超期")]
        public bool isBeyond { get; set; }
    }
}