# Infrastructure Layer

This layer contains classes for accessing external resources such as file systems, web services, smtp, and so on.
These classes should be based on interfaces defined within the application layer.

# Overview
* Persistence (EF)
* Identity
* Filesystem
* System Clock
* API Clients

# Key Points
* Independent of the database
* Use Fluent API Configuration over Data Annontations
* Prefer conventions over configuration
* Automatically apply all entity type configurations
* No layers depend on Infrastructure layer e.q. Presentation Layer


# Shuld we use Unit of Work and Repository Patterns
Should we implement these patterns?
It isn't always the best choice, because:
* EF Core insulates your code from database changes
* DbContext acts as unit of work
* DbSet acts as repository
* EF Core has features for unit testing without repositories

People
* Jimmy Bogard: I'am over repositories, and definitely over abstracting the data layer (negativ)
* Steve Smith: No, you don't need a repository. But there are many benefits and you should consider it! (positiv, a little!)
* Jon Smith: No, the repository/unit-of-work pattern isn't useful with EF core (negative)