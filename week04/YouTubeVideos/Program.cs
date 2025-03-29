using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("C# Tutorial for Beginners", "CodeAcademy", 600);
        video1.AddComment(new Comment("Alice", "Great explanation, thanks!"));
        video1.AddComment(new Comment("Bob", "This really helped me understand classes."));
        video1.AddComment(new Comment("Charlie", "Do you have one on interfaces?"));
        videos.Add(video1);

        Video video2 = new Video("Top 10 Programming Languages", "DevWorld", 420);
        video2.AddComment(new Comment("Dave", "Python should be higher!"));
        video2.AddComment(new Comment("Eve", "Love this video."));
        video2.AddComment(new Comment("Frank", "You forgot Rust!"));
        videos.Add(video2);

        Video video3 = new Video("Flutter UI Tutorial", "MobileDev", 980);
        video3.AddComment(new Comment("Grace", "Amazing transitions."));
        video3.AddComment(new Comment("Heidi", "Subscribed!"));
        video3.AddComment(new Comment("Ivan", "Can you do one for dark mode UI?"));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}
