namespace Codebase.Spaceships
{
    public enum ShipSlotItemType
    {
        None = 0,
        
        //Guns
        MachineGunLight = 10,
        MachineGunDoubleMedium = 20,
        PlasmaCannonLight = 30,
        PlasmaCannonDoubleMedium = 40,
        MachineGunDoublePlasmaCannonDoubleHeavy = 50,
        MachineGunPlasmaCannonEnergyShieldHeavy = 51,
        
        //Engines
        SmallEngineMedium = 110,
        LargeEngineHeavy = 120,
        
        //Items
        EnergyShieldMedium = 301,
        HpRegeneratorLight = 302,
    }
}