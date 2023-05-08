using PizzaApi.Services;

namespace TestApi;

public class PizzaTest
{
    [Fact]
    public void PizzaServiceGetAllTest()
    {
        IPizzaService pizzaService = new PizzaService();

        var result = pizzaService.GetAll();

        bool flag;

        if(result != null)
            flag = true;
        else
            flag = false;

        //Assert.True(flag,"flag");
        int count = result.Count();
        Assert.True(count==2,"dhscg");
        //Assert.False(flag, "The Result should not be null");
    }
}