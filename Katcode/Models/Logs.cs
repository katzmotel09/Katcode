using System.ComponentModel.DataAnnotations;

namespace Katcode.Models
{
        public partial class Logs
        {
            public int LogsId { get; set; }
            public string Title { get; set; }
            public string Body { get; set; }
            public DateTime CreatedDate { get; set; }

            public Logs(int logsId, string title, string body, DateTime createdDate)
            {
                LogsId = logsId;
                Title = title;
                Body = body;
                CreatedDate = DateTime.Now;
            }

            public Logs()
            {

            }
        }
}