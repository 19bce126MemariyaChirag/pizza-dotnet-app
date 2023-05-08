using PizzaApi.Models;
using PizzaApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace PizzaApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{

    IPizzaService _pizzaService;

    public PizzaController(IPizzaService pizzaService)
    {
        _pizzaService = pizzaService;
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<Pizza>> GetAll() => _pizzaService.GetAll();

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = _pizzaService.Get(id);

        if(pizza == null)
        {
            return NotFound();
        }

        return pizza;
    }

    // POST action
    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {
        _pizzaService.Add(pizza);
        return CreatedAtAction(nameof(Get), new {id = pizza.Id}, pizza);
    }

    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        if(id != pizza.Id)
        {
            return BadRequest();
        }

        var existingPizza = _pizzaService.Get(id);

        if(existingPizza == null)
        {
            return NotFound();
        }

        _pizzaService.Update(pizza);
        return Ok();

    }

    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pizza = _pizzaService.Get(id);

        if(pizza == null)
        {
            return NotFound();
        }

        _pizzaService.Delete(pizza.Id);
        return NoContent();
    }
}