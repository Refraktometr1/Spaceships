using System.Collections.Generic;
using System.Linq;
using Codebase.Spaceships;
using Codebase.StaticData;
using UnityEngine;

namespace Codebase.Services
{
    public static class StaticDataService 
    {
        private const string ShipDataPath = "StaticData/Ships";
        private const string GunsDataPath = "StaticData/Guns";
        private const string EnginesDataWindowPath = "StaticData/Engines";


        private static Dictionary<ShipType,SpaceshipStaticData> _spaceships;
        private static Dictionary<ShipSlotItemType, GunStaticData> _guns;
        private static Dictionary<ShipSlotItemType, EngineStaticData> _engines;

        public static void Load()
        {
            _spaceships = Resources.LoadAll<SpaceshipStaticData>(ShipDataPath).ToDictionary(x => x.Type, x => x);
            _guns = Resources.LoadAll<GunStaticData>(GunsDataPath).ToDictionary(x => x.ShipSlotItemType, x => x);
            _engines = Resources.LoadAll<EngineStaticData>(EnginesDataWindowPath).ToDictionary(x => x.ShipSlotItemType, x => x);
        }

        public static SpaceshipStaticData GetSpaceshipData(ShipType shipType) =>
            _spaceships.TryGetValue(shipType, out SpaceshipStaticData spaceshipStaticData) ? spaceshipStaticData : null;

        public static GunStaticData GetGunData(ShipSlotItemType gunType) => 
            _guns.TryGetValue(gunType, out GunStaticData gunStaticData) ? gunStaticData : null;

        public static EngineStaticData GetEngineData(ShipSlotItemType slotItemType) => 
            _engines.TryGetValue(slotItemType, out EngineStaticData engineStaticData) ? engineStaticData : null;
    }
}