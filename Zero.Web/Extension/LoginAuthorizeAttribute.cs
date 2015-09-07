﻿
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Zero.Utility;

namespace Zero.Web
{
    /// <summary>
    /// 登录权限认证
    /// </summary>
    public class LoginAuthorizeAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// 响应前执行验证,查看当前用户是否有效 
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var areaName = filterContext.RouteData.DataTokens["area"];
            var controllerName = filterContext.RouteData.Values["controller"];
            var action = filterContext.RouteData.Values["Action"];
            //登录是否过期
            if (!ManageProvider.Provider.IsOverdue())
            {
                filterContext.Result = new RedirectResult("~/Login/Default");
            }
        }
    }
}