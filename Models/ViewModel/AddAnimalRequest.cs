namespace GWIZD2023.Models.ViewModel
{
    public class AddAnimalRequest
    {
        public string Breed { get; set; }
        public string TypeOfAnimal { get; set; }
        public string Color { get; set; }
        public DateTime Date { get; set; }
        public string Details { get; set; }
        public bool Found { get; set; }
        public string Location { get; set; }
        public bool Lost { get; set; }
        public bool Wild { get; set; }
        public string ImageData { get; set; } 
    }
}
