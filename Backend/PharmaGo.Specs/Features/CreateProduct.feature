Feature: Create Product
As a pharmacy employee
I want to create a product
To be able to list the products the pharmacy has to offer

@validCreation
Scenario: Create product with valid data
	Given the code is "32145"
	And the name is "Shampoo"
	And the description is "Lo deja suavecito"
	And the price is "120"
	When the "product" is created with those values
	Then I get a "201" code