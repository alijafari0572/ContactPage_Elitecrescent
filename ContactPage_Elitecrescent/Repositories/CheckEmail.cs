using ContactPage_Elitecrescent.Models;
using EmailValidation;
namespace ContactPage_Elitecrescent.Repositories
{
    public class CheckEmail : ICheckEmail
        {
            public bool CheckValidEmail(Contact_Model contactModel)
            {
                var IsValidEmail = EmailValidator.Validate(contactModel.Email);
                return IsValidEmail;
            }
        }
    
}
