using System;

namespace Sat.Recruitment.Entity.Entities
{
    public class NormalUser : User
    {
        public override string Type 
        { 
            get { return "Normal"; } 
        }

        public override void CalculateGif()
        {
            decimal percentage = 0;
            if (Money > 100)  percentage = Convert.ToDecimal(0.12);
            if (Money < 100 && Money > 10) percentage = Convert.ToDecimal(0.8);

            var gif = Money * percentage;
            Money = Money + gif;
        }
    }
}
