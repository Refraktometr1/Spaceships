using System.Collections.Generic;
using Codebase.Services;
using Codebase.ShipEngines;
using Codebase.Spaceships;
using Codebase.StaticData;
using UnityEngine;
using UnityEngine.UI;

namespace Codebase
{
    public class GameFactory : MonoBehaviour
    {
        public Button Button;
        public Canvas Canvas;
        
        [SerializeField] private GameObject slotPrefab;
        
        private const int HpLevelUpgradeCoefficient = 2;
        private const int SpeedLevelUpgradeCoefficient = 2;


        private void Awake()
        {
            Button.onClick.AddListener(ButtonClick);
            StaticDataService.Load();
        }

        public void ButtonClick()
        {
            CreateShip(ShipType.Enterprise, 2);
        }

        private void CreateShip(ShipType shipType, int level)
        {
            SpaceshipStaticData shipStaticData = StaticDataService.GetSpaceshipData(shipType);
            GameObject spaceshipGameObject = Instantiate(shipStaticData.shipPrefab, Canvas.transform);
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
                    var gunStatic = StaticDataService.GetGunData(shipStaticData.Slots[i].SlotItemType);
                    slotPrefab.GetComponent<Image>().sprite = gunStatic.Sprite;
                    
                    var gunGameObject = Instantiate(slotPrefab, slotsGO.Slots[i].transform);

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
                    var engineStatic = StaticDataService.GetEngineData(shipStaticData.Slots[i].SlotItemType);
                    slotPrefab.GetComponent<Image>().sprite = engineStatic.Sprite;
                    
                    var engineGameObject = Instantiate(slotPrefab, slotsGO.Slots[i].transform);
                    
                    var engine = engineGameObject.AddComponent<ShipEngine>();
                    
                    engine.Level = shipStaticData.Slots[i].Level;
                    engine.SlotItemType = shipStaticData.Slots[i].SlotItemType;
                    engine.SlotType = shipStaticData.Slots[i].SlotType;

                    engine.MovePower = engineStatic.MovePower;
                }
            }
        }
    }
}