using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MultiShop.WebUI.Areas.Admin.Attributes
{
    public class PopulateViewBagAttribute : ActionFilterAttribute
    {
        private readonly string _param1;
        private readonly string _param2;
        private readonly string _param3;

        public PopulateViewBagAttribute(string param1, string param2, string param3)
        {
            _param1 = param1;
            _param2 = param2;
            _param3 = param3;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.Controller as Controller;
            if (controller != null)
            {
                // ViewBag'e parametreleri ekleme
                controller.ViewBag.v1 = _param1;
                controller.ViewBag.v2 = _param2;
                controller.ViewBag.v3 = _param3;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
