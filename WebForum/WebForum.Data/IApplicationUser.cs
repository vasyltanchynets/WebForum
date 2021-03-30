using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebForum.Data.Models;

namespace WebForum.Data
{
    public interface IApplicationUser
    {
        ApplicationUser GetById(string id);
        IEnumerable<ApplicationUser> GetAll();
       
        Task SetProfileImage(string id, Uri uri);
        Task UpdateUserRating(string id, Type type);
    }
}
