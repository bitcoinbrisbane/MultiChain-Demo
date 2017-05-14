using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WebDemoXPlatform.XTests
{
    public class DataControllerTests
    {
        [Fact]
        public void Should_Get_256bit_Key()
        {
            WebDemoXPlatform.Controllers.DataController controller = new Controllers.DataController();
            var result = controller.Create();

            Assert.NotNull(result);
        }

        [Fact]
        public void Should_Encrypt_Data()
        {
            String base64PrivateKey = "8eUSPgMzzLwSY+EA79ikwA==";
            var model = new ViewModels.DataEntityViewModel() { PrivateKey = base64PrivateKey, Data = "<xml>test</xml>" };

            WebDemoXPlatform.Controllers.DataController controller = new Controllers.DataController();
            var result = controller.Create(model);
        }

        [Fact]
        public void Should_Decrypt_Data()
        {
            String base64PrivateKey = "8eUSPgMzzLwSY+EA79ikwA==";
            var model = new ViewModels.DataEntityViewModel() { PrivateKey = base64PrivateKey, Data = "AAAAAAAAAAAAAAAAAAAAAH92zvuJ1DYMn0bzI5H4kdY=" };

            WebDemoXPlatform.Controllers.DataController controller = new Controllers.DataController();
            var result = controller.Create(model);
        }
    }
}
