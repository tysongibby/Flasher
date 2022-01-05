using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlasherServer.Data.Dtos
{
    public class QuestionDto
    {       
        public int Id { get; set; }
       
        public int Number { get; set; }
       
        public bool AnsweredCorrectly { get; set; }
       
        public int TestId { get; set; }
               
        public int FlashcardId { get; set; }
    }
}