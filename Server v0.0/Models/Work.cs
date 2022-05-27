using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server_v0._0.Models
{
    public class Work : IValidatableObject
    {
        public int WorkID { get; set; }

        [Required(ErrorMessage = "Выберете дату начала!")]
        [Display(Name = "Дата Начала:")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MMMM-yyyy}")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Выберете дату окончания!")]
        [Display(Name = "Дата окончания:")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MMMM-yyyy}")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Количество рабочих не может быть меньше нуля!")]
        [Display(Name = "Колличество рабочих:")]
        [Range(0, 1000000000)]
        public int WorkersCount { get; set; }

        public List<Transaction> Transactions { get; set; }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            if (EndDate < StartDate)
            {
                yield return new ValidationResult("Дата окончания работы должна быть позднее даты начала!");
            }
        }
    }
}
