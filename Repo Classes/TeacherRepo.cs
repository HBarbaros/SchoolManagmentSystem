using System.Net;

public class TeacherRepo : DapperRepo<Teacher>
{
    public TeacherRepo(DatabaseConnection databaseConnection) : base(databaseConnection)
    {
    }

    public void AddTeacher(Teacher teacher)
    {
        string insertSql = "INSERT INTO Teachers (Name, DoB) VALUES (@Name, @DoB)";
        Add(insertSql, teacher);
    }

    public void UpdateTeacher(Teacher teacher)
    {
        string updateSql = "UPDATE Teachers SET Name = @Name, DoB = @DoB WHERE Id = @Id";
        Update(updateSql, teacher);
    }

    public void DeleteTeacher(int id)
    {
        Delete(id, "Teachers");
    }

    public List<Teacher> GetAllTeachers()
    {
        return GetAll("Teachers").ToList();
    }

    public Teacher GetTeacherById(int id)
    {
        return GetById(id, "Teachers");
    }

    public Teacher SelectTeacherById(int teacherID)
    {
        List<Teacher> teachers = GetAllTeachers();
        Teacher selectedTeacher;

        foreach (var teacher in teachers)
        {
            if (teacherID == teacher.Id)
            {
                selectedTeacher = teacher;
                return selectedTeacher;
            }
        }
        return null;
    }

    public bool IsTeacherAgeOk(DateTime DoB)
    {

        int age = DateTime.Now.Year - DoB.Year;
        if (age >= 21)
        {
            return true;
        }
        else
        {
            return false;
        }

    }



}