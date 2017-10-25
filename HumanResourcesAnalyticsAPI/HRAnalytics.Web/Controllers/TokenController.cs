using Microsoft.AspNetCore.Mvc;
using HRAnalytics.Web.Utils.Security;
using HRAnalytics.Web.Models.Token;

namespace HRAnalytics.Web.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        [HttpPost]
        public IActionResult Get(TokenInputModel inputModel)
        {
            if (inputModel.Username != "superuser" || inputModel.Password != "password_GOD")
                return Unauthorized();

            var token = new JwtTokenBuilder()
                                .AddSecurityKey(JwtSecurityKey.Create("bg393c[Ey|*P:a6A"))
                                .AddSubject("Super User")
                                .AddIssuer("LDP_GROUP_005")
                                .AddAudience("LDP_007")
                                .AddClaim("MembershipId", "5")
                                .AddExpiry(15)
                                .Build();

            return Ok("Bearer " + token.Value);
        }
    }
}
