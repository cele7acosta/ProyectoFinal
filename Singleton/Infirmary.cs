using ProyectoFinal.Interface;

namespace ProyectoFinal.Singleton
{
    public class Infirmary
    {
        private static Infirmary _instance;
        private int _remainingVisits;

        private Infirmary()
        {
            _remainingVisits = 5; 
        }

        public static Infirmary GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Infirmary();
            }
            return _instance;
        }

        public void VisitInfirmary(ISuperHero hero, int numberOfVisits)
        {
            if (_remainingVisits <= 0)
            {
                hero.LastInfirmaryVisitResult = "No more visits available in the infirmary.";
                return;
            }

            int allowedVisits = Math.Min(numberOfVisits, _remainingVisits);

            int successfulHeals = 0;
            string resultMessage = string.Empty;

            for (int i = 0; i < allowedVisits; i++)
            {
                if (hero.Health < 5) 
                {
                    hero.Health++;
                    successfulHeals++;
                }
                else
                {
                    break;
                }
            }

            _remainingVisits -= successfulHeals;

            resultMessage = successfulHeals > 0
            ? $"Hero {hero.Name} visited the infirmary {successfulHeals} time(s). Health is now {hero.Health}. Remaining visits: {_remainingVisits}."
            : $"Hero {hero.Name} already has maximum health. No healing applied.";

            hero.LastInfirmaryVisitResult = resultMessage;
        }

        public int GetRemainingVisits()
        {
            return _remainingVisits;
        }
    }
}
