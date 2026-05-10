using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Interfaces
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> GetAllAsync(int? first);
        Task<Item?> GetByIdAsync(int id);
    }
}