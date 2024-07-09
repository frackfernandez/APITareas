namespace Application.DTO
{
    public class TaskDto
    {
        public int Id { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }
}
