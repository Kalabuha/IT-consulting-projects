using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resources.Models;
using Resources.Enums;
using Resources.Extensions;
using WebAppForAdmins.Models.Applications;
using Services.Interfaces;

namespace WebAppForAdmins.Controllers
{
    [Authorize(Roles = "Junior, Senior, Admin")]
    public class ApplicationsController : Controller
    {
        private readonly IApplicationService _applicationService;

        public ApplicationsController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Filter(ApplicationsFilterViewModel filterModel)
        {
            var viewModel = await GetApplicationsViewModelAsync(filterModel);

            return PartialView(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeApplicationStatus(SelectApplicationStatusModel selectModel)
        {
            var selectedApplication = await _applicationService.GetApplicationById(selectModel.SelectedApplicationId);
            if (selectedApplication == null)
            {
                return NotFound();
            }

            selectedApplication.Status = selectModel.SelectedStatus;
            await _applicationService.UpdateApplicationToDb(selectedApplication);

            return new EmptyResult();
        }

        private async Task<ApplicationsViewModel> GetApplicationsViewModelAsync(ApplicationsFilterViewModel filterModel)
        {
            List<ApplicationModel> applications;
            // Пользоваетль выбрал период времени из списка предложенных
            if (filterModel.RequestedPeriod != DateTimePeriod.SelectedPeriodDateTime)
            {
                applications = await _applicationService.GetFilteredApplications(
                       filterModel.RequestedStatuses, filterModel.RequestedPeriod.GetStartDateTimePeriod(), DateTime.Now);
            }
            // Пользователь указал свой период времени и выбрал его
            else
            {
                if (filterModel.StartTimePeriod == null || filterModel.EndTimePeriod == null)
                {
                    applications = new List<ApplicationModel>();
                }
                else
                {
                    applications = await _applicationService.GetFilteredApplications(
                        filterModel.RequestedStatuses, filterModel.StartTimePeriod.Value, filterModel.EndTimePeriod.Value);
                }
            }

            return new ApplicationsViewModel { Applications = applications };
        }
    }
}
