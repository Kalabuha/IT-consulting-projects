using System.Net.Http.Json;
using ApiRepositories.Base;
using ApiRepositories.Interfaces;
using Entities;

namespace ApiRepositories
{
    public class ProjectRepositoryApi : BaseRepositoryApi<ProjectEntity>, IProjectRepositoryApi
    {
        public ProjectRepositoryApi(HttpClient httpClient) : base(httpClient, "api/Projects")
        {

        }
    }
}
