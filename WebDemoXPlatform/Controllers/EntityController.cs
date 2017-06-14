using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebDemoXPlatform.Controllers
{
    public class EntityController : Controller
    {
        private const string id = "gbst";
        private const string stream = "Entity";

        // GET: Entity
        public async Task<ActionResult> Index()
        {
            Models.ChainSettings setting = Global.Chains.SingleOrDefault(s => s.Name == id);
            using (Clients.Client client = new Clients.Client(setting.Host, setting.RPCUser, setting.RPCPassword, setting.Port))
            {
                ViewModels.StreamItemsViewModel viewModel = new ViewModels.StreamItemsViewModel();
                viewModel.ChainName = id;
                viewModel.Stream = stream;

                List<Models.DTOs.Entity> entities = new List<Models.DTOs.Entity>();

                var response = await client.ListStreamItems(id, stream);

                if (response != null)
                {
                    foreach (Models.ListStreamsItems.Result result in response.Result)
                    {
                        Models.DTOs.Entity entity = Helpers.SerialisationHelper.ToObject<Models.DTOs.Entity>(result.Data);
                        entities.Add(entity);
                        //viewModel.Items.Add(result);
                    }
                }

                return View(entities);
            }
        }

        public ActionResult Create()
        {
            Models.DTOs.Entity dto = new Models.DTOs.Entity();
            return View(dto);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Models.DTOs.Entity dto)
        {
            //push to chain
            Models.ChainSettings setting = Global.Chains.SingleOrDefault(s => s.Name == id);

            using (Clients.Client client = new Clients.Client(setting.Host, setting.RPCUser, setting.RPCPassword, setting.Port))
            {
                String hex = Helpers.SerialisationHelper.ToHex(dto);
                var response = await client.PublishStreamItem(id, "Entity", dto.Id.ToString(), hex);

                ViewBag.Response = "";
                return RedirectToAction("Index");
            }
        }
    }
}