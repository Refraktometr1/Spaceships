using Codebase.Services;
using Codebase.ShipEngines;
using Codebase.Spaceships;
using Codebase.StaticData;
using UnityEngine;
using UnityEngine.UI;

namespace Codebase
{
    public class GameFactory
    {
        private GameObject _mainCanvas;
        private GameObject _slotPrefab;
        private StaticDataService _staticDataService;

        private const int HpLevelUpgradeCoefficient = 2;
        private const int SpeedLevelUpgradeCoefficient = 2;


        public GameFactory(GameObject mainCanvas, GameObject slotPrefab, StaticDataService staticDataService)
        {
            _mainCanvas = mainCanvas;
            _slotPrefab = slotPrefab;
            _staticDataService = staticDataService;
        }

        public void CreateShip(ShipType shipType, int level)
        {
            SpaceshipStaticData shipStaticData = _staticDataService.GetSpaceshipData(shipType);
            GameObject spaceshipGameObject = Object.Instantiate(shipStaticData.shipPrefab, _mainCanvas.transform);
            var slotsGO = spaceshipGameObject.GetComponent<SpaceshipSlots>();

            var spaceship = spaceshipGameObject.AddComponent<Spaceship>();

            spaceship.Level = shipStaticData.Level;
            spaceship.Hp = shipStaticData.BaseHp * (HpLevelUpgradeCoefficient * spaceship.Level);
            spaceship.Speed = shipStaticData.BaseSpeed * (SpeedLevelUpgradeCoefficient * spaceship.Level);
            spaceship.Type = shipType;

            for (int i = 0; i < shipStaticData.Slots.Count; i++)
            {
                int slotItemTypeIndex = (int) shipStaticData.Slots[i].SlotItemType;
                
                if (slotItemTypeIndex == 0)
                {
                    Debug.Log($"slot {i} is empty");
                    continue;
                }
                
                if (slotItemTypeIndex < 100)
                {
                    var gunStatic = _staticDataService.GetGunData(shipStaticData.Slots[i].SlotItemType);
                    _slotPrefab.GetComponent<Image>().sprite = gunStatic.Sprite;
                    
                    var gunGameObject = Object.Instantiate(_slotPrefab, slotsGO.Slots[i].transform);

                    var gun = gunGameObject.AddComponent<ShipGun>();
                    gun.SlotItemType = shipStaticData.Slots[i].SlotItemType;
                    gun.SlotType = shipStaticData.Slots[i].SlotType;
                    
                    gun.Barrels = gunStatic.Barrels;
                    gun.Hp = gunStatic.Hp;
                    gun.Level = shipStaticData.Slots[i].Level;
                    gun.EnergyShield = gunStatic.EnergyShield;
                    gun.RegeneratorHp = gunStatic.RegeneratorHp;
                }

                if (slotItemTypeIndex is > 100 and < 300)
                {
                    var engineStatic = _staticDataService.GetEngineData(shipStaticData.Slots[i].SlotItemType);
                    _slotPrefab.GetComponent<Image>().sprite = engineStatic.Sprite;
                    
                    var engineGameObject = Object.Instantiate(_slotPrefab, slotsGO.Slots[i].transform);
                    
                    var engine = engineGameObject.AddComponent<ShipEngine>();
                    
                    engine.Level = shipStaticData.Slots[i].Level;
                    engine.SlotItemType = shipStaticData.Slots[i].SlotItemType;
                    engine.SlotType = shipStaticData.Slots[i].SlotType;

                    engine.MovePower = engineStatic.MovePower;
                }

                if (slotItemTypeIndex > 300)
                {
                    var itemStatic = _staticDataService.GetItemData(shipStaticData.Slots[i].SlotItemType);
                    _slotPrefab.GetComponent<Image>().sprite = itemStatic.Sprite;
                    
                    var slotGameObject = Object.Instantiate(_slotPrefab, slotsGO.Slots[i].transform);
                    
                    var item = slotGameObject.AddComponent<ShipSlotItem>();

                    item.Level = shipStaticData.Slots[i].Level;
                    item.SlotItemType = shipStaticData.Slots[i].SlotItemType;
                    item.SlotType = shipStaticData.Slots[i].SlotType;
                    
                    item.EnergyShield = itemStatic.EnergyShield;
                    item.RegeneratorHp = itemStatic.RegeneratorHp;
                }
            }
        }
    }
}