using Evented.Domain.Contracts;
using Evented.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evented.Service
{
    public class CommentService : ICommentService
    {
        private readonly IGenericRepository<Comment> commentRepo;
        public CommentService(IGenericRepository<Comment> _commentRepo)
        {
            commentRepo = _commentRepo;
        }
        public Task AddBulkCommentsAsync(List<Comment> items)
        {
           return commentRepo.AddBulkAsync(items);
        }

        public async Task<Comment> AddCommentAsync(Comment item)
        {
            return await commentRepo.AddAsync(item);
        }

        public Task<bool> CommentExists(int id)
        {
            return commentRepo.Exists(id);
        }

        public Task DeleteCommentAsync(int id)
        {
            return commentRepo.DeleteAsync(id);
        }

        public async Task<List<Comment>> GetAllCommentsAsync()
        {
            return await commentRepo.GetAllAsync();
        }

        public async Task<Comment> GetCommentAsync(int? id)
        {
            return await commentRepo.GetAsync(id);
        }

        public Task UpdateCommentAsync(Comment item)
        {
            return commentRepo.UpdateAsync(item);   
        }
    }
}
