namespace Domain
{
    //This is an entity
    public class Post   //Class name refers to a table and a property is a column in that table
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}