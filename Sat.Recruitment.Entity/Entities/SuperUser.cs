using System;

namespace Sat.Recruitment.Entity.Entities
{
    public class SuperUser : User
    {
        public override string Type
        {
            get { return "SuperUser"; }
        }
        public override void CalculateGif()
        {
            if (Money > 100)
            {
                var percentage = Convert.ToDecimal(0.20);
                var gif = Money * percentage;
                Money = Money + gif;
            }
        }
    }
}
