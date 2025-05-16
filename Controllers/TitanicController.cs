using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace mvc_expressions.Controllers
{
    public class TitanicController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ViewBagData = "CustomViewBagDataHotReleoadTest";
            ViewData["ViewDataData"] = "CustomViewDataDataHotReloadTest";
            Response.Cookies.Append("CookieItem", "test cookie item");
            var rvalue = Request.Cookies.Where((kvp) =>
            {
                bool bReturnValue = false; ;
                var svalue = kvp.Key;
                if (svalue.Equals("CookieItem"))
                {
                    bReturnValue = true;
                }
                else
                {
                    bReturnValue |= false;
                }
                return bReturnValue;
            });
            var fod = rvalue.FirstOrDefault();
            return View("Titanic");
        }
    }
}
