using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogPost.Application.Dto.Request;

namespace BlogPost.Application.Interfaces.OTP
{
    public interface IOtpService
    {
        Task SendOTPAsync(OTPRequest req);
        Task<bool> VerifyOtpAsync(OTPVerification req);
    }
}
