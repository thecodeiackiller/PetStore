# PetStore Project

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

