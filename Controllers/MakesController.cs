using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vega.Controllers.Resources;
using vega.Models;
using vega.Persistence;

namespace vega.Controllers
{
    public class MakesController : Controller
    {
        private readonly VegaDBContext context;
        public MakesController(VegaDBContext context, IMapper mapper)
        {
            this.context = context;
        }

        // explicity defines that GetMakes is a GET request and supply the endpoint.
        [HttpGet("/api/makes")]
        // define action - want to return list of makes.
        public async Task<IEnumerable<MakeResource>> GetMakes()
        {
            var makes = await context.Makes.Include(m => m.Models).ToListAsync();
            return Mapper.Map<List<Make>, List<MakeResource>>(makes);
        }

    }
}