using Codebase.Spaceships;
using Codebase.StaticData;

namespace Codebase.Services
{
    public interface IStaticDataService
    {
        void Load();
        GunStaticData GetGunData(ShipSlotItemType gunType);
    }
}