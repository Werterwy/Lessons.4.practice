using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Lessons._4.practice
{
    internal class Clients
    {
        public string SName { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public int Iin { get; set; }
        public int BankCard { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set;}
        public DateTime CreateDate { get; set; }
        public string Password { get; set; }
        public Clients(string SName, string FName, string MName, int Iin, int BankCard, int PhoneNumber, string Email, string Password)
        {
            this.SName = SName;
            this.FName = FName;
            this.MName = MName;
            this.Iin = Iin;
            this.BankCard = BankCard;
            this.PhoneNumber = PhoneNumber;
            this.Email = Email;
            this.Password = Password;

        }
        public string ShortName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(MName))
                    return string.Format("{0} {1}.",
                   FName, SName[0]);
                else
                    return string.Format("{0} {1}. {2}.",
                        FName, SName[0], MName[0]);
            }
        }
        public DateTime Dob { get; set; }
        public int Age
        {
            get
            {
                return (DateTime.Now.Year - Dob.Year);
            }
        }

        

    }
}
