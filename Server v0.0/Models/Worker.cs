using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server_v0._0.Models
{
    public class Worker
    {
        public int WorkerID { get; set; }

        [Required(ErrorMessage = "Фамилия не может быть более 30 символов!")]
        [StringLength(30)]
        [Display(Name = "Фамилия:")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Имя не может быть более 30 символов!")]
        [StringLength(30)]
        [Display(Name = "Имя:")]
        public string FirstName { get; set; }

        [StringLength(30, ErrorMessage = "Отчество не может быть более 30 символов!")]
        [Display(Name = "Отчество:")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Зарплата не может быть меньше нуля!")]
        [Range(0, 1000000000)]
        [Display(Name = "Зарплата:")]
        public double Salary { get; set; }

        [StringLength(50)]
        [Display(Name = "Почтовый адрес:")]
        public string Email { get; set; }

        public List<Transaction> Transactions { get; set; }
    }
}
