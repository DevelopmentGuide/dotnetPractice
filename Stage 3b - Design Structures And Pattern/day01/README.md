# Objectives

### Demonstrate code modifications are done for any 2 of the SOLID principles

### Modify code to implement Single responsibility, Interface segregation

Refactor code to follow SRP, ISP of SOLID principles Please download the application available here. This will be refactored to follow Single responsibility and Interface segregation principles A console application on Phone order and repair is provided. Refactor the application to follow

1. Single responsibility of the class. Go through, analyze the distinct functionalities of the application. Refactor the application accordingly.

2. Interface segregation. Go through, analyze if the current interface can be split to follow the principle

Note: An example of Dependency Injection principle

There is a folder in the application “DependencyInjection”. This folder has an example of the implementation of dependency injection.

There is an IPhone class that contains abstract methods. Classes Redmi7 and SamsungNote implement the methods as per the IPhone interface.

The class ProcessPhoneRepair has a method RepairSteps. It contains the steps followed to repair a

phone. It takes in a parameter of any phone object that implements the IPhone interface.

This way the method is independent that concentrates ONLY on the process and it becomes the responsibility of the caller to send the appropriate dependency to be used.