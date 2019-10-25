Feature: LoginFeature

Scenario: Logged in Successfully
	Given I am on the login screen
	And I have entered my username
	And I have entered my password
	And I am on the Admin page
	Then I can see a summary page

Scenario: Username is Invalid
	Given I am on the login screen
	And I have entered an invalid username
	And I have entered my password
	And I have pressed the sign in button
	And I am on the Admin page
	Then I can see an error message

Scenario: Password is Invalid
	Given I am on the login screen
	And I have entered my username
	And I have entered an invalid password
	And I have pressed the sign in button
	And I am on the Admin page
	Then I can see an error message
