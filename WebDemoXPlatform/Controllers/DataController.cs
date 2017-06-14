using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebDemoXPlatform.Controllers
{
    public class DataController : BaseController
    {
        //private readonly Encoding _encoding;
        //private readonly IBlockCipher _blockCipher;
        //private PaddedBufferedBlockCipher _cipher;
        //private IBlockCipherPadding _padding;

        private const string id = "gbst";
        private const string stream = "Data";

        public DataController()
        {
            //_encoding = new UTF8Encoding(); //ASCIIEncoding();
            //_blockCipher = new AesEngine();
            //_cipher = new PaddedBufferedBlockCipher(_blockCipher);
        }
            
        /// <summary>
        /// Get data
        /// </summary>
        /// <param name="id">Chain</param>
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            Models.ChainSettings setting = Global.Chains.SingleOrDefault(s => s.Name == id);
            using (Clients.Client client = new Clients.Client(setting.Host, setting.RPCUser, setting.RPCPassword, setting.Port))
            {
                var response = await client.ListStreamItems(id, stream);

                List<Models.DTOs.DataEntity> entities = new List<Models.DTOs.DataEntity>();

                foreach (Models.ListStreamsItems.Result result in response.Result)
                {
                    Models.DTOs.DataEntity entity = Helpers.SerialisationHelper.ToObject<Models.DTOs.DataEntity>(result.Data);
                    entities.Add(entity);
                }

                return View(entities);
            }
        }

        public ActionResult Create()
        {
            //TODO: KEY SIZE, fixed at 256 bit
            Byte[] key = new Byte[16];
            Random rnd = new Random();
            rnd.NextBytes(key);

            ViewModels.DataEntityViewModel viewModel = new ViewModels.DataEntityViewModel(key);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ViewModels.DataEntityViewModel viewModel)
        {
            if (!String.IsNullOrEmpty(viewModel.Data))
            {
                Byte[] data = Encoding.ASCII.GetBytes(viewModel.Data);
                Byte[] key = Convert.FromBase64String(viewModel.PrivateKey);

                Byte[] encryptedData = EncryptByteArray(key, data);

                Models.DTOs.DataEntity dataDto = new Models.DTOs.DataEntity() { Id = viewModel.Id };
                dataDto.Data = Convert.ToBase64String(encryptedData);

                Models.DTOs.Access accessDto = new Models.DTOs.Access()
                {
                    ConsumingEntityId = viewModel.ConsumingEntityId,
                    PublishingEntityId = viewModel.PublishingEntityId,
                    DataId = dataDto.Id,
                    PrivateKey = viewModel.PrivateKey
                };

                //push to chain
                Models.ChainSettings setting = Global.Chains.SingleOrDefault(s => s.Name == "gbst");
                using (Clients.Client client = new Clients.Client(setting.Host, setting.RPCUser, setting.RPCPassword, setting.Port))
                {
                    String hex = Helpers.SerialisationHelper.ToHex(dataDto);
                    var dataTask = client.PublishStreamItem("gbst", "Data", dataDto.Id.ToString(), hex);
                    var accessTask = client.PublishStreamItem("gbst", "Access", dataDto.Id.ToString(), hex);

                    await Task.WhenAll(accessTask, dataTask);
                }
            }

            return View(); 
        }

        /// <summary>
        /// Encrypt a byte array using AES 128
        /// </summary>
        /// <param name="key">128 bit key</param>
        /// <param name="secret">byte array that need to be encrypted</param>
        /// <returns>Encrypted array</returns>
        public static byte[] EncryptByteArray(byte[] key, byte[] secret)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (AesManaged cryptor = new AesManaged())
                {
                    cryptor.Mode = CipherMode.CBC;
                    cryptor.Padding = PaddingMode.PKCS7;
                    cryptor.KeySize = 256;
                    cryptor.BlockSize = 128;

                    //We use the random generated iv created by AesManaged
                    //byte[] iv = cryptor.IV;
                    //TODO, GET FROM CONFIG
                    byte[] iv = new Byte[16] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

                    using (CryptoStream cs = new CryptoStream(ms, cryptor.CreateEncryptor(key, iv), CryptoStreamMode.Write))
                    {
                        cs.Write(secret, 0, secret.Length);
                    }
                    byte[] encryptedContent = ms.ToArray();

                    //Create new byte array that should contain both unencrypted iv and encrypted data
                    byte[] result = new byte[iv.Length + encryptedContent.Length];

                    //copy our 2 array into one
                    Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                    Buffer.BlockCopy(encryptedContent, 0, result, iv.Length, encryptedContent.Length);

                    return result;
                }
            }
        }

        /// <summary>
        /// Decrypt a byte array using AES 128
        /// </summary>
        /// <param name="key">key in bytes</param>
        /// <param name="secret">the encrypted bytes</param>
        /// <returns>decrypted bytes</returns>
        public static byte[] DecryptByteArray(byte[] key, byte[] secret)
        {
            byte[] iv = new byte[16]; //initial vector is 16 bytes
            byte[] encryptedContent = new byte[secret.Length - 16]; //the rest should be encryptedcontent

            //Copy data to byte array
            Buffer.BlockCopy(secret, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(secret, iv.Length, encryptedContent, 0, encryptedContent.Length);

            using (MemoryStream ms = new MemoryStream())
            {
                using (AesManaged cryptor = new AesManaged())
                {
                    cryptor.Mode = CipherMode.CBC;
                    cryptor.Padding = PaddingMode.PKCS7;
                    cryptor.KeySize = 256;
                    cryptor.BlockSize = 128;

                    using (CryptoStream cs = new CryptoStream(ms, cryptor.CreateDecryptor(key, iv), CryptoStreamMode.Write))
                    {
                        cs.Write(encryptedContent, 0, encryptedContent.Length);

                    }
                    return ms.ToArray();
                }
            }
        }
    }
}