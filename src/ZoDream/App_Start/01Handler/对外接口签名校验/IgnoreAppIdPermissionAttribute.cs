﻿using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace ZoDream.Web
{
    /// <summary>
    /// 忽略校验AppId接口权限
    /// </summary>
    public class IgnoreAppIdPermissionAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}