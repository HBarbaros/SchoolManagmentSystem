public class Course
{
    public int Id { get; set; }     // Unique identifier for the course
    public string Title { get; set; }    // Name or title of the course

    // Overriding ToString for better readability when displaying course information
    public override string ToString()
    {
        return $"CourseID: {Id}, Title: {Title}";
    }
}
