using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCStore.Domain.Core
{
   public class ShippingDetails
    {
        [Required(ErrorMessage = "Укажите ваше Имя.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Укажите вашу Фамилию.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Укажите ваш город.")]
        public string City { get; set; }


        [Required(ErrorMessage = "Укажите ваш номер телефона")]
        [RegularExpression(@"\d{3}\d{3}\d{4}$", ErrorMessage = "Номер телефона должен иметь формат +ХХХ-ХХХ-ХХХХ.")]
        public string PhoneNumber { get; set; }

        [RegularExpression(@"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                           @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$",
                           ErrorMessage = "Введенный E-mail имеет не верный формат.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Укажите ваш Индекс")]
        [RegularExpression(@"\d{5}", ErrorMessage = "Введённый PostalCode имеет не верный формат.")]
        public string PostalCode { get; set; }

        public bool CallBack { get; set; }

    }
}
