using System.ComponentModel.DataAnnotations;

namespace Recruitment.Models
{
    public class interview
    {
        public int Id { get; set; }

        [Display(Name="Start Time")]
        public DateTime Start_time { get; set; }

        [Display(Name = "End Time")]
        public DateTime End_time { get; set; }

        public int ApplicationID { get; set; }
        public application Application { get; set; }

        public ICollection<interviewNotes>InterviewNotes { get; set; }
    }


}
