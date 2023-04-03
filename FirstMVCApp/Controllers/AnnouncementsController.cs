using FirstMVCApp.Models;
using FirstMVCApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCApp.Controllers
{
    public class AnnouncementsController : Controller
    {
        private readonly AnnouncementsRepository _repository;

        public AnnouncementsController(AnnouncementsRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var announcements = _repository.GetAnnouncements();
            return View("Index", announcements);
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(IFormCollection collection)
        {
            AnnouncementModel model = new AnnouncementModel();
            TryUpdateModelAsync(model);
            _repository.Add(model);


            return RedirectToAction("Index");
        }
        public IActionResult Edit(Guid id)
        {
            var model = _repository.GetAnnouncementById(id);
            return View("Edit", model);
        }

        [HttpPost]
        public IActionResult Edit(IFormCollection collection)
        {
            AnnouncementModel model = new();
            TryUpdateModelAsync(model);
            _repository.Update(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(Guid id, IFormCollection collection)
        {
            var model = _repository.GetAnnouncementById(id);
            return View("Delete", model);
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Details(Guid id)
        {
            return View("Details", _repository.GetAnnouncementById(id));
        }
    }
}