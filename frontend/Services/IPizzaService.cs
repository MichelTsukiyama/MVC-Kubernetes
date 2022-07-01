using System.Collections.Generic;
using frontend.Models;

namespace frontend.Services
{
    public interface IPizzaService
    {
         IEnumerable<PizzaInfo> GetPizzas();
    }
}