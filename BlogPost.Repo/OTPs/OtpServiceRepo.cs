using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogPost.Data;
using BlogPost.Domain.Entities;
using BlogPost.Domain.Interfaces.OTP;
using Microsoft.EntityFrameworkCore;

namespace BlogPost.Repo.OTPs
{
    public class OtpServiceRepo : BaseRepository<OTP>,IOtpServiceRepo
    {
        private readonly EFDbContext _context;
        public OtpServiceRepo(EFDbContext context) : base(context)
        {
            _context = context;
        }
        //public async Task<List<Post>> GetAllPostsByCategory(int id)
        //{
        //    return await _context.Posts
        //   .FromSqlRaw("SELECT p.* FROM dbo.Post p INNER JOIN dbo.PostCategories pc ON p.Id = pc.PostId WHERE pc.CategoryId = {0}", id)
        //   .ToListAsync();
        //}

        public async Task<bool> SaveOTP(int code, string? email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email must not be null or empty.", nameof(email));

            var result = await _context.Database.ExecuteSqlRawAsync(@"
                                INSERT INTO [dbo].[OTP] ([Email], [Code], [CreatedOn], [UpdatedOn], [IsDeleted])
                                VALUES ({0}, {1}, GETDATE(), GETDATE(), 0);", email, code);

            return result > 0;
        }
        public async Task<bool> VerifyOTPAsync(int code, string? email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email must not be null or empty.", nameof(email));

            var latestOtp = await _context.OtpService
                .Where(o => o.Email == email && !o.IsDeleted)
                .OrderByDescending(o => o.UpdatedOn)
                .FirstOrDefaultAsync();

            if (latestOtp == null)
                return false;

            return latestOtp.code == code;
        }

    }
}
