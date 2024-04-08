using Clarity_Crate.Data;
using Clarity_Crate.Models;
using Microsoft.EntityFrameworkCore;

namespace Clarity_Crate.Services
{
    public class TermService
    {
        private readonly ApplicationDbContext _context;

        public TermService(ApplicationDbContext context)
        {
            _context = context;
        }

        //CREATE
        public async Task<Boolean> AddTerm(Term term)
        {
            //check if the term already exists case insensitive
            var termExists = await _context.Term.AnyAsync(t => t.Name.ToLower() == term.Name.ToLower());
            if (termExists)
            {
                return false;
            }
            //check if the topic for term exists
            var topic = await _context.Topic.FirstOrDefaultAsync(t => t.Id == term.TopicId);
            if (topic == null)
            {
                return false;
            }
            else
            {
                _context.Add(term);
                await _context.SaveChangesAsync();
                return true;
            }
        }
        //READ
        public async Task<List<Term>> GetTerms()
        {
            return await _context.Term.ToListAsync();
        }

        public async Task<Term?> GetTermById(int id)
        {
            return await _context.Term.FirstOrDefaultAsync(t => t.Id == id);
        }

        //UPDATE
        public async Task UpdateTerm(Term term)
        {
            _context.Update(term);
            await _context.SaveChangesAsync();
        }

        //DELETE
        public async Task DeleteTerm(int id)
        {
            var term = await GetTermById(id);
            if (term != null)
            {
                _context.Remove(term);
                await _context.SaveChangesAsync();
            }
        }

    }
}
