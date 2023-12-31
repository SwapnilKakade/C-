using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NETMVCCRUD.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class LeadsEntity
    {
        [Key]
        [DisplayName("Lead Id")]
        public int Id { get; set; }

        [Display(Name = "Lead Date")]

        [DataType(DataType.Date)]
        public DateTime LeadDate { get; set; }

        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Display(Name = "Mobile Number")]
        public string Mobile { get; set; }

        [Display(Name = "Lead Source")]
        public string LeadSource { get; set; }

        [Display(Name = "Lead Status")]
        public string LeadStatus { get; set; }

        [Display(Name = "Next Follow-Up Date")]
        [DataType(DataType.Date)]
        public DateTime NextFollowUpDate { get; set; }
    }

}

