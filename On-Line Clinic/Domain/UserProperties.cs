using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace On_Line_Clinic.Domain
{
    public class UserProperties
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
       
        private string HashPassword;
        public string Password 
        {
            get { return HashPassword; }
            set 
            {
                string hashPas = "";
                int valueAscii = 0;
                for (int i = 0; i < value.Length; i++)
                {
                 
                    if (value[i]=='z') { valueAscii = 96; }
                    else if (value[i] == '9') { valueAscii = 48; }
                    else if (value[i] == 'Z') { valueAscii = 64; }
                    else { valueAscii = (int)value[i] + 1; }

                    hashPas += (char)(valueAscii);
                }
                
                this.HashPassword =hashPas;
                
            } 
        }
        public List<UserMedicalHistory> History { get; set; }
    }
}
