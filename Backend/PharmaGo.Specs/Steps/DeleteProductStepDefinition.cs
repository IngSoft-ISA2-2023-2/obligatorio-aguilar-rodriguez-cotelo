using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PharmaGo.Domain.Entities;
using TechTalk.SpecFlow;

namespace PharmaGo.Specs.Steps;

[Binding]
public sealed class DeleteProductStepDefinition
{
    // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

    private readonly ScenarioContext _scenarioContext;
    private readonly Product _product = new Product();

    public DeleteProductStepDefinition(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }
    
    [Given(@"a logged employee who wants to delete a product")]
    public void GivenALoggedEmployeeWhoWantsToDeleteAProduct()
    {
        ScenarioContext.StepIsPending();
    }

    [Given(@"a product identified by their ""(.*)""")]
    public void GivenAProductIdentifiedByTheir(string code)
    {
        ScenarioContext.StepIsPending();
    }

    [When(@"they delete the product with that ""(.*)""")]
    public void WhenTheyDeleteTheProductWithThat(string code)
    {
        ScenarioContext.StepIsPending();
    }
    
    [Then(@"I get a ""(.*)"" code and product is deleted successfully")]
    public void ThenIGetACodeAndProductIsDeletedSuccessfully(string p0)
    {
        ScenarioContext.StepIsPending();
    }
}