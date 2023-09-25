namespace BoardR
{
    public class Issue : BoardItem
    {
        private const Status InitialStatus = Status.Open;

        private string description;

        public Issue(string title, string description, DateTime dueDate)
            : base(title, dueDate, InitialStatus)
        {
            this.Description = description;
            this.AddEventLog($"Created Issue: {this.ViewInfo()}. Description: {this.description}");
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            init
            {
                this.description = value ?? "No description";               
            }
        }

        public override void AdvanceStatus()
        {
            if (this.Status != FinalStatus)
            {
                this.Status = FinalStatus;
                this.AddEventLog($"Issue status set to '{FinalStatus}'.");
            }
            else
            {
                this.AddEventLog($"Issue status already '{FinalStatus}'.");
            }
        }

        public override void RevertStatus()
        {
            if (this.Status != InitialStatus)
            {
                this.Status = InitialStatus;
                this.AddEventLog($"Issue status set to '{InitialStatus}'.");
            }
            else
            {
                this.AddEventLog($"Issue status already '{InitialStatus}'.");
            }
        }
    }
}
