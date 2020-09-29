using Seamless.Model.Models;
using System.Threading.Tasks;

namespace Seamless.Service.Services.Helpers
{
    public interface ITokenHelper
    {
        Task<string> CreateJWTAsync(AUser user);

    }

}
