namespace HRAnalytics.Domain.Services.Utils.Satisfaction.PA
{
    public class JuniorPerformanceAppraisal : IPerformanceAppraisal
    {
        public double GetLastSatisfactionScore(double value)
        {
            if (value == SatisfactionConst.NOT_APPLICABLE)
            {
                return SatisfactionConst.LEVEL_OK;
            }
            else
            {
                return value < 97 ? SatisfactionConst.LOW_LEVEL : (value * 0.01) * SatisfactionConst.LEVEL_OK;
            }
        }

        public double GetPrevSatisfactionScore(double value)
        {
            return value == SatisfactionConst.NOT_APPLICABLE ? SatisfactionConst.LEVEL_OK : (value * 0.01) * SatisfactionConst.LEVEL_OK;
        }

        public double GetTimeSatisfactionScore(int months, double lastSatisfactionPAScore)
        {
            double result = 0;

            if (months > 0)
            {
                result = months == 2 ? 0.1 : 0.05;
            }
                    
            return 1 + (lastSatisfactionPAScore >= SatisfactionConst.LEVEL_OK ? result : -result);
        }
    }
}
