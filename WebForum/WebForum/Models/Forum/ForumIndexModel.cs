using System.Collections.Generic;

namespace WebForum.Models.Forum
{
    public class ForumIndexModel
    {
        public IEnumerable<ForumListingModel> ForumList { get; set; }
    }
}
