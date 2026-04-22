namespace Store.Proyect.Core.Http;

public class Response <T>
{
    public bool Success { get; set; }

    public T? Data { get; set; }

    public string Message { get; set; } = string.Empty;

    public List<string> Errors { get; set; } = new List<string>();
}