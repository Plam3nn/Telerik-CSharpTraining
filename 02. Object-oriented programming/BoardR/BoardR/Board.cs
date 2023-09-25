using BoardR.Loggers.Contracts;

namespace BoardR
{
    public static class Board
    {
        private static List<BoardItem> Items = new List<BoardItem>();
        
        public static void AddItem(BoardItem item)
        {
            CheckItemExistence(item);
            Items.Add(item);
        }

        public static int TotalItems
        {
            get
            {
                return Items.Count;
            }
        }

        private static void CheckItemExistence(BoardItem item)
        {
            if (Items.Contains(item))
            {
                throw new InvalidOperationException("Item already exists");
            }
        }

        public static void LogHistory(ILogger logger)
        {
            foreach (var item in Items)
            {
                logger.Log(item.ViewHistory());
            }
        }
    }
}
