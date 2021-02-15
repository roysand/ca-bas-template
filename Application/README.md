# Application Layer

This layer contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project.
This layer defines interfaces that are implemented by outside layers. 
For example, if the application need to access a notification service, a new interface would be added to application and an implementation would be created within infrastructure.

# Key notes
* Interfaces (implemented by outside layers)
* Models (View models and DTO's')
* Logic
* Command and Queries (Command Queries Responsibility Segregation (CQRS) with MediatR)
* Validators
* Exceptions

# CQRS
* Command Query Responsibility Segregation
* Separate reads (queries) from writes (commands)
* Can maximise performance, scalability, and simplicity
* Easy to add new features, just add a new query or command
* Easy to maintain, changes only affect one command or query

#MediatR + CQRS = ♥
* Define commands and queries as requests
* Application layer is just a series of request / response objects
* Ability to attach additional behaviour before and / or after each request, e.g. logging, validation, caching, authorisation and so on
* Using CQRS + MediatR simplifies overall design
* MediatR simplifes cross cutting concerns
* Fluent Validation is useful for all validation scenarios
* Automapper simplifies mapping and projections
* Independent of infrastrucure and data access concerns
