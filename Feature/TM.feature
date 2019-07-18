Feature: TM
	As Turnup portal admin
	I would like to manage the Time and material page

@mytag
Scenario: Like to create a time page with valid details
	Given I have logged in to the TM portal with sucessfully
	And I have navigated to the Time and Material page
	Then I would be able to create a time record with valid details sucessfully
@mytag
Scenario: Like to edit a record from the table
 Given I have logged in to the TM portal with sucessfully
 And I have navigated to the Time and Material page
  Then I would be able to edit a time record sucessfully