@mytag
Feature: Adding comments are visible to site visitors
    I can add a comment to a published note that is later visible to
    site visitors

Scenario: Adding comment
    Given I have open website 'http://automatyzacja.benedykt.net/'
    And I add a comment with content 'lalala' and signature 'melily' and email address 'fake@fake.pl'
    When I publish a comment
	Then I should be able to view the comment
