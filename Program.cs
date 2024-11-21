using System;

class Program
{
    static void Main(string[] args)
    {

        DatabaseConnection dbConnection = new DatabaseConnection();

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
