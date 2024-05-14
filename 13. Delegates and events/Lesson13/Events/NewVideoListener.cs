namespace Events;

public sealed class NewVideoListener
{
    private readonly int _listenerId;

    public NewVideoListener(int listenerId, YoutubeChannelEventsNotifier channelEventsNotifier)
    {
        _listenerId = listenerId;
        channelEventsNotifier.NewVideoAddedEvent += PrintNewVideoEvent;
    }

    private void PrintNewVideoEvent(NewVideoAddedEventArgs args)
    {
        Console.WriteLine($"{_listenerId}: catch new video: author - {args.Author}, name - '{args.Name}'");
    }
}