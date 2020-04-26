using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accenture.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Accenture.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AccentureDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, AccentureDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public List<SubOrder> Orders { get; set; }

        public void OnGet()
        {
                Orders = _context.SubOrders.FromSql(@"select distinct DownstreamCustomerOrders as Id from accenture.supplyorders as so
where exists(select * from accenture.operations op where op.MainId = so.IDPlanRequest)
order by Id;")
                    .ToList();
            
        }
    }
}
