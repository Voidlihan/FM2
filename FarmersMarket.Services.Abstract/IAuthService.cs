using FarmersMarket.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmersMarket.Services.Abstract
{
    public interface IAuthService
    {
        User SignUp(string email, string password);
        User SignIn(string email, string password);
    }
}
