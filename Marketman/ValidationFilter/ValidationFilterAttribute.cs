using Microsoft.AspNetCore.Mvc.Filters;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketman.ValidationFilter
{
    public class ValidationFilterAttribute : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var param = context.ActionArguments.SingleOrDefault(p => p.Value is Celebrity);
            if (param.Value == null)
                throw new Exception("Object is null");
            if (!context.ModelState.IsValid)
                throw new Exception("Object is not valid");

        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
