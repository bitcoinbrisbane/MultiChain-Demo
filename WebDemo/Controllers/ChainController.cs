using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebDemo.Controllers
{
    public class ChainController : Controller
    {
        public ActionResult Index()
        {
            List<ViewModels.ChainViewModel> models = new List<ViewModels.ChainViewModel>();
            models.Add(new ViewModels.ChainViewModel() { Name = "gbst1" });
            return View(models);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Chain Name</param>
        /// <returns></returns>
        public async Task<ActionResult> Details(String id)
        {
            Models.Client client = new Models.Client(System.Configuration.ConfigurationManager.AppSettings["Node1"], System.Configuration.ConfigurationManager.AppSettings["Username"], System.Configuration.ConfigurationManager.AppSettings["Password"]);
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