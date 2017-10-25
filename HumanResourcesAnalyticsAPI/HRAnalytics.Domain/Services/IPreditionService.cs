using HRAnalytics.Domain.Models;

namespace HRAnalytics.Domain.Services
{
    public interface IPreditionService
    {
        PredictDismissalResponse PredictDismissal(PredictDismissalRequest request);
    }
}
