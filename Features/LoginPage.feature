Feature: Login Page

Create form

Background: 
	Given I Enter the Voltas Url
	And I Login to Application

	@createForm
Scenario Outline: Create Form
    When Create form <ExcelFileName>,<SheetName>,<ColumnName>,<RowNumber>
	Then Logout from App

	Examples: 
	| ExcelFileName | SheetName  | ColumnName | RowNumber |
	| CreateForm    | CreateForm | ActivityDescription           | 2         |

	@deleteForm
Scenario Outline: Delete Form
    When Delete form <ExcelFileName>,<SheetName>,<ColumnName>,<RowNumber>
	Then Logout from App

	Examples: 
	| ExcelFileName | SheetName  | ColumnName | RowNumber |
	| CreateForm    | CreateForm | ActivityDescription           | 2         |