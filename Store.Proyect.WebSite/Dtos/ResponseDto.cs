namespace Store.Proyect.WebSite.Dtos;

public class ResponseDto<T>
{
    public T Data { get; set; }
    public List<string> Errors { get; set; } = new();
}