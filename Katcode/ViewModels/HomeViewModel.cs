using Katcode.Data;
using Katcode.Models;
using Katcode.Repositories;

namespace Katcode.ViewModels
{
	public class HomeViewModel
	{
		private LogsRepository _repo;
		public List<Logs> LogsList { get; set; }

		public Logs CurrentLog { get; set; }
		public HomeViewModel(KatCodeContext context)
		{
			_repo = new LogsRepository(context);
			LogsList = GetAllLogs();
			CurrentLog = LogsList.FirstOrDefault();
		}

		public HomeViewModel(KatCodeContext context, int logsId)
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
