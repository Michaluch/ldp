using HRAnalytics.Domain.Models;

namespace HRAnalytics.Domain.Services.Utils.Satisfaction.Salary
{
    public class JuniorSalary : ISalary
    {
        //public double GetSalaryScore(double score)
        //{
        //    if (score >= 0 && score < 5) return SatisfactionConst.LOW_LEVEL;
        //    if (score >= 5 && score < 25) return SatisfactionConst.NOT_LOW_LEVEL;
        //    if (score >= 25 && score < 50) return SatisfactionConst.LEVEL_OK;

        //    return 100;
        //}

        public double GetSalaryScore(PredictDismissalRequest request)
        {
            var score = request.LastSalaryReviewPercentage;
            if (score < 0) return SatisfactionConst.MIN_LEVEL;

            if (score < 0 ) return score;

            if (request.CompanyWorkingMonths < 6)
            {
                return CalculateSalaryScore(score, 30, 35);
            }

            if (request.CompanyWorkingMonths < 9)
            {
                return CalculateSalaryScore(score, 25, 30, true, request.MonthsAfterLastPromotion);
            }

            if (request.CompanyWorkingMonths < 12)
            {
                return CalculateSalaryScore(score, 18, 20);
            }

            if (request.CompanyWorkingMonths < 15)
            {
                return CalculateSalaryScore(score, 15, 20, true, request.MonthsAfterLastPromotion);
            }

            if (request.CompanyWorkingMonths < 18)
            {
                return CalculateSalaryScore(score, 12, 17);
            }

            if (request.CompanyWorkingMonths < 21)
            {
                return CalculateSalaryScore(score, 12, 15);
            }

            if (request.CompanyWorkingMonths < 21)
            {
                return CalculateSalaryScore(score, 11, 12);
            }

            if (request.CompanyWorkingMonths <= 24)
            {
                return CalculateSalaryScore(score, 10, 12);
            } else
            {
                return SatisfactionConst.NOT_LOW_LEVEL;
            }
        }       

        public double GetTimeSalaryScore(PredictDismissalRequest request, double satisfactionScore)
        {
            double result = 1;

            if (request.MonthsAfterLastSalaryReview <= 3 || request.MonthsAfterLastPerformanceAppraisal != -1)
            {
                result = request.MonthsAfterLastSalaryReview == 2 ? 0.1 : 0.05;
                result = 1 + (satisfactionScore >= SatisfactionConst.LEVEL_OK ? result : -result);
            }

            var monthsWithoutSalaryReview = request.MonthsAfterLastSalaryReview - request.MonthsAfterLastPerformanceAppraisal;

            if (monthsWithoutSalaryReview > 0)
            {
                result -= monthsWithoutSalaryReview * 0.05;
            }

            return result;
        }

        private double CalculateSalaryScore(double score, double fromScore, double toScore, bool includePromotion = false, int monthsAfterPromotion = 0)
        {
            if (score >= fromScore && score <= toScore)
            {
                if (includePromotion)
                {
                    return monthsAfterPromotion < 3 ? SatisfactionConst.LEVEL_OK : SatisfactionConst.NOT_LOW_LEVEL;
                }

                return SatisfactionConst.LEVEL_OK;
            }

            if (score >= 0 && score < 5) return SatisfactionConst.LOW_LEVEL;
            if (score >= 5 && score < toScore) return SatisfactionConst.NOT_LOW_LEVEL;

            return 100;
        }
    }
}
