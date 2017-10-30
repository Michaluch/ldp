using HRAnalytics.Domain.Services;
using HRAnalytics.Domain.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;

namespace HRAnalytics.Data.Services
{
    public class PreditionService : IPreditionService
    {
        private readonly string _apiKey = "";
        private readonly string _apiUrl = "";

        public PreditionService(IConfiguration configuration)
        {
            _apiKey = configuration.GetSection("AzureML").GetSection("ApiKey").Value;
            _apiUrl = configuration.GetSection("AzureML").GetSection("ApiUrl").Value;
        }

        public PredictDismissalResponse PredictDismissal(PredictDismissalRequest request)
        {
            using (var client = new HttpClient())
            {
                var scoreRequest = new
                {
                    Inputs = new Dictionary<string, List<Dictionary<string, string>>>
                    {
                        {
                            "input1",
                            new List<Dictionary<string, string>>
                            {
                                new Dictionary<string, string>
                                {
                                    { "Position", request.Position.ToString() },
                                    { "Position Level", "" },
                                    { "Competence Group", request.CompetenceGroup.ToString() },
                                    { "Location", request.Location.ToString() },
                                    { "Company Working Months", request.CompanyWorkingMonths.ToString() },
                                    { "Months In Current Role", request.MonthsInCurrentRole.ToString() },
                                    { "Months With Current Manager", request.MonthsWithCurrentManager.ToString() },
                                    { "Project Count", request.ProjectCount.ToString() },
                                    { "Language Level", "Intermediate" },
                                    { "Months after Last Promotion", request.MonthsAfterLastPromotion.ToString() },
                                    { "Months after Last Performance Appraisal", request.MonthsAfterLastPerformanceAppraisal.ToString() },
                                    { "Last Performance Appraisal Score", request.LastPerformanceAppraisalScore.ToString(CultureInfo.InvariantCulture) },
                                    { "Previous  Performance Appraisal Date", request.PreviousPerformanceAppraisalScore.ToString(CultureInfo.InvariantCulture) },
                                    { "Sickness Hours", "0" },
                                    { "Left", "0" },
                                    { "Last Sarary Review Percentage", request.LastSalaryReviewPercentage.ToString(CultureInfo.InvariantCulture) },
                                    { "Months after Last Salary Review", request.MonthsAfterLastSalaryReview.ToString() },
                                    { "satisfaction level", request.SatisfactionLevel.ToString(CultureInfo.InvariantCulture) },
                                }
                            }
                        },
                    },
                    GlobalParameters = new Dictionary<string, string>()
                };

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
                client.BaseAddress = new Uri(_apiUrl);

                string stringData = JsonConvert.SerializeObject(scoreRequest);
                var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync("", contentData).Result;

                if (response.IsSuccessStatusCode)
                {
                    
                    string result = response.Content.ReadAsStringAsync().Result;
                    JObject jObj = JObject.Parse(result);
                    JToken IsPossible = jObj["Results"]["output1"][0]["Scored Labels"];
                    JToken score = jObj["Results"]["output1"][0]["Scored Probabilities"];
                    var scoreValue = score.Value<double>();
                    return new PredictDismissalResponse()
                    {
                        IsPossible = IsPossible.Value<int>() == 1,

                        Score = Math.Round(scoreValue > 0 ? scoreValue : scoreValue * 100, 2)
                    };
                }
            }

            return new PredictDismissalResponse()
            {
                IsPossible = false,
                Score = 0
            };
        }
    }
}
