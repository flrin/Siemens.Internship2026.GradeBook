namespace Siemens.Internship2026.GradeBook.Interfaces
{
    public interface IItemStatisticsService
    {
        Task<decimal> GetAverageItemValueAsync();
        Task<int> GetItemTotalCountAsync();
    }
}