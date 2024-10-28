# Petstore Project

Welcome to the **PetStore** project repository! This project was developed incrementally over several weeks, with each week introducing new features, concepts, and improvements. The branches in this repository are organized by week, allowing you to easily track the progression and evolution of the application over time. Below, you will find the steps I took to complete the project on a weekly basis. Each branch contains the specific changes and additions made during that particular week, showcasing the application's development phase by phase.

# Part 1

In Week 1, I established the foundational structure of the PetStore application by creating classes with essential properties and fields, focusing on key object-oriented programming principles such as encapsulation and inheritance. I implemented a console application that manages user input, allowing for the instantiation of product objects and basic application flow control using loops and conditional logic. Additionally, I introduced exception handling to demonstrate error management in the application. This foundational work sets the stage for further development in subsequent weeks.

# Part 2

In Week 2, I enhanced the PetStore application by implementing collections, specifically utilizing `List<Product>` and `Dictionary<string, DogLeash>`. I added functionality that allowed users to search for product names using dictionary key-value pairs, solidifying my understanding of collection manipulation. This included creating methods for adding products and retrieving details, reinforcing key programming concepts such as polymorphism and inheritance.

# Part 3

In Week 3, I advanced the PetStore application by implementing error handling and reinforcing object-oriented programming (OOP) principles. I wrapped the product retrieval method in the `ProductLogic` class with a try-catch block to handle exceptions gracefully, returning null when a product is not found. This prevents the application from crashing and enhances user experience. Additionally, I introduced the `DryCatFood` class, which inherits from the existing `CatFood` class, demonstrating the principles of inheritance and encapsulation. This structural organization of classes improves code maintainability and readability, essential aspects of OOP that employers highly value.

# Part 4

In Week 4, I enhanced the PetStore application by introducing interfaces and utilizing LINQ queries for data manipulation. I created the `IProductLogic` interface, specifying essential methods for the `ProductLogic` class, thus establishing a clear contract for implementation. This design promotes code maintainability and reusability. I implemented the `GetOnlyInStockProducts` method using LINQ to filter products with a quantity greater than zero, simplifying the logic with a single line: `return _products.Where(x => x.Quantity > 0).ToList();`. Additionally, I introduced UI options to display only in-stock products, showcasing how interfaces and LINQ can enhance application functionality and user experience.

# Part 5

In Week 5, I enhanced the PetStore application by implementing extension methods to improve code readability and maintainability. I created a static class `ListExtensions`, adding the `InStock<T>` method that checks for products in stock, leveraging generics for flexibility. This method simplifies the logic previously implemented in `ProductLogic`, promoting cleaner code practices. Additionally, I introduced a new method called `GetTotalPriceOfInventory`, utilizing the `InStock` method along with LINQ's `Select` and `Sum` to calculate the total inventory value. A new UI option was also added to access this functionality, showcasing the power of extension methods in enhancing existing classes.

# Part 6

In Week 6, I focused on refactoring the PetStore application to adhere to "Clean Coding" principles, enhancing the code's maintainability and readability. I identified and eliminated duplicate code by extracting common logic into methods. The `UserInput` functionality was streamlined by refactoring the `GetUserInput` method to adopt a positive conditional and utilizing `List<T>` for better handling of user inputs. I also improved method naming conventions, ensuring names like `ListUserInputOptions` are descriptive and intuitive. Additionally, I reorganized the project structure, moving classes into relevant folders and adjusting namespaces accordingly, while emphasizing the use of interfaces over concrete classes to foster better abstraction and flexibility. This effort is aligned with SOLID principles, laying a strong foundation for future enhancements.

# Part 7

In Week 7, I implemented Dependency Injection (DI) in the PetStore application to enhance modularity and testability. I began by installing the `Microsoft.Extensions.Hosting` NuGet package and created a static method called `CreateServiceCollection` in the `Program` class, which returns an `IServiceProvider`. This method serves as the central configuration point for services within the application. I registered `ProductLogic` as a transient service using the `AddTransient` method, allowing for a clean separation of concerns and better management of dependencies. Finally, I updated the instantiation of the `ProductLogic` variable to retrieve it from the service collection. This integration of DI lays a solid groundwork for more complex architectures and future enhancements.

# Part 8

In Week 8, I implemented JSON input handling and validation for the PetStore application, enhancing data integrity and usability. I modified Option 1 in the `Program` class to accept JSON input, utilizing the `System.Text.Json` NuGet package for deserialization. A sample JSON object was provided for testing, enabling users to input a `DogLeash` in a structured format. To ensure that all `DogLeash` properties meet defined criteria, I integrated the `FluentValidation` NuGet package and created a validation class in a new `Validators` folder. Validation rules included requiring the `Name` property, ensuring `Price` and `Quantity` are positive numbers, and setting a minimum character length for the `Description` property. I updated the `ProductLogic` class to use this validator, throwing a `ValidationException` when inputs do not conform to the rules. Additionally, I refactored the method for retrieving products to be generic, allowing it to handle various product types, including both `DogLeash` and `CatFood`, improving code reusability and maintainability.

# Part 9

In Week 9, I integrated Entity Framework Core into the PetStore application, enabling persistent data storage through a SQLite database. A new class library project, `PetStore.Data`, was created and linked to the main PetStore project. I added the `Microsoft.EntityFrameworkCore.Sqlite` NuGet package and established a `ProductContext` class as the `DbContext`. The `Product` class was updated to include a `ProductId` property, allowing for unique identification in the database.

I implemented a `ProductRepository` class, which includes methods for adding products to the database, retrieving products by ID, and fetching all products. This repository was then registered as a transient service in the dependency injection container. In `ProductLogic`, I modified the constructor to accept the repository interface and updated the product management methods to utilize this repository for database operations instead of in-memory lists.

As part of the cleanup process, I removed redundant classes and methods that were no longer necessary due to the shift to database storage. This included eliminating the `DogLeash`, `CatFood`, and `DryCatFood` classes, along with various methods in `ProductLogic`. I also ensured that the validator was updated to handle product validation, reinforcing data integrity before database insertion.

Finally, I successfully tested the database integration by adding a product and verifying that it could be retrieved by its ID, confirming that the application is now capable of performing CRUD operations using Entity Framework Core.

# Part 10

In Week 10, I enhanced the PetStore application by adding a new entity relationship between `Order` and `Product` using Entity Framework Core. I created the `Order` entity with properties for `OrderId`, `OrderDate`, and a collection of `Product`. This involved adding a `DbSet<Order>` to the `ProductContext` class and establishing a foreign key relationship in the `Product` class through an `Order` navigation property and an `OrderId`.

After implementing the entity relationships, I executed a migration and updated the database, ensuring that the schema reflected the new relationships correctly. I then added functionality to manage orders, including a new `OrderRepository` class that handles adding and retrieving orders. The `GetOrder` method utilizes `.Include(x => x.Products)` to load the associated products for each order.

To test the new functionality, I created a JSON payload for adding orders and verified that the application successfully stored the data, with EF Core managing the relationships automatically.

In addition to database updates, I set up a new project for unit testing, `PetStore.Tests`, using MSTest and the Moq library. I added a `ProductLogicTests` class with a unit test for the `GetProductById` method. This test involved setting up mock repositories to return fake data, executing the method under test, and asserting that the expected repository method was called correctly.

Overall, this week focused on strengthening the application's data handling capabilities through effective use of Entity Framework Core and establishing unit testing practices to enhance code quality and maintainability.

# Part 11: API Functionality Implementation

In this section, I successfully integrated API functionality into the PetStore application by creating a new Web API project within the same solution, allowing me to reference the existing Console application and its ProductContext. This approach streamlined the conversion process, circumventing the need to rely on an outdated tutorial for transforming a Console Application into a Web API. I implemented two controllers, each featuring GET requests to retrieve product and order data.

Throughout this process, I gained a deeper understanding of `IActionResult`, recognizing that actions in an ASP.NET controller are analogous to handlers in Spring. I also expanded my knowledge of various HTTP status codes, particularly those automatically returned by the `System.Http` namespace. With the core functionality established, I plan to implement POST methods in the future to enhance the API’s capabilities.


