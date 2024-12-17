using ProyectoFinal.Interface;
using ProyectoFinal.Model;

namespace ProyectoFinal.Factory
{
    public static class SuperHeroFactory
    {
        public static ISuperHero CreateSuperHero(string type, string name)
        {
            return type.ToLower() switch
            {
                "warrior" => new Warrior(name),
                "mage" => new Mage(name),
                "archer" => new Archer(name),
                _ => throw new ArgumentException("Invalid superhero type")
            };
        }
    }
}
