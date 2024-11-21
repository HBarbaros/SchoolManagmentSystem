public class Grade
{
    public int Id { get; set; }       // Unique identifier for the grade
    public int StudentID { get; set; }    // ID of the student
    public int CourseID { get; set; }     // ID of the course
    public string Value { get; set; }     // Grade value (e.g., A, B, C, etc.)

    // Overriding ToString for better readability when displaying grades
    public override string ToString()
    {
        return $"GradeID: {Id}, StudentID: {StudentID}, CourseID: {CourseID}, Value: {Value}";
    }
}
