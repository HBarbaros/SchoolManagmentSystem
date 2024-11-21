using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Dapper;

public abstract class DapperRepo<T>
{
    protected DatabaseConnection _databaseConnection;

    public DapperRepo(DatabaseConnection databaseConnection)
    {
        _databaseConnection = databaseConnection;
    }

    public IEnumerable<T> GetAll(string tableName)
    {
        using (IDbConnection conn = _databaseConnection.CreateConnection())
        {
            string sql = $"SELECT * FROM {tableName}";
            return conn.Query<T>(sql);
        }
    }

    public T GetById(int id, string tableName)
    {
        using (IDbConnection conn = _databaseConnection.CreateConnection())
        {
            string sql = $"SELECT * FROM {tableName} WHERE Id = @Id";
            return conn.QuerySingleOrDefault<T>(sql, new { Id = id });
        }
    }

    public void Add(string insertSql, T entity)
    {
        using (IDbConnection conn = _databaseConnection.CreateConnection())
        {
            conn.Execute(insertSql, entity);
        }
    }

    public void Update(string updateSql, T entity)
    {
        using (IDbConnection conn = _databaseConnection.CreateConnection())
        {
            conn.Execute(updateSql, entity);
        }
    }

    public void Delete(int id, string tableName)
    {
        using (IDbConnection conn = _databaseConnection.CreateConnection())
        {
            string sql = $"DELETE FROM {tableName} WHERE Id = @Id";
            conn.Execute(sql, new { Id = id });
        }
    }

    // Retrieve all records with a WHERE condition
    public IEnumerable<T> GetAllByCondition(string tableName, string whereClause, object parameters)
    {
        using (var conn = _databaseConnection.CreateConnection())
        {
            string sql = $"SELECT * FROM {tableName} WHERE {whereClause}";
            return conn.Query<T>(sql, parameters);
        }
    }

    // Retrieve a scalar value
    public int GetScalar(string sql, object parameters)
    {
        using (IDbConnection conn = _databaseConnection.CreateConnection())
        {
            return conn.ExecuteScalar<int>(sql, parameters);
        }
    }

    // Execute bulk operations
    public void ExecuteBulk(string sql, IEnumerable<object> parameters)
    {
        using (IDbConnection conn = _databaseConnection.CreateConnection())
        {
            conn.Execute(sql, parameters);
        }
    }
    public IEnumerable<T> GetHousesByRanking()
    {
        using (IDbConnection conn = _databaseConnection.CreateConnection())
        {
            string sql = "SELECT * FROM Houses ORDER BY Points DESC";
            return conn.Query<T>(sql);
        }
    }

    public void AddHousePoints(int houseID, int points)
    {
        using (IDbConnection conn = _databaseConnection.CreateConnection())
        {
            string sql = "UPDATE Houses SET Points = Points + @Points WHERE Id = @Id";
            conn.Execute(sql, new { Points = points, Id = houseID });
        }
    }

    public void MinusHousePoints(int houseID, int points)
    {
        using (IDbConnection conn = _databaseConnection.CreateConnection())
        {
            string sql = "UPDATE Houses SET Points = Points - @Points WHERE Id = @Id";
            conn.Execute(sql, new { Points = points, Id = houseID });
        }
    }
    public void UpdateTeacher(string name, DateTime? DoB, int id)
    {
        using (IDbConnection conn = _databaseConnection.CreateConnection())
        {
            string sql = "UPDATE Teachers SET Name = @Name, DoB = @DoB WHERE Id = @Id";
            conn.Execute(sql, new { Name = name, DoB, Id = id });

        }
    }
    public string GetCourseNameByTeacherId(int Id)
    {
        using (IDbConnection conn = _databaseConnection.CreateConnection())
        {
            string sql = @"SELECT Courses.Title FROM Courses INNER JOIN Teachers ON Teachers.CourseId = Courses.Id WHERE Teachers.Id = @Id";

            return conn.QuerySingleOrDefault<string>(sql, new { Id });
        }
    }
    public string GetTeacherNameByCourseId(int courseId)
    {
        using (IDbConnection conn = _databaseConnection.CreateConnection())
        {
            string sql = @"SELECT Teachers.Name FROM Teachers INNER JOIN Courses ON Teachers.CourseId = Courses.Id WHERE Courses.Id = @CourseId";

            return conn.QuerySingleOrDefault<string>(sql, new { CourseId = courseId });
        }
    }
    public void AssignCourseToTeacher(int teacherid, int courseid)
    {
        using (IDbConnection conn = _databaseConnection.CreateConnection())
        {
            string sql = @"UPDATE Teachers SET CourseId = @CourseId WHERE Id = @TeacherId;";

            conn.Execute(sql, new { CourseId = courseid, TeacherId = teacherid });
        }
    }
    public List<Course> GetCoursesWithoutTeacher()
    {
        using (IDbConnection conn = _databaseConnection.CreateConnection())
        {
            string sql = @"SELECT Id, Title FROM Courses WHERE Id NOT IN (SELECT CourseId FROM Teachers WHERE CourseId IS NOT NULL);";
            return conn.Query<Course>(sql).ToList();
        }
    }
    public List<Teacher> GetTeachersWithoutCourse()
    {
        using (IDbConnection conn = _databaseConnection.CreateConnection())
        {
            string sql = @"SELECT Id, Name FROM Teachers WHERE CourseId IS NULL;";
            return conn.Query<Teacher>(sql).ToList();
        }
    }
}


