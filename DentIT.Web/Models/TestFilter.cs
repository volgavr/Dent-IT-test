namespace DentIT.Web.Models
{
    public class YearMonth
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public string Display => $"{Month}.{Year}";
    }
    public class TestFilter
    {
        public YearMonth YearMonth { get; set; }

    }
}
