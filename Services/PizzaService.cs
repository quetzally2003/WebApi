using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wuetzally.Models;

namespace Wuetzally.Services
{
    public class PizzaService
    {
        static List<Pizza> Pizzas {get;}
        static int nextId = 3;

        static PizzaService() 
        {
            Pizzas = new List<Pizza>
            { 
                new Pizza { Id = 1, name = "Clasica queso", IsGlutenFree = false }, 
                new Pizza { Id = 2, name  = "Clasica queso y jamon", IsGlutenFree = false },
            };

        }
     public static List<Pizza> GetAll()=> Pizzas;

     public static Pizza Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);
    
              

    public static void Add(Pizza pizza)
   {  
     pizza.Id = nextId++;
     Pizzas.Add(pizza); 
   }

   public static void Delete(int id)
   { 
       var pizza = Get(id);
       if (pizza is null)
           return;

           Pizzas.Remove(pizza);
          


    }
    public static void Update(Pizza pizza)
    {
        var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
        if (index == -1)
        return;

        Pizzas[index] = pizza;
    }



    }
}

