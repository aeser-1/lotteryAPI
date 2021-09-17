using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lotteryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListController : ControllerBase
    {
        [HttpGet("/ListAll")]
        public IEnumerable<Ticket> Get()
        {
            LotterytabContext context = HttpContext.RequestServices.GetService(typeof(lotteryAPI.LotterytabContext)) as LotterytabContext;

            return (IEnumerable<Ticket>)context.GetAll();
        }

        [HttpGet("/SearchDate/{month},{year}")]
        public IEnumerable<Ticket> Get(int month,int year)
        {
            LotterytabContext context = HttpContext.RequestServices.GetService(typeof(lotteryAPI.LotterytabContext)) as LotterytabContext;

            return (IEnumerable<Ticket>)context.Get(month,year);
        }

        [HttpGet("/SearchTicket/{n1},{n2},{n3},{n4},{n5},{n6}")]
        public IEnumerable<Ticket> Get(int n1, int n2, int n3, int n4, int n5, int n6)
        {
            LotterytabContext context = HttpContext.RequestServices.GetService(typeof(lotteryAPI.LotterytabContext)) as LotterytabContext;

            return (IEnumerable<Ticket>)context.Get(n1, n2, n3, n4, n5, n6);
        }
    }
}
