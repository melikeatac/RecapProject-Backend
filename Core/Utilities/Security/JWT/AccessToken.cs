using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken
    {
        /*Kullanıcı api üzerinden yani postmandan kullanıcı adı password verecek ve biz de ona token vereceğiz ve
         ne zaman sonlanacağı bilgisi vereceğiz.*/
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
