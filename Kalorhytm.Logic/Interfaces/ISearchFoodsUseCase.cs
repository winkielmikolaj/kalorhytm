using Kalorhytm.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalorhytm.Logic.Interfaces
{

    public interface ISearchFoodsUseCase
    {
        Task<List<FoodModel>> ExecuteAsync(string searchTerm);
    }
}
