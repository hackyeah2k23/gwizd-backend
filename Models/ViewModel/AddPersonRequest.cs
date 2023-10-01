using GWIZD2023.Models.Domain;

namespace GWIZD2023.Models.ViewModel
{
    public class AddPersonRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public byte[] ImageData { get; set; }
        public Animal animal {  get; set; }
    }
}
