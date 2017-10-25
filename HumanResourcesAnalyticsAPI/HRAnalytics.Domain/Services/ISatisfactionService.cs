using HRAnalytics.Domain.Models;

namespace HRAnalytics.Domain.Services
{
    public interface ISatisfactionService
    {
        double GetSatisfactionLevel(PredictDismissalRequest request);
    }
}
