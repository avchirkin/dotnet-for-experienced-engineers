using Events;

var notifier = new YoutubeChannelEventsNotifier();
_ = new NewVideoListener(1, notifier);
_ = new NewVideoListener(2, notifier);

notifier.ProcessNewVideoAdded("Андрей Акиньшин", "Бенчмарки на каждый день");
notifier.ProcessNewVideoAdded("Stephen Cleary", "C# TPL brief review");