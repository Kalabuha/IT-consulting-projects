using Refit;
using DataModels;

namespace WebAppDataApi.Client
{
    public interface IApplicationsApi
    {
        [Get("api/Applications")]
        Task<ApplicationDataModel> Get();

        [Get("api/Applications/{id}")]
        Task<ApplicationDataModel> Get(int id);
    }
}