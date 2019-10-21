using System.Threading.Tasks;

namespace Eventlauncher.Web.Services.Abstractions
{
    public interface IComputerService
    {
        Task AwakeComputer(string ipAddress);
    }
}