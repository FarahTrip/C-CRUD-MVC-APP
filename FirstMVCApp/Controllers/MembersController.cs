using FirstMVCApp.Models;
using FirstMVCApp.Repositories;
using FirstMVCApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCApp.Controllers
{
    public class MembersController : Controller
    {
        private readonly MembersRepository _repository;

        public MembersController(MembersRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var members = _repository.GetMembers();
            return View("Index", members);
        }

        public IActionResult Create()
        {
            return View("CreateMember");
        }

        [HttpPost]
        public IActionResult CreateMember(IFormCollection members)
        {
            MemberModel model = new MemberModel();
            TryUpdateModelAsync(model);
            _repository.AddMember(model);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(Guid id)
        {
            return View("Edit", _repository.GetMemberById(id));
        }

        [HttpPost]
        public IActionResult Edit(IFormCollection collection)
        {
            MemberModel member = new MemberModel();
            TryUpdateModelAsync(member);
            _repository.UpdateMember(member);


            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid id)
        {
            return View("Details", _repository.GetMemberById(id));
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            return View("Delete", _repository.GetMemberById(id));
        }

        [HttpPost]
        public IActionResult Delete(Guid id, IFormCollection collection)
        {
            _repository.DeleteMemberById(id);
            return RedirectToAction("Index");
        }

        public IActionResult DetailsWithCodeSnippets(Guid id)
        {
            MemberCodeSnippetsViewModel viewModel = _repository.GetMemberCodeSnippets(id);
            return View("DetailsWithCodeSnippets", viewModel);
        }
    }
}