# Domain Layer
This will contain all entities, enums, exceptions, types and logic specific to the domain. The Entity Framework related classes are abstract, and should be considered in 
the same light as .NET Core. For testing, use an InMemory provider such as InMemory or SqlLite.

* Entities
* Value Objects
* Enumerations
* Logic
* Exceptions

Key Points:
* Don't use data annotations
* Use value object where appropriate
* Initialize all collections & use privte setters
* Create custom domain exceptions (better understandable and testable)
* Automatically track changes using AuditableEntity
* Avoide dependency on system clock with IDateTime (System clock is Infrastructure)
