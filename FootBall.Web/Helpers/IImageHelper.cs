using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace FootBall.Web.Helpers
{
    public interface IImageHelper
    {
        Task<string> UploadImageAsyc(IFormFile imageFile, string folder);
    }
}
