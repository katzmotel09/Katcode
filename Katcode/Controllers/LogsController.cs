using Katcode.Data;
using Katcode.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Katcode.Controllers
{
    public class LogsController : Controller
    {
        private readonly KatCodeContext _context;

        public LogsController(KatCodeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            LogsViewModel model = new LogsViewModel(_context);
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int logsID, string title, string body, DateTime createdDate)
        {
            LogsViewModel model = new LogsViewModel(_context);

            Logs logs = new(logsID, title, body, createdDate);

            model.SaveLogs(logs);
            model.IsActionSuccess = true;
            model.ActionMessage = "Log has been saved successfully";

            return View(model);
        }

        public IActionResult Update(int id)
        {
            LogsViewModel model = new LogsViewModel(_context, id);
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            LogsViewModel model = new LogsViewModel(_context);

            if (id > 0)
            {
                model.RemoveLog(id);
            }

            model.IsActionSuccess = true;
            model.ActionMessage = "Log has been deleted successfully";
            return View("Index", model);
        }
    }
}
