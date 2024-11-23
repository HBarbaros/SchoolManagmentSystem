public class Result
{
    public bool Success { get; private set; }
    public string Error { get; private set; }

    public static Result Succeeded()
    {
        return new Result { Success = true, Error = null };
    }

    public static Result Failure(string error)
    {
        if (string.IsNullOrEmpty(error))
        {
            error = "Unknown error occurred";
        }
        return new Result { Success = false, Error = error };
    }
}
