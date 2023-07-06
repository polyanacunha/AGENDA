namespace AgendaMvcProject.Models;

public class Contact
{
    public string? Name { get; set; }
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
