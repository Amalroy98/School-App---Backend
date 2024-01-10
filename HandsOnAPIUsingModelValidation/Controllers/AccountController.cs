using HandsOnAPIUsingModelValidation.Controllers.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using HandsOnAPIUsingModelValidation.Controllers.Models;
using HandsOnWebApiUsingModelValidation.Models;

namespace HandsOnAPIUsingModelValidation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        List<Login> logins = new List<Login>()
        {
            new Login(){username="Anna",password="12345"},
            new Login(){username="Faris",password="12345"},
            new Login(){username="Amal",password="12345"},
            new Login(){username="Arjun",password="12345"},
        };
        List<User> users = new List<User>()
        {
            new User (){Id=1,Name="Amal",Email="amalroy@gmail.com",Mobile="1234567890",Username="Amal Roy",Password="007"}
        };
        [HttpPost]
        public IActionResult Validate(Login login)

        {
            try
            {


                if (ModelState.IsValid)
                {


                    // var user = (from u in logins
                    //    where u.username == login.username && u.password == login.password
                    // select u).SingleOrDefault();
                    var user = (from l in logins
                                join u in users
                                on l.username equals u.Username
                                where u.Username == login.username &&
                                u.Password == login.password
                                select u).SingleOrDefault();

                    if (user != null)
                    {
                        return StatusCode(200, new JsonResult("Valid user"));


                    }
                    else
                    {
                        return StatusCode(200, new JsonResult("Invalid user"));
                    }
                }

                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost, Route("Register")]
        public IActionResult Register([FromBody] User user)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    user.Id = new Random().Next(1000, 9999);
                    users.Add(user);
                    return Ok(user);
                }



                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(501, ex);
               
            }
        }
       
    }

}