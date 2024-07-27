using Katcode.Models;
using Katcode.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katcode.Repositories
{
    public class LogsRepository
    {
        private KatCodeContext _dbContext;

        public LogsRepository(KatCodeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(Logs logs)
        {

            _dbContext.Add(logs);
            _dbContext.SaveChanges();

            return logs.LogsId;
        }

        public int Update(Logs logs)
        {
            Logs existingLog = _dbContext.Logs.Find(logs.LogsId);

            existingLog.Title = logs.Title;
            existingLog.Body = logs.Body;
            existingLog.CreatedDate = logs.CreatedDate;

            _dbContext.SaveChanges();

            return existingLog.LogsId;
        }

        public bool Delete(int logsID)
        {
            Logs logs = _dbContext.Logs.Find(logsID);
            _dbContext.Remove(logs);
            _dbContext.SaveChanges();

            return true;
        }

        public List<Logs> GetAllLogs()
        {
            List<Logs> logsList = _dbContext.Logs.ToList();

            return logsList;
        }

        public Logs GetLogByID(int logsID)
        {
            Logs logs = _dbContext.Logs.Find(logsID);

            return logs;
        }
    }
}
