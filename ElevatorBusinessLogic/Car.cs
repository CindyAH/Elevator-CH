using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorModels
{
    /// <summary>
    /// A Car is a single elevator.  The terms are used interchangeably.
    /// </summary>
    public class Car
    {
        // todo Add logic and variables for elevators that don't serve all floors.
        
        /// <summary>
        /// Id of the Car is the same as its number.  There is no provision for an elevator
        /// with a name such as "Freight elevator".
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// IsInService specifies whether a car is shut down, if broken.
        /// </summary>
        public bool IsInService { get; set; }

        /// <summary>
        /// Create a Car (elevator).
        /// </summary>
        /// <param name="id">Elevator number</param>
        /// <param name="inService">Is the elevator running now?</param>
        public Car(int id, bool inService = true) 
        { 
            Id = id;
            IsInService = inService;
        }
    }
}
