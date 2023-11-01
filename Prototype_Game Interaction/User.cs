using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Prototype_Game_Interaction
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string gebruikersnaam { get; set; }

        public string email { get; set; }

        public string wachtwoord { get; set; }

        public string postcode { get; set; }
    }

}