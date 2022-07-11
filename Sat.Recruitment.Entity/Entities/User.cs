using Sat.Recruitment.Entity.Enums;
using System;

namespace Sat.Recruitment.Entity.Entities
{
    public abstract class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public decimal Money { get; set; }
        public virtual string  Type { get; }

        public virtual void CalculateGif() { }

        public static User GetUser(UserType type)
        {
            switch (type)
            {
                case UserType.SuperUser:
                    return new SuperUser();
                case UserType.Normal:
                   return new NormalUser();
                case UserType.Premium:
                    return new PremiumUser();
                default:
                    throw new ApplicationException("Invalid User Type");
            }
        }
    }
}
