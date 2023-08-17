# ElevatorCH
## Summary
This is a minimal API for controlling elevators in a building.  The purpose is to provide a framework for developers to test with as they build out the elevator control logic.  
## How to run
Start within Visual Studio, and you will see a Swagger page giving the basic access.  Additionally, there is a file in the ElevatorCH project called ElevatorDispatch.postman_collection.json which will run the commands within Postman.  The port is 8080.
## Implementation details
The project is written in C#, for .Net Core.  It is API only, with no front end.  The business logic is all in the ElevatorModels project, and most of it is intended to be replaced as developers build out the system.  The existing logic is only a stub and the datastore is mostly hardcoded.

The classes are
- Car - a single elevator / car.  The terms are used interchangeably.
- Floor - a floor that can be serviced by an elevator car.
- Call - a junction record between Car and Floor
- Building - a placeholder for the temporary business logic

## Next steps
- Create a datastore, probably in a database.
- Create actual logic for choosing how to deploy cars.
- Add logic for elevators that don't go to all floors.
- Add logic to ensure that there are not duplicate records for a Call (specific elevator going to specific floor).
- and many more.
