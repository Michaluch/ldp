using HRAnalytics.Domain.Models;

namespace HRAnalytics.Domain.Services.Utils.Satisfaction.Salary
{
    public class TechLeadSalary : ISalary
    {
        public double GetSalaryScore(PredictDismissalRequest request)
        {
            var score = request.LastSalaryReviewPercentage;
            if (score < 0) return SatisfactionConst.MIN_LEVEL;
            if (score >= 0 && score < 3) return SatisfactionConst.LOW_LEVEL;
            if (score >= 3 && score < 5) return SatisfactionConst.NOT_LOW_LEVEL;
            if (score >= 5 && score < 15) return SatisfactionConst.LEVEL_OK;

            return 100;
        }

        public double GetTimeSalaryScore(PredictDismissalRequest request, double satisfactionScore)
        {
            double result = 1;

            if (request.MonthsAfterLastSalaryReview <= 9 || request.MonthsAfterLastPerformanceAppraisal != -1)
            {
                switch (request.MonthsAfterLastSalaryReview)
                {
                    case 0:
                    case 1:
                        result = 0.2;
                        break;
                    case 2:
                        result = 0.17;
                        break;
                    case 3:
                        result = 0.16;
                        break;
                    case 4:
                        result = 0.14;
                        break;
                    case 5:
                        result = 0.12;
                        break;
                    case 6:
                        result = 0.10;
                        break;
                    case 7:
                        result = 0.8;
                        break;
                    case 8:
                        result = 0.6;
                        break;
                    case 9:
                        result = 0.4;
                        break;
                    case 10:
                        result = 0.02;
                        break;
                    case 11:
                        result = 0.01;
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
