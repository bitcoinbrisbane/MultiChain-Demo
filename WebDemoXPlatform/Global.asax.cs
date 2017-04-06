using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using System.Collections.Generic;

namespace WebDemoXPlatform
{
	public class Global : HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			//GlobalConfiguration.Configure(WebApiConfig.Register);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
		}

        internal static IEnumerable<Models.ChainSettings> Chains
        {
            get
            {
                List<Models.ChainSettings> chains = new List<Models.ChainSettings>(2);
                chains.Add(new Models.ChainSettings() { Name = "gbst1", Host = "http://139.59.100.99:9742", RPCUser = "multichainrpc", RPCPassword = "F6iFWNPinwoeHA7Ai8g3xG36jNxVUgErx2w3Y1isgmfG" });
                chains.Add(new Models.ChainSettings() { Name = "chain1", Host = "http://139.59.100.99:8364", RPCUser = "multichainrpc", RPCPassword = "4HuYGDSP2mw53rzRHyZ7SAuob1oSmsJjFoQWyPvpMLts" });

                return chains;
            }
        }
	}
}
