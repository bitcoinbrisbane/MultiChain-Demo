using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebDemoXPlatform.Controllers
{
    public class ChainsController : Controller
    {
        public ActionResult Index()
        {
            List<ViewModels.ChainViewModel> models = new List<ViewModels.ChainViewModel>();
            foreach(Models.ChainSettings settings in Global.Chains)
            {
                models.Add(new ViewModels.ChainViewModel() { Name = settings.Name });
            }
            
            return View(models);
        }

        public async Task<ActionResult> Details(String id)
        {
            Models.ChainSettings setting = Global.Chains.SingleOrDefault(s => s.Name == id);
            using (Clients.Client client = new Clients.Client(System.Configuration.ConfigurationManager.AppSettings["Node1"], setting.RPCUser, setting.RPCPassword))
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