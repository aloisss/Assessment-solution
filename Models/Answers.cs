using System.ComponentModel.DataAnnotations;

namespace Recruitment.Models
{
    public class Answers
    {
        public int AnswersId { get; set; }

        [Display(Name="Total Grades")]
        public int Total_grades { get; set; }
        public string Pass { get; set; }

        [Display(Name = "Answer Details")]
        public string Answer_details {get;set;}

        public int ApplicationTestId { get; set; }

        [Display(Name = "Application Test ID")]
        public application_test ApplicationTest { get; set;}
    }
    
}
