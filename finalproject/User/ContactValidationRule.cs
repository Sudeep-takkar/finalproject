using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace finalproject.User
{
    class ContactValidationRule : ValidationRule
    {
        private int min;
        private int max;

        public int Min
        {
            get => min;
            set => min = value;
        }
        public int Max
        {
            get => max;
            set => max = value;
        }

        public override ValidationResult Validate
            (object value, CultureInfo cultureInfo)
        {
            int number = 0;
            if (!int.TryParse((string)value, out number))
            {
                return new ValidationResult(false,
                    "Data Type of Phone number is incorrect.");
            }
            if (number < min || number > max)
            {
                return new ValidationResult(false, string.Format("Contact number must be of 10 digits."));
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}
