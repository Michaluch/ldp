using Microsoft.AspNetCore.Mvc;
using HRAnalytics.Domain.Models;
using HRAnalytics.Domain.Services;

namespace HRAnalytics.Web.Controllers
{
    [Route("api/[controller]")]
    public class PredictionDismissalController : Controller
    {
        private readonly IPreditionService _predictionService;
        private readonly ISatisfactionService _satisfactionService;

        public PredictionDismissalController(IPreditionService predictionService, ISatisfactionService satisfactionService)
        {
            _predictionService = predictionService;
            _satisfactionService = satisfactionService;
        }

        // POST api/predictionDismissal
        [HttpPost]
        public PredictDismissalResponse Post(PredictDismissalRequest request)
        {
            request.SatisfactionLevel = _satisfactionService.GetSatisfactionLevel(request);
            return _predictionService.PredictDismissal(request);
        }
    }
}
