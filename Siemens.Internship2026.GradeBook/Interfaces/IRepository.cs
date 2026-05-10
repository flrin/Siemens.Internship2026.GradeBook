using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Interfaces;

public interface IRepository
{
    Task<Item?> GetByIdAsync(int id);
    Task<IEnumerable<Item>> GetAllAsync();
    Task<int> GetItemTotalCountAsync();
    Task<decimal> GetAverageItemValueAsync();
}
