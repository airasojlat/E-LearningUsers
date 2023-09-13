namespace superheroapi.Services.InstructorsServices
{
    public interface IinstructorService
    {
        Task<List<Instructor>> GetAllInstructors();
        Task<List<Instructor>> AddInstructor(Instructor instructor);
    }
}
