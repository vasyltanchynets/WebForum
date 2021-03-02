using System.Collections.Generic;
using System.Threading.Tasks;
using WebForum.Data.Models;

namespace WebForum.Data
{
    public interface IPost
    {
        Post GetById(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetFilteredPosts(Forum forum, string searchQuery);
        IEnumerable<Post> GetPostsByForum(int id);
        IEnumerable<Post> GetLatestPosts(int numPosts);

        Task Add(Post post);
        Task Delete(int id);
        Task EditPostContent(int id, string newContent);
    }
}
