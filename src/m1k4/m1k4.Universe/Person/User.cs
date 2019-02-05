using System.ComponentModel.DataAnnotations;

namespace m1k4.Model
{
    public class User : Person
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}