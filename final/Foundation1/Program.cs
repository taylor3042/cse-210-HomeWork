using System;
using System.Collections.Generic;

class Comment
{
    public string CommenterName { get; set; }
    public string CommentText { get; set; }

    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public List<Comment> GetComments()
    {
        return comments;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("Exploring the Mountains", "John Smith", 300);
        Video video2 = new Video("Cooking with Amy", "Amy Johnson", 180);
        Video video3 = new Video("Tech Reviews", "Michael Brown", 600);

        // Add comments to video1
        video1.AddComment(new Comment("Alice", "Great video!"));
        video1.AddComment(new Comment("Bob", "Why won't you call me back Sharel!!."));
        video1.AddComment(new Comment("Charlie", "Amazing adventure!"));

        // Add comments to video2
        video2.AddComment(new Comment("Dave", "Very helpful, thanks!"));
        video2.AddComment(new Comment("Bob", "I keep calling but you still won't answer Sharel!!."));
        video2.AddComment(new Comment("Frank", "Can't wait to try this recipe."));

        // Add comments to video3
        video3.AddComment(new Comment("Grace", "Best review ever!"));
        video3.AddComment(new Comment("Bob", "Hey guys, sharell called me back. (cool emoji here)"));
        video3.AddComment(new Comment("Ivy", "Keep up the good work!"));

        // Create a list of videos
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display information for each video
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.CommentText}");
            }

            Console.WriteLine();
        }
    }
}
