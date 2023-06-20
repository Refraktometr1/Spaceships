using System.Collections.Generic;
using Codebase.Services;
using Codebase.Spaceships;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Codebase
{
    public class GameFactory : MonoBehaviour
    {
        public Button Button;
        public Canvas Canvas;
        [SerializeField] private GameObject gunPrefab;

        private void Awake()
        {
            Button.onClick.AddListener(ButtonClick);
            StaticDataService.Load();
        }

        public void ButtonClick()
        {
            CreateShip(ShipType.Enterprise, 2);
        }

        public void CreateShip(ShipType shipType, int level)
        {
            var shipStaticData = StaticDataService.GetSpaceshipData(shipType);
            GameObject spaceshipGameObject = Instantiate(shipStaticData.shipPrefab, Canvas.transform);
            var slotsGO = spaceshipGameObject.GetComponent<SpaceshipSlots>();
            
            var spaceship = new Spaceship();
            
            spaceship.Hp = shipStaticData.BaseHp;
            spaceship.Speed = shipStaticData.BaseSpeed;
            spaceship.Type = shipType;
            spaceship.Slots = new List<ShipSlotItem>(shipStaticData.Slots.Count);
                
            for (int i = 0; i < shipStaticData.Slots.Count; i++)
            {
                int slotItemTypeIndex = (int) shipStaticData.Slots[i].SlotItemType; 
                if (slotItemTypeIndex < 100)
                {
                    var gunStatic = StaticDataService.GetGunData(shipStaticData.Slots[i].SlotItemType);
                    gunPrefab.GetComponent<Image>().sprite = gunStatic.Sprite;
                    
                    var gunGameObject = Instantiate(gunPrefab, slotsGO.Slots[i].transform);

                    var gun = gunGameObject.AddComponent<ShipGun>();
                    gun.SlotItemType = shipStaticData.Slots[i].SlotItemType;
                    gun.SlotType = shipStaticData.Slots[i].SlotType;
                    
                    gun.Barrels = gunStatic.Barrels;
                    gun.Hp = gunStatic.Hp;
                    gun.Level = shipStaticData.Slots[i].Level;
                    gun.EnergyShield = gunStatic.EnergyShield;
                    gun.RegeneratorHp = gunStatic.RegeneratorHp;
                    
                }
            }
        }
    }
}