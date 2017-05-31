using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Login
    {

        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public int GenderId { get; set; }
        public int PermanentCountryId { get; set; }
        public string PermanentCity { get; set; }
        public string PermanentAddress { get; set; }
        public Nullable<int> CurrentCountryId { get; set; }
        public Nullable<int> CurrentStateId { get; set; }
        public string CurrentCity { get; set; }
        public string CurrentAddress { get; set; }
        public string gender { get; set; }
        public string CurrentState { get; set; }
        public string CurrentCountry { get; set; }
        public string PermanentCountry { get; set; }
        public byte[] ImageArray { get; set; }

        public IEnumerable<Item> listGender { get; set; }
        public IEnumerable<Country> listCountry { get; set; }
        public IEnumerable<State> listState { get; set; }
    }
}
