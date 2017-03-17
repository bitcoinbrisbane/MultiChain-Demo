using BitcoinLib.Services;
using BitcoinLib.Services.Coins.Bitcoin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            BitcoinService CoinService = new BitcoinService("139.59.100.99:9742", "multichainrpc", "F6iFWNPinwoeHA7Ai8g3xG36jNxVUgErx2w3Y1isgmfG");
            //CoinService.Parameters.RpcUsername = "multichainrpc";
            //CoinService.Parameters.RpcPassword = "F6iFWNPinwoeHA7Ai8g3xG36jNxVUgErx2w3Y1isgmfG";

            var info = CoinService.GetInfo();

            Console.ReadLine();
        }
    }
}
