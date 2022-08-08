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
        public async Task<IActionResult> Filter(ApplicationsFilterViewModel model)
        {
            List<ApplicationModel> applications;
            // Пользоваетль выбрал период времени из списка предложенных
            if (model.RequestedPeriod != DateTimePeriod.SelectedPeriodDateTime)
            {
                applications = await _applicationService.GetFilteredApplications(
                       model.RequestedStatuses, model.RequestedPeriod.GetStartDateTimePeriod(), DateTime.Now);
            }
            // Пользователь указал свой период времени и выбрал его
            else
            {
                if (model.StartTimePeriod == null || model.EndTimePeriod == null)
                {
                    applications = new List<ApplicationModel>();
                }
                else
                {
                    applications = await _applicationService.GetFilteredApplications(
                        model.RequestedStatuses, model.StartTimePeriod.Value, model.EndTimePeriod.Value);
                }
            }

            return PartialView(new ApplicationsViewModel
            {
                Applications = applications
            });
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
