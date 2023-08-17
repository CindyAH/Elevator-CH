namespace ElevatorModels
{
    /// <summary>
    /// A Call is a join object for a <see cref="Car"/> and a <see cref="Floor"/>.  It
    /// can be created when only the floor is known (when someone is in the elevator
    /// lobby wanting a car), and the business logic will assign
    /// the best car to service that floor, and it can be created when both the car and the
    /// floor are known (when someone is in the car and wants to go to another floor).
    /// </summary>
    public class Call
    {
        private static int _nextId;

        /// <summary>
        /// The Id for the Call.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Floor is the location a car needs to be sent to.
        /// </summary>
        public Floor Floor { get; }

        /// <summary>
        /// Car is the car that's assigned to go to the floor.
        /// </summary>
        public Car Car { get; }

        /// <summary>
        /// Create a Call for the specified <see cref="Floor"/>, where the car to service the Call
        /// is determined by business logic.  This would be used when someone is 
        /// in the elevator lobby and presses a button to call an elevator.
        /// </summary>
        /// <param name="floor"></param>
        public Call(Floor floor) 
        { 
            Floor = floor;
            Car = new Building().GetCar();
            Id = GetNextId();
        }

        /// <summary>
        /// Create a Call for the specified <see cref="Car"/> to go to the specified <see cref="Floor"/>.  This
        /// would be used when a car occupant presses a floor button.
        /// </summary>
        /// <param name="floor">The floor the car needs to go to</param>
        /// <param name="car">The car that's going to the floor</param>
        public Call(Floor floor, Car car)
        {
            Floor = floor;
            Car = car;
            Id = GetNextId();
        }

        /// <summary>
        /// Remove a Call from the datastore once it has been serviced.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Delete()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the next ID that should be assigned to a call.  When this feature
        /// is complete, this method will no longer be needed because the Building.GetCar
        /// method will get it from the datastore.
        /// </summary>
        /// <returns></returns>
        private int GetNextId()
        {
#warning "GetNextId is temporary code until there is a real datastore that stores Calls."
            return ++_nextId;
        }
    }
}
