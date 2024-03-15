using Clarity_Crate.Data;
using Clarity_Crate.Models;
using Microsoft.EntityFrameworkCore;

namespace Clarity_Crate.Services
{
    public class SubjectService
    {
        private readonly ApplicationDbContext _context;
        public List<Subject> Subjects { get; set; }


        public SubjectService(ApplicationDbContext context)
        {
            _context = context;
        }



        public async Task CreateSubject(Subject subject, int curriculumId)
        {
            //check if the curriculum exists
            var curriculum = await _context.Curriculum.FindAsync(curriculumId);
            if (curriculum == null) { return; }

            //check the subject with the same name exists to avoid redundancy
            var subjectExists = await _context.Subject
               .FirstOrDefaultAsync(s => s.Name.ToLower().Trim() == subject.Name.ToLower().Trim());

            if (subjectExists != null)
            {
                //since a subject can have different curriculums
                //check if the curriculum already exists for the subject that already exists
                //by looping through the subject curriculums
                foreach (var cur in subjectExists.Curriculums)
                {
                    if (cur.Id == curriculum.Id)
                    {
                        return;
                    }

                }

                //if the curriculum does not exist for the subject
                //add the curriculum to the subject
                subjectExists.Curriculums.Add(curriculum);
                await _context.SaveChangesAsync();
            }


            else
            {

                subject.Curriculums.Add(curriculum);

                _context.Subject.Add(subject);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<Subject?> GetSubject(int id)
        {
            var subject = await _context.Subject.Include(s => s.Curriculums).FirstOrDefaultAsync(s => s.Id == id);

            return subject;
        }

        public async Task GetSubjects()
        {
            //get subjects with their curriculum
            var subjects = await _context.Subject.Include(s => s.Curriculums).ToListAsync();

            Subjects = subjects;
        }

        public async Task<Boolean> UpdateSubject(int id, Subject subject)
        {
            var itemExists = await _context.Subject.FindAsync(id);

            if (itemExists == null)
            {
                return false;
            }

            try
            {
                itemExists.Name = subject.Name;


                await _context.SaveChangesAsync();
                return false;

            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw;
            }
        }


        public async Task<Boolean> DeleteSubject(int id)
        {
            var itemExists = await _context.Subject.FindAsync(id);

            if (itemExists == null)
            {
                return false;
            }

            _context.Subject.Remove(itemExists);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
