using Microsoft.AspNetCore.Mvc;
using Resources.Models;
using Resources.Enums;
using Resources.Extensions;
using WebAppForAdmins.Models;
using Services.Interfaces;

namespace WebAppForAdmins.Controllers
{
    public class ApplicationsController : Controller
    {
        private readonly IApplicationService _applicationService;

        public ApplicationsController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        // GET: AcceptanceApplications
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

        // GET: AcceptanceApplications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AcceptanceApplications/Create
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

        // GET: AcceptanceApplications/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AcceptanceApplications/Edit/5
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

        // GET: AcceptanceApplications/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AcceptanceApplications/Delete/5
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
