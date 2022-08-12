# Objectives

· Demonstrate custom exception filter creation

o Create class that implements IExceptionFilter, Use log4Net to log

· Demonstrate a new web page creation with model binding with scaffolding & Entity framework

o Explain Scaffolding with Entity framework concepts, Bind parameter in Create methods

Logging

Filters are like interceptors and can be added at global level in .Net core. Create a custom filter to handle exceptions. Implement IExceptionFilter to handle exception. Use log4Net to log the error details on to a text file.

Throw an exception in the Index method of any controller of the .Net core application to check if its being handled or not.

Configure the custom filter in the ConfigureServices method of Startup.cs to register it.

Use the below code to add the logger settings for log4Net in the ConfigureServices method of Startup.cs

ILoggerFactory logger = new LoggerFactory()

.AddLog4Net();

services.AddSingleton(logger).AddLogging();

This is just for your knowledge. As Log4Net works till .Net core 2.0

Log4Net usage for logging

Create an ASP.Net Web application(.Net standard) with MVC template. 
Use log4Net NuGetpackage to download & reference the package for logging. 
Include the following line of code in Global.asax.cs to register the logger component. 
log4net.Config.XmlConfigurator.Configure(); Include the following configuration settings in Web.config. 
This setting is required to configure the logging to File. 
Check and change the attribute 'file' value as that is the path where the log file will be created

```csharp
<configSections>
 <section name="log4net" type="log4net.Config.Log4NetConfigurationSectionHandler,log4net" /> 
</configSections> <log4net> <appender name="RollingFile" type="log4net.Appender.RollingFileAppender"> 
<file value="C:\Temp\nSightsLog.log" /> <appendToFile value="true" /> <maximumFileSize value="500KB" />
 <maxSizeRollBackups value="2" /> <layout type="log4net.Layout.PatternLayout">
 <conversionPattern value="%date %level %logger - %message%newline" /> 
</layout>
 </appender> 
<root> <level value="All" /> <appender-ref ref="RollingFile" /> </root>
</log4net>
```

In any of the Home controller action methods, create an object of type ILog for the HomeController. Log information thru that instance. Note: This is for an ASP.Net Web application using MVC template for .Net standard framework and NOT for .Net core 2.2

Create a .Net core web application with a controller that is scaffolded with Entity framework options.
 Create a Model class 'Account' with 'AccountId' and 'AccountName' as properties. Use this model in scaffolding.
 Observe the Action methods for GET, PUT, POST and DELETE action methods. There would be an action method for Create.
 ' Bind' keyword would be used to selectively choose the properties of the model. Notice the usage ModelState.
IsValid in the method whose HttpActionVerb is POST Notice the presence of 2 Action methods 'Create',
 one for GET and another for 'POST' Notice the usage of 'NotFound' action result