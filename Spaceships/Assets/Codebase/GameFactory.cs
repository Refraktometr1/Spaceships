using System;
using System.Collections.Generic;
using Codebase.Services;
using Codebase.Spaceships;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Codebase
{
    public class GameFactory : MonoBehaviour
    {
        public Button Button;
        public Canvas canvas;

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
            GameObject spaceshipGameObject = Object.Instantiate(shipStaticData.shipPrefab, canvas.transform);
            var slotsGO = spaceshipGameObject.GetComponent<SpaceshipSlots>();
            
            
            var spaceship = new Spaceship();
            
            spaceship.Hp = shipStaticData.BaseHp;
            spaceship.Speed = shipStaticData.BaseSpeed;
            spaceship.Type = shipType;
            spaceship.Slots = new List<ShipSlotItem>(shipStaticData.Slots.Count);
                
            for (int i = 0; i < shipStaticData.Slots.Count; i++)
            {
                if ((int)shipStaticData.Slots[i].SlotItemType < 100)
                {
                    var gunStatic = StaticDataService.GetGunData(shipStaticData.Slots[i].SlotItemType);
                    var gun = new ShipGun(gunStatic.ShipSlotItemType, gunStatic.Barrels, gunStatic.Hp, shipStaticData.Slots[i].Level, gunStatic.EnergyShield, gunStatic.RegeneratorHp);
                    Object.Instantiate(gunStatic.Prefab, slotsGO.Slots[i].transform);
                }
            }
        }
    }
}