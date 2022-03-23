namespace backend_user_registration.Data.Dtos
{
    public class CreateUserDto
    {
        public string name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime birthdate { get; set;}

        public List<PhoneNumber> phoneNumbers { get; set; }

        public List<Adress> adresses { get; set; }

        public SocialMedia socialMedia { get; set; }

        public string cpf { get; set; }

        public string rg { get; set; }
    }
    }
}