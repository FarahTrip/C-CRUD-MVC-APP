using FirstMVCApp.DataContext;
using FirstMVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCApp.Repositories
{
    public class AnnouncementsRepository
    {
        // clasele de tip repository sunt clase care implementeaza operatiile CRUD pe Baza de date

        private readonly ProgrammingClubDataContext _context;

        public AnnouncementsRepository(ProgrammingClubDataContext context)
        {
            _context = context;
        }


        // metoda echivalenta Get
        public DbSet<AnnouncementModel> GetAnnouncements()
        {
            return _context.Announcements;
        }

        public void Add(AnnouncementModel model)
        {
            model.IdAnnouncement = Guid.NewGuid();  //setam id-ul
            _context.Announcements.Add(model);      // adaugam modelul in layerul ORM
            _context.SaveChanges();                 // commit to database
        }


        public AnnouncementModel GetAnnouncementById(Guid id)
        {
            AnnouncementModel model = _context.Announcements.FirstOrDefault(a => a.IdAnnouncement == id);
            return model;
        }


        public void Update(AnnouncementModel model)
        {
            if (GetAnnouncementById((Guid)model.IdAnnouncement) != null)
            {
                _context.Announcements.Update(model);
                _context.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            if (GetAnnouncementById(id) != null)
            {
                _context.Announcements.Remove(GetAnnouncementById(id));
                _context.SaveChanges();
            }
        }
    }
}