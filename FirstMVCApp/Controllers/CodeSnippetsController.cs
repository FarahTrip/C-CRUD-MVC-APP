using FirstMVCApp.Models;
using FirstMVCApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCApp.Controllers
{
    public class CodeSnippetsController : Controller
    {
        private readonly CodeSnippetsRepository _repository;
        private readonly MembersRepository _membersRepository;

        public CodeSnippetsController(CodeSnippetsRepository repository, MembersRepository membersRepository)
        {
            _repository = repository;
            _membersRepository = membersRepository;
        }

        public ActionResult Index()
        {
            var codeSnippets = _repository.GetAll();
            return View("Index", codeSnippets);
        }

        public ActionResult Details(Guid id)
        {
            var codeSnippet = _repository.GetById(id);
            return View("Details", codeSnippet);
        }

        public ActionResult Create()
        {
            var members = _membersRepository.GetMembers();
            ViewBag.data = members;
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            var model = new CodeSnippetModel();
            TryUpdateModelAsync(model);
            _repository.Add(model);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid id)
        {
            return View("Edit", _repository.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            var model = new CodeSnippetModel();
            TryUpdateModelAsync(model);
            _repository.Update(model);
            return RedirectToAction("Index");
        }


        public ActionResult Delete(Guid id)
        {
            return View("Delete", _repository.GetById(id));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            _repository.DeleteById(id);
            return RedirectToAction("Index");
        }
    }
}