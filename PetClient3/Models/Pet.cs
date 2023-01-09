namespace PetClient3.Models
{
    public class Pet
    {
        public Pet()
        {
        }

        public string PetName { get; set; }
        public DateTime PetBirthday { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public Guid Id { get; set; }

    }
}
