namespace PhoneRepositoryLibJson
{
    public class Note
    {
        public Note(int id, string surname, string phoneNumber)
        {
            Id = id;
            Surname = surname;
            PhoneNumber = phoneNumber;
        }

        public int Id { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
    }
}
