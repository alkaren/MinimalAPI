namespace MinimalAPI.Entities
{
    public class RuleCarProduction
    {
        public int Id { get; set; }
        public string DayName { get; set; }
        public int SequenceDay { get; set; }
        public int Priority { get; set; }
        public int TotalProduction { get; set; }
    }
}
