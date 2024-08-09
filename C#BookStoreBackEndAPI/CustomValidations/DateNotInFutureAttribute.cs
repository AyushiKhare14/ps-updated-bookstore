using System.ComponentModel.DataAnnotations;

namespace C_BookStoreBackEndAPI.CustomValidations
{
    public class DateNotInFutureAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateOnly dateValue)
            {
                return dateValue <= DateOnly.FromDateTime(DateTime.Now);
            }
            return false;
        }
    }
}
