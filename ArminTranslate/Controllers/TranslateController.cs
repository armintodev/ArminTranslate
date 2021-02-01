using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace ArminTranslate.Controllers
{
    public class TranslateController : Controller
    {
        public IActionResult Translate(string from,string to,string text)
        {
            //translate api
            var client = new RestClient($"https://api.codebazan.ir/lang/google/?FROM={from}&TO={to}&TEXT={text}");
            
            //request api
            var request = new RestRequest(Method.GET);
            
            //response api
            IRestResponse response = client.Execute(request);

            //this is for return value to view .
            ViewBag.Content = response.Content;
            return View();
        }
    }
}
