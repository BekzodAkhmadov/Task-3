using Microsoft.AspNetCore.Mvc;

namespace Task_3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LcmController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromQuery] string x, [FromQuery] string y)
        {
            if (!int.TryParse(x, out int a) || !int.TryParse(y, out int b))
            {
                return Content("NaN"); 
            }

            if (a <= 0 || b <= 0)
            {
                return Content("NaN"); 
            }

            int lcm = a / Gcd(a, b) * b;

            return Content(lcm.ToString());
        }

        private int Gcd(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}
