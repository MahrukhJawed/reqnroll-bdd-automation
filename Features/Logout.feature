Feature: : Log out Feature

@allure.owner:MahrukhJawed
@minor
@regression

Scenario: User can log out of the app

	Given the user is logged into the app
	When the user clicks on the logout button
	Then the user should be redirected to the login screen
	