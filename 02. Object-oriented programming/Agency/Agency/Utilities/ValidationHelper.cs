namespace Agency.Utilities
{
    public static class ValidationHelper
    {
        public static bool NumberIsInRange(double number, double min, double max)
        {
            if (number < min || number > max)
            {
                return false;
            }

            return true;
        }
    }
}
