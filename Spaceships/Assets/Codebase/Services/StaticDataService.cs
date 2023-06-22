using System.Collections.Generic;
using System.Linq;
using Codebase.Spaceships;
using Codebase.StaticData;
using UnityEngine;

namespace Codebase.Services
{
    public class StaticDataService 
    {
        private const string ShipDataPath = "StaticData/Ships";
        private const string GunsDataPath = "StaticData/Guns";
        private const string EnginesDataPath = "StaticData/Engines";
        private const string ItemDataPath = "StaticData/Items";


        private static Dictionary<ShipType,SpaceshipStaticData> _spaceships;
        private static Dictionary<ShipSlotItemType, GunStaticData> _guns;
        private static Dictionary<ShipSlotItemType, EngineStaticData> _engines;
        private static Dictionary<ShipSlotItemType, ItemStaticData> _items;

        public void Load()
        {
            _spaceships = Resources.LoadAll<SpaceshipStaticData>(ShipDataPath).ToDictionary(x => x.Type, x => x);
            _guns = Resources.LoadAll<GunStaticData>(GunsDataPath).ToDictionary(x => x.ShipSlotItemType, x => x);
            _engines = Resources.LoadAll<EngineStaticData>(EnginesDataPath).ToDictionary(x => x.ShipSlotItemType, x => x);
            _items = Resources.LoadAll<ItemStaticData>(ItemDataPath).ToDictionary(x => x.ShipSlotItemType, x => x);
        }

        public SpaceshipStaticData GetSpaceshipData(ShipType shipType) =>
            _spaceships.TryGetValue(shipType, out SpaceshipStaticData spaceshipStaticData) ? spaceshipStaticData : null;

        public GunStaticData GetGunData(ShipSlotItemType gunType) => 
            _guns.TryGetValue(gunType, out GunStaticData gunStaticData) ? gunStaticData : null;

        public EngineStaticData GetEngineData(ShipSlotItemType slotItemType) => 
            _engines.TryGetValue(slotItemType, out EngineStaticData engineStaticData) ? engineStaticData : null;

        public ItemStaticData GetItemData(ShipSlotItemType slotItemType) => 
            _items.TryGetValue(slotItemType, out ItemStaticData itemStaticData) ? itemStaticData : null;
    }
}