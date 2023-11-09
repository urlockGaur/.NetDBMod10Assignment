using System;
using EFTutorial.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace EFTutorial
{
    class Program
    {
        static void Main(string[] args)
        {


            //Menu
            while (true)
            {

                var input = DisplayMenu().ToLower();

                if (input == "1")
                {
                    //display  blogs
                    using (var db = new BlogContext())
                    {
                        Console.WriteLine();
                        Console.WriteLine("Display Blogs List: ");
                        Console.WriteLine("--------------------------------------");

                        var blogs = db.Blogs.ToList();
                        if (blogs.Any())
                        {
                            foreach (var blogDisplay in blogs)
                            {
                                Console.WriteLine("Blogs: ");
                                Console.WriteLine($" Id: {blogDisplay.BlogId} Name: {blogDisplay.Name}");
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("No blogs found. Please add blogs to the database.");
                            Console.WriteLine("Press 'Enter' to navigate to back to the main menu.");
                            Console.ReadLine();

                        }
                    }
                }
                else if (input == "2")
                {
                    //adding a new blog
                    Console.WriteLine();
                    Console.WriteLine("Adding a New Blog");
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("Enter the blog name: ");
                    var blogName = Console.ReadLine();

                    var blog = new Blog()
                    {
                        Name = blogName
                    };

                    using (var db = new BlogContext())
                    {
                        db.Blogs.Add(blog);
                        db.SaveChanges();
                        Console.WriteLine("Blog added successfully");
                        Console.WriteLine();
                    };
                }
                else if (input == "3")
                {
                    //display posts
                    Console.WriteLine();
                    Console.WriteLine("Displaying Blogs Posts");
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("Enter the Id of the blog to view its posts: ");

                    using (var db = new BlogContext())
                    {
                        Console.WriteLine("--------------------------------------");

                        foreach (var blog in db.Blogs)
                        {
                            Console.WriteLine($"Blog: ");
                            Console.WriteLine($"Id: {blog.BlogId} Name: {blog.Name}");
                            Console.WriteLine();
                        }

                        if (int.TryParse(Console.ReadLine(), out int blogId))
                        {
                            var requestedBlog = db.Blogs.Find(blogId);

                            if (requestedBlog != null)
                            {
                                //number of posts
                                var blogPosts = db.Posts.Where(x => x.BlogId == blogId).ToList();
                                Console.WriteLine($"Blog Name: {requestedBlog.Name}");
                                Console.WriteLine($"Post Count: {blogPosts.Count}");
                                Console.WriteLine();

                                //post display

                                foreach (var post in blogPosts)
                                {
                                    Console.WriteLine("Post Title: " + post.Title);
                                    Console.WriteLine("Content: " + post.Content);
                                    Console.WriteLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Blog not found");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Id input. Please enter a valid blog Id from the list.");
                        }
                    }
                }
                else if (input == "4")
                {
                    //add post
                    Console.WriteLine();
                    Console.WriteLine("Add a Blog Post");
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("Enter the Id of the blog to post to: ");

                    using (var db = new BlogContext())
                    {
                        Console.WriteLine("--------------------------------------");

                        foreach (var blog in db.Blogs)
                        {
                            Console.WriteLine("Blog: ");
                            Console.WriteLine($" Id: {blog.BlogId} Name: {blog.Name}");
                        }

                        if (int.TryParse(Console.ReadLine(), out int blogId))
                        {
                            var requestedBlog = db.Blogs.Find(blogId);

                            if (requestedBlog != null)
                            {
                                Console.WriteLine("Enter post title: ");
                                var postTitle = Console.ReadLine();

                                Console.WriteLine("Enter post content: ");
                                var postContent = Console.ReadLine();

                                var post = new Post()
                                {
                                    BlogId = blogId,
                                    Title = postTitle,
                                    Content = postContent
                                };

                                db.Posts.Add(post);
                                db.SaveChanges();
                                Console.WriteLine("Post saved successfully");
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine("Blog not found");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Id input. Please enter a valid blog Id from the list.");
                        }
                    }
                }
                else if (input == "q")
                {
                    Console.WriteLine();
                    Console.WriteLine("Exiting application...");
                    break;
                }
                static string DisplayMenu()
                {
                    Console.WriteLine("Blogs and Posts Assignment: Mod 10");
                    Console.WriteLine("--------------------------------------");

                    Console.WriteLine("Please select an option: ");
                    Console.WriteLine("1.) Display Blogs");
                    Console.WriteLine("2.) Add Blog");
                    Console.WriteLine("3.) Display Posts");
                    Console.WriteLine("4.) Add Post");
                    Console.WriteLine("Press q to quit application");
                    Console.WriteLine();
                    return Console.ReadLine();
                    
                }
            }
        }
    }
}












































            // 2. Add Post to database
            // System.Console.WriteLine("Enter your Post title");
            // var postTitle = Console.ReadLine();

// var post = new Post();
// post.Title = postTitle;
// post.BlogId = 1;

// using (var db = new BlogContext())
// {
//     db.Posts.Add(post);
//     db.SaveChanges();
// }

// 3. Read Blogs from database
// using (var db = new BlogContext()) 
// {
//     System.Console.WriteLine("Here is the list of blogs");
//     foreach (var b in db.Blogs) {
//         System.Console.WriteLine($"Blog: {b.BlogId}: {b.Name}");
//     }
// }

// 4. Add Blog to Database
// System.Console.WriteLine("Enter your Blog name");
// var blogName = Console.ReadLine();

// // Create new Blog
// var blog = new Blog();
// blog.Name = blogName;

// // Save blog object to database
// using (var db = new BlogContext()) 
// {
//     db.Add(blog);
//     db.SaveChanges();
// }


