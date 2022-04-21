namespace Gladiator.Application.Gladiator.Responses
{
    public class GladiatorFullResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Health { get; set; }
        public int Experience { get; set; }
        public int MaxGearSlots { get; set; }
        public int OccupiedGearSlots { get; set; }
        public int MaxGearWeight { get; set; }
        public int GearWeight { get; set; }
        public int Armour { get; set; }
        public int Damage { get; set; }
        public int BlockingStrength { get; set; }
        public int AttackStrength { get; set; }
        public int Constitution { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }

        public GladiatorStatsResponse Stats { get; set; }
        public GladiatorStatsResponse StatUpdates { get; set; }
        public GladiatorArenaResponse Arena { get; set; }
        public GladiatorSchoolResponse School { get; set; }
        public GladiatorPlayerResponse Player { get; set; }
        public List<GladiatorGearResponse> Gear { get; set; }
    }

    public class GladiatorStatsResponse
    {
        public int Constitution { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }
    }

    public class GladiatorArenaResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class GladiatorSchoolResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class GladiatorPlayerResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class GladiatorGearResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }
        public int Durability { get; set; }
        public int Slots { get; set; }
        public int Weight { get; set; }
        public GladiatorStatsResponse StatModifiersPoints { get; set; }
        public GladiatorStatsResponse StatModifiersPercent { get; set; }
    }
}
