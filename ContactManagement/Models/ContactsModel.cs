using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ContactManagement.Models
{
    public class ContactsModel
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public string ProfessionalNumber { get; set; }
        public string HomeNumber { get; set; }
        public int MobileNumber { get; set; }
    }

}
