using Kalorhytm.Contracts;
using Kalorhytm.Contracts.Models;
using Kalorhytm.Domain.Enums;
using Kalorhytm.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kalorhytm.WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class MealEntriesController : ControllerBase
    {
        private readonly IAddMealEntryUseCase _addMealEntryUseCase;
        private readonly IGetDailyNutritionUseCase _getDailyNutritionUseCase;

        public MealEntriesController(
            IAddMealEntryUseCase addMealEntryUseCase,
            IGetDailyNutritionUseCase getDailyNutritionUseCase)
        {
            _addMealEntryUseCase = addMealEntryUseCase;
            _getDailyNutritionUseCase = getDailyNutritionUseCase;
        }

        /// <summary>
        /// Pobiera dzienne podsumowanie żywieniowe dla określonej daty
        /// </summary>
        /// <param name="date">Data w formacie yyyy-MM-dd (opcjonalnie, domyślnie dzisiaj)</param>
        /// <returns>Dzienne podsumowanie żywieniowe</returns>
        [HttpGet("daily")]
        [ProducesResponseType(typeof(DailyNutritionModel), 200)]
        public async Task<ActionResult<DailyNutritionModel>> GetDailyNutrition([FromQuery] DateTime? date)
        {
            var targetDate = date ?? DateTime.Today;
            var dailyNutrition = await _getDailyNutritionUseCase.ExecuteAsync(targetDate);
            return Ok(dailyNutrition);
        }

        /// <summary>
        /// Dodaje wpis posiłku
        /// </summary>
        /// <param name="request">Dane posiłku</param>
        /// <returns>Dodany wpis posiłku</returns>
        [HttpPost]
        [ProducesResponseType(typeof(MealEntryModel), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<MealEntryModel>> AddMealEntry([FromBody] AddMealEntryRequest request)
        {
            if (request.Food == null)
            {
                return BadRequest("Food cannot be null");
            }

            if (request.Quantity <= 0)
            {
                return BadRequest("Quantity must be greater than 0");
            }

            var mealEntry = await _addMealEntryUseCase.ExecuteAsync(
                request.Food,
                request.Quantity,
                request.MealType,
                request.Date ?? DateTime.Today
            );

            return CreatedAtAction(nameof(GetDailyNutrition), new { date = mealEntry.Date }, mealEntry);
        }

        /// <summary>
        /// Dodaje wpis posiłku używając ID produktu
        /// </summary>
        /// <param name="foodId">ID produktu</param>
        /// <param name="quantity">Ilość w gramach</param>
        /// <param name="mealType">Typ posiłku</param>
        /// <param name="date">Data (opcjonalnie, domyślnie dzisiaj)</param>
        /// <returns>Dodany wpis posiłku</returns>
        [HttpPost("{foodId}")]
        [ProducesResponseType(typeof(MealEntryModel), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<MealEntryModel>> AddMealEntryById(
            [FromRoute] int foodId,
            [FromQuery] double quantity,
            [FromQuery] MealType mealType,
            [FromQuery] DateTime? date)
        {
            if (quantity <= 0)
            {
                return BadRequest("Quantity must be greater than 0");
            }

            var mealEntry = await _addMealEntryUseCase.ExecuteAsync(
                foodId,
                quantity,
                mealType,
                date ?? DateTime.Today
            );

            return CreatedAtAction(nameof(GetDailyNutrition), new { date = mealEntry.Date }, mealEntry);
        }
    }

    /// <summary>
    /// Request model do dodawania wpisu posiłku
    /// </summary>
    public class AddMealEntryRequest
    {
        /// <summary>
        /// Produkt spożywczy
        /// </summary>
        public FoodModel? Food { get; set; }

        /// <summary>
        /// Ilość w gramach
        /// </summary>
        public double Quantity { get; set; }

        /// <summary>
        /// Typ posiłku (Breakfast, SecondBreakfast, Lunch, Snack, Dinner)
        /// </summary>
        public MealType MealType { get; set; }

        /// <summary>
        /// Data posiłku (opcjonalnie, domyślnie dzisiaj)
        /// </summary>
        public DateTime? Date { get; set; }
    }
}

