using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVCPractice.Controllers
{
    public class 宣告客戶分類的SelectList物件Attribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var li = new List<SelectListItem>();
            li.Add(new SelectListItem() { Text = "分類1", Value = "分類1" });
            li.Add(new SelectListItem() { Text = "分類2", Value = "分類2" });
            li.Add(new SelectListItem() { Text = "分類3", Value = "分類3" });
            filterContext.Controller.ViewBag.客戶分類 = new SelectList(li, "Value", "Text");
            base.OnActionExecuting(filterContext);
        }
    }
}