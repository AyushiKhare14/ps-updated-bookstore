//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Identity.Client;

//namespace C_BookStoreBackEndAPI.Controllers
//{
//    [Route("api/authentication")]
//    [ApiController]
//    public class AuthenticationController : ControllerBase
//    {
//        public class AuthenticationRequestBody
//        {
//            public string? UserName { get; set; }
//            public string? Password { get; set; }
//        }

//        [HttpPost("authenticate")]
//        public ActionResult<string> Authenticate(AuthenticationRequestBody authenticationRequestBody)
//        {
//            var user = ValidateUserCredentials(
//                authenticationRequestBody.UserName,
//                authenticationRequestBody.Password);

//        }

//        private object ValidateUserCredentials()

//    }

//    }
//}
