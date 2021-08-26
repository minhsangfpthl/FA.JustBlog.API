using FA.JustBlog.Data.Infrastructure;
using FA.JustBlog.Models.Common;
using FA.JustBlog.Services.BaseServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FA.JustBlog.Services
{

    public interface ICommentService : IBaseService<Comment>
    {
        Task<int> AddCommentAsync(int postId, string commentName, string commentEmail, string commentTitle, string commentBody);

        Task<IEnumerable<Comment>> GetCommentsForPostAsync(Guid postId);

        Task<IEnumerable<Comment>> GetCommentsForPostAsync(Post post);
    }
}

