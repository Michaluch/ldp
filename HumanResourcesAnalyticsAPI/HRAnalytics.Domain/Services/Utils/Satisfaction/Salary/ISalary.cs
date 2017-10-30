using HRAnalytics.Domain.Models;

namespace HRAnalytics.Domain.Services.Utils.Satisfaction.Salary
{
    public interface ISalary
    {
        double GetSalaryScore(PredictDismissalRequest request);
        double GetTimeSalaryScore(PredictDismissalRequest request, double satisfactionScore);
    }
}
