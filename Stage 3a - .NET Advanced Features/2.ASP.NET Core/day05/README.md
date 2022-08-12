# Objectives

###  Demonstrate HTML helpers & Tag helpers to illustrate the concept of two way data binding

    Use HTML helpers - DisplayFor, asp-action, asp-for(EditorFor), asp-route-id, asp-controller - WITHOUT Scaffolding

###  Demonstrate Data Annotations for basic validations

    Use Required, Range attribute for Model property for validation, Use validation message on validation failure, Use ValidationSummary

###  Demonstrate partial view usage

    Explain Partial tag helper, Use partial tag helper to bind data to the partial view

    Create a Razor view to list a few Organizations at Hyderabad and highlight the one that has recently build its largest offshore office at India.

    Description: Create a new Action method ‘ITOrganizations’ in the Home controller. Add a view to it. Use Razor syntax to create list of data type string. Add few organizations at Hyderabad,

###  Microsoft 

###  Google

###  Amazon

To the list. Use foreach loop to loop thru the list and use DIV and a span inside it to list the organizations.

Amazon is the IT organization that has built its largest office at Hyderabad in 2019.

Use IF condition to check if the list item is ‘Amazon’, if so highlight it by making it bold.

Note: Ensure to add a link in _Layout file to add a link for ‘IT Organizations’

Create a Razor view to list few employee details using Model data binding

Description: Create a model class ‘Employee’ to be used for Employee details. Create properties

###  Id – datatype Int

###  Name – datatype string

###  Salary – datatype decimal

###  IsPermanent – datatype bool

Create a new Action method ‘GetEmployeeList’ in the Home controller and add a new View. Use the data provided below to feed the data to a list of Employee model class

```Json

[{
"id": "1",
"name": "John",
"salary": 10000,
"permanent": true
},

{
"id": "2",
"name": "Smith",
"salary": 5000,
"permanent": false
},

{
"id": "3",
"name": "Mark",
"salary": 5000,
"permanent": false
},

{
"id": "4",
"name": "Mary",
"salary": 5000,
"permanent": false
}]
```
Send the list of model data to the View from controller. Use Razor syntax to loop thru the items in the Model list and use DIV and span to display the employee detail

Employee name, Salary and Highlight if the permanent value is true

Note: Use bootstrap styles for the DIV display

###  Row

###  Col-md-4

Demonstrate partial view usage

Create a partial view to have the Employee list table data that could be reused in Employee list view.

Revisit the Index view to move the content into a Partial view and refer the partial view in the Index view