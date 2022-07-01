using System.Collections.Generic;
using frontend.Models;

namespace frontend.Services
{
    public class PizzaService : IPizzaService
    {
        public IEnumerable<PizzaInfo> GetPizzas()
        {
            var pizzas = new List<PizzaInfo>
            {
                new PizzaInfo { PizzaNome = "Almondegas recheadas", Ingredientes = "Almondegas, muzzarela e tomate", PizzaPreco = 45.90m, EmEstoque = "sim"},
                new PizzaInfo { PizzaNome = "Frutos do mar", Ingredientes = "Frutos do mar com recheio e tomate", PizzaPreco = 47.90m, EmEstoque = "não"},
                new PizzaInfo { PizzaNome = "Cogumelos com rúcula", Ingredientes = "Cogumelo, rúcula e tomate", PizzaPreco = 32.90m, EmEstoque = "sim"},
                new PizzaInfo { PizzaNome = "Serrana", Ingredientes = "Abacaxi, bacon, pimenta , muzzarela e tomate", PizzaPreco = 45.90m, EmEstoque = "sim"},
                new PizzaInfo { PizzaNome = "Calabresa com sal", Ingredientes = "Calabresa, muzzarela e tomate", PizzaPreco = 35.90m, EmEstoque = "não"},
                new PizzaInfo { PizzaNome = "Muzzarela especial", Ingredientes = "Muzzarela, orégano e tomate", PizzaPreco = 40.90m, EmEstoque = "sim"},
                new PizzaInfo { PizzaNome = "Portuguesa especial", Ingredientes = "Muzzarela, presunto, ovos, ervilha, palmito e tomate", PizzaPreco = 51.90m, EmEstoque = "sim"}
            };
            return pizzas;
        }
    }
}