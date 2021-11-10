using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.Web.Filters
{
    public class AuthAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var userSession = filterContext.HttpContext.Session["LoginBilgileri"];
            if (userSession == null)
            {
                filterContext.HttpContext.Response.Redirect("/auth/login");
            }
        }
    }
}