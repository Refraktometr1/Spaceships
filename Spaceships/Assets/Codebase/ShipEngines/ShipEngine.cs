using Codebase.Spaceships;

namespace Codebase.ShipEngines
{
    public class ShipEngine :  ShipSlotItem , IShipAccelerator
    {
        public int MovePower;
        
        public int GetPower() => MovePower;
    }
}