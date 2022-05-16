using System.ComponentModel.DataAnnotations;
namespace Recruitment.Models
{
    public class application
    {
        public int ApplicationId { get; set; }

        [Display(Name = "Applicant")]
        public string ApplicantName { get; set; }

        [Display(Name = "Date of application")]
        public DateTime Date_of_application { get; set; }
        public string Education { get; set; }

        public string Experience { get; set; }

        public ICollection<application_test> ApplicationTest { get; set; }



    }
}

    
