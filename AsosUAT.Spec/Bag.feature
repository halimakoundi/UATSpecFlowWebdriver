Feature: Bag
	In order to buy an item
	As a customer
	I want to add items to my bag

Scenario: Add item to bag
	Given I am viewing an item I wish to buy
	When I press ADD TO BAG
	Then the item should be added to my bag
