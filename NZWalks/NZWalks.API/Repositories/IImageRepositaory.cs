using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IImageRepositaory
    {
        Task<Image> Upload(Image image);
    }
}
