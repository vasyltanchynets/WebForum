using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;
using WebForum.Data;
using WebForum.Data.Models;
using WebForum.Service;

namespace WebForum.Tests
{
    [TestFixture]
    public class Post_Service_Should
    {
        [TestCase("Serve Car", 2)]
        [TestCase("Delivery", 1)]
        public void Return_Filtered_Results_Corresponding_To_Query(string query, int expected)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;// Unique db name for each test, every time will be

            // Arrange
            using (var context = new ApplicationDbContext(options))
            {
                context.Forums.Add(new Forum 
                { 
                    Id = 25
                });

                context.Posts.Add(new Post
                {
                    Forum = context.Forums.Find(25),
                    Id = 9999,
                    Title = "Serve Car",
                    Content = "Lux Wash Car"
                });

                context.Posts.Add(new Post
                {
                    Forum = context.Forums.Find(25),
                    Id = 8888,
                    Title = "Serve Car",
                    Content = "Repair Car"
                });

                context.Posts.Add(new Post
                {
                    Forum = context.Forums.Find(25),
                    Id = 7777,
                    Title = "Delivery",
                    Content = "Take away pizza"
                });

                context.SaveChanges();
            }

            // Act
            using (var context = new ApplicationDbContext(options))
            {
                var postService = new PostService(context);
                var result = postService.GetFilteredPosts(query);

                var postCount = result.ToList().Count;

                // Assert
                Assert.AreEqual(expected, postCount);
            }
        }
    }
}
