namespace BoardR
{
    public class Task : BoardItem
    {
        private const int AssigneeMinLength = 5;
        private const int AssigneeMaxLength = 30;
        private const Status InitialStatus = Status.ToDo;

        private string assignee;

        public Task(string title, string assignee, DateTime dueDate)
            : base(title, dueDate, InitialStatus)
        {
            this.Assignee = assignee;
            this.AddEventLog($"Created Task: {this.ViewInfo()}");
        }

        public string Assignee
        {
            get
            {
                return this.assignee;
            }
            private set
            {
                ValidateAssignee(value);
                this.assignee = value;
            }
        }

        private void ValidateAssignee(string assignee)
        {
            if (string.IsNullOrEmpty(assignee))
            {
                throw new ArgumentException("Assignee cannot be null or empty.");
            }

            if (assignee.Length < AssigneeMinLength || assignee.Length > AssigneeMaxLength)
            {
                throw new ArgumentException("Assignee must be between 5 and 30 characters.");
            }
        }

        public void ChangeAssignee(string assignee)
        {
            string previousAssignee = this.Assignee;
            this.Assignee = assignee;
            this.AddEventLog($"Assignee changed from {previousAssignee} to {this.Assignee}");
        }

        public override void RevertStatus()
        {
            if (this.Status != InitialStatus)
            {
                Status previousStatus = this.Status;
                this.Status--;
                this.AddEventLog($"Status changed from {previousStatus} to {this.Status}");
            }
            else
            {
                this.AddEventLog($"Status cannot be reverted. It is already '{InitialStatus}'.");
            }
        }

        public override void AdvanceStatus()
        {
            if (this.Status != FinalStatus)
            {
                Status previousStatus = this.Status;
                this.Status++;
                this.AddEventLog($"Status changed from {previousStatus} to {this.Status}");
            }
            else
            {
                this.AddEventLog($"Status cannot be advanced. It is already '{FinalStatus}'.");
            }
        }

        public override string ViewInfo()
        {
            return $"{this.GetType().Name}: {base.ViewInfo()} Assignee: {this.Assignee}";
        }
    }
}
