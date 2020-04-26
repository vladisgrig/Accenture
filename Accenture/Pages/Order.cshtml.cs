using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Accenture.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace Accenture.Pages
{
    public class OrderModel : PageModel
    {
        private readonly ILogger<OrderModel> _logger;
        private readonly AccentureDbContext _context;

        public OrderModel(ILogger<OrderModel> logger, AccentureDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet(string id)
        {
            if (id != null)
            {
                ViewData["orderId"] = id;

                string command = @"SELECT OperationDescription as Id, Start, End, """" as StartLabel, """" as EndLabel, MainId, """" as Timeline  FROM accenture.operations where MainId IN (
SELECT IDPlanRequest FROM accenture.supplyorders where DownstreamCustomerOrders = @id)
ORDER by Id desc";

                MySqlParameter parameterid = new MySqlParameter("@id", id);

                var operations = _context.Operations.FromSql(command, parameterid).ToList();

                var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(operations);
                ViewData["dataSet"] = jsonString;
            }
            else
            {
                ViewData["orderId"] = "-";
                ViewData["dataSet"] = "[]";
            }

        }
    }
}
