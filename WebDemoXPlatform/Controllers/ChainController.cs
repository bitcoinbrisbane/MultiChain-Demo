using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebDemoXPlatform.Controllers
{
    public class ChainController : Controller
    {
        public ActionResult Index()
        {
            List<ViewModels.ChainViewModel> models = new List<ViewModels.ChainViewModel>();
            models.Add(new ViewModels.ChainViewModel() { Name = "gbst1" });
            models.Add(new ViewModels.ChainViewModel() { Name = "chain1" });
            return View(models);
        }

        public async Task<ActionResult> Details(String id)
        {
            using (Clients.Client client = new Clients.Client(System.Configuration.ConfigurationManager.AppSettings["Node1"], System.Configuration.ConfigurationManager.AppSettings["Username"], System.Configuration.ConfigurationManager.AppSettings["Password"]))
            {
                var response = await client.GetInfo(id);

                ViewModels.ChainViewModel model = new ViewModels.ChainViewModel()
                {
                    Name = id,
                    Version = response.Result.Version,
                    Balance = response.Result.Balance
                };

                return View(model);
            }
        }
    }
}