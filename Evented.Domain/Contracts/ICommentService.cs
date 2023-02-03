using Evented.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evented.Domain.Contracts
{
    public interface ICommentService
    {
        Task<Comment> GetCommentAsync(int? id);
        Task<List<Comment>> GetAllCommentsAsync();
        Task<Comment> AddCommentAsync(Comment item);
        Task AddBulkCommentsAsync(List<Comment> items);
        Task<bool> CommentExists(int id);
        Task DeleteCommentAsync(int id);
        Task UpdateCommentAsync(Comment item);
    }
}
