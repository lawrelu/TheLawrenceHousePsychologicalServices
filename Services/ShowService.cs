using System.Threading.Tasks;

public interface IShowService
{
    Task CreateShowAsync(Show show);
    Task ShowManagementAsync(int showId);
    Task UpdateShowPosterAsync(int showId, string newPosterUrl);
}

public class ShowService : IShowService
{
    public async Task CreateShowAsync(Show show)
    {
        // Implementation for creating a show
    }

    public async Task ShowManagementAsync(int showId)
    {
        // Implementation for managing a show
    }

    public async Task UpdateShowPosterAsync(int showId, string newPosterUrl)
    {
        // Implementation for updating show poster asynchronously
    }
}