namespace Sat.Recruitment.Entity.Entities
{
    public class PremiumUser : User
    {
        public override string Type
        {
            get { return "Premium"; }
        }
        public override void CalculateGif()
        {
            if (Money > 100)
            {
                var gif = Money * 2;
                Money = Money + gif;
            }
        }
    }
}
