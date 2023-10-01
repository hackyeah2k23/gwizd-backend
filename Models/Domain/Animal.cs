namespace GWIZD2023.Models.Domain
{
    public class Animal
    {
        public Guid Id { get; set; }
        public string Color { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }
        public DateTime Date { get; set; }
        public string TypeOfAnimal { get; set; }
        public string Breed { get; set; }
        public Boolean Wild { get; set; }
        public string ImageData { get; set; }
        public Boolean Found { get; set; }
        public Boolean Lost { get; set; }
    }
}
