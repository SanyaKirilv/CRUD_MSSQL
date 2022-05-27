using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server_v0._0.Models
{
    public class Worker
    {
        public int WorkerID { get; set; }

        [Required(ErrorMessage = "������� �� ����� ���� ����� 30 ��������!")]
        [StringLength(30)]
        [Display(Name = "�������:")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "��� �� ����� ���� ����� 30 ��������!")]
        [StringLength(30)]
        [Display(Name = "���:")]
        public string FirstName { get; set; }

        [StringLength(30, ErrorMessage = "�������� �� ����� ���� ����� 30 ��������!")]
        [Display(Name = "��������:")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "�������� �� ����� ���� ������ ����!")]
        [Range(0, 1000000000)]
        [Display(Name = "��������:")]
        public double Salary { get; set; }

        [StringLength(50)]
        [Display(Name = "�������� �����:")]
        public string Email { get; set; }

        public List<Transaction> Transactions { get; set; }
    }
}
