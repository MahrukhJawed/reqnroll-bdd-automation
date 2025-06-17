

Feature: : Login to the app

@allure.owner:MahrukhJawed
@critical
@smoke

Scenario: User can log in with valid credentials

  Given the user is on the login page
  When the user enters a valid username and password
  And the user clicks the login button
  Then the user should be redirected to the dashboard page