# Adventure Works API

The project is done for Azure Mentoring Program 2020Q4.  
The main aim of the project is to create Restul API for AdventureWork sample database.

## The main concepts

The project is created and build in the Three-Layer-Architecture.
![Three-Layer-Architecture-Image](/Documents/Three-Layer-Architecture.png)

The connection is done by base classes represented by basic CRUD logic. If the complex logic will be needed that the edit can be done very fast and easily:

-   Create a new class and inherit logic from the base one.
-   Add a record in DI container list for automatic resolve.

Also, the structure can be improved by moving Entities and Models POCO-classes to distinct projects.

![Three-Layer-Architecture-Image-Modified](/Documents/Three-Layer-Architecture-Modified.png)

Even more abstract structure can be created with help of DI container. In this case the application become very loose coupling.

![Three-Layer-Architecture-Interface-Image-Modified](/Documents/Three-Layer-Architecture-Interface-Image-Modified.png)

The application can be upgraded very fast without need to write the same code to same object types.
