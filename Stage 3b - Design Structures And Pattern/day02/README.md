# Objectives

### Demonstrate code modifications are done for any 2 of the SOLID principles

 Modify code to implement Single responsibility, Interface segregation

### Demonstrate the usage of Abstract factory design pattern

 Factory of objects created using factory design pattern

### Demonstrate the usage and implementation of Singleton design pattern

Realtime instance of significance of one object instance in memory, Eg: single DB connection object; how to achieve it using Private Static Constructor, thread safety

Analyze and implement the following design patterns thru real life problems

Implement all these problems thru a Console application

Singleton: Please refer to the handson document available here.

### `Singleton Pattern`:- Hands on exercise.

#### An online shopping web application makes multiple calls from different services to the database. The requirement is to restrict creation of multiple data base connection objects everytime a caller requests for a connection object. Please implement a DBCon class which will return the same instance of the class, irrespective of the requests

#### Exercise Steps

1. Create a DBConn class with a static private member – ‘instance’ to hold its own instance.

2. Create a new instance of the object and assign it to the instance variable.

3. Make the constructor of the class as private

4. Implement a ‘getInstance()’ static method to return the instance variable.

5. Implement a caller method to call this method to get the instance

#### Points to ponder

1. What will happen if you don’t make the constructor as private?

2. What happens to the class if static keywords are attached to a member.?

3. Will you be able to instantiate the object without ‘new’ operator?


### `Abstract factory`: Please refer to the handson document available here.

An automobile manufacturer produces parts for cars, such as tires and headlights. They produce these parts for different car brands like Mercedes and Audi. The UML given explains our Factory class which is an abstract class that provides a common interface for creating similar objects.

Using the UML please implement the Classes and demonstrate the usage of Abstract factory pattern

### Steps:

1. Create abstract classes for Tire, Headlight and Factory

2. Implement separate factory classes, Tire and Headlight classes for Audi and Mercedes

3. Implement a factory getter based on the type of the factory either , Mercedes or Audi. The type can be passed as a parameter

4. In the client Implement

a. Get the appropriate factory object.

b. Use that object to make the Tire and Headlights

c. Validate the output.