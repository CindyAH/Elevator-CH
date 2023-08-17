namespace ElevatorModels
{
    /// <summary>
    /// The Building class contains the datastore definitions of the Floors,
    /// Cars, and Calls, and business logic to use them.  Most of the code
    /// will be replaced as the application is developed.  The datastore
    /// is hardcoded and non-persistent, and the methods are mostly stubs.
    /// </summary>
    public class Building
    {
        /// <summary>
        /// List of all the <see cref="Floor"></see> in the building
        /// </summary>
        public List<Floor> Floors { get; }

        /// <summary>
        /// List of all the <see cref="Car"></see> in the building
        /// </summary>
        public List <Car> Cars { get; }

        /// <summary>
        /// List of all the <see cref="Call"></see> in the building
        /// </summary>
        public List <Call> Calls { get; set; } = new List<Call>();

        /// <summary>
        /// Constructor for Building with hardcoded Floors and Cars
        /// </summary>
        public Building() 
        {
            Cars = new List<Car>()
            {
                new Car(1), 
                new Car(2), 
                new Car(3, false), 
                new Car(4)
            };

            Floors = new List<Floor>()
            {
                new Floor (0, "P1"),
                new Floor (1, "P2", false),
                new Floor (2, "Amenities"),
                new Floor (3, "1"),
                new Floor (4, "2"),
                new Floor (5, "3")
            };
        }

        /// <summary>
        /// Get the Car object given the Id.
        /// </summary>
        /// <param name="id">Id of the Car to be returned.</param>
        /// <returns>the Car object matching the Id, if found.</returns>
        public Car? GetCar(int id)
        {
            Car? car = Cars.FirstOrDefault(c => c.Id == id);
            return car;
        }

        /// <summary>
        /// Get the Floor object given the user-friendly name.
        /// </summary>
        /// <param name="name">Name of the floor to be returned.</param>
        /// <returns>the Floor matching the Name, if found.</returns>
        public Floor? GetFloor(string name)
        {
            name = name.ToLower();
            Floor? floor = Floors.FirstOrDefault(f => f.Name.ToLower() == name.ToLower());
            return floor;
        }

        /// <summary>
        /// Add a Call (Car/Floor combination) to the datastore. 
        /// </summary>
        /// <param name="call">the Call to add to the datastore.</param>
        public void AddCall(Call call)
        {
#warning "This creates duplicate calls and puts duplicate calls in the datastore"

            Calls.Add(call);
        }

        /// <summary>
        /// Return the appropriate car to go to the floor to meet the next call
        /// request.  
        /// </summary>
        /// <returns></returns>
        public Car GetCar()
        {
            #warning "This is random - use proper math to get the best next car"
            Random rnd = new Random();
            int randIndex = rnd.Next(Cars.Count);
            return Cars[randIndex];
        }

        /// <summary>
        /// Return the next Call this Car should service.
        /// </summary>
        /// <param name="carId"></param>
        /// <returns>The next Call? for this Car to service.</returns>
        public Call? NextCallForCar(int carId)
        {
            #warning "This is next in the queue, not the 'best' - use proper math to get the best next floor"
            return Calls.FirstOrDefault(c => c.Car.Id == carId);
        }

        /// <summary>
        /// Return all Floors this Car should service.
        /// </summary>
        /// <param name="carId"></param>
        /// <returns>The next Call? for this Car to service.</returns>
        public List<Floor> AllFloorsForCar(int carId)
        {
            #warning "This is next in the queue, not the 'best' - use proper math to get the best next floor"
            return Calls.Where(c => c.Car.Id == carId).Select(c => c.Floor).ToList();
        }
    }
}
