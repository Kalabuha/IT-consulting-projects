using Refit;
using DataModels;

namespace WebAppDataApi.Client
{
    public interface IApplicationsApi
    {
        [Get("api/Applications")]
        Task<ApplicationData> Get();

        [Get("api/Applications/{id}")]
        Task<ApplicationData> Get(int id);
    }
}