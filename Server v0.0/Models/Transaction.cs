using Server_v0._0.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Server_v0._0
{
    public class Transaction
    {
        public int TransactionID { get; set; }

        [Required(ErrorMessage = "Выберете почтовый адрес рабочего!")]
        [Range(0, 1000000000)]
        [Display(Name = "Почтовый адрес рабочего:")]
        public int WorkerID { get; set; }
        [Display(Name = "Почтовый адрес рабочего:")]
        public Worker Worker { get; set; }

        [Required(ErrorMessage = "Выберете код работы!")]
        [Range(0, 1000000000)]
        [Display(Name = "Код работы:")]
        public int WorkID { get; set; }
        [Display(Name = "Код работы:")]
        public Work Work { get; set; }

        [Required(ErrorMessage = "Выберете тип работы!")]
        [Range(0, 1000000000)]
        [Display(Name = "Тип работы:")]
        public int WorkTypeID { get; set; }
        [Display(Name = "Тип работы:")]
        public WorkType WorkType { get; set; }
    }
}
