namespace Com.OfficerFlake.Libraries
{
    public static class Testing
    {
        private static string _testString;

        public static string TestString
        {
            get { return _testString; }
            set { _testString = value ?? ""; }
        }
    }
}
