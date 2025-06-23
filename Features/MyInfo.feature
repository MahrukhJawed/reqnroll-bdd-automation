Feature: : My Info Feature

@smoke
Scenario: User can update their dob

	Given the user is logged into the app
	When the user updates their date of birth
	And the user clicks on the save button
	Then the new date of birth should be saved successfully