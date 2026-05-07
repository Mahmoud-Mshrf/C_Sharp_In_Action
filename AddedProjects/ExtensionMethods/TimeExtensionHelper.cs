namespace ExtensionMethods
{
    // to use Extension methods you have to do 3 steps
    // the class must be static
    // the method that you want to make it extension must be static
    // in the method that you want to make it extension you must put (this) before first parameter
    public static class TimeExtensionHelper
    {
        public static bool IsWeekEnd(this DateTime value)
        {
            return value.DayOfWeek == DayOfWeek.Friday || value.DayOfWeek == DayOfWeek.Saturday;
        }
        public static bool IsWeekDay(this DateTime value)
        {
            return !IsWeekEnd(value);
        }
    }
}
