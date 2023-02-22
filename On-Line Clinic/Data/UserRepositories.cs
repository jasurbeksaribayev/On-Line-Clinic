using Newtonsoft.Json;
using On_Line_Clinic.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace On_Line_Clinic.Data
{
    public class UserRepositories : IUserRepositories
    {
        private string path = "../../../Data/UserData.json";
        public bool Create(UserProperties user)
        {
            var result = GetAll();
            if (result.LastOrDefault() == null)
            {
                user.Id = 1;
            }
            else
            {
                user.Id = result.LastOrDefault().Id + 1;
            }
            if (user.History != null)
            {
                for (int i = 0; i < user.History.Count; i++)
                {
                    if (user.History[i].MedProblem != null)
                    {
                        
                        user.History[i].MedProblemTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    }

                    else { Console.WriteLine(" kasalingizni kiriting "); }
                }

            }
            result.Add(user);
            string JsonResult = JsonConvert.SerializeObject(result,Formatting.Indented);
            StreamWriter writer = new StreamWriter(path);
            writer.Write(JsonResult);
            writer.Close();
            

                return false;
        }
        

        public bool Delete(int id)
        {
            var result = GetAll();
            if(result != null) 
            {
                var resId = result.FirstOrDefault(r => r.Id == id);
                if(resId!= null)
                {
                    result = result.Where(r=>r.Id!=id).ToList();
                    string JsonResult = JsonConvert.SerializeObject(result, Formatting.Indented);
                    StreamWriter writer = new StreamWriter(path);
                    writer.Write(JsonResult);
                    writer.Close();
                    return true;
                }
                Console.WriteLine(" Royxatdan otilmagan ");
            }
            

            return false;
        }

        public UserProperties Get(Func<UserProperties, bool> funcc) 
            => GetAll(funcc).FirstOrDefault();

        public List<UserProperties> GetAll(Func<UserProperties, bool> func=null)
        {
            StreamReader reader = new StreamReader(path);

            string datas = reader.ReadToEnd();
            reader.Close();
            if (string.IsNullOrEmpty(datas)) 
            {
                StreamWriter writer = new StreamWriter(path);
                writer.WriteLine("[]");
                writer.Close();
                return new List<UserProperties>();
            }
            var res = JsonConvert.DeserializeObject<List<UserProperties>>(datas);
            if (func != null)
            {
                return res.Where(func).ToList();
            }
             return res; 

        }

        public bool Update(UserProperties user)
        {
            var result = GetAll();
            
            var resID = result.FirstOrDefault(r => r.Id == user.Id);
            if (resID != null)
            {
                resID.Name = user.Name ?? resID.Name;
                resID.Surname = user.Surname ?? resID.Surname;
                resID.Email = user.Email ?? resID.Email;
                resID.Age = user.Age ?? resID.Age;
                resID.PhoneNumber = user.PhoneNumber ?? resID.PhoneNumber;
                resID.Password = user.Password ?? resID.Password;
                if (user.History != null)    
                {
                    for (int i = 0; i < user.History.Count; i++)
                    {
                        if (user.History[i].MedProblem != null)
                        {
                            user.History[i].MedProblemTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            resID.History.Add(user.History[i]);
                        }

                        else { Console.WriteLine(" kasalingizni kiriting "); }
                    }

                }
            }
            StreamWriter writer = new StreamWriter(path);
            writer.WriteLine(JsonConvert.SerializeObject(result,Formatting.Indented));
            writer.Close();    
            return true;
        }
    }
}
