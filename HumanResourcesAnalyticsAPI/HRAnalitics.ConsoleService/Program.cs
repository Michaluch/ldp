using HRAnalytics.Domain.Enums;
using HRAnalytics.Domain.Models;
using HRAnalytics.Domain.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HRAnalitics.ConsoleService
{
    class Program
    {
        private static void GenerateSatisfactionLevel()
        {
            /*
             * Position	
             * Position Level	
             * Competence Group	
             * Location	
             * Company Working Months	
             * Months In Current Role	
             * Months With Current Manager	
             * Project Count	
             * Language Level	
             * Months after Last Promotion	
             * Months after Last Performance Appraisal	
             * Last Performance Appraisal Score	
             * Previous  Performance Appraisal Date	
             * Sickness Hours	
             * Left	
             * Last Sarary Review Percentage	
             * Months after Last Salary Review	
             * satisfaction level
              */
            var satisfactionService = new SatisfactionService();
            List<PredictDismissalRequest> items = File.ReadAllLines("D:\\input.csv")
                                           .Skip(1)
                                           .Select(line => InitRequest(line, satisfactionService))
                                           .ToList();
            var result = new List<string>();

            result.Add(File.ReadAllLines("D:\\input.csv").First());

            foreach(var item in items)
            {
                result.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17}",
                    item.Position,
                    item.PositionLevel,
                    item.CompetenceGroup,
                    item.Location,
                    item.CompanyWorkingMonths,
                    item.MonthsInCurrentRole,
                    item.MonthsWithCurrentManager,
                    item.ProjectCount,
                    item.LanguageLevel,
                    item.MonthsAfterLastPromotion,
                    item.MonthsAfterLastPerformanceAppraisal,
                    item.LastPerformanceAppraisalScore,
                    item.PreviousPerformanceAppraisalScore,
                    item.SicknessHours,
                    item.Left,
                    item.LastSalaryReviewPercentage,
                    item.MonthsAfterLastSalaryReview,
                    item.SatisfactionLevel
                ));
            }

            File.WriteAllLines("D:\\output.csv", result);
        }

        private static PredictDismissalRequest InitRequest(string line, SatisfactionService service)
        {
            string[] values = line.Split(',');
            var item = new PredictDismissalRequest()
            {
                Position = Enum.Parse<Position>(values[0]),
                PositionLevel = values[1],
                CompetenceGroup = Enum.Parse<CompetenceGroup>(values[2]),
                Location = Enum.Parse<Location>(values[3]),
                CompanyWorkingMonths = int.Parse(values[4]),
                MonthsInCurrentRole = int.Parse(values[5]),
                MonthsWithCurrentManager = int.Parse(values[6]),
                ProjectCount = int.Parse(values[7]),
                LanguageLevel = values[8],
                MonthsAfterLastPromotion = int.Parse(values[9]),
                MonthsAfterLastPerformanceAppraisal = int.Parse(values[10]),
                LastPerformanceAppraisalScore = double.Parse(values[11]),
                PreviousPerformanceAppraisalScore = double.Parse(values[12]),
                SicknessHours = values[13],
                Left = values[14],
                LastSalaryReviewPercentage = double.Parse(values[15]),
                MonthsAfterLastSalaryReview = int.Parse(values[16])
            };

            item.SatisfactionLevel = service.GetSatisfactionLevel(item);
            return item;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            GenerateSatisfactionLevel();
        }
    }
}
