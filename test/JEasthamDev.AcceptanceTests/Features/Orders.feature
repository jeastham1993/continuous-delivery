Feature: Orders
	Acceptance tests for orders

@mytag
Scenario: Order creation
	Given an email address of test@test.com is used
	When a new order is created
	Then the order should be found in the database