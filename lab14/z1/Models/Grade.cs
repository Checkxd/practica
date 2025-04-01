namespace GradeJournal.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public double Value { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }
}