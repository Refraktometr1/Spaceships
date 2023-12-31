﻿using System.Collections.Generic;
using Codebase.Spaceships;
using UnityEngine;

namespace Codebase.StaticData
{
    [CreateAssetMenu(fileName = "SpaceshipData", menuName = "Static Data/Spaceship")]
    public class SpaceshipStaticData : ScriptableObject
    {
        public ShipType Type;
        
        [Range(1,20)]
        public int BaseHp;
        
        [Range(1,20)]
        public int BaseSpeed;

        [Range(1,99)]
        public int Level;

        public List<ShipSlotItemData> Slots;

        public GameObject shipPrefab;
    }
}