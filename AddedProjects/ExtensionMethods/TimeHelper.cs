namespace ExtensionMethods
{
    public static class TimeHelper
    {
        public static bool IsWeekEnd(DateTime value)
        {
            return value.DayOfWeek == DayOfWeek.Friday || value.DayOfWeek == DayOfWeek.Saturday;
        }
        public static bool IsWeekDay(DateTime value)
        {
            return !IsWeekEnd(value);
        }
    }
}
