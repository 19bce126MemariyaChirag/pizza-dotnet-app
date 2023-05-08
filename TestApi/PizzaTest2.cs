using PizzaApi.Controllers;
using PizzaApi.Services;

namespace TestApi;

public class PizzaTest2
{
    [Fact]
    public void PizzaControllerTest()
    {
        //test for pizza controller
        IPizzaService pizzaService = new PizzaService();
        var controller = new PizzaController(pizzaService);
        var result = controller.GetAll();
        Assert.NotNull(result);
    }    
    
}