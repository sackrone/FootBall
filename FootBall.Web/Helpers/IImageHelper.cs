using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace FootBall.Web.Helpers
{
    internal interface IImageHelper
    {
        Task<string> UploadImageAsyc(IFormFile imageFile, string folder);
    }
}
