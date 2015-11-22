using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPNET5EFDemo.Controllers.Web
{
   
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Echo()
        {
            var data = new List<string>();


            foreach ( var q in Request.Query)
            {
                string queryValue = string.Empty;
                foreach (var s in q.Value)
                    queryValue += s;
                data.Add(q.Key + ":" + queryValue);
                
            }

            if (Request.HasFormContentType)
            {
                foreach (var f in Request.Form)
                {
                    string postValue = string.Empty;
                    foreach (var s in f.Value)
                        postValue += s;
                    data.Add(f.Key + ":" + postValue);
                    
                }
            }

            return View(data);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
