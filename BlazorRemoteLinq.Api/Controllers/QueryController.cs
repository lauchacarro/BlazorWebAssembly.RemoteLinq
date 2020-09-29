using System.Collections.Generic;

using Aqua.Dynamic;

using BlazorRemoteLinq.Api.Data;
using BlazorRemoteLinq.Shared;

using Microsoft.AspNetCore.Mvc;

using Remote.Linq.EntityFrameworkCore;

namespace BlazorRemoteLinq.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QueryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public QueryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IEnumerable<DynamicObject> Query([FromBody] Query query) => query.Expression.ExecuteWithEntityFrameworkCore(_context);

    }
}
