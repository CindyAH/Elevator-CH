using Microsoft.AspNetCore.Mvc;
using ElevatorModels;

namespace ElevatorCH.Controllers
{
    /// <summary>
    /// ElevatorDispatchController is an API for the functions necessary to run the elevators
    /// in a building with multiple elevators (cars) and multiple floors.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ElevatorDispatchController : ControllerBase
    {
        private static readonly Building _building = new Building();
        private readonly ILogger<ElevatorDispatchController> _logger;
        public ElevatorDispatchController(ILogger<ElevatorDispatchController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Given the floor name, requests an elevator (TBD) be sent to that floor.  Create a Call
        /// in the Building's datastore, and return a response. 
        /// </summary>
        /// <param name="floorName">The user-friendly name of the floor</param>
        /// <exception cref="NotFoundObjectResult"></exception>
        /// <returns>the new Call created</returns>
        [HttpPost]
        [Route("CallCar")]
        public IActionResult CallCar(string floorName)
        {
            var floor = _building.GetFloor(floorName);
            if (floor == null)
            {
                return NotFound($"There is no floor with the name {floorName}");
            }

            var call = new Call(floor);
            _building.AddCall(call);

            return Created(new Uri(Request.Path, UriKind.Relative), call);
        }

        /// <summary>
        /// Given the floor name and elevator number, requests that the car be sent to
        /// that floor to let people in that elevator out at that floor.  Create a Call
        /// in the Building's datastore, and return a response. 
        /// </summary>
        /// <exception cref="NotFoundObjectResult"></exception>
        /// <param name="floorName">The user-friendly name of the floor</param>
        /// <returns>the new Call created</returns>
        [HttpPost]
        [Route("StopCar")]
        public IActionResult StopCar(string floorName, int carId)
        {
            var floor = _building.GetFloor(floorName);
            if (floor == null)
            {
                return NotFound(value: $"There is no floor with the name {floorName}");
            }

            var car = _building.GetCar(carId);
            if (car == null)
            {
                return NotFound(value: $"There is no elevator car with the ID number {carId}");
            }

            var call = new Call(floor, car);
            _building.AddCall(call);

            return Created(new Uri(Request.Path, UriKind.Relative), call);
        }

        /// <summary>
        /// GetNextCallForCar returns the next car the elevator car should go to, based on
        /// the datastore containing all the requests that have been made.  The caller can
        /// get the Floor from the Call.
        /// </summary>
        /// <param name="carId"></param>
        /// <exception cref="NotFoundObjectResult"></exception>
        /// <returns></returns>
        [HttpGet]
        [Route("GetNextCallForCar")]
        public IActionResult GetNextCallForCar(int carId)
        {
            Call? call;
            call = _building.NextCallForCar(carId);

            if (call == null)
            {
                return NotFound(value: $"This elevator doesn't have any pending floor calls");
            }

            return Ok(call);
        }

        /// <summary>
        /// GetAllFloorsForCar returns all Calls that are in the specified Car's queue.
        /// </summary>
        /// <param name="carId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllFloorsForCar")]
        public IActionResult GetAllFloorsForCar(int carId)
        {
            var floors = _building.AllFloorsForCar(carId);
            if (floors == null || ! floors.Any())
            { 
                return NotFound(value: $"This elevator doesn't have any pending floor to service");
            }

            return Ok(floors);
        }
    }
}
