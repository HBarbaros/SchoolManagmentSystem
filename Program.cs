using System;
using Microsoft.Extensions.Configuration;

class Program
{
    static void Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        DatabaseConnection dbConnection = new DatabaseConnection(configuration);

        StudentRepo studentRepo = new StudentRepo(dbConnection);
        CourseRepo courseRepo = new CourseRepo(dbConnection);
        GradeRepo gradeRepo = new GradeRepo(dbConnection);
        TeacherRepo teacherRepo = new TeacherRepo(dbConnection);
        HouseRepo houseRepo = new HouseRepo(dbConnection);

        StudentUI studentUI = new StudentUI(studentRepo);
        CourseUI courseUI = new CourseUI(courseRepo);
        GradeUI gradeUI = new GradeUI(gradeRepo);
        TeacherUI teacherUI = new TeacherUI(teacherRepo);
        HouseUI houseUI = new HouseUI(houseRepo);


        SchoolSystemUI ui = new SchoolSystemUI(studentUI, courseUI, gradeUI, teacherUI, houseUI);

        ui.MainMenu();
    }
}
