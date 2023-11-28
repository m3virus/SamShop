using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace SamShop.Domain.Core.Interfaces.AppServices
{
    public interface ICloudAppServices
    {
        Task<ImageUploadResult> AddPhoto(IFormFile photo, CancellationToken cancellation);
        Task<DeletionResult> DeletePhoto(int PhotoId, CancellationToken cancellation);
    }
}
