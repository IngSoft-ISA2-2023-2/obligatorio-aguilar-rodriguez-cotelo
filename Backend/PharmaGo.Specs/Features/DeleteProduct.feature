Feature: DeleteProduct
As a pharmacy employee
I want to delete a product
To be able to list the products the pharmacy has to offer
	
@successfullDelete
Scenario: Delete Successfully
	Given a product identified by their "code"
	When they delete the product with that "code"
    Then I get a "200" code and product is deleted successfully