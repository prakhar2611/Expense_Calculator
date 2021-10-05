﻿using Microsoft.AspNetCore.Http;
using Expense_Calculator.Infrastructure;

namespace Expense_Calculator.Services
{
    public class AccountService : ServiceBase
    {
        public Result<ServiceUser> Login(HttpContext context, string login, string password)
        {
            context.Response.Cookies.Append(Constants.AuthorizationCookieKey, login);

            return Ok(new ServiceUser
            {
                Login = login
            });
        }

        public Result<ServiceUser> Verify(HttpContext context)
        {
            var cookieValue = context.Request.Cookies[Constants.AuthorizationCookieKey];
            if (string.IsNullOrEmpty(cookieValue))
                return Error<ServiceUser>();
            return Ok(new ServiceUser
            {
                Login = cookieValue
            });
        }

        public Result Logout(HttpContext context)
        {
            context.Response.Cookies.Delete(Constants.AuthorizationCookieKey);
            return Ok();
        }
    }
}