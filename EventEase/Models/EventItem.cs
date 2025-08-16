namespace EventEase.Models;

public class EventItem
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public DateTime Date { get; set; } = DateTime.Today;
    public string Location { get; set; } = "";
    public string Description { get; set; } = "";
}