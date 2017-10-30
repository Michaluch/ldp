using HRAnalytics.Domain.Models;
using HRAnalytics.Domain.Services.Utils.Satisfaction.PA;
using HRAnalytics.Domain.Services.Utils.Satisfaction.Salary;

namespace HRAnalytics.Domain.Services
{
    public class SatisfactionService : ISatisfactionService
    {
        private int COUNT = 3;
        private IPerformanceAppraisal _performanceAppraisal;
        private ISalary _salary;

        public double GetSatisfactionLevel(PredictDismissalRequest request)
        {
            Init(request.Position);

            var lastPAScore = _performanceAppraisal.GetLastSatisfactionScore(request.LastPerformanceAppraisalScore);
            var prevPAScore = _performanceAppraisal.GetPrevSatisfactionScore(request.PreviousPerformanceAppraisalScore);
            var timeSatisfactionPAScore = _performanceAppraisal.GetTimeSatisfactionScore(request.MonthsAfterLastPerformanceAppraisal, lastPAScore);
            var salaryScore = _salary.GetSalaryScore(request);
            var timeSalaryScore = _salary.GetTimeSalaryScore(request, salaryScore);

            return ((lastPAScore * timeSatisfactionPAScore) + prevPAScore + (salaryScore * (salaryScore < 0 ? - timeSalaryScore : timeSalaryScore))) / COUNT;
        }

        private void Init(Enums.Position position)
        {
            switch(position)
            {
                case Enums.Position.SoftwareEngineerTrainee:
                case Enums.Position.AbilitonJuniorSoftwareEngineer:
                case Enums.Position.AbilitonPROJuniorSoftwareEngineer:
                    _salary = new JuniorSalary();
                    _performanceAppraisal = new JuniorPerformanceAppraisal();                    
                    break;
                case Enums.Position.AbilitonIntermediateSoftwareEngineer:
                case Enums.Position.AbilitonPROIntermediateSoftwareEngineer:
                    _salary = new MiddleSalary();
                    _performanceAppraisal = new MiddlePerformanceAppraisal();
                    break;
                case Enums.Position.AbilitonSeniorSoftwareEngineer:
                case Enums.Position.AbilitonPROSeniorSoftwareEngineer:
                    _salary = new SeniorSalary();
                    _performanceAppraisal = new SeniorPerformanceAppraisal();
                    break;
                default:
                    _salary = new TechLeadSalary();
                    _performanceAppraisal = new TechLeadPerformanceAppraisal();
                    break;
            }
        }
    }
}
