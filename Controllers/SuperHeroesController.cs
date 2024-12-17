using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Request;
using ProyectoFinal.Factory;
using ProyectoFinal.Interface;
using ProyectoFinal.Singleton;

namespace ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroesController : ControllerBase
    {
        private static List<ISuperHero> _heroes = new();

        [HttpPost]
        [Route("create")]
        public IActionResult CreateSuperHero([FromBody] CreateHeroRequest request)
        {
            var existingHero = _heroes.FirstOrDefault(h => h.Name.Equals(request.Name, StringComparison.OrdinalIgnoreCase));
            if (existingHero != null)
            {
                return BadRequest(new
                {
                    Message = "A hero with this name already exists."
                });
            }

            var hero = SuperHeroFactory.CreateSuperHero(request.Type, request.Name);
            _heroes.Add(hero);

            return Ok(new
            {
                hero.Name,
                hero.SpecialPower,
                hero.Strength,
                hero.Health
            });
        }

        [HttpPost]
        [Route("attack")]
        public IActionResult AttackHero([FromBody] AttackHeroRequest request)
        {
            var hero = _heroes.FirstOrDefault(h => h.Name == request.Name);

            if (hero == null)
                return NotFound("Hero not found");

            hero.Attack();
            return Ok(new
            {
                hero.Name,
                hero.Health,
                Message = hero.LastAttackResult  
            });
        }

        [HttpPost]
        [Route("defend")]
        public IActionResult DefendHero([FromBody] DefendHeroRequest request)
        {
            var hero = _heroes.FirstOrDefault(h => h.Name == request.Name);

            if (hero == null)
                return NotFound("Hero not found");

            hero.Defend();

            return Ok(new
            {
                hero.Name,
                hero.Health,
                Message = hero.LastDefendResult  
            });
        }

        [HttpPost]
        [Route("visit-infirmary")]
        public IActionResult VisitInfirmary([FromBody] VisitInfirmaryRequest request)
        {
            if (request.NumberOfVisits <= 0)
            {
                return BadRequest(new
                {
                    Message = "The number of visits must be greater than zero."
                });
            }
            var hero = _heroes.FirstOrDefault(h => h.Name == request.Name);

            if (hero == null)
                return NotFound("Hero not found");

           
            var infirmary = Infirmary.GetInstance();
            infirmary.VisitInfirmary(hero, request.NumberOfVisits);

            return Ok(new
            {
                hero.Name,
                hero.Health,
                RemainingVisits = infirmary.GetRemainingVisits(),
                Message = hero.LastInfirmaryVisitResult  
            });
            
        }

    }
}
