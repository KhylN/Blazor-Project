using System.Collections.Concurrent;

namespace EventEase.Models;

public static class EventStore
{
    private static readonly List<EventItem> _events = new List<EventItem>
    {
        new EventItem { Id = 1, Title = "Tech Meetup", Date = DateTime.Today.AddDays(3), Location = "Hall A", Description = "Networking + talks" },
        new EventItem { Id = 2, Title = "Career Fair", Date = DateTime.Today.AddDays(10), Location = "Main Gym", Description = "Employers & booths" },
        new EventItem { Id = 3, Title = "Hack Night", Date = DateTime.Today.AddDays(17), Location = "Lab 204", Description = "Casual coding jam" }
    };

    public static IReadOnlyList<EventItem> GetAll() => _events;

    public static bool TryGet(int id, out EventItem? item)
    {
        item = _events.FirstOrDefault(e => e.Id == id);
        return item is not null;
    }
}