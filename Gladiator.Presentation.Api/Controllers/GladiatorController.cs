using Microsoft.AspNetCore.Mvc;
using System;

namespace Gladiator.Presentation.Api.Controllers
{
    [ApiController]
    [Route("api/Gladiator")]
    public class GladiatorController : ControllerBase
    {
        [HttpGet]
        public ActionResult<String> ReadGladiator(int? id)
        {  Double _id;
           if (id != null)
            {   _id=Convert.ToDouble(id);
                string ReadGladiator = "ReadGladiator"+Convert.ToString(_id);
                return ReadGladiator;
            }
            else
            {
                string ReadGladiator = "ReadGladiator";
                return ReadGladiator;
            }
        }
        [HttpPost]
        public ActionResult<String> CreateGladiator()
        {
            string NewGladiator = "NewGladiator";
            return NewGladiator;
        }
        [HttpPut]
        public ActionResult<String> UpdateGladiator()
        {
            string UpdateGladiator = "UpdateGladiator";
            return UpdateGladiator;
        }
        [HttpDelete]
        public ActionResult<String> DeleteGladiator()
        {
            string DeleteGladiator = "DeleteGladiator";

            return DeleteGladiator;
        }
    }
}
