using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        [HttpGet(Name = "GetCalcute")]
        public string Calculate(string str)
        {
            CalculatorConsoleApp.CalculatorClass calculator = new CalculatorConsoleApp.CalculatorClass();
            return calculator.Calculate(str);
        }
    }
}
