﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            Models.DTOs.Entity dto = new Models.DTOs.Entity();
            return View(dto);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Models.DTOs.Entity dto)
        {
            //push to chain
            Models.ChainSettings setting = Global.Chains.SingleOrDefault(s => s.Name == "gbst");

            using (Clients.Client client = new Clients.Client(setting.Host, setting.RPCUser, setting.RPCPassword, setting.Port))
            {
                String hex = Helpers.SerialisationHelper.ToHex(dto);
                var response = await client.PublishStreamItem("gbst", "Entity", dto.Id.ToString(), hex);

                return View(response);
            }
        }
    }
}