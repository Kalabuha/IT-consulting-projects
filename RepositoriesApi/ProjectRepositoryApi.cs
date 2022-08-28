using System.Net.Http.Json;
using RepositoriesApi.Base;
using Resources.Entities;
using ResourcesApi;

namespace RepositoriesApi
{
    public class ProjectRepositoryApi : BaseRepositoryApi<ProjectEntity, ProjectResource>
    {
        public ProjectRepositoryApi(HttpClient httpClient) : base(httpClient, "api/Projects")
        {

        }
    }
}
