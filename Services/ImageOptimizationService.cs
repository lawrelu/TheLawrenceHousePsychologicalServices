using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Processing.Processors.Convolution;

namespace TheLawrenceHousePsychologicalServices.Services
{
    public class ImageOptimizationService
    {
        public async Task<byte[]> UploadAndOptimizeAsync(Stream imageStream, Size? newSize = null)
        {
            using (var image = await Image.LoadAsync(imageStream))
            {
                // Resize if desired
                if (newSize.HasValue)
                {
                    image.Mutate(x => x.Resize(newSize.Value.Width, newSize.Value.Height));
                }

                // Convert to WebP format
                using (var memoryStream = new MemoryStream())
                {
                    await image.SaveAsync(memoryStream, new WebpEncoder());
                    return memoryStream.ToArray();
                }
            }
        }
    }
}