using System.Text;

namespace BoardR
{
    public abstract class BoardItem
    {
        private const int TitleMinLength = 5;
        private const int TitleMaxLength = 30;

        protected const Status FinalStatus = Status.Verified;
        
        private readonly List<EventLog> history;

        private string title;
        private DateTime dueDate;
        private Status status;

        public BoardItem(string title, DateTime dueDate, Status initialStatus)
        {
            this.history = new List<EventLog>();

            this.Title = title;
            this.DueDate = dueDate;
            this.Status = initialStatus;
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            private set
            {
                this.ValidateTitle(value);
                this.title = value;
            }
        }

        public DateTime DueDate
        {
            get
            {
                return this.dueDate;    
            }
            private set
            {
                ValidateDueDate(value);       
                this.dueDate = value;
            }
        }

        public Status Status
        {
            get
            {
                return this.status;
            }
            protected set
            {
                this.status = value;
            }
        }

        public abstract void RevertStatus();

        public abstract void AdvanceStatus();

        public virtual string ViewInfo()
        {
            return @$"'{this.Title}', [{this.Status}|{this.DueDate.ToString("dd-MM-yyyy")}]";
        }

        public string ViewHistory()
        {
            StringBuilder output = new StringBuilder();

            foreach (EventLog log in this.history)
            {
                output.AppendLine(log.ViewInfo());
            }

            return output.ToString().TrimEnd();
        }

        public void ChangeTitle(string title)
        {
            string previousTitle = this.Title;
            this.Title = title;
            this.AddEventLog($"Title changed from '{previousTitle}' to '{this.Title}'");
        }

        public void ChangeDueDate(DateTime dueDate)
        {
            DateTime previousDueDate = this.DueDate;
            this.DueDate = dueDate;
            this.AddEventLog($"DueDate changed from '{previousDueDate:dd-MM-yyyy}' to '{this.DueDate:dd-MM-yyyy}'");
        }

        protected void AddEventLog(string description)
        {
            this.history.Add(new EventLog(description));
        }

        private void ValidateTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("Title cannot be null or empty.");
            }

            if (title.Length < TitleMinLength || title.Length > TitleMaxLength)
            {
                throw new ArgumentException("Title must be between 5 and 30 characters.");
            }
        }

        private void ValidateDueDate(DateTime dueDate)
        {
            if (dueDate < DateTime.Now)
            {
                throw new ArgumentException("Date must not be in the past.");
            }
        }
    }
}
