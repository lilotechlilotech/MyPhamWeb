
using System.Web;
using System.Web.Security;

namespace Outsourcing.Core.Authentication
{
    public interface IFormsAuthentication
    {       
        void Signout();       
        void SetAuthCookie(HttpContextBase httpContext, FormsAuthenticationTicket authenticationTicket);        
        void SetAuthCookie(HttpContext httpContext, FormsAuthenticationTicket authenticationTicket);
        FormsAuthenticationTicket Decrypt(string encryptedTicket);
    }
}