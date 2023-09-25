namespace BoardR
{
    public class EventLog
    {
        public EventLog(string description)
        {
            ValidateDescription(description);

            this.Description = description;
            this.Time = DateTime.Now;
        }

        public string Description { get; }

        public DateTime Time { get; }        

        public string ViewInfo()
        {
            return $"[{this.Time:yyyyMMdd|HH:mm:ss.FFFF}]{this.Description}";
        }

        private void ValidateDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentException("Description cannot be null or empty.");
            }
        }
    }
}
