using System;

public class StudentUI
{
    private readonly StudentRepo _studentRepo;

    // Constructor: StudentRepo bağımlılığı enjekte edilir.
    public StudentUI(StudentRepo studentRepo)
    {
        _studentRepo = studentRepo;
    }

    // Yeni bir öğrenci ekler.
    public void AddStudent()
    {
        Console.WriteLine("=== Add New Student ===");

        // Kullanıcıdan öğrenci adı al
        string name = GetValidName();

        // Kullanıcıdan doğum tarihi al
        DateTime birthDate = GetValidBirthDate();

        // Kullanıcıdan House ID al
        int houseId = GetValidHouseId();

        // Yeni bir öğrenci oluştur
        var student = new Student
        {
            Name = name,
            BirthDate = birthDate,
            HouseId = houseId
        };

        // Repository üzerinden öğrenci ekle
        _studentRepo.AddStudent(student);

        Console.WriteLine("Student added successfully!");
    }

    // Tüm öğrencileri listeler.
    public void ShowAllStudents()
    {
        Console.WriteLine("=== List of Students ===");

        var students = _studentRepo.GetAllStudents();

        if (students.Count == 0)
        {
            Console.WriteLine("No students found.");
        }
        else
        {
            foreach (var student in students)
            {
                Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, BirthDate: {student.BirthDate.ToShortDateString()}, HouseId: {student.HouseId}");
            }
        }
    }

    // Belirli bir öğrenciyi ID ile gösterir.
    public void ShowStudentById()
    {
        Console.WriteLine("=== Show Student by ID ===");

        int id = GetValidStudentId();

        var student = _studentRepo.GetStudentById(id);

        if (student != null)
        {
            Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, BirthDate: {student.BirthDate.ToShortDateString()}, HouseId: {student.HouseId}");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    // Bir öğrenciyi günceller.
    public void UpdateStudent()
    {
        Console.WriteLine("=== Update Student ===");

        int id = GetValidStudentId();

        var existingStudent = _studentRepo.GetStudentById(id);

        if (existingStudent == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        Console.WriteLine($"Current Name: {existingStudent.Name}, Enter New Name (Leave blank to keep current): ");
        string name = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(name))
        {
            existingStudent.Name = name;
        }

        Console.WriteLine($"Current BirthDate: {existingStudent.BirthDate.ToShortDateString()}, Enter New BirthDate (Leave blank to keep current): ");
        string birthDateInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(birthDateInput) && DateTime.TryParse(birthDateInput, out var newBirthDate))
        {
            existingStudent.BirthDate = newBirthDate;
        }

        Console.WriteLine($"Current HouseId: {existingStudent.HouseId}, Enter New HouseId (1-4, Leave blank to keep current): ");
        string houseIdInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(houseIdInput) && int.TryParse(houseIdInput, out var newHouseId) && newHouseId >= 1 && newHouseId <= 4)
        {
            existingStudent.HouseId = newHouseId;
        }

        _studentRepo.UpdateStudent(existingStudent);
        Console.WriteLine("Student updated successfully!");
    }

    // Bir öğrenciyi siler.
    public void DeleteStudent()
    {
        Console.WriteLine("=== Delete Student ===");

        int id = GetValidStudentId();

        var result = _studentRepo.DeleteStudent(id);

        if (result)
        {
            Console.WriteLine("Student deleted successfully.");
        }
        else
        {
            Console.WriteLine("Error deleting student. Student not found.");
        }
    }


    // Belirli bir HouseId'ye göre öğrencileri görüntüler.
    public void ViewStudentsByHouse()
    {
        Console.WriteLine("=== View Students by House ===");

        int houseId = GetValidHouseId();

        var students = _studentRepo.GetStudentsByHouse(houseId);

        if (students.Count == 0)
        {
            Console.WriteLine($"No students found in House {houseId}.");
        }
        else
        {
            Console.WriteLine($"=== Students in House {houseId} ===");
            foreach (var student in students)
            {
                Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, BirthDate: {student.BirthDate.ToShortDateString()}");
            }
        }
    }

    // Kullanıcıdan geçerli bir isim alır.
    private string GetValidName()
    {
        string name;
        do
        {
            Console.Write("Enter student name: ");
            name = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(name) || !IsAlphabetic(name));

        return name;
    }

    // Kullanıcıdan geçerli bir doğum tarihi alır.
    private DateTime GetValidBirthDate()
    {
        DateTime birthDate;
        do
        {
            Console.Write("Enter birth date (YYYY-MM-DD): ");
        } while (!DateTime.TryParse(Console.ReadLine(), out birthDate));

        return birthDate;
    }

    // Kullanıcıdan geçerli bir House ID alır.
    private int GetValidHouseId()
    {
        int houseId;
        do
        {
            Console.Write("Enter house ID (1-4): ");
        } while (!int.TryParse(Console.ReadLine(), out houseId) || houseId < 1 || houseId > 4);

        return houseId;
    }

    // Kullanıcıdan geçerli bir öğrenci ID'si alır.
    private int GetValidStudentId()
    {
        int id;
        do
        {
            Console.Write("Enter student ID: ");
        } while (!int.TryParse(Console.ReadLine(), out id));

        return id;
    }

    // Girilen string'in sadece harflerden oluşup oluşmadığını kontrol eder.
    private bool IsAlphabetic(string input)
    {
        foreach (var c in input)
        {
            if (!char.IsLetter(c))
                return false;
        }
        return true;
    }
}
