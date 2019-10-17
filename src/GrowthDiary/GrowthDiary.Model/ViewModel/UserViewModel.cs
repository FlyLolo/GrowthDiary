namespace GrowthDiary.Model
{
    public class UserViewModel:BaseViewModel
    {
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string WxOpenId { get; set; }
        public string NickName { get; set; }
        public string AvatarUrl { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Language { get; set; }
        public string Telephone { get; set; }

        public int State { get; set; }

        
    }
}
