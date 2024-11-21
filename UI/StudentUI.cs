public class StudentUI
{
    private StudentRepo _studentRepo;

    public StudentUI(StudentRepo studentRepo)
    {
        _studentRepo = studentRepo;
    }

    public void AddStudent()
    {
        string name;
        while (true)
        {
            Console.Write("Enter student name: ");
            name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name) && name.All(char.IsLetter))
                break;

            Console.WriteLine("Invalid input. Please enter alphabetic characters only.");
        }

        DateTime birthDate;
        while (true)
        {
            Console.Write("Enter student birth date (YYYY-MM-DD): ");
            if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                break;

            Console.WriteLine("Invalid date format. Please try again.");
        }

        int houseId;
        while (true)
        {
            Console.Write("Enter house ID (1-4): ");
            if (int.TryParse(Console.ReadLine(), out houseId) && houseId >= 1 && houseId <= 4)
                break;

            Console.WriteLine("Invalid house ID. Please enter a number between 1 and 4.");
        }

        var student = new Student { Name = name, BirthDate = birthDate, HouseId = houseId };

        if (_studentRepo.AddStudent(student))
            Console.WriteLine("Student added successfully.");
        else
            Console.WriteLine("Error adding student.");
    }

    public void ShowAllStudents()
    {
        var students = _studentRepo.GetAllStudents();
        Console.WriteLine("List of Students:");
        foreach (var student in students)
        {
            Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, HouseId: {student.HouseId}");
        }
    }

    public void ShowStudentById()
    {
        int id;
        while (true)
        {
            Console.Write("Enter student ID: ");
            if (int.TryParse(Console.ReadLine(), out id))
                break;

            Console.WriteLine("Invalid input. Please enter a valid number.");
        }

        var student = _studentRepo.GetStudentById(id);
        if (student != null)
        {
            Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, HouseId: {student.HouseId}");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    public void UpdateStudent()
    {
        int id;
        while (true)
        {
            Console.Write("Enter student ID to update: ");
            if (int.TryParse(Console.ReadLine(), out id) && id > 0)
                break;

            Console.WriteLine("Invalid input. Please enter a valid number.");
        }

        var student = _studentRepo.GetStudentById(id);

        if (student != null)
        {
            Console.WriteLine("Leave fields blank to keep current values.");

            Console.Write($"Current Name: {student.Name}, New Name: ");
            string name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name) && name.All(char.IsLetter))
                student.Name = name;

            Console.Write($"Current BirthDate: {student.BirthDate}, New BirthDate: ");
            string birthDateInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(birthDateInput) && DateTime.TryParse(birthDateInput, out var birthDate))
                student.BirthDate = birthDate;

            Console.Write($"Current HouseId: {student.HouseId}, New HouseId: ");
            string houseIdInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(houseIdInput) && int.TryParse(houseIdInput, out var houseId) && houseId >= 1 && houseId <= 4)
                student.HouseId = houseId;

            if (_studentRepo.UpdateStudent(student))
                Console.WriteLine("Student updated successfully.");
            else
                Console.WriteLine("Error updating student.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    public void DeleteStudent()
    {
        int id;
        while (true)
        {
            Console.Write("Enter student ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out id) && id > 0)
                break;

            Console.WriteLine("Invalid input. Please enter a valid number.");
        }

        if (_studentRepo.DeleteStudent(id))
            Console.WriteLine("Student deleted successfully.");
        else
            Console.WriteLine("Error deleting student.");
    }

    public void ViewStudentsByHouse()
    {
        int houseId;
        while (true)
        {
            Console.Write("Enter house ID (1-4): ");
            if (int.TryParse(Console.ReadLine(), out houseId) && houseId >= 1 && houseId <= 4)
                break;

            Console.WriteLine("Invalid input. Please enter a valid house ID.");
        }

        var students = _studentRepo.GetStudentsByHouse(houseId);

        Console.WriteLine($"Students in House {houseId}:");
        foreach (var student in students)
        {
            Console.WriteLine($"Id: {student.Id}, Name: {student.Name}");
        }
    }
}
