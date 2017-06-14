using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebDemoXPlatform.Controllers
{
    public class AccessController : Controller
    {
        public async Task<ActionResult> Index()
        {
            const string id = "gbst";
            const string stream = "Access";

            Models.ChainSettings setting = Global.Chains.SingleOrDefault(s => s.Name == id);
            using (Clients.Client client = new Clients.Client(setting.Host, setting.RPCUser, setting.RPCPassword, setting.Port))
            {
                ViewModels.StreamItemsViewModel viewModel = new ViewModels.StreamItemsViewModel();
                viewModel.ChainName = id;
                viewModel.Stream = stream;

                List<Models.DTOs.Access> entities = new List<Models.DTOs.Access>();

                var response = await client.ListStreamItems(id, stream);

                if (response != null)
                {
                    foreach (Models.ListStreamsItems.Result result in response.Result)
                    {
                        //viewModel.Items.Add(result);
                        Models.DTOs.Access entity = Helpers.SerialisationHelper.ToObject<Models.DTOs.Access>(result.Data);
                        entities.Add(entity);
                    }
                }

                return View(entities);
            }
        }
    }
}