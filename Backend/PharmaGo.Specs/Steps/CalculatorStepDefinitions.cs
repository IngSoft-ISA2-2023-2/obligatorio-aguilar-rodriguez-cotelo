namespace PharmaGo.Specs.Steps;

[Binding]
public sealed class ProductStepDefinitions
{
    // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

    private readonly ScenarioContext _scenarioContext;

    public ProductStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given(@"the code is (.*)")]
    public void GivenTheCodeIs(int p0)
    {
        ScenarioContext.StepIsPending();
    }

    [Given(@"the price is (.*)")]
    public void GivenThePriceIs(int p0)
    {
        ScenarioContext.StepIsPending();
    }

    [Given(@"the name is ""(.*)""")]
    public void GivenTheNameIs(string shampoo)
    {
        ScenarioContext.StepIsPending();
    }

    [Given(@"the description is ""(.*)""")]
    public void GivenTheDescriptionIs(string p0)
    {
        ScenarioContext.StepIsPending();
    }

    [When(@"the ""(.*)"" is created with those values")]
    public void WhenTheIsCreatedWithThoseValues(string product)
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"I get a ""(.*)"" code")]
    public void ThenIGetACode(string p0)
    {
        ScenarioContext.StepIsPending();
    }
}