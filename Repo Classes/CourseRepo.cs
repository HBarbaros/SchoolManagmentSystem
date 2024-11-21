public class CourseRepo : DapperRepo<Course>
{
    public CourseRepo(DatabaseConnection databaseConnection) : base(databaseConnection) { }

    public void AddCourse(Course course)
    {
        string sql = "INSERT INTO Courses (Title) VALUES (@Title)";
        Add(sql, course);
    }

    public IEnumerable<Course> GetAllCourses()
    {
        return GetAll("Courses");
    }

    public Course GetCourseById(int id)
    {
        return GetById(id, "Courses");
    }

    public void UpdateCourse(Course course)
    {
        string sql = "UPDATE Courses SET Title = @Title WHERE Id = @Id";
        Update(sql, course);
    }

    public void DeleteCourse(int id)
    {
        Delete(id, "Courses");
    }
}