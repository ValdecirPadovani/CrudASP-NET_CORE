using CrudASP_NET_CORE.Buseness;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CrudASP_NET_CORE.Model;

namespace CrudASP_NET_CORE.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class LoginController : ControllerBase
    {

        private ILoginBuseness _iLoginBuseness;

        public LoginController(ILoginBuseness iLoginBuseness) => _iLoginBuseness = iLoginBuseness;


        // POST api/values
        [AllowAnonymous]
        [HttpPost]
        public object Post([FromBody] Users users)
        {
            if (users == null) return BadRequest();
            return _iLoginBuseness.FindByLogin(users);
        }
    }
}
