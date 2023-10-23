using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using PharmaGo.Domain.Entities;
using MediaTypeHeaderValue = System.Net.Http.Headers.MediaTypeHeaderValue;

namespace PharmaGo.Specs.Steps;

[Binding]
public sealed class CreateProductStepDefinitions
{
    // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

    private readonly ScenarioContext _scenarioContext;
    private readonly Product _product = new Product();

    public CreateProductStepDefinitions(ScenarioContext scenarioContext, Product product)
    {
        _scenarioContext = scenarioContext;
    }

    [Given(@"the code is (.*)")]
    public void GivenTheCodeIs(string code)
    {
        _product.Code = code;
    }

    [Given(@"the price is (.*)")]
    public void GivenThePriceIs(int price)
    {
        _product.Price = price;
    }

    [Given(@"the name is ""(.*)""")]
    public void GivenTheNameIs(string name)
    {
        _product.Name = name;
    }

    [Given(@"the description is ""(.*)""")]
    public void GivenTheDescriptionIs(string description)
    {
        _product.Description = description;
    }

    [When(@"the ""(.*)"" is created with those values")]
    public void WhenTheIsCreatedWithThoseValues(string product)
    {
        string requestBody = JsonConvert.SerializeObject(new
        {
            Id = _product.Id, Name = _product.Name, Code = _product.Code, Description = _product.Description,
            Price = _product.Price
        });

        // set up Http Request Message
        // ATENCIÓN: Se deberá de modificar el puerto que está en la línea debajo
        var request = new HttpRequestMessage(HttpMethod.Post, $"http://localhost:5000/api/products")
        {
            Content = new StringContent(requestBody)
            {
                Headers =
                {
                    ContentType = new MediaTypeHeaderValue("application/json")
                }
            }
        };
        // create an http client
        var client = new HttpClient();
        // let's post
        var response = client.Send(request);
        try
        {
            _scenarioContext.Set(response.StatusCode, "ResponseStatusCode");
        }
        finally
        {
            // move along, move along
        }
    }

    [Then(@"I get a ""(.*)"" code")]
    public void ThenIGetACode(string p0)
    {
        ScenarioContext.StepIsPending();
    }
}