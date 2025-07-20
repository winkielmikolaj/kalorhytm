using Kalorhytm.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalorhytm.Logic.Interfaces
{
    public interface IGetDailyNutritionUseCase
    {
        Task<DailyNutritionModel> ExecuteAsync(DateTime date);
    }
}
