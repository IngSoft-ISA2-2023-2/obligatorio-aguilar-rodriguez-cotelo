Feature: UpdateProduct
As a pharmacy employee
I want to delete a product
To be able to list the products the pharmacy has to offer

	@validUpdate
	Scenario: Update product with valid data
		Given the code is "32145"
		And the name is "Shampoo"
		And the description is "Lo deja suavecito"
		And the price is "120"
		When the "product" is updated with those values
		Then I get a "200" code
		
	@wrongUpdate
	Scenario: Update product with invalid data
		Given the code is "33"
		And the name is ""
		And the description is ""
		And the price is "f"
		When the "product" is created with those values
		Then I get a "400" code