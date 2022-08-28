using Refit;
using Resources.Datas;

namespace WebAppWebApli.Client
{
    public interface IApplicationsApi
    {
        [Get("api/Applications")]
        Task<ApplicationData> Get();

        [Get("api/Applications/{id}")]
        Task<ApplicationData> Get(int id);
    }
}