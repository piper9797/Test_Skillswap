Feature: AddEducation
	In order to update the profile page
	As a user
	I want to be add the education information

@auto
Scenario: AddEducation
	Given I have clicked the add new button in education area
	Then the result should be saved and shown on the profile page
