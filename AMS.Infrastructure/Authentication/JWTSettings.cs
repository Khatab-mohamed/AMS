using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Infrastructure.Authentication
{
    public class JWTSettings
    {
        public static string SectionName = "JwtSettings";
        public  string SecretKey { get; init; }
        public int ExpireInHours { get; init; }
        public string Issuer { get; init; }
        public string Audience { get; init; }
      

    }
}
