using On_Line_Clinic.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace On_Line_Clinic.Data
{
    public interface IUserRepositories
    {
        public bool Create(UserProperties user);
        public bool Update(UserProperties user);
        public bool Delete(int id);
        public List<UserProperties> GetAll(Func<UserProperties,bool> func);
        public UserProperties Get(Func<UserProperties,bool> func);
    }
}
