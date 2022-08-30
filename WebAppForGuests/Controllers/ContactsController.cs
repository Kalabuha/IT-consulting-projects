using Microsoft.AspNetCore.Mvc;
using WebAppForGuests.Models;
using WebServices.Interfaces;
using DataModelsWebModelsConverters;

namespace WebAppForGuests.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IHeaderService _headerService;

        public ContactsController(IContactService contactService, IHeaderService headerService)
        {
            _contactService = contactService;
            _headerService = headerService;
        }


        public async Task<ActionResult<ContactsViewModel>> Index()
        {
            var menuData = await _headerService.GetUsedMenuDataAsync();
            ViewBag.PageH1 = menuData.Contacts;

            var contactData = await _contactService.GetPublishedContactDataAsync();
            if (contactData == null)
            {
                return NotFound();
            }

            var contactModel = contactData.ContactDataToModel();

            return View(new ContactsViewModel { Contact = contactModel });
        }
    }
}
