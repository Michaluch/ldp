using HRAnalytics.Domain.Enums;
using System;

namespace HRAnalytics.Domain.Models
{
    [Serializable]
    public class PredictDismissalRequest
    {
        public Position Position { get; set; }
        public CompetenceGroup CompetenceGroup { get; set; }
        public Location Location { get; set; }
        public int CompanyWorkingMonths { get; set; }
        public int MonthsInCurrentRole { get; set; }
        public int MonthsWithCurrentManager { get; set; }
        public int ProjectCount { get; set; }
        public int MonthsAfterLastPromotion { get; set; }
        public int MonthsAfterLastPerformanceAppraisal { get; set; }
        public double LastPerformanceAppraisalScore { get; set; }
        public double PreviousPerformanceAppraisalScore { get; set; }
        public int MonthsAfterLastSalaryReview { get; set; }
        public double LastSalaryReviewPercentage { get; set; }

        [NonSerialized]
        public double SatisfactionLevel;
        [NonSerialized]
        public string PositionLevel;
        [NonSerialized]
        public string LanguageLevel;
        [NonSerialized]
        public string SicknessHours;
        [NonSerialized]
        public string Left;
    }
}
