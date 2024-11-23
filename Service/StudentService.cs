using System;
using System.Collections.Generic;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _repository;
    private readonly IStudentValidator _validator;

    public StudentService(IStudentRepository repository, IStudentValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public Result AddStudent(string name, DateTime birthDate, int houseId)
    {
        if (!_validator.IsValid(name, birthDate, houseId))
        {
            return Result.Failure("Invalid student data.");
        }

        try
        {
            _repository.AddStudent(new Student
            {
                Name = name,
                BirthDate = birthDate,
                HouseId = houseId
            });
            return Result.Succeeded();
        }
        catch (Exception ex)
        {
            return Result.Failure($"An error occurred: {ex.Message}");
        }
    }

    public List<StudentDto> GetAllStudents()
    {
        var students = _repository.GetAllStudents();
        var studentDtos = new List<StudentDto>();

        foreach (var student in students)
        {
            studentDtos.Add(new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                BirthDate = student.BirthDate,
                HouseId = student.HouseId
            });
        }

        return studentDtos;
    }

    public StudentDto GetStudentById(int id)
    {
        var student = _repository.GetStudentById(id);
        if (student == null)
        {
            return null;
        }

        return new StudentDto
        {
            Id = student.Id,
            Name = student.Name,
            BirthDate = student.BirthDate,
            HouseId = student.HouseId
        };
    }
}
