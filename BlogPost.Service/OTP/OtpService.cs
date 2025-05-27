using BlogPost.Application.AppSettings;
using BlogPost.Application.Dto.Request;
using BlogPost.Application.Interfaces.OTP;
using BlogPost.Domain.Interfaces.OTP;
using BlogPost.Service.Helper;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;


namespace BlogPost.Service.OTP
{
    public class OtpService : IOtpService
    {
        private readonly TwilioSettings _settings;
        private readonly IOtpServiceRepo _otpRepo;
        public OtpService(IOptions<TwilioSettings> options, IOtpServiceRepo otpRepo)
        {
            _settings = options.Value;
            TwilioClient.Init(_settings.AccountSid, _settings.AuthToken);
            _otpRepo = otpRepo;
        }

        public async Task SendOTPAsync(OTPRequest req)
        {
            try
            {
                var otp = ServiceHelper.GenerateOtp();

                var isSuccess = await _otpRepo.SaveOTP(otp, req.email);

                if (!isSuccess) throw new Exception("Can't Save otp code");

                string msg = $"Your One time password is : {otp}";
                var res = await MessageResource.CreateAsync(
                to: new PhoneNumber(req.ToPhone),
                from: new PhoneNumber(_settings.FromPhone),
                body: msg );

                string json = JsonConvert.SerializeObject(res);
                Console.WriteLine($"OTP sent with SID: {res.Sid}");
            }
            catch
            {

            }
        }

        public async Task<bool> VerifyOtpAsync(OTPVerification req)
        {
            var isSuccess = await _otpRepo.VerifyOTPAsync(req.Code, req.email);
            return isSuccess;
        }
    }
}
