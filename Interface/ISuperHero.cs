namespace ProyectoFinal.Interface
{
    public interface ISuperHero
    {
        string Name { get; }
        string SpecialPower { get; }
        int Strength { get; }
        int Health { get; set; }
        string LastInfirmaryVisitResult { get; set; }
        string LastAttackResult { get; set; }    
        string LastDefendResult { get; set; }

        void Attack();
        void Defend();
    }
}
