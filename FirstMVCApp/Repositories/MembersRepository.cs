using FirstMVCApp.DataContext;
using FirstMVCApp.Models;
using FirstMVCApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCApp.Repositories
{
    public class MembersRepository
    {
        private readonly ProgrammingClubDataContext _context;

        public MembersRepository(ProgrammingClubDataContext context)
        {
            _context = context;
        }

        public DbSet<MemberModel> GetMembers()
        {
            return _context.Members;
        }

        public void AddMember(MemberModel member)
        {
            member.IDMember = Guid.NewGuid();
            _context.Members.Add(member);
            _context.SaveChanges();
        }

        public MemberModel GetMemberById(Guid id)
        {
            return _context.Members.FirstOrDefault(a => a.IDMember == id);
        }

        public void UpdateMember(MemberModel member)
        {
            _context.Members.Update(member);
            _context.SaveChanges();
        }

        public void DeleteMemberById(Guid id)
        {
            var member = _context.Members.FirstOrDefault(a => a.IDMember == id);
            _context.Members.Remove(member);
            _context.SaveChanges();
        }

        public MemberCodeSnippetsViewModel GetMemberCodeSnippets(Guid memberID)
        {
            MemberCodeSnippetsViewModel memberCodesnipptsViewModel = new MemberCodeSnippetsViewModel();

            MemberModel member = _context.Members.FirstOrDefault(x => x.IDMember == memberID);
            if (member != null)
            {
                memberCodesnipptsViewModel.Name = member.Name;
                memberCodesnipptsViewModel.Position = member.Position;
                memberCodesnipptsViewModel.Title = member.Title;


                memberCodesnipptsViewModel.CodeSnippets = _context.CodeSnippets.Where(x => x.IDMember == memberID).ToList();
            }

            return memberCodesnipptsViewModel;
        }
    }
}