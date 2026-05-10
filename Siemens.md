# SOLID
Single Responsability Principle
--Open to extension, Closed to motifications - in loc de decision trees sa ai interfete
--Liskov substitution principle - inheritance ul mere bine
--Interface segregation principle - interfata nu e prea mare
Dependency Inversion principle - mereu folosesti interfete in loc de clase direct

# I. Code Review and SOLID PRINCIPLES

#### Violation 1: GET api/item
In ItemController.cs on lines 22-23 there is a violation of the Single Reponsability Principle.

The endpoint api/item does the reading directly from the repository.

The solution is to create a Service layer that handles the reading.

#### Violation 2: GET api/item
In ItemController.cs on lines 25-28 and 33-38 there is a violation of the Single Responsability Principle.

The endpoint api/item should only return the list of all items, but instead it returns in addition the number of items and the average value

The solution is to create an additional controller that holds two endpoints: GET api/statistics/count and GET api/statistics/average

#### Violation 3:  GET api/item/id
In ItemController.cs on lines 47-58 there is a violation of the Single Responsability Principle.

The endpoint api/item/id does both the validation of an id and the search.

The solution is to create a Service that takes care of retrieving the data and validating inputs.

#### Violation 4: Item controller
In ItemController.cs on lines 20, 28, 45, 49, 56 there is a violation of the Open/Closed Principle.

The controller does the logging without doing so through a proper ILogger interface.

The solution is to inject the controllers with an implementation of the ILogger interface

#### Renamings and errors
IItemReader.cs should be named IRepository.cs, to better define its utility as a repository interface

The dependency injection isnt properly done in Program.cs
