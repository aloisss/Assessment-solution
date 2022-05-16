using System.ComponentModel.DataAnnotations;
namespace Recruitment.Models
{
    public class test
    {
        public int TestId {get;set;}
        public int Duration { get;set;}

        [Display(Name = "Maximum Score")]
        public int Max_score { get;set;}

        public ICollection<application_test> ApplicationTest { get; set; }

    }
}
