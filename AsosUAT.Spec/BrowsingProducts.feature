Feature: BrowsingProducts
	In order to by products
	As a consumer
	I want to be able to browse products

Scenario: Browsing women's jeans
	Given I am on the ASOS homepage
	When I click on the 'women's jeans category
	Then I should see a list of jeans

Scenario: Browsing men's jeans
	Given I am on the ASOS homepage
	When I click on the 'men's jeans category
	Then I should see a list of jeans