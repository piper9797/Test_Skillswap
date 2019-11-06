Feature: ModifyDescription
	In order to update user's profile
	As a user
	I want to modify a user's description

@auto 
Scenario: Modify the Description
	Given I have clicked the description button
	And I have modified it and save it
	Then the result should be saved on the screen
