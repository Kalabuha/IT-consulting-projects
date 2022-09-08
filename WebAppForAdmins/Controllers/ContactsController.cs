using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppForAdmins.Models.Contacts;
using ServiceInterfaces;
using DataModelsWebModelsMappers;
using WebModels;

namespace WebAppForAdmins.Controllers
{
    [Authorize(Roles = "Senior, Admin")]
    public class ContactsController : Controller
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var datas = await _contactService.GetAllContactDatasAsync();
            var models = datas.Select(c => c.ContactDataToModel())
                .ToList();

            var viewModel = new ContactsViewModel()
            {
                Contacts = models
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.IsChangeDisabled = false;

            var model = new ContactWebModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(ContactWebModel model)
        {
            if (model.MapAsFormFile == null)
            {
                ModelState.AddModelError("MapAsString", "Изображение карты не установлено");
            }

            if (!ModelState.IsValid)
            {
                return View(nameof(Create), model);
            }

            var data = model.ContactModelToData();
            var id = await _contactService.AddContactToDbAsync(data);

            if (data.IsPublished)
            {
                await _contactService.PublishContact(id);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.IsChangeDisabled = false;

            var data = await _contactService.GetContactDataByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            var model = data.ContactDataToModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditPost(ContactWebModel model)
        {
            var oldData = await _contactService.GetContactDataByIdAsync(model.Id);
            if (oldData == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                var oldModel = oldData.ContactDataToModel();
                model.MapAsString = oldModel.MapAsString;
                return View(nameof(Edit), model);
            }

            var newData = model.ContactModelToData();
            await _contactService.EditContactToDbAsync(newData);

            if (newData.IsPublished)
            {
                await _contactService.PublishContact(newData.Id);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            ViewBag.IsChangeDisabled = true;

            var data = await _contactService.GetContactDataByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            var model = data.ContactDataToModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _contactService.RemoveContactToDbAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
