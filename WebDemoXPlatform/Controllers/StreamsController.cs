using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebDemoXPlatform.Controllers
{
    public class StreamsController : Controller
    {
        /// <summary>
        /// Stream
        /// </summary>
        /// <param name="id">Chain name</param>
        /// <returns></returns>
        public async Task<ActionResult> Index(String id)
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
    }
}