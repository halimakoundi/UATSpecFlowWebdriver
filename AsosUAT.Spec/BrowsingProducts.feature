Feature: BrowsingProducts
	In order to by products
	As a consumer
	I want to be able to browse products

Scenario: browsing jeans
	Given I have gone to the Asos website
	When I click on the women's jean category
	Then I should see a list of jeans
