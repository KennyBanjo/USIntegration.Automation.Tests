
Feature: EquifaxUS
	User should be able to run a full credit report to make a decision on a customer

Background: 
	Given I have navigated to plugin configuration
    When I click the 'nCino Equifax (UK)' plug-in checkbox to activate
    Then the 'nCino Equifax (UK)' plug-in checkbox should be selected
    When I click the 'nCino Experian (UK)' plug-in checkbox to deactivate
    Then the 'nCino Experian (UK)' plug-in checkbox should be de-selected


@PreviousReleaseRegression @EQStandardDB @PreviousReleaseSanity
Scenario: Run Business credit verification
	When I navigate to verification on a business account
	Then I should see 'Business EQUUK Credit' under report
	When I click the checkbox for equifax
	And I click on the 'runSelectedReports()' button
	Then the status should display 'IN FILE'
	And the report date should equal today's date
	And the 'ACTIONS' column should display 'View Report'
	
    
@PreviousReleaseRegression @EQStandardDB
Scenario: Run consumer soft credit verification for Pass
	When I Navigate to Ursula cave's account
	Then I should see 'Soft EQUUK Credit' under report
	Then the status should display 'OPEN'
    Then I see 'URSULA CAVE' under relationship in row '1'
	When I click the checkbox for equifax
	And I click on the 'runSelectedReports()' button
	Then the status should display 'PASS'
	And the report date should equal today's date
	And the 'ACTIONS' column should display 'View Report'


#@PreviousReleaseRegression @EQStandardDB 
#Scenario: Verify error message when birthdate is not provided
#	When I go to the verification page for Neal Springthorpe
#	Then I should see 'Soft EQUUK Credit' under report
#	Then the status should display 'OPEN'
#	When I click the checkbox for equifax
#	And I click on the 'runSelectedReports()' button
#	Then the status should display 'ERROR'
#	Then An 'ERROR : Soft EQUUK Credit' should appear with the message 'Input data missing - Please ensure the following data is populated on the Contact record: Birthdate'
#
#@PreviousReleaseRegression @EQStandardDB
#Scenario: Verify error message when address is not provided
#    When I navigate to the verification page for Emanuel Harrison
#	Then I should see 'Soft EQUUK Credit' under report
#	Then the status should display 'OPEN'
#	When I click the checkbox for equifax
#	And I click on the 'runSelectedReports()' button
#	Then the status should display 'ERROR'
#	Then An 'ERROR : Soft EQUUK Credit' should appear with the message 'Input data missing - Please ensure the following data is populated on the Contact record: Address'

@PreviousReleaseRegression @EQStandardDB 
Scenario: Run consumer soft credit verification for review
    When I navigate the the relationship record for EMILLIO OSMOND
	Then I should see 'Soft EQUUK Credit' under report
	Then the status should display 'OPEN'
	When I click the checkbox for equifax
	And I click on the 'runSelectedReports()' button
	Then the status should display 'NEEDS REVIEW'
	And the report date should equal today's date
	And the 'ACTIONS' column should display 'View Report'
#    When I click the back to relationship button 
#    And I click on the 'Relationships' tab
#    And I search for 'EMILLIO OSMOND' in the 'Account-search-input' textfield
#    Then I should see 'EMILLIO OSMOND'
#    And the Fico score should be lower than '250'
	

@PreviousReleaseRegression @EQStandardDB
Scenario: Run consumer hard credit report
    When I navigate to verification on the relationship record for Wally Sallway
	Then I should see 'Soft EQUUK Credit' under report
	Then the status should display 'OPEN'
	When I click the checkbox for equifax
	And I click on the 'runSelectedReports()' button
	Then the status should display 'PASS'
	And the report date should equal today's date
	And the 'ACTIONS' column should display 'View Report'
	When I refresh the page
	Then I should see 'Hard EQUUK Credit' under report
	Then the status should display 'OPEN'
	When I click the checkbox for equifax
	And I click on the 'runSelectedReports()' button
	Then the status should display 'PASS'
	And the report date should equal today's date
	And the 'ACTIONS' column should display 'View Report'

@PreviousReleaseRegression @EQStandardDB
Scenario: Run verification without CompanyId
    When I navigate to the verification page for Paxton Access Ltd
	Then I should see 'Business EQUUK Credit' under report
	When I click the checkbox for equifax
	And I click on the 'runSelectedReports()' button
	Then the report date should equal today's date
	Then the status should display 'ERROR'
	Then An 'ERROR : Business EQUUK Credit' should appear with the message 'Input data missing - Please ensure the following data is populated on the Relationship record: Company Number'

@PreviousReleaseRegression @EQBusinessLoanDB
Scenario: Run Business verification from loan
    When I navigate to verification from loan
	Then I see 'Business EQUUK Credit' under report
	When I click the checkbox for equifax
	And I click on the 'runSelectedReports()' button
	Then the status should display 'IN FILE'
	And the report date should equal today's date
	And the 'ACTIONS' column should display 'View Report'
	
@PreviousReleaseRegression @EQIndividualLoanDB
Scenario: Run Consumer verification from loan
	When I navigate to verification from loan
	Then I see 'Soft EQUUK Credit' under report in row '1'
    Then I see 'WALLY SALWAY' under relationship in row '1'
	When I click the checkbox for equifax
	And I click on the 'runSelectedReports()' button
	Then the status should display 'PASS'
	And the report date should equal today's date
	And the 'ACTIONS' column should display 'View Report'

@PreviousReleaseRegression @EQMultiLoanDB 
Scenario: Run Multiple Business verification from loan
	When I navigate to verification from loan
	Then I see 'Business EQUUK Credit' under report
	When I click all the checkboxes
    And I click on the 'runSelectedReports()' button
	Then all statuses should read 'IN FILE'
	And all report dates should equal today's date
	And the 'ACTIONS' columns should display 'View Report'

@PreviousReleaseRegression @EQMultiIndDB
Scenario: Run multiple Consumer verification from loan
	When I navigate to verification from loan
	Then I see 'Soft EQUUK Credit' under report in row '1'
    Then I see 'WALLY SALWAY' under relationship in row '1'
    Then I see 'Soft EQUUK Credit' under report in row '2'
    Then I see 'EMILLIO OSMOND' under relationship in row '2'
    Then I see 'Soft EQUUK Credit' under report in row '3'
    Then I see 'URSULA CAVE' under relationship in row '3'
	When I click all the checkboxes
	And I click on the 'runSelectedReports()' button
	Then the status in row '1' should read 'PASS'  
    Then the status in row '2' should read 'NEEDS REVIEW'  
    Then the status in row '3' should read 'PASS'  
	And all report dates should equal today's date
	And the 'ACTIONS' columns should display 'View Report'

@PreviousReleaseRegression @EQBusinessAndIndDB 
Scenario: Run Business and Individual verification from loan
	When I navigate to verification from loan
	Then I see 'Business EQUUK Credit' under report in row '1'
    Then I see 'Soft EQUUK Credit' under report in row '2'
    Then I see '(EQUUK) IMAGINATION TECHNOLOGIES LIMITED' under relationship in row '1'
    Then I see 'WALLY SALWAY' under relationship in row '2'
	When I click the checkbox in row '1'
    And I click the checkbox in row '2' 
    And I click on the 'runSelectedReports()' button
	Then the status in row '1' should read 'IN FILE'
    Then the status in row '2' should read 'PASS'    
	And the report date in row '1' should equal today's date
    And the report date in row '2' should equal today's date
	And the 'ACTIONS' column in row '1' should display 'View Report'
    And the 'ACTIONS' column in row '2' should display 'View Report'

 @PreviousReleaseRegression @EQPortalDB
 Scenario: Run consumer soft report from customer portal for a pass
	 When I navigate to the contact record for '0034K00000JWxg3QAD'
     And I click on the 'LoginToNetworkAsUser' button
     And I click on the 'Marketplace' button
     And I click the Flow Test Apply button
     And I click the Next button
     And  I select 'ProviderEquukChoice' from the provider dropdown 
     And  I select 'ReportTypeSoftChoice' from the report-type dropdown 
     And I enter '0014K00000PVBoWQAX' in the EntityId textfield
     And I click the Next button
     Then I should see the message 'The credit pull was successful!'
     Then the status should read 'Status: PASS '
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

@PreviousReleaseRegression @InMemoryProvider @EQStandardDB
Scenario: Run Consumer verification with in memory provider
	When I Navigate to Ursula cave's account
Then I should see 'Soft EQUUK Credit' under report
	Then the status should display 'OPEN'
	Then I see 'URSULA CAVE' under relationship in row '1'
	When I click the checkbox for equifax
	And I click on the 'runSelectedReports()' button
	Then the status should display 'PASS'
	And the report date should equal today's date
	And the 'ACTIONS' column should display 'View Report'
	

@PreviousReleaseRegression @InMemoryProvider @EQStandardDB
Scenario: Run Commercial verification with in memory provider
	When I navigate to verification on a business account
	Then I should see 'Business EQUUK Credit' under report
	When I click the checkbox for equifax
	And I click on the 'runSelectedReports()' button
	Then the status should display 'IN FILE'
	And the report date should equal today's date
	And the 'ACTIONS' column should display 'View Report'
	
	
#@PreviousReleaseRegression @EQStandardDB @QaSpringSanity
#Scenario: Perform soft credit search using invocable method
#	When I navigate to the credit report invoker url
#	And I select 'ProviderEquukChoice' from the 'ProviderInput' dropdown
#	And I select 'ReportTypeSoftChoice' from the 'ReportTypeInput' dropdown
#	And I enter the entity id in the 'EntityIdInput' textfield
#	And I click on the 'Next' button
#	Then I should see the message 'The credit pull was successful!'
#	
#@PreviousReleaseRegression @EQStandardDB @QaSpringSanity
#Scenario: Perform hard credit search using invocable method
#	When I navigate to the credit report invoker url
#	And I select 'ProviderEquukChoice' from the 'ProviderInput' dropdown
#	And I select 'ReportTypeHardChoice' from the 'ReportTypeInput' dropdown
#	And I enter the entity id in the 'EntityIdInput' textfield
#	And I click on the 'Next' button
#	Then I should see the error message 'Failed to locate existing credit report'

	
