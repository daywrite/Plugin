using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContactsPlugin.DataAccessors;
using ContactsPlugin.Models;
using ContactsPlugin.ViewModels;

namespace ContactsPlugin.Controllers
{
    public class ContactsController : Controller
    {
        public bool Check(string permissionId)
        {
            return BundleActivator.PermissionServiceTracker.DefaultOrFirstService.Check(BundleActivator.Bundle, permissionId);
        }

        public ActionResult NoPermissionView()
        {
            return View(PermissionAttribute.NoPermissionView);
        }

        [Permission("ViewContacts")]
        public ActionResult Index(int? currentPageNum, int? pageSize)
        {
            if (!currentPageNum.HasValue)
            {
                currentPageNum = 1;
            }
            if (!pageSize.HasValue)
            {
                pageSize = ContactListViewModel.DefaultPageSize;
            }

            var contactDataAccessor = new ContactDataAccessor();

            int pageNum = currentPageNum.Value, pageCount, contactCount;
            var contacts = contactDataAccessor.GetPage(pageSize.Value, ref pageNum, out contactCount, out pageCount);

            var contactLitViewModel = new ContactListViewModel(contactCount, pageSize.Value, currentPageNum.Value, contacts);

            return View(contactLitViewModel);
        }

        public ActionResult AddOrEdit(int currentPageNum, int pageSize, int? id)
        {
            if(!id.HasValue)
            {
                if (!Check("AddContact"))
                {
                    return NoPermissionView();
                }

                return View(new AddOrEditContactViewModel { Added = true, Contact = Contact.New(), CurrentPageNum = currentPageNum, PageSize = pageSize });
            }
            else
            {
                if (!Check("EditContact"))
                {
                    return NoPermissionView();
                }

                var contact = new ContactDataAccessor().GetById(id.Value);
                return View(new AddOrEditContactViewModel { Added = false, Contact = contact, CurrentPageNum = currentPageNum, PageSize = pageSize });
            }
        }

        [Permission("Delete")]
        public ActionResult Delete(int id, int currentPageNum, int pageSize)
        {
            new ContactDataAccessor().Delete(id);
            return RedirectToAction("Index", new { currentPageNum = currentPageNum, pageSize = pageSize });
        }

        [HttpPost]
        public ActionResult Add(AddOrEditContactViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View("AddOrEdit", model);
            }

            new ContactDataAccessor().Add(model.Contact);
            return RedirectToAction("Index", new { currentPageNum = model.CurrentPageNum, pageSize = model.PageSize });
        }

        [HttpPost]
        public ActionResult Edit(AddOrEditContactViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("AddOrEdit", model);
            }

            new ContactDataAccessor().Save(model.Contact);
            return RedirectToAction("Index", new { currentPageNum = model.CurrentPageNum, pageSize = model.PageSize });
        }
    }
}