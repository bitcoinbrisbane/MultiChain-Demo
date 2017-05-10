using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebDemoXPlatform.Controllers
{
    public class StreamItemsController : Controller
    {
        // GET: All stream items
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Chain</param>
        /// <param name="stream">Stream</param>
        /// <returns></returns>
        public async Task<ActionResult> Index(String id, String stream)
        {
            Models.ChainSettings setting = Global.Chains.SingleOrDefault(s => s.Name == id);
            using (Clients.Client client = new Clients.Client(System.Configuration.ConfigurationManager.AppSettings["Node1"], setting.RPCUser, setting.RPCPassword))
            {
                var response = await client.GetStreamItems(id, stream);
                return View(response.Result);
            }
        }

        public ActionResult Deserialize(String id, String data)
        {
            Models.DTOs.Entity model = Helpers.SerialisationHelper.ToObject<Models.DTOs.Entity>(data);
            return View(model);
        }

        /// <summary>
        /// Stream
        /// </summary>
        /// <param name="id">Chain name</param>
        /// <returns></returns>
        public async Task<ActionResult> Post(ViewModels.AddStreamKeyValueViewModel viewModel)
        {
            Models.ChainSettings setting = Global.Chains.SingleOrDefault(s => s.Name == viewModel.Name);
            using (Clients.Client client = new Clients.Client(System.Configuration.ConfigurationManager.AppSettings["Node1"], setting.RPCUser, setting.RPCPassword))
            {
                //var response = await client.GetStreams(id);

                //ViewModels.ChainViewModel model = new ViewModels.ChainViewModel()
                //{
                //    Name = id,
                //    Version = response.Result.Version,
                //    Balance = response.Result.Balance
                //};

                return View();
            }
        }
    }
}