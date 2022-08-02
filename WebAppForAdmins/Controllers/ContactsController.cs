using Microsoft.AspNetCore.Mvc;
using Resources.Models;
using Services.Converters;
using Services.Interfaces;
using WebAppForAdmins.Models;

namespace WebAppForAdmins.Controllers
{
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

            var model = new ContactModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(ContactModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Create), model);
            }

            var data = model.ContactModelToData();
            await _contactService.AddContactToDbAsync(data);

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
        public async Task<IActionResult> EditPost(ContactModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Edit), model);
            }

            var data = model.ContactModelToData();
            await _contactService.EditContactToDbAsync(data);

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
