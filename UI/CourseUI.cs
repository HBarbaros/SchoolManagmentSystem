using System;
using System.Data.Common;
using System.Runtime.ConstrainedExecution;

public class CourseUI
{
    private CourseRepo _courseRepo;

    public CourseUI(CourseRepo courseRepo)
    {
        _courseRepo = courseRepo;
    }

    public void AddCourse()
    {
        string title;
        while (true)
        {
            Console.Write("Enter course title: ");
            title = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(title))
                break;

            Console.WriteLine("Invalid input. Please enter a valid course title.");
        }


        var course = new Course { Title = title };
        try
        {
            _courseRepo.AddCourse(course);
            Console.WriteLine("Course added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding course: {ex.Message}");
        }
    }

    public void ShowAllCourses()
    {
        var courses = _courseRepo.GetAllCourses();

        Console.WriteLine("List of Courses:");

        foreach (var course in courses)
        {
            string teacherName = _courseRepo.GetTeacherNameByCourseId(course.Id);
            Console.WriteLine($"Id: {course.Id}, Title: {course.Title},TeacherName: {teacherName}");
        }
    }

    public void ShowCourseById()
    {
        int id;
        while (true)
        {
            Console.Write("Enter course ID: ");
            if (int.TryParse(Console.ReadLine(), out id))
                break;

            Console.WriteLine("Invalid input. Please enter a valid course ID.");
        }

        var course = _courseRepo.GetCourseById(id);
        if (course != null)
        {
            string teacherName = _courseRepo.GetTeacherNameByCourseId(course.Id);
            Console.WriteLine($"Id: {course.Id}, Title: {course.Title}, TeacherName: {teacherName}");
        }
        else
        {
            Console.WriteLine("Course not found.");
        }
    }

    public void UpdateCourse()
    {
        int id;
        while (true)
        {
            Console.Write("Enter course ID to update: ");
            if (int.TryParse(Console.ReadLine(), out id))
                break;

            Console.WriteLine("Invalid input. Please enter a valid course ID.");
        }

        var course = _courseRepo.GetCourseById(id);
        if (course != null)
        {
            Console.WriteLine("Leave fields blank to keep current values.");

            Console.Write($"Current Title: {course.Title}, New Title: ");
            string title = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(title)) course.Title = title;

            try
            {
                _courseRepo.UpdateCourse(course);
                Console.WriteLine("Course updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating course: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Course not found.");
        }
    }

    public void DeleteCourse()
    {
        int id;
        while (true)
        {
            Console.Write("Enter course ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out id))
                break;

            Console.WriteLine("Invalid input. Please enter a valid course ID.");
        }

        try
        {
            _courseRepo.DeleteCourse(id);
            Console.WriteLine("Course deleted successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting course: {ex.Message}");
        }
    }

    public void AssignTeacherToCourse()
    {


        ShowTeachersWithoutCourse();
        Console.WriteLine("Teacher ID: ");
        string tID = Console.ReadLine();

        ShowCoursesWithoutTeacher();
        Console.WriteLine("Course ID: ");
        string cID = Console.ReadLine();

        if (int.TryParse(tID, out int teacherid) && int.TryParse(cID, out int courseID))
        {
            _courseRepo.AssignCourseToTeacher(teacherid, courseID);
        }
    }
    public void ShowTeachersWithoutCourse()
    {

        List<Teacher> t = _courseRepo.GetTeachersWithoutCourse();

        foreach (var item in t)
        {
            Console.WriteLine("\n ID" + item.Id +
                                "\n Name: " + item.Name +
                                "\n Age: " + item.DoB);
        }

    }
    public void ShowCoursesWithoutTeacher()
    {

        List<Course> t = _courseRepo.GetCoursesWithoutTeacher();

        foreach (var item in t)
        {
            Console.WriteLine("\n ID" + item.Id +
                                "\n Name: " + item.Title);
        }

    }



}
