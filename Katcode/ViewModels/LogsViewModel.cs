using Katcode.Data;
using Katcode.Repositories;

namespace Katcode.Models
{
    public class LogsViewModel
    {
        private LogsRepository _repo;

        public List<Logs> LogsList { get; set; }

        public Logs CurrentLog { get; set; }

        public bool IsActionSuccess { get; set; }

        public string ActionMessage { get; set; }

        public LogsViewModel(KatCodeContext context)
        {
            _repo = new LogsRepository(context);
            LogsList = GetAllLogs();
            CurrentLog = LogsList.FirstOrDefault();
        }

        public LogsViewModel(KatCodeContext context, int logsId)
        {
            _repo = new LogsRepository(context);
            LogsList = GetAllLogs();

            if (logsId > 0)
            {
                CurrentLog = GetLogs(logsId);
            }
            else
            {
                CurrentLog = new Logs();
            }
        }

        public void SaveLogs(Logs logs)
        {
            if (logs.LogsId > 0)
            {
                _repo.Update(logs);
            }
            else
            {
                logs.LogsId = _repo.Create(logs);
            }

            LogsList = GetAllLogs();
            CurrentLog = GetLogs(logs.LogsId);
        }

        public void RemoveLog(int logsID)
        {
            _repo.Delete(logsID);
            LogsList = GetAllLogs();
            CurrentLog = LogsList.FirstOrDefault();
        }

        public List<Logs> GetAllLogs()
        {
            return _repo.GetAllLogs();
        }

        public Logs GetLogs(int logsId)
        {
            return _repo.GetLogByID(logsId);
        }
    }
}
