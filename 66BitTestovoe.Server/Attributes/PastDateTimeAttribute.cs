using System.ComponentModel.DataAnnotations;

namespace _66BitTestovoe.Server.Attributes;

public class PastDateTimeAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value is not DateTime dateTime || dateTime <= DateTime.Now)
        {
            return true;
        }
        
        ErrorMessage = "Date cannot be in the future.";
        return false;
    }
}