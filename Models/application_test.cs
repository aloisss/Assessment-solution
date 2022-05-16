using System.ComponentModel.DataAnnotations;

namespace Recruitment.Models
{
    public class application_test
    {
        [Key]
        public int ApplicationTestId { get; set; }

        public int ApplicationId { get; set; }
        public application Application { get; set; }

        [Display(Name = "Starting Day")]
        public DateTime Starting_day { get; set; }

        [Display(Name = "Ending Day")]
        public DateTime Ending_day { get; set; }

        public ICollection<Answers> Answers { get; set; }

        public int TestId { get; set; }
        public test Test { get; set; }

        public ICollection<interview> Interviews { get; set; }





    }


    

}
