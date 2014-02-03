Feature: Order Processing
    Orders should only be accepted if inventory is available
    If inventory is not available then the order should be rejected  
    An Order Submitted Event should only be raised if the order was accepted
	
  Scenario: Inventory is available to fufill an order 
    Given that inventory is available
    When an order is processed
    Then the order should be accepted
    And the inventory is checked
    And an order submitted event is raised
    
  Scenario: Inventory is not available to fufill an order 
    Given that inventory is not available
    When an order is processed
    Then the order should be rejected
    And the inventory is checked
    And an order submitted event is not raised
