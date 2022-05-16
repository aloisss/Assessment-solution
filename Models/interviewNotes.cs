namespace Recruitment.Models
{
    public class interviewNotes
    {
        public int Id { get; set; }
        public string Pass { get; set; }

        public int InterviewId { get; set; }
        public interview Interview { get; set; }


    }

   
}
