# Objectives:

### Explain CORS enablement for Web API access for local application

1. What is CORS?, 
2. How to enable CORS thru Startup.cs, 
3. Install Cors nuget package to Web API application

### Demonstrate security in WebAPI

Bearer and Jwt token authentication, Use Authorize attribute & send roles in Jwt token, Setting in Startup.cs for AddAuthentication and AddJwtBearer with validation attributes, UseAuthentication, AllowAnonymous to AuthController to generate token, Claims

1. JsonWebToken

There are various modes of authenticating a request. Json Web Token(JWT) authentication is one among them. It is a methodology of passing a token in the Authorization header value in the request so that it can be checked at the WebAPI and validated. If not there, then ‘Unauthorized’ status message with status code 401 should be thrown.

Use the below code in Startup.cs

### In ConfigureServices method

```csharp
string securityKey = "mysuperdupersecret";

var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

services.AddAuthentication(x =>

{

x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

x.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;

})

.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, x =>

{

x.TokenValidationParameters = new TokenValidationParameters

{

//what to validate

ValidateIssuer = true,

ValidateAudience = true,

ValidateLifetime = true,

ValidateIssuerSigningKey = true,

//setup validate data

ValidIssuer = "mySystem",

ValidAudience = "myUsers",

IssuerSigningKey = symmetricSecurityKey

};

});
```
### In Configure method
```csharp
app.UseAuthentication();
```
This is to enable the JWT authentication in .Net core

Create a new controller ‘AuthController’ in the Web API application. Add AllowAnonymous attribute to the controller. Create a private method GenerateJSONWebToken as shown thru the code below.

```csharp
private string GenerateJSONWebToken(int userId, string userRole)

{

var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysuperdupersecret"));

var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

var claims = new List<Claim>

{

new Claim(ClaimTypes.Role, userRole),

new Claim("UserId", userId.ToString())

};

var token = new JwtSecurityToken(

issuer: "mySystem",

audience: "myUsers",

claims: claims,

expires: DateTime.Now.AddMinutes(10),

signingCredentials: credentials);

return new JwtSecurityTokenHandler().WriteToken(token);

}
```

Note that the issuer, audience and the securitykey defined in the Startup.cs code and method code shown above is the same and should match.

Invoke the GenerateJSONWebToken in the GET action method by sending some value for user id and ‘Admin’ for the user role. This is to set Claims information to check the user role

2. Use the JWT generated thru the AuthController to be used in POSTMAN request.

Remove the ‘CustomAuthFilter’ that is currently mapped to the Employee controller(if already done)

Use Authorize attribute in the Employee controller to check if the request header contains ‘Authorization’ key with ‘Bearer’ token or not. If the token is unavailable, then ‘Unauthorized’ status message whose code 401 will be thrown. Use POSTMAN to hit a GET action method call. Note the ‘Status’ attribute in the ‘Headers’ section in the output window.

Use the AuthController to generate the JWT. Use that in the GET action method call thru POSTMAN if the request is authenticated or not.

Modify the token value in the POSTMAN tool and check if ‘Unauthorized’ status message is thrown. Note the ‘Status’ attribute in the ‘Headers’ section in the output window.

3. Check for JWT expiration

A JWT token has an attribute which can be set to determine how long the token is valid to be used.

In the GenerateJSONWebToken method in AuthController, the ‘expires’ attribute of the JwtSecurityToken object denotes the time in minutes for which the token would be valid.

Modify the duration for ‘expires’ attribute to 2 minutes. Check the POSTMAN request for GET call AFTER 2 minutes of generation of the JWT, which should yield ‘Unauthorized’ message with Http status code 401.

4. Add the roles to be authorized in the Authorize attribute.

The Authorize attribute supports the roles to be used to filter the controller action method access.

The GenerateJSONWebToken method of AuthController uses the role ‘Admin’ set in the claims.

Include the role ‘POC’ in the Authorize attribute in the Employee controller. Hit the GET action method of the Employee controller thru POSTMAN. Verify if the response status is ‘Unauthorized’ with status code 401

Include the role ‘Admin’ along with ‘POC’ in the Authorize attribute in the Employee controller. Hit the GET action method of the Employee controller thru POSTMAN. Verify if the response status is `OK` with status code `200`


# Objectives:

### Demonstrate using EF to hit database and get data for GET, PUT and POST request

### Demonstrate referencing Web API application in an MVC application

Use hardcoded list data for operations, 

For Action methods with input parameters check for valid value for that input and if not, 

use BadRequest to return the data

1. Reference WebAPI in Angular application for GET & POST

Create an Angular/ASP.Net MVC Core application(Use already created if available) - Whichever is there in the curriculum From the application to hit the Web API to

### Get employee data as list of Custom entity from Web API GET action method - Use ADO.Net to get data from database

### Use Angular application to create new Employee data. Use POST action method - Use ADO.Net to create data in database

- - - - 

## Note:

### Create a controller 'AuthController' in the Web API application with 'AllowAnonymous' attribute

### Generate JWT thru a Private method in the AuthController and return it thru the GET action method

### Use the JWT in the Angular request

Use Authorize attribute without any role at the Employee controller level
