using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server_v0._0.Models
{
    public class WorkType
    {
        public int WorkTypeID { get; set; }

        [Required(ErrorMessage = "Название не может быть больше 30 символов!")]
        [StringLength(30)]
        [Display(Name = "Название:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Оплата за день не может быть меньше нуля!")]
        [Range(0, 1000000000)]
        [Display(Name = "Оплата за день:")]
        public double Pay { get; set; }

        public List<Transaction> Transactions { get; set; }
    }
}
