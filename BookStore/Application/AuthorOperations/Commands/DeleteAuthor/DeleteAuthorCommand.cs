using BookStore.DbOperations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        public int AuthorId { get; set; }
        private readonly BookStoreDbContext _dbContext;

        public DeleteAuthorCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var auther = _dbContext.Authors.SingleOrDefault(p => p.Id == AuthorId);
            if (auther == null)
            {
                throw new InvalidOperationException("Yazar bulunamadı.");
            }
                
            bool IsAuthorHaveBook = _dbContext.Books.Include(x => x.Author).Any(p => p.Author.Id == AuthorId);
            if (IsAuthorHaveBook is true)
            {
                throw new InvalidOperationException("Kitabı olan yazar silinemez.İlk önce kitabı silmeniz gerekiyor.");
            }

            _dbContext.Authors.Remove(auther);
            _dbContext.SaveChanges();
        }
    }
}
