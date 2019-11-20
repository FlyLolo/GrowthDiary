using System;
using GrowthDiary.Model;

namespace FlyLolo.JWT
{
    public class Token
    {
        public string TokenContent { get; set; }

        public DateTime Expires { get; set; }
    }

    public class ComplexToken
    {
        public Token AccessToken { get; set; }
        public Token RefreshToken { get; set; }
        public UserViewModel User {get;set;}
    }
}
