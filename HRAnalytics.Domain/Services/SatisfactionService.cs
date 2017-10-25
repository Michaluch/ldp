using HRAnalytics.Domain.Models;

namespace HRAnalytics.Domain.Services
{
    public class SatisfactionService : ISatisfactionService
    {
        private const int NOT_APPLICABLE = -1;
        private const double LEVEL_OK = 70;
        private const double LOW_LEVEL = 50;
        private const double NOT_LOW_LEVEL = 65;
        private int COUNT = 3;

        public double GetSatisfactionLevel(PredictDismissalRequest request)
        {
            return (
                GetLastPAScore(request.LastPerformanceAppraisalScore) + 
                GetPrevPAScore(request.PreviousPerformanceAppraisalScore) +
                GetSalaryScore(request.LastSalaryReviewPercentage)
            ) / COUNT;
        }

        private double GetLastPAScore(double score)
        {
            if (score == NOT_APPLICABLE)
            {
                return LEVEL_OK;
            } else
            {
                return score < 97 ? LOW_LEVEL : (score * 0.01) * LEVEL_OK;
            }
        }

        private double GetPrevPAScore(double score)
        {
            return score == NOT_APPLICABLE ? LEVEL_OK : (score * 0.01) * LEVEL_OK;
        }

        private double GetSalaryScore(double score)
        {
            if (score >= 0 && score < 5) return LOW_LEVEL;
            if (score >= 5 && score < 25) return NOT_LOW_LEVEL;
            if (score >= 25 && score < 50) return LEVEL_OK;

            return score;
        }
    }
}
