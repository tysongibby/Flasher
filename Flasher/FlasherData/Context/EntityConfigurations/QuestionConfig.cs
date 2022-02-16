using FlasherData.DataModels;
using FlasherData.Repositories;
using FlasherData.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace FlasherData.Context.EntityConfigurations
{
    class QuestionConfig : IEntityTypeConfiguration<Question>
    {
        readonly FlasherContext flasherContext = new FlasherContext();
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            UnitOfWork unitOfWork = new UnitOfWork(flasherContext);
            List<Flashcard> flashcards = unitOfWork.Flashcards.GetAllFlashcardsForSubject(1).ToList();
            List<Question> questions = new List<Question>();
            int questionCount = 1;
            foreach (Flashcard flashcard in flashcards)
            {
                Question question = new Question
                {
                    Id = 0,
                    FlashcardId = flashcard.Id,
                    Number = questionCount,
                    AnsweredCorrectly = false,
                    TestId = 1
                };
            }

            builder.HasData(questions);

            //builder.HasData(
            //        new List<Question>
            //        {
            //            new Question{ Id = 1, Number = 1, AnsweredCorrectly = false, FlashcardId = 1, TestId = 1},
            //            new Question{ Id = 2, Number = 2, AnsweredCorrectly = false, FlashcardId = 2, TestId = 1},
            //            new Question{ Id = 3, Number = 3, AnsweredCorrectly = false, FlashcardId = 3, TestId = 1},
            //            new Question{ Id = 4, Number = 4, AnsweredCorrectly = false, FlashcardId = 4, TestId = 1},
            //            new Question{ Id = 5, Number = 1, AnsweredCorrectly = false, FlashcardId = 5, TestId = 2},
            //            new Question{ Id = 6, Number = 2, AnsweredCorrectly = false, FlashcardId = 6, TestId = 2},
            //            new Question{ Id = 7, Number = 3, AnsweredCorrectly = false, FlashcardId = 7, TestId = 2},
            //            new Question{ Id = 8, Number = 4, AnsweredCorrectly = false, FlashcardId = 8, TestId = 2}
            //        }
            //    );

        }
    }

}
