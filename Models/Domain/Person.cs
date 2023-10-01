namespace GWIZD2023.Models.Domain
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public byte[] ImageData { get; set; }
        public ICollection<Animal> Animals { get; set; }
    }
}
