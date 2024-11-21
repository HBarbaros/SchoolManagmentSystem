using System;

public class SchoolSystemUI
{

    private StudentUI _studentUI;
    private CourseUI _courseUI;
    private GradeUI _gradeUI;
    private TeacherUI _teacherUI;
    private HouseUI _houseUI;

    public SchoolSystemUI(StudentUI studentUI, CourseUI courseUI, GradeUI gradeUI, TeacherUI teacherUI, HouseUI houseUI)
    {
        _studentUI = studentUI;
        _courseUI = courseUI;
        _gradeUI = gradeUI;
        _teacherUI = teacherUI;
        _houseUI = houseUI;
    }


    public void MainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== SCHOOL SYSTEM MENU ===");
            Console.WriteLine("1. Student Management");
            Console.WriteLine("2. Teacher Management");
            Console.WriteLine("3. Course Management");
            Console.WriteLine("4. Grade Management");
            Console.WriteLine("5. House Management");
            Console.WriteLine("6. Exit");
            Console.Write("Your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    StudentManagementMenu();
                    break;
                case "2":
                    TeacherManagementMenu();
                    break;
                case "3":
                    CourseManagementMenu();
                    break;
                case "4":
                    GradeManagementMenu();
                    break;
                case "5":
                    HouseManagementMenu();
                    break;
                case "6":
                    Console.WriteLine("Exiting system. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    private void StudentManagementMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== STUDENT MANAGEMENT ===");
            Console.WriteLine("1. Add New Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Show Student By ID");
            Console.WriteLine("4. Update Student");
            Console.WriteLine("5. Delete Student");
            Console.WriteLine("6. View Students by House");
            Console.WriteLine("7. Back to Main Menu");
            Console.Write("Your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    _studentUI.AddStudent();
                    break;
                case "2":
                    _studentUI.ShowAllStudents();
                    break;
                case "3":
                    _studentUI.ShowStudentById();
                    break;
                case "4":
                    _studentUI.UpdateStudent();
                    break;
                case "5":
                    _studentUI.DeleteStudent();
                    break;
                case "6":
                    _studentUI.ViewStudentsByHouse();
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    private void CourseManagementMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== COURSE MANAGEMENT ===");
            Console.WriteLine("1. Add New Course");
            Console.WriteLine("2. View All Courses");
            Console.WriteLine("3. Show Course By ID");
            Console.WriteLine("4. Update Course");
            Console.WriteLine("5. Delete Course");
            Console.WriteLine("6. Assign Teacher to course");
            Console.WriteLine("7. Back to Main Menu");
            Console.Write("Your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    _courseUI.AddCourse();
                    break;
                case "2":
                    _courseUI.ShowAllCourses();
                    break;
                case "3":
                    _courseUI.ShowCourseById();
                    break;
                case "4":
                    _courseUI.UpdateCourse();
                    break;
                case "5":
                    _courseUI.DeleteCourse();
                    break;
                case "6":
                    _courseUI.AssignTeacherToCourse();
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    private void GradeManagementMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== GRADE MANAGEMENT ===");
            Console.WriteLine("1. Add New Grade");
            Console.WriteLine("2. View All Grades");
            Console.WriteLine("3. View Grades By Student");
            Console.WriteLine("4. View Grades By Course");
            Console.WriteLine("5. Delete Grades By Id");
            Console.WriteLine("6. Update Grades By Id");
            Console.WriteLine("7. Back to Main Menu");
            Console.Write("Your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    _gradeUI.AddGrade();
                    break;
                case "2":
                    _gradeUI.ShowAllGrades();
                    break;
                case "3":
                    _gradeUI.ShowGradesByStudent();
                    break;
                case "4":
                    _gradeUI.ShowGradesByCourse();
                    break;
                case "5":
                    _gradeUI.DeleteGrade();
                    break;
                case "6":
                    _gradeUI.UpdateGrade();
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    public void TeacherManagementMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== TEACHER MANAGMENT ===");
            Console.WriteLine("1. Show All Teachers");
            Console.WriteLine("2. Show Teacher By ID ");
            Console.WriteLine("3. Update Teacher");
            Console.WriteLine("4. Add New Teacher");
            Console.WriteLine("5. Delete Teacher");
            Console.WriteLine("6. Back to Main Menu");
            Console.Write("Your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    _teacherUI.DisplayAllTeachers();
                    break;
                case "2":
                    _teacherUI.GetTeacherById();
                    break;
                case "3":
                    _teacherUI.UpdateTeacher();
                    break;
                case "4":
                    _teacherUI.AddNewTeacher();
                    break;
                case "5":
                    _teacherUI.DeleteTeacher();
                    return;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
        }

    }
    public void HouseManagementMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== HOUSE MANAGMENT ===");
            Console.WriteLine("1. Display all houses");
            Console.WriteLine("2. Add house points");
            Console.WriteLine("3. Deduct house points");
            Console.WriteLine("4. Back to Main Menu");
            Console.Write("Your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    _houseUI.DisplayAllHousesInOrder();
                    break;
                case "2":
                    _houseUI.AddHousePoints();
                    break;
                case "3":
                    _houseUI.DeductHousePoints();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
        }

    }


}