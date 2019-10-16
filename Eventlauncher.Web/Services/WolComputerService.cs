using System;
using System.Net;
using System.Threading.Tasks;
using Eventlauncher.Web.Services.Abstractions;

namespace Eventlauncher.Web.Services
{
    public class WolComputerService : IComputerService
    {
        public async Task AwakeComputer(string ipAddress)
        {
            var macAddress = await GetMacAddress(IPAddress.Parse(ipAddress));
            await IPAddress.Broadcast.SendWolAsync(macAddress);
        }

        private static async Task<byte[]> GetMacAddress(IPAddress ipAddress)
        {
            var result = await ArpRequest.SendAsync(ipAddress);

            if (result.Exception != null)
            {
                throw new InvalidOperationException(
                    $"There was an exception while retrieving the MAC-address for the IP-address {ipAddress}",
                    result.Exception);
            }
            else
            {
                return result.Address.GetAddressBytes();
            }
        }
    }
}
