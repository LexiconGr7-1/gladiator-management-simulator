using Microsoft.AspNetCore.Mvc;


    namespace Gladiator.Presentation.Api.Controllers
{
    [ApiController]
    [Route("api/Gladiator")]
    public class GladiatorController : ControllerBase
    {
        [HttpGet]
        public ActionResult<String> CreateGladiator()
        {
            string NewGladiator="NewGladiator";
            return NewGladiator;
        }
        [HttpPost]
        public ActionResult<String> ReadGladiator()
        {
            string ReadGladiator = "ReadGladiator";
            return ReadGladiator;
        }
        [HttpPut]
        public ActionResult<String> UpdateGladiator()
        {
            string UpdateGladiator = "UpdateGladiator";
            return UpdateGladiator;
        }
        [HttpDelete]
        public ActionResult<String> DeleterGladiator()
        {
            string DeleteGladiator = "DeleteGladiator";

            return DeleteGladiator;
        }
    }
}
