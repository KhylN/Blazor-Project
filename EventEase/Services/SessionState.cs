namespace EventEase.Services;

public class SessionState
{
    public string? CurrentUserName { get; set; }

    // eventId -> attendees set
    private readonly Dictionary<int, HashSet<string>> _attendees = new();

    public IReadOnlyCollection<string> GetAttendees(int eventId) =>
        _attendees.TryGetValue(eventId, out var set) ? set : Array.Empty<string>();

    public bool AddAttendee(int eventId, string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return false;
        if (!_attendees.TryGetValue(eventId, out var set))
        {
            set = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            _attendees[eventId] = set;
        }
        return set.Add(name.Trim());
    }

    public bool RemoveAttendee(int eventId, string name)
    {
        if (!_attendees.TryGetValue(eventId, out var set)) return false;
        return set.Remove(name.Trim());
    }
}
