namespace E06RepetitionRest.Models
{
    public class Module
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Sws { get; set; }

        public int Cp { get; set; }
    }
}

