using FirstMVCApp.DataContext;
using FirstMVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCApp.Repositories
{
    public class CodeSnippetsRepository
    {
        private readonly ProgrammingClubDataContext _context;

        public CodeSnippetsRepository(ProgrammingClubDataContext context)
        {
            _context = context;
        }

        public DbSet<CodeSnippetModel> GetAll()
        {
            return _context.CodeSnippets;
        }

        public CodeSnippetModel GetById(Guid id)
        {
            return _context.CodeSnippets.FirstOrDefault(a => a.IDCodeSnippet == id);
        }

        public void Add(CodeSnippetModel codeSnippet)
        {
            codeSnippet.IDCodeSnippet = Guid.NewGuid();
            _context.CodeSnippets.Add(codeSnippet);
            //_context.Entry(CodeSnippetModel).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Update(CodeSnippetModel codeSnippet)
        {
            _context.CodeSnippets.Update(codeSnippet);
            _context.SaveChanges();
        }

        public void DeleteById(Guid id)
        {
            _context.CodeSnippets.Remove(GetById(id));
            _context.SaveChanges();
        }


    }
}