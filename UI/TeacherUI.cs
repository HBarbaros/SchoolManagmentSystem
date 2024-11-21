using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;

public class TeacherUI
{

    private TeacherRepo _teacherRepo;

    public TeacherUI(TeacherRepo teacherRepo)
    {
        _teacherRepo = teacherRepo;
    }

    public void DisplayAllTeachers()
    {
        Console.Clear();
        List<Teacher> t = _teacherRepo.GetAllTeachers();

        foreach (var teacher in t)
        {
            string subject = _teacherRepo.GetCourseNameByTeacherId(teacher.Id);
            Console.WriteLine("\n Name: " + teacher.Name +
                                "\n Age: " + teacher.DoB +
                                "\n Subject: " + subject);

        }

    }

    public void DisplayAllTeachersWithID()
    {
        Console.Clear();
        List<Teacher> t = _teacherRepo.GetAllTeachers();

        foreach (var teacher in t)
        {
            string subject = _teacherRepo.GetCourseNameByTeacherId(teacher.Id);
            Console.WriteLine("\n ID" + teacher.Id +
                                "\n Name: " + teacher.Name +
                                "\n Age: " + teacher.DoB +
                                "\n Subject: " + subject);
        }
    }

    public void AddNewTeacher()
    {
        Console.Clear();

        string name = GetTeacherName();

        DateTime? DoB = GetTeacherAge();

        if (name == null || DoB == null)
        {
            return;
        }
        else
        {
            Teacher newTeacher = new Teacher() { Name = name, DoB = DoB };
            _teacherRepo.AddTeacher(newTeacher);
            Console.WriteLine("Added " + name);
        }
        Console.WriteLine("Press any key to continue");
        Console.ReadKey(true);

    }
    public string GetTeacherName()
    {
        Console.WriteLine("Name: ");
        string name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name) == false)
        {
            return name;
        }
        else
        {
            Console.WriteLine("Invalid Name");
            return null;
        }
    }
    public DateTime? GetTeacherAge()
    {
        Console.WriteLine("Enter teacher age (YYYY-MM-DD): ");

        if (DateTime.TryParse(Console.ReadLine(), out DateTime dob))
        {
            if (_teacherRepo.IsTeacherAgeOk(dob))
            {
                return dob;
            }
            else
            {
                Console.WriteLine("Teachers must be 21+");
                return null;
            }
        }
        else
        {
            Console.WriteLine("Invalid Age");
            return null;
        }

    }

    public void DeleteTeacher()
    {
        DisplayAllTeachersWithID();
        Console.WriteLine("Teacher id to delete: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            _teacherRepo.Delete(id, "Teachers");
            Console.WriteLine("Deleted");
        }
        else
        {
            Console.WriteLine("Not Deleted");
        }
    }
    public void GetTeacherById()
    {
        DisplayAllTeachersWithID();
        Console.WriteLine("Teacher id to select: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            if (_teacherRepo.SelectTeacherById(id) != null)
            {
                Teacher selectedTeacher = _teacherRepo.SelectTeacherById(id);
                string subject = _teacherRepo.GetCourseNameByTeacherId(selectedTeacher.Id);
                Console.WriteLine("Name: " + selectedTeacher.Name +
                                "\n Age: " + selectedTeacher.DoB +
                                "\n Subject: " + subject);
            }
        }
        else
        {
            Console.WriteLine("Invalid ID");
        }

    }

    public void UpdateTeacher()
    {

        DisplayAllTeachersWithID();
        Console.WriteLine("Select id to update: ");
        if (int.TryParse(Console.ReadLine(), out int id)) ;

        string name = GetTeacherName();
        DateTime? DoB = GetTeacherAge();

        _teacherRepo.UpdateTeacher(name, DoB, id);
    }

}