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
        [OutputCache(Duration = 30)]
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
        [OutputCache(Duration = 30, VaryByParam = "id")]
        public async Task<ActionResult> Stream(String id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                using (Clients.Client client = new Clients.Client(System.Configuration.ConfigurationManager.AppSettings["Node1"], System.Configuration.ConfigurationManager.AppSettings["Username"], System.Configuration.ConfigurationManager.AppSettings["Password"]))
                {
                    Models.ListStreams.Response response = await client.GetStreams(id);
                    List<ViewModels.StreamsViewModel> streams = new List<ViewModels.StreamsViewModel>();

                    foreach (Models.ListStreams.Result result in response.Result)
                    {
                        streams.Add(new ViewModels.StreamsViewModel() { Chain = id, Name = result.Name, Open = result.Open, Subscribed = result.Subscribed, Synchronised = result.Synchronised });
                    }
                    return View(streams);
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

                //List<ViewModels.StreamsViewModel> streams = new List<ViewModels.StreamsViewModel>();

                //foreach(Models.ListStreams.Result result in response.Result)
                //{
                //    streams.Add(new ViewModels.StreamsViewModel() { Chain = id, Name = result.Name, Open = result.Open, Subscribed = result.Subscribed, Synchronised = result.Synchronised });
                //}

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
            Models.DTOs.Entity model = Helpers.SerialisationHelper.ToObject<Models.DTOs.Entity>(data);
            return View(model);
        }
    }
}