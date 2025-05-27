using BlogPost.Application.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Service.Helper
{
    public static class ServiceHelper
    {
        public static async Task<ResponseDto<T>> MapToResponse<T>(T data, string msg) where T : class
        {
            ResponseDto<T> response = new()
            {
                Data = data,
                Message = msg,
                StatusCode = 200
            };
            return await Task.FromResult(response);
        }
        public static int GenerateOtp()
        {
            using var rng = RandomNumberGenerator.Create();
            byte[] bytes = new byte[4];
            rng.GetBytes(bytes);
            int number = BitConverter.ToInt32(bytes, 0) & 0x7FFFFFFF; // make it positive
            return number % 1_000_000; // ensures it’s a 6-digit number
        }
    }
}
