
using System.Threading.Tasks;
using ContactPage_Elitecrescent.Models;

namespace ContactPage_Elitecrescent.Repositories
{
    public interface ICheckEmail
    {
        public bool CheckValidEmail(Contact_Model contactModel);

    }
}