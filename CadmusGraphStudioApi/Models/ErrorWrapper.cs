namespace CadmusGraphStudioApi.Models;

public class ErrorWrapper<T>
{
    public string? Error { get; set; }
    public T? Value { get; set; }
}
