namespace HRAnalytics.Domain.Services.Utils.Satisfaction.PA
{
    public class MiddlePerformanceAppraisal : IPerformanceAppraisal
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

            switch (months)
            {
                case 0:
                    result = 0;
                    break;
                case 1:
                    result = 0.1;
                    break;
                case 2:
                    result = 0.07;
                    break;
                case 3:
                    result = 0.05;
                    break;
                case 4:
                    result = 0.3;
                    break;
                case 5:
                    result = 0.01;
                    break;
                default:
                    result = 0;
                    break;
            }

            return 1 + (lastSatisfactionPAScore >= SatisfactionConst.LEVEL_OK ? result : -result);
        }
    }
}
