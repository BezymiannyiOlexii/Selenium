Feature: Testing Epam web-site


Background: 
    Given Opened Epam web-site

# 1
Scenario: Select Servises
  Given Сlick servises select button
  When select one of servises oppotrunities
  Then I expact to be directed to chosen opportunity page
# 2
Scenario: Find some info about company 
  Given I am on the main page
  When Click "How we do it" button
  Then I expect to see information about company (motivation list, why I need to choose EPAM)
# 3
    Scenario: Want to choose language
      Given I am on the main page
      And By default the language is english
      When I click on "Global (EN)" button and choose "Ukraine (EN)"
      Then I expect to be redirectid to "https://careers.epam.ua/"
# 4
Scenario: Display office location
  Given I am on the main page
  * Scroll down the page
  * Select office in Russia
  * See list of cities in Rassia with EPAM offices
  * Select Saint_Petesrburg city
  When I click "MAP" link
  Then My browser should open new tab with google maps
# 5
Scenario: Connection to Linkenin
  Given I am on the main page
  And Scroll to the bottom 
  When Click Linkenin frame
  Then Browser should redirect me to the EPAM Linkenin web page in new tab
# 6   
Scenario: Using Search tool
  Given I am on the main page
  * I click on the magnifier button
  * Serch menu drops down
  * I type in "python" in search field
  When I click "FIND" button
  Then I should see all results of search related to the "python"
# 7
Scenario: Adaptive structure
  Given I am on the main page
  And I switch my browser from full-screen to the window mode
  When I manually dicrease size of window 
  Then All text and sections on the site should adjust for the size of the window
  And All menu options should be compressed in one "MENU +" button with the drop submenu
# 8
  Scenario: Change sort criteria
  Given I am on the .NET job offers page
  And by default all offers are sorted by relevance
  And I want to order them by Date
  When I hover my mouse on the "Date" text
  Then cursore form should change into hand with pointing finger to show user that this text is clickable