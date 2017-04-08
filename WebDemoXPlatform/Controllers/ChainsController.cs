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

        /// <summary>
        /// Stream
        /// </summary>
        /// <param name="id">Chain name</param>
        /// <returns></returns>
        public async Task<ActionResult> Stream(String id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                using (Clients.Client client = new Clients.Client(System.Configuration.ConfigurationManager.AppSettings["Node1"], System.Configuration.ConfigurationManager.AppSettings["Username"], System.Configuration.ConfigurationManager.AppSettings["Password"]))
                {
                    Models.ListStreams.Response response = await client.GetStreams(id);
                    return View(response.Result);
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        // GET: All stream items
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Chain</param>
        /// <param name="stream">Stream</param>
        /// <returns></returns>
        public async Task<ActionResult> StreamItems(String id, String stream)
        {
            Models.ChainSettings setting = Global.Chains.SingleOrDefault(s => s.Name == id);
            using (Clients.Client client = new Clients.Client(System.Configuration.ConfigurationManager.AppSettings["Node1"], setting.RPCUser, setting.RPCPassword))
            {
                var response = await client.GetStreamItems(id, stream);
                return View(response.Result);
            }
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

        public ActionResult Deserialize(String id, String data)
        {
            Models.DTOs.Instrument model = Helpers.SerialisationHelper.ToObject<Models.DTOs.Instrument>(data);
            return View(model);
        }
    }
}