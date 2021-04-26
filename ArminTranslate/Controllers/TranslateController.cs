using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace ArminTranslate.Controllers
{
    public class TranslateController : Controller
    {
        [HttpGet]
        public IActionResult Translate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Translate(string from, string to, string text)
        {
            //translate api
            var client = new RestClient($"https://api.codebazan.ir/lang/google/?FROM={from}&TO={to}&TEXT={text}");

            //request api
            var request = new RestRequest(Method.GET);

            //response api
            IRestResponse response = client.Execute(request);
            if (!response.IsSuccessful)
            {
                return new JsonResult("خطایی در سمت سرویس رخ داده است");
            }

            //this is for return value to view .
            ViewBag.Content = response.Content;
            return View();
        }
    }
}
