using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class RegisterModel
    {
        [Required(ErrorMessage = "Поле ПІБ обов'язкове")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Поле вік обов'язкове")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Поле обласний центр обов'язкове")]
        public string RegionalCenter { get; set; }
        [Required(ErrorMessage = "Поле eMail обов'язкове")]
        [EmailAddress(ErrorMessage = "Неправильний формат eMail")]
        public string Email { get; set; }
        public string Phone { get; set; }
        [Required(ErrorMessage = "Поле пароль обов'язкове")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}