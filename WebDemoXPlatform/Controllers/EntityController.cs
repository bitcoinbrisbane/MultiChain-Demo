using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDemoXPlatform.Controllers
{
    public class EntityController : Controller
    {
        // GET: Entity
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Create(Models.DTOs.Entity model)
        {
            String node = System.Configuration.ConfigurationManager.AppSettings["Node1"];
            String username = System.Configuration.ConfigurationManager.AppSettings["Username"];
            String password = System.Configuration.ConfigurationManager.AppSettings["Password"];

            using (MultiChainLib.MultiChainClient client = new MultiChainLib.MultiChainClient(node,  , false, username, password))
            {
                
            }
        }
    }
}