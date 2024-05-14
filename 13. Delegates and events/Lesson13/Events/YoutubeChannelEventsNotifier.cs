namespace Events;

public sealed class YoutubeChannelEventsNotifier
{
    public delegate void NewVideo(NewVideoAddedEventArgs args);
    public event NewVideo? NewVideoAddedEvent;
    
    public void ProcessNewVideoAdded(string author, string name)
    {
        var args = new NewVideoAddedEventArgs(author, name);
        NewVideoAddedEvent?.Invoke(args);
    }
}

public class NewVideoAddedEventArgs(string author, string name) : EventArgs
{
    public string Author { get; init; } = author;

    public string Name { get; init; } = name;
}