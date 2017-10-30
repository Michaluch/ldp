namespace HRAnalytics.Domain.Services.Utils.Satisfaction.PA
{
    public interface IPerformanceAppraisal
    {
        double GetLastSatisfactionScore(double value);
        double GetPrevSatisfactionScore(double value);
        double GetTimeSatisfactionScore(int months, double lastSatisfactionPAScore);
    }
}
