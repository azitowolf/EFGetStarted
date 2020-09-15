using System;
using System.Linq;

namespace EFGetStarted
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                System.Console.WriteLine("Please enter an argument.");
                return 1;
            } 
            using (var db = new BloggingContext())
            {
                // Create
                Console.WriteLine("Inserting a new blog=" + args[0]);
                db.Add(new Blog { Url = args[0] });
                db.SaveChanges();

                // Read
                Console.WriteLine("Querying for a blog");
                var blog = db.Blogs
                    .OrderBy(b => b.BlogId)
                    .First();

                // Update
                Console.WriteLine("Updating the blog and adding a post");
                blog.Url = "https://devblogs.microsoft.com/dotnet";
                blog.Posts.Add(
                    new Post
                    {
                        Title = "Hello World",
                        Content = "I wrote an app using EF Core!"
                    });
                db.SaveChanges();

                // Delete
                // Console.WriteLine("Delete the blog");
                // db.Remove(blog);
                // db.SaveChanges();
                return 1;
            }
        }
    }
}