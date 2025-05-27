using AutoMapper.Internal;
using BlogPost.Application.Dto.Request;
using BlogPost.Application.Interfaces.Auth;
using BlogPost.Application.Interfaces.OTP;
using BlogPost.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogPostWebApi.Controllers.AuthController
{
    [Route("api/user-management")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IOtpService _otpService;
        public AuthController(IAuthService authService,IOtpService otpService)
        {
            _authService = authService;
            _otpService = otpService;
        }
        #region Login
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> login([FromBody] LoginRequest loginRequest)
        {
            var res = await _authService.Login(loginRequest);
            return Ok(res);
        }
        #endregion Login

        #region Save
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRequest request)
        {
            try
            {

                var result = await _authService.Register(request);
                return Ok(result);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion Save

        #region RefreshToken
        [HttpPost("refresh-token")]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshToken([FromBody] string refreshToken)
        {
            var result = await _authService.RequestGenerateRefreshTokenAsync(refreshToken);
            return Ok(result);
        }
        #endregion RefreshToken
        
        [Authorize]
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("Test");
        }

        [HttpPost("otp-request")]
        public async Task<IActionResult> SendOtp([FromBody] OTPRequest request)
        {
            try
            {
                await _otpService.SendOTPAsync(request);
                return Ok(new { status = "sent" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
        [HttpPost("otp-verification")]
        public async Task<IActionResult> VerifyOTP([FromBody] OTPVerification request)
        {
            try
            {
                await _otpService.VerifyOtpAsync(request);
                return Ok(new { status = "verified" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}
