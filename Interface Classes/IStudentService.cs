public interface IStudentService
{
    Result AddStudent(string name, DateTime birthDate, int houseId);
    List<StudentDto> GetAllStudents();
    StudentDto GetStudentById(int id);
}
