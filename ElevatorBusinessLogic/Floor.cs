namespace ElevatorModels
{
    /// <summary>
    /// Floor is a floor of a building that is served by one or more elevators.
    /// </summary>
    public class Floor
    {
        /// <summary>
        /// Id is the absolute order of the floor, with 0 being the bottom floor.  It doesn't 
        /// matter where the floor is in relation to the ground or the sky, only where the floor 
        /// is in relation to the other floors.  Example: Garage 2 == 0, Garage 1 == 1, Lobby == 2, 
        /// Clubhouse == 3, 1 == 4, Roof == the biggest number
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name is the public name of the floor - 1, 2, 3, Parking, Lobby, Penthouse, etc.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// IsInService specifies whether an entire floor is shut down, as for a private event or a hazard.
        /// </summary>
        public bool IsInService { get; set; }

        /// <summary>
        /// Create a Floor.
        /// </summary>
        /// <param name="id">ordinal from the ground up, starting with zero</param>
        /// <param name="name">user-friendly name, such as "P1", "pool", "1", "2", "Penthouse"</param>
        /// <param name="inService">Is the floor accessible now?</param>
        public Floor(int id, string name, bool inService = true)
        {
            Id = id;
            Name = name;
            IsInService = inService;
        }
    }
}