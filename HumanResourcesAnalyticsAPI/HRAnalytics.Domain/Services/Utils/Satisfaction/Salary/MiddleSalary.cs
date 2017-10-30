using HRAnalytics.Domain.Models;

namespace HRAnalytics.Domain.Services.Utils.Satisfaction.Salary
{
    public class MiddleSalary : ISalary
    {
        public double GetSalaryScore(PredictDismissalRequest request)
        {
            var score = request.LastSalaryReviewPercentage;
            if (score < 0) return SatisfactionConst.MIN_LEVEL;
            if (score >= 0 && score < 10) return SatisfactionConst.LOW_LEVEL;
            if (score >= 10 && score < 18) return SatisfactionConst.NOT_LOW_LEVEL;
            if (score >= 18 && score < 30) return SatisfactionConst.LEVEL_OK;

            return 100;
        }

        public double GetTimeSalaryScore(PredictDismissalRequest request, double satisfactionScore)
        {
            double result = 1;

            if (request.MonthsAfterLastSalaryReview <= 6 || request.MonthsAfterLastPerformanceAppraisal != -1)
            {
                switch (request.MonthsAfterLastSalaryReview)
                {
                    case 0:
                        result = 0;
                        break;
                    case 1:
                        result = 0.2;
                        break;
                    case 2:
                        result = 0.14;
                        break;
                    case 3:
                        result = 0.1;
                        break;
                    case 4:
                        result = 0.06;
                        break;
                    case 5:
                        result = 0.04;
                        break;
                    default:
                        result = 0;
                        break;
                }

                result = 1 + (satisfactionScore >= SatisfactionConst.LEVEL_OK ? result : -result);
            }

            var monthsWithoutSalaryReview = request.MonthsAfterLastSalaryReview - request.MonthsAfterLastPerformanceAppraisal;

            if (monthsWithoutSalaryReview > 0)
            {
                result -=  monthsWithoutSalaryReview * 0.05;
            }

            return result;
        }
    }
}
