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


