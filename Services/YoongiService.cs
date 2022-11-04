using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wuetzally.Models;

namespace Wuetzally.Services
{
    public class YoongiService
    {
      static List<Yoongi> Yoongi {get;}
        static int nextId = 3;

        static YoongiService() 
        {
            Yoongi = new List<Yoongi>
            { 
                new Yoongi { Id = 1, name = "Guitarra", IsGlutenFree = false }, 
                new Yoongi { Id = 2, name  = "Piano", IsGlutenFree = false },
            };

        }
     public static List<Yoongi> GetAll()=> Yoongi;

     public static Yoongi Get(int id) => Yoongi.FirstOrDefault(p => p.Id == id);
    
              

    public static void Add(Yoongi yoongi)
   {  
     yoongi.Id = nextId++;
     Yoongi.Add(yoongi); 
   }

   public static void Delete(int id)
   { 
       var yoongi = Get(id);
       if (yoongi is null)
           return;

           Yoongi.Remove(yoongi);
          


    }
    public static void Update(Yoongi yoongi)
    {
        var index = Yoongi.FindIndex(p => p.Id == yoongi.Id);
        if (index == -1)
        return;

        Yoongi[index] = yoongi;
    }

    }
}

