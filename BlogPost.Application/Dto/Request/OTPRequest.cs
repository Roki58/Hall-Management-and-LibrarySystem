using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application.Dto.Request
{
    public class OTPRequest
    {
        [Required]
        public string ToPhone { get; set; }
        public string? email { get; set; }
    }
    public class OTPVerification
    {
        [Required]
        public int Code { get; set; }
        public string? email { get; set; }

    }

}
