using Server_v0._0.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Server_v0._0
{
    public class Transaction
    {
        public int TransactionID { get; set; }

        [Required(ErrorMessage = "�������� �������� ����� ��������!")]
        [Range(0, 1000000000)]
        [Display(Name = "�������� ����� ��������:")]
        public int WorkerID { get; set; }
        [Display(Name = "�������� ����� ��������:")]
        public Worker Worker { get; set; }

        [Required(ErrorMessage = "�������� ��� ������!")]
        [Range(0, 1000000000)]
        [Display(Name = "��� ������:")]
        public int WorkID { get; set; }
        [Display(Name = "��� ������:")]
        public Work Work { get; set; }

        [Required(ErrorMessage = "�������� ��� ������!")]
        [Range(0, 1000000000)]
        [Display(Name = "��� ������:")]
        public int WorkTypeID { get; set; }
        [Display(Name = "��� ������:")]
        public WorkType WorkType { get; set; }
    }
}
