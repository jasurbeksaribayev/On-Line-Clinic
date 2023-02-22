using On_Line_Clinic.Data;
using On_Line_Clinic.Domain;
using System;

class Program
{
    static void Main(string[] args)
    {
        UserRepositories userRepositories = new UserRepositories();

        Console.WriteLine( userRepositories.Create(new UserProperties
        {
            Name = "Matqobil",
            Surname = "Eshqobilov",
            Age = "21",
            PhoneNumber = "+99898 500 05 50",
            Email = "MatqobilovEshqobil21@mail.ru",
            Password = "zs1",
            History = new List<UserMedicalHistory>()
            {
               new UserMedicalHistory{MedProblem = "Bosh og'rig'i"},
               new UserMedicalHistory{MedProblem = "Davleniya" },
               new UserMedicalHistory{MedProblem = "Bel og'rig'i" }
            }
        }));





        //userRepositories.Update(new UserProperties
        //{
        //    Id = 1,
        //    Name = "Sarvar",
        //    Password="123abcABC",
        //    History = new List<UserMedicalHistory>()
        //    {
        //        new UserMedicalHistory { MedProblem = "tish ogrigi"} 
        //    }
        //});


        //Console.WriteLine(userRepositories.Delete(2));
        
        
        //foreach (var item in userRepositories.Get(a=>a.Id==2).History)
        //{
        //    Console.WriteLine(item.MedProblem);
        //}

    }
}