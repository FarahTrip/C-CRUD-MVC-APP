using FirstMVCApp.DataContext;
using FirstMVCApp.Models;
using FirstMVCApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCApp.Repositories
{
    public class MembershipTypesRepository
    {
        private readonly ProgrammingClubDataContext _context;

        public MembershipTypesRepository(ProgrammingClubDataContext context) => _context = context;

        public DbSet<MembershipTypeModel> GetAllMembershipTypes()
        {
            return _context.MembershipTypes;
        }

        public DbSet<MembershipTypeModel> GetAll()
        {
            return _context.MembershipTypes;
        }

        internal void AddMembershiptType(MembershipTypeModel model)
        {
            _context.MembershipTypes.Add(model);
            _context.SaveChanges();
        }

        public MembershipTypeModel FindById(Guid id)
        {
            return _context.MembershipTypes.FirstOrDefault(a => a.IDMembershipType == id);
        }

        internal void UpdateMembershipType(Guid id, MembershipTypeModel updatedMembership)
        {
            _context.MembershipTypes.Update(updatedMembership);
            _context.SaveChanges();
        }

        public void DeleteMembershipType(MembershipTypeModel membershipType)
        {
            _context.MembershipTypes.Remove(membershipType);
            _context.SaveChanges();
        }

        public MembershipTypesMembersViewModel GetMembersByMembership(Guid MembershipTypeId)
        {
            MembershipTypesMembersViewModel membershipType = new MembershipTypesMembersViewModel();

            var membership = _context.MembershipTypes.FirstOrDefault(x => x.IDMembershipType == MembershipTypeId);
            if (membership != null)
            {
                membershipType.Name = membership.Name;
                membershipType.Description = membership.Description;
                membershipType.members = _context.Members.Where(x => x.IDMember == MembershipTypeId).ToList();
                membershipType.Count = membershipType.members.Count;
            }

            return membershipType;
        }
    }
}