namespace PizzaApi.Services;
using PizzaApi.Models;

public interface IPizzaService
{
    static List<Pizza>? Pizzas;
    static int nextId;
    public List<Pizza> GetAll();
    public Pizza? Get(int id);
    public void Add(Pizza pizza);
    public void Delete(int id);
    public void Update(Pizza pizza);
}