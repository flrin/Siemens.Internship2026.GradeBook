namespace Siemens.Internship2026.GradeBook.Interfaces
{
    public interface IItemStatisticsRepository
    {
        Task<int> GetItemTotalCountAsync();
        Task<decimal> GetAverageItemValueAsync();
    }
}