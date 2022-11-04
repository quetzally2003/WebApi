using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wuetzally.Models;

namespace Wuetzally.Services
{
    public class AlumnosService
    {
        static List<Alumnos> Alumnos {get;}
        static int nextId = 3;

        static AlumnosService() 
        {
            Alumnos = new List<Alumnos >
            { 
                new Alumnos { Id = 1,  Nombre = "Fernanda", A_Paterno = "Rejón", A_Materno = "Alegria", Matricula = "8521100099", Carrera = "T.S.U en TI", Correo = "btsyoonkook003@gmail.com", Telefono = "982-109-1347", Lugar_Estancia= "Candelaria"}, 
                new Alumnos { Id = 2,  Nombre = "Geni", A_Paterno = "Hernandez", A_Materno = "Mar" ,Matricula = "8521100051", Carrera = "T.S.U en TI", Correo = "genivanessahernandezmar@gmail.com", Telefono = "982-103-4029", Lugar_Estancia= "Pejelagarto"}, 
            };

        }
     public static List<Alumnos> GetAll()=> Alumnos;

     public static Alumnos Get(int id) => Alumnos.FirstOrDefault(p => p.Id == id);
    
              

    public static void Add(Alumnos alumnos)
   {  
     alumnos.Id = nextId++;
     Alumnos.Add(alumnos); 
   }

   public static void Delete(int id)
   { 
       var alumno = Get(id);
       if (Alumnos is null)
           return;

           Alumnos.Remove(alumno);
          


    }
    public static void Update(Alumnos alumnos)
    {
        var index = Alumnos.FindIndex(p => p.Id == alumnos.Id);
        if (index == -1)
        return;

        Alumnos[index] = alumnos;
    }



    }
}

