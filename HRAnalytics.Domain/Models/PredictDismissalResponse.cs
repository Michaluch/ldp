namespace HRAnalytics.Domain.Models
{
    public class PredictDismissalResponse
    {
        public bool IsPossible { get; set; }
        public double Score { get; set; }
    }
}
