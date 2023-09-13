using superheroapi.Models;
using superheroapi.Services.InstructorsServices;

namespace superheroapi.Services.InstructorsServices
{
    public class InstructorService : IinstructorService
    {
        private readonly DataContext _context;

        public InstructorService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Instructor>> AddInstructor(Instructor instructor)
        {
            _context.Instructors.Add(instructor);
            await _context.SaveChangesAsync();
            return await _context.Instructors.ToListAsync();
        }

        public async Task<List<Instructor>> GetAllInstructors()
        {
            var instructors = await _context.Instructors.ToListAsync();
            return instructors;
        }
    }
}
