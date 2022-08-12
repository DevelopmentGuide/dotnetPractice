# Objectives:

### Demonstrate creation of an Action method to return list of custom class entity

Model class creation, Use AllowAnonymous attribute, Use HttpGet action method

### Explain the usage of FromBody attribute

Read the model object from request, other than the query string parameter

### Demonstrate Custom filter

Usage of ActionFilterAttribute, OnActionExecuting method to intercept the request, Create filter for Custom exception - Need to install Microsoft.AspNetCore.Mvc.WebApiCompatShim package


### 1. Web Api using custom model class

Create a Custom class ‘Employee’ of the below defined structure

```csharp
public class Employee

{
public int Id { get; set; }
public string Name { get; set; }
public int Salary { get; set; }
public bool Permanent { get; set; }
public Department Department { get; set; }
public List<Skill> Skills { get; set; }
public DateTime DateOfBirth { get; set; }
}
```

Create a new controller - EmployeeController with Read Write actions

Constructor: Create few records, HTTPGet, HTTPPost/HTTPPut

Create a Private method GetStandardEmployeeList that returns a List of Employee class. Invoke this method in the Get action method of the EmployeeController that was created in the previous step.

Public ActionResult<Employee> GetStandrad()

Modify the return type of the Get action method(without parameter) to return List of Employee class object

Add ProducesResponseType to the GET action method for Status code 200

Check the Swagger description for the GET method for success status code


### 2. Create a Custom action filter for Authorization.

The requirement is to intercept incoming requests and check if there is a key ‘Authorization’ in the request header or not. If it is there, then to check if it contains a value ‘Bearer’ or not.

Create a folder ‘Filters’ in the application solution. Create a class ‘CustomAuthFilter’ to filter requests. Inherit ActionFilterAttribute. Override OnActionExecuting method to check if the request object has Header ‘Authorization’ or not. If not, throw BadRequestResult with the message

Invalid request - No Auth token

If the header is present, then check if the value contains the word ‘Bearer’. If not, throw BadRequestResult with the message

Invalid request - Token present but Bearer unavailable

Add an attribute CustomAuthFilter to the Employee controller to filter any request to check for the Authorization token in the request header.

### 3. Custom Exception filter

Create a class ‘CustomExceptionFilter’ to catch the exceptions occuring the application Implement IExceptionFilter thru the OnException method Use the exception context to fetch the exception detail. Capture that and write it to a File in the system. Set the Result property of the exception context to ExceptionResult. Throw an exception in GET action method. Ensure that the GET action method has ProducesResponseType for 500 - Internal server error Use Swagger to test the exception and message being thrown. Note: This needs WebApiCompatShim NuGet package installation

- - - -

# Objectives:

###  Demonstrate creation of an Action method to perform data create, update & delete operation

Use FromBody attribute, extract data to custom model class using FromBody attribute, use hardcoded data to update & delete data, Use Swagger and POSTMAN to test

### 1. Web Api CRUD operation

Update Employee data as per the input thru Web API PUT action method call

Employee information has to be updated based on the user input. Use Swagger tool to invoke the action method mapped with Http PUT action verb to update an employee data.

Modify the action method to return Employee data thru ActionResult.

Check if the id value is lesser than or equal to 0. If true, throw BadRequest action result with the message ‘Invalid employee id’

If the value is greater than 0 but not available in the list of employee ids that is there in the hardcoded list of employees, throw BadRequest action result with the same message as stated above.

If the id value is valid, use the JSON data from the input body and update the hardcoded list. Filter the employee list data for the input id and return that as the output.