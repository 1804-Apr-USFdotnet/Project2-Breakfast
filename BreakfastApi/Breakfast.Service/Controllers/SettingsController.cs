using Breakfast.Business;
using System.Web.Http;

namespace Breakfast.Service.Controllers
{
    public class SettingsController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetSettings(string userId)
        {
            SettingsModel settings = Settings.getSettings(userId);
            try { return Ok(settings); }
            catch { return InternalServerError(); }
        }
    }
}
