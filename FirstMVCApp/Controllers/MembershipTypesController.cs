using FirstMVCApp.Models;
using FirstMVCApp.Repositories;
using FirstMVCApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCApp.Controllers
{
    public class MembershipTypesController : Controller
    {
        private readonly MembershipTypesRepository _repository;

        public MembershipTypesController(MembershipTypesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var memberships = _repository.GetAll();
            return View("Index", memberships);
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(IFormCollection collection)
        {
            var model = new MembershipTypeModel();
            TryUpdateModelAsync(model);
            _repository.AddMembershiptType(model);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(Guid id)
        {
            var membership = _repository.FindById(id);
            return View("Edit", membership);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, IFormCollection collection)
        {
            var updatedMembership = new MembershipTypeModel();
            TryUpdateModelAsync(updatedMembership);

            _repository.UpdateMembershipType(id, updatedMembership);

            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid id)
        {
            return View("Details", _repository.FindById(id));
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var model = _repository.FindById(id);
            return View("Delete", model);
        }

        [HttpPost]
        public IActionResult Delete(Guid id, IFormCollection collection)
        {
            _repository.DeleteMembershipType(_repository.FindById(id));
            return RedirectToAction("Index");
        }

        public IActionResult DetailsByMembershipType(Guid id)
        {
            MembershipTypesMembersViewModel model = _repository.GetMembersByMembership(id);
            return View("DetailsByMembershipType", model);
        }
    }
}