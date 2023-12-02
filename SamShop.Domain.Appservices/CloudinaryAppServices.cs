using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using SamShop.Domain.Core.Helper;
using SamShop.Domain.Core.Interfaces.AppServices;

namespace SamShop.Domain.Appservices
{
    public class CloudinaryAppServices : ICloudAppServices
    {
        private readonly Cloudinary _cloudinary;
        public CloudinaryAppServices(IOptions<CloudinarySettings> config)
        {
            var acc = new Account(
                config.Value.CLoudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
                );
            _cloudinary = new Cloudinary( acc );
        }
        public async Task<ImageUploadResult> AddPhoto(IFormFile photo ,CancellationToken cancellation)
        {
            var uploadResult = new ImageUploadResult();
            if (photo.Length > 0)
            {
                using var stream = photo.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(photo.FileName ,stream),
                    Transformation = new Transformation().Height(200).Width(200).Crop("fill").Gravity("face")
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams, cancellation);
            }
            return uploadResult;
        }

        public async Task<DeletionResult> DeletePhoto(int photoId, CancellationToken cancellation)
        {
            var deleteParams = new DeletionParams(Convert.ToString(photoId));
            var result = await _cloudinary.DestroyAsync(deleteParams);
            return result;
        }

        public async Task<List<ImageUploadResult>> AddPhotos(List<IFormFile> photo, CancellationToken cancellation)
        {
            var uploadResults = new List<ImageUploadResult>();
            foreach (IFormFile photoItem in photo)
            {
                if (photoItem.Length > 0)
                {
                    using var stream = photoItem.OpenReadStream();
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(photoItem.FileName, stream),
                        Transformation = new Transformation().Height(200).Width(200).Crop("fill").Gravity("face")
                    };
                    var uploadResult = await _cloudinary.UploadAsync(uploadParams, cancellation);
                    uploadResults.Add(uploadResult);
                }
            }
            
            return uploadResults;
        }
    }
}
