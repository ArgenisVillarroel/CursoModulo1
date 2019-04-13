using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccountManager.Data.Models.DTO
{
    public class AccountDTO
    {
        public int Id { get; set; }

        [Display(Name = "Código")]
        [MaxLength(3)]
        [Required(ErrorMessage = "{0} es requerido")]
        public string Code { get; set; }

        [Display(Name = "Nomabre")]
        [MaxLength(3)]
        [Required(ErrorMessage = "{0} es requerido")]
        public string Name { get; set; }


        public ViewModelDTO<int> AccountType { get; set; }
    }
}
