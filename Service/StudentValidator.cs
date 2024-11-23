public class StudentValidator : IStudentValidator
{
    public bool IsValid(string name, DateTime birthDate, int houseId)
    {
        return !string.IsNullOrWhiteSpace(name) &&
               houseId >= 1 && houseId <= 4 &&
               birthDate <= DateTime.Now;
    }
}
