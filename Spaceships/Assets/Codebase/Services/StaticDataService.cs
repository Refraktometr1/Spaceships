using System.Collections.Generic;
using System.Linq;
using Codebase.Spaceships;
using Codebase.StaticData;
using UnityEngine;

namespace Codebase.Services
{
    public static class StaticDataService 
    {
        private const string GunsDataPath = "StaticData/Guns";
        private const string ShipDataPath = "StaticData/Ships";
        private const string EnginesDataWindowPath = "Static Data/Engines";


        private static Dictionary<ShipSlotItemType, GunStaticData> _guns;
        private static Dictionary<ShipType,SpaceshipStaticData> _spaceships;

        public static void Load()
        {
            _guns = Resources.LoadAll<GunStaticData>(GunsDataPath).ToDictionary(x => x.ShipSlotItemType, x => x);
            _spaceships = Resources.LoadAll<SpaceshipStaticData>(ShipDataPath).ToDictionary(x => x.Type, x => x);
        }

        public static GunStaticData GetGunData(ShipSlotItemType gunType) => 
            _guns.TryGetValue(gunType, out GunStaticData gunStaticData) ? gunStaticData : null;
        
        public static SpaceshipStaticData GetSpaceshipData(ShipType shipType) => 
            _spaceships.TryGetValue(shipType, out SpaceshipStaticData spaceshipStaticData) ? spaceshipStaticData : null;
    }
}