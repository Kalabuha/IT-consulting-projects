using System.ComponentModel.DataAnnotations;

namespace WebModels.Validations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class PhoneNumberAttribute : RegularExpressionAttribute
    {
        public PhoneNumberAttribute() 
            : base(@"(\+7|8)[\s-]?((\(\d{3})\)|\d{3})([\s-]?\d){7}")
        {
            ErrorMessage = "Некорректный номер телефона";
        }
    }
}
