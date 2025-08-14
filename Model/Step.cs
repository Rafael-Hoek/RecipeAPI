namespace RecipeAPI.Model
{
    public class Step
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Order { get; set; }
        public TimeSpan? Duration { get; set; }
        public TimeSpan? ActiveTime { get; set; }
        public TimeSpan? WaitingTime { get; set; }
        //These properties can be used to create a tree structure of steps, because I'm fancy and want to use recursion
        public List<Step> PreviousSteps { get; set; } = new List<Step>();
        public List<Step> NextSteps { get; set; } = new List<Step>();
    }
}
