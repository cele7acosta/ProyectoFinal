using ProyectoFinal.Interface;

namespace ProyectoFinal.Model
{
    public class Archer : ISuperHero
    {
        public string Name { get; private set; }
        public string SpecialPower => "Arrow Shot";
        public int Strength => 7;
        public int Health { get; set; }
        public string LastInfirmaryVisitResult { get; set; }
        public string LastAttackResult { get; set; }
        public string LastDefendResult { get; set; }

        private Random _random;
        public Archer(string name)
        {
            Name = name;
            Health = 5; 
            _random = new Random();
        }

        public void Attack()
        {
            int damage = _random.Next(1,4); 
            Health = Math.Max(Health - damage, 0);

            LastAttackResult = Health > 0
                ? $"Hero {Name} was attacked. Lost {damage} health. Current health: {Health}."
                : $"Hero {Name} has no health left to be attacked.";
        }

        public void Defend()
        {
            int damage = _random.Next(1, 4); 
            Health = Math.Max(Health - damage, 0);

            LastDefendResult = Health > 0
                ? $"Hero {Name} defended against the attack. Lost {damage} health. Current health: {Health}."
                : $"Hero {Name} has no health left to defend.";
        }
    }
}
