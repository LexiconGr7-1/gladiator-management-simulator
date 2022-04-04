namespace Gladiator.Presentation.Models
{
    public static class GladiatorList
    {
        public static int IDcount;
        public static List<Gladiator> Gladiators { get; set; }
        static GladiatorList()
        {
           Gladiators = new List<Gladiator>();
           IDcount = 1;
        }
        public static void AddGladiator(Gladiator gladiator)
        {
            if (gladiator.Id > IDcount)
            { IDcount = gladiator.Id; }
            if (gladiator.Id == 0)
            {
                gladiator.Id = IDcount;
                IDcount = IDcount + 1;
            }
            Gladiators.Add(gladiator);
            
        }
        public static void RemoveGladiator(int id)
        {
            int a = Gladiators.FindIndex(x => Convert.ToInt32(x.Id) == id);

            if (a > -1)
            { Gladiators.RemoveAt(a); }

        }
    }
}

