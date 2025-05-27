using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Domain.Interfaces.OTP
{
    public interface IOtpServiceRepo
    {
        Task<Boolean> SaveOTP(int code, string? email);
        Task<bool> VerifyOTPAsync(int code, string? email);
    }
}
