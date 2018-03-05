using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace YahooFantasyWeb.Pages
{
    public class GameModel : PageModel
    {
        public void OnGet()
        {
            byte[] bytes;
            HttpContext.Session.TryGetValue("auth", out bytes);
            if (bytes != null)
            {
                TempData["auth"] = bytes.ToViewModel();
            }
        }
    }
}