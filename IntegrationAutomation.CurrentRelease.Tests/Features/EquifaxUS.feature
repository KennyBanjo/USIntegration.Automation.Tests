
Feature: EquifaxUS
	User should be able to run a full credit report to make a decision on a customer
Background: 
	Given The 'Equifax Credit' plugin is activated
	
	
#Background: 
#	Given I have navigated to plugin configuration
#    When I click the 'Equifax Credit' plug-in checkbox to activate
#    Then the 'Equifax Credit' plug-in checkbox should be selected
#	When I click the 'Equifax Credit CAN' plug-in checkbox to activate
#    Then the 'Equifax Credit CAN' plug-in checkbox should be de-selected


@CurrentReleaseRegression @EQStandardDB
Scenario: Run Equifax Business credit report
	When I navigate to verification on a business account
	Then I should see 'Business Equifax Credit' under report
	When I run the 'Business Equifax Credit' report
	Then the 'Business Equifax Credit' status should display 'IN FILE'
	Then the 'Business Equifax Credit' report date should equal today's date
	Then the 'Business Equifax Credit' actions column should display 'View Report'
	
@CurrentReleaseRegression @EQStandardDB
Scenario: Run Equifax consumer report with invalid SS numbers
	Given I have navigated to an invalid SS consumer account
	When I run the 'Hard Equifax Credit' report
	Then the 'Hard Equifax Credit' report date should equal today's date
	Then An 'ERROR : Hard Equifax Credit' should appear with the message 'Error: Valid SS# is required in order to proceed, please verify primary applicant SS# is 9 digits and resubmit.'
	
@CurrentReleaseRegression @EQStandardDB
Scenario: Run Equifax consumer credit report
	When I navigate to a consumer account
	Then I should see 'Soft Equifax Credit' under report
	When I run the 'Soft Equifax Credit' report
	Then the 'Soft Equifax Credit' status should display 'NEEDS REVIEW'
	Then the 'Soft Equifax Credit' report date should equal today's date
	Then the 'Soft Equifax Credit' actions column should display 'View Report'
	
	
@CurrentReleaseRegression @EQBusinessLoanDB
Scenario: Run Business verification from loan
	When I navigate to verification from a 'Business' loan
	Then I should see 'Business Equifax Credit' under report
	When I run the 'Business Equifax Credit' report
	Then the 'Business Equifax Credit' status should display 'IN FILE'
	Then the 'Business Equifax Credit' report date should equal today's date
	Then the 'Business Equifax Credit' actions column should display 'View Report'

#@CurrentReleaseRegression @EQStandardDB 
#Scenario: Verify error message when SS is not provided
#	When I go to the verification page for missing SS account 
#	Then I should see 'Soft Equifax Credit' under report
#	Then the 'Soft Equifax Credit' status should display 'OPEN'
#	When I click the checkbox for equifax
#	And I click on the 'runSelectedReports()' button
#	Then the status should display 'ERROR'
#	Then An 'ERROR : Soft Equifax Credit' should appear with the message 'Error: Valid SS# is required in order to proceed, please verify primary applicant SS# is 9 digits and resubmit.'

	
@CurrentReleaseRegression @EQIndividualLoanDB
Scenario: Run Consumer verification from loan
	When I navigate to verification from a 'Consumer' loan
	Then I should see 'Hard Equifax Credit' under report
	When I run the 'Hard Equifax Credit' report
	Then the 'Hard Equifax Credit' status should display 'NEEDS REVIEW'
	Then the 'Hard Equifax Credit' report date should equal today's date
	Then the 'Hard Equifax Credit' actions column should display 'View Report'
#	Then I see 'Soft EQUUK Credit' under report in row '1'
#    Then I see 'WALLY SALWAY' under relationship in row '1'
#	When I click the checkbox for equifax
#	And I click on the 'runSelectedReports()' button
#	Then the status should display 'PASS'
#	And the report date should equal today's date
#	And the 'ACTIONS' column should display 'View Report'

@CurrentReleaseRegression @EQMultiLoanDB 
Scenario: Run Multiple Business verification from loan
	When I navigate to verification from a 'Business' loan
	Then I should see 'Business Equifax Credit' under report for both accounts
	When I run all the 'Business Equifax Credit' reports
	Then all 'Business Equifax Credit' statuses should read 'IN FILE'
	And all 'Business Equifax Credit' report dates should equal today's date
#	And the 'ACTIONS' columns should display 'View Report'
#
@CurrentReleaseRegression @EQMultiIndDB
Scenario: Run multiple Consumer verification from loan
	When I navigate to verification from a 'Consumer' loan
	Then I should see 'Hard Equifax Credit' under report for both accounts
	When I run both 'Hard Equifax Credit' and 'Soft EQUUK Credit' report
	Then all 'Business Equifax Credit' statuses should read 'IN FILE'
	And all 'Business Equifax Credit' report dates should equal today's date

@CurrentReleaseRegression @EQBusinessAndIndDB 
Scenario: Run Business and Individual verification from loan
	When I navigate to verification from a 'Consumer' loan
	Then I should see 'Business Equifax Credit' under report
	Then I should see 'Hard Equifax Credit' under report
	When I run both 'Business Equifax Credit' and 'Hard Equifax Credit' report
	Then the 'Business Equifax Credit' status should display 'IN FILE'
	Then the 'Hard Equifax Credit' status should display 'NEEDS REVIEW'
	Then the 'Business Equifax Credit' report date should equal today's date
	Then the 'Hard Equifax Credit' report date should equal today's date
#	Then the 'Business Equifax Credit' actions column should display 'View Report'
#	Then the 'Hard Equifax Credit' actions column should display 'View Report'
	

# @PreviousReleaseRegression @EQPortalDB
# Scenario: Run consumer soft report from customer portal for a pass
#	 When I navigate to the contact record for '0034K00000JWxg3QAD'
#     And I click on the 'LoginToNetworkAsUser' button
#     And I click on the 'Marketplace' button
#     And I click the Flow Test Apply button
#     And I click the Next button
#     And  I select 'ProviderEquukChoice' from the provider dropdown 
#     And  I select 'ReportTypeSoftChoice' from the report-type dropdown 
#     And I enter '0014K00000PVBoWQAX' in the EntityId textfield
#     And I click the Next button
#     Then I should see the message 'The credit pull was successful!'
#     Then the status should read 'Status: PASS '
#     Then the equifax credit score should be higher than 'Credit Score: 250'
	 

#	@PreviousReleaseRegression @EQPortalDB
#	Scenario: Equifax consumer soft report from customer portal for review
#		Given I have updated the equifax review account credentials
#		When I navigate to the contact record for '0034K00000JWxg3QAD'
#		And I click on the 'LoginToNetworkAsUser' button
#		And I click on the 'Marketplace' button
#		And I click the Flow Test Apply button
#		And I click the Next button
#		And  I select 'ProviderEquukChoice' from the provider dropdown 
#		And  I select 'ReportTypeSoftChoice' from the report-type dropdown 
#		And I enter '0014K00000PVBoWQAX' in the EntityId textfield
#		And I click the Next button
#		Then I should see the message 'The credit pull was successful!'
#		Then the status should read 'Status: NEEDS REVIEW '
#		Then the equifax credit score should be lower than 'Credit Score: 250'

#	@PreviousReleaseRegression @EQPortalDB
#	Scenario: Equifax consumer hard report from customer portal for pass
#		When I navigate to the contact record for '0034K00000JWxg3QAD'
#		And I click on the 'LoginToNetworkAsUser' button
#		And I click on the 'Marketplace' button
#		And I click the Flow Test Apply button
#		And I click the Next button
#		And  I select 'ProviderEquukChoice' from the provider dropdown 
#		And  I select 'ReportTypeHardChoice' from the report-type dropdown 
#		And I enter '0014K00000PVBoWQAX' in the EntityId textfield
#		And I click the Next button
#		Then I should see the message 'The credit pull was successful!'
#		Then the status should read 'Status: PASS '
#		Then the equifax credit score should be higher than 'Credit Score: 250'


# @PreviousReleaseRegression @EQPortalDB
# Scenario: Run commercial report from customer portal
#	 When I navigate to the contact record for '0034K000003SRWGQA4'
#     And I click on the 'LoginToNetworkAsUser' button
#     And I click on the 'Marketplace' button
#     And I click the Flow Test Apply button
#     And I click the Next button
#     And  I select 'ProviderEquukChoice' from the provider dropdown 
#     And  I select 'ReportTypeBusinessChoice' from the report-type dropdown 
#     And I enter '0014K000006PyVEQA0' in the EntityId textfield
#     And I click the Next button
#     Then I should see the message 'The credit pull was successful!'
#     Then the commercial status should read 'Status: IN FILE '

