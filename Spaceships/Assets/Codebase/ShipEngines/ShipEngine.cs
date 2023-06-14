using Codebase.Spaceships;

namespace Codebase.ShipEngines
{
    public class ShipEngine :  ShipSlotItem , IShipAccelerator
    {
        private int _movePower;
        
        public int GetPower() => _movePower;
    }
}