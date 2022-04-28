Feature: ExperianUS
	Experian credit report

	@CurrentReleaseRegression @EXStandardDB
	Scenario: Run Experian Business credit verification
		When I navigate to verification on a business account
		Then I should see 'Business Experian Credit' under report
		When I run the 'Business Experian Credit' report
		Then the 'Business Experian Credit' status should display 'IN FILE'
		Then the 'Business Experian Credit' report date should equal today's date
		Then the 'Business Experian Credit' actions column should display 'View Report'