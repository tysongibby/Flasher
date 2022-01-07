using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlasherData.DataModels;
using System.IO;

namespace FlasherData.Context.EntityConfigurations
{
    class FlashcardConfig : IEntityTypeConfiguration<Flashcard>
    {
        public void Configure(EntityTypeBuilder<Flashcard> builder)
        {
            //builder.HasKey(c => c.Id);
            //builder.Property(c => c.Name)
            //       .IsRequired();
            //builder.Property(c => c.Front)
            //       .IsRequired();
            //builder.Property(c => c.Back)
            //       .IsRequired();
            //builder.Property(fc => fc.Subject)
            //       .IsRequired();
            //builder.Property(fc => fc.Category);

            // Add initial data

            List<Flashcard> newFlashcards = new List<Flashcard>();
            int idCounter = 1;

            // read domain 1 data from files
            List<Flashcard> domainFlashcards = new List<Flashcard>();
            string domain1frontsData = File.ReadAllText("../FlasherData/TestData/Security+_Domain_1_Threats_Attacks_and_Vulnerabilities_Fronts.txt");
            string domain1backsData = File.ReadAllText("../FlasherData/TestData/Security+_Domain_1_Threats_Attacks_and_Vulnerabilities_Backs.txt");            
            // parse domain 1 data from files to lists
            List<string> domain1Fronts = domain1frontsData.Split('■').ToList();            
            List<string> domain1Backs = domain1backsData.Split('■').ToList();
            // create flashcards from domain 1 data            
            if (domain1Fronts.Count == domain1Backs.Count)
            {
                for (int i = 0; i < domain1Fronts.Count; i++)
                {
                    domainFlashcards.Add(new Flashcard { Id = idCounter, Name = "", Front = domain1Fronts[i], Back = domain1Backs[i], AnsweredCorrectly = false, CategoryId = 1 });
                    idCounter++;
                }
            }
            else
            {
                throw new Exception($"Flashcard fronts and flashcard backs must be equal in number:\nFronts = {domain1Fronts.Count}, Backs = {domain1Backs.Count}");
            }
            newFlashcards.AddRange(domainFlashcards);
            domainFlashcards.Clear();

            // read domain 2 data from files
            string domain2frontsData = File.ReadAllText("../FlasherData/TestData/Security+_Domain_2_Architecture_and_Design_Fronts.txt");
            string domain2backsData = File.ReadAllText("../FlasherData/TestData/Security+_Domain_2_Architecture_and_Design_Backs.txt");
            // parse domain 2 data from files to lists
            List<string> domain2Fronts = domain2frontsData.Split('■').ToList();
            List<string> domain2Backs = domain2backsData.Split('■').ToList();
            // create flashcards from domain 2 data            
            if (domain2Fronts.Count == domain2Backs.Count)
            {
                for (int i = 0; i < domain2Fronts.Count; i++)
                {
                    domainFlashcards.Add(new Flashcard { Id = idCounter, Name = "", Front = domain2Fronts[i], Back = domain2Backs[i], AnsweredCorrectly = false, CategoryId = 1 });
                    idCounter++;
                }
            }
            else
            {
                throw new Exception($"Flashcard fronts and flashcard backs must be equal in number:\nFronts = {domain2Fronts.Count}, Backs = {domain2Backs.Count}");
            }
            newFlashcards.AddRange(domainFlashcards);
            domainFlashcards.Clear();

            // read domain 3 data from files
            string domain3frontsData = File.ReadAllText("../FlasherData/TestData/Security+_Domain_3_Implementation_Fronts.txt");
            string domain3backsData = File.ReadAllText("../FlasherData/TestData/Security+_Domain_3_Implementation_Backs.txt");
            // parse domain 3 data from files to lists
            List<string> domain3Fronts = domain3frontsData.Split('■').ToList();
            List<string> domain3Backs = domain3backsData.Split('■').ToList();
            // create flashcards from domain 3 data            
            if (domain3Fronts.Count == domain3Backs.Count)
            {
                for (int i = 0; i < domain3Fronts.Count; i++)
                {
                    domainFlashcards.Add(new Flashcard { Id = idCounter, Name = "", Front = domain3Fronts[i], Back = domain3Backs[i], AnsweredCorrectly = false, CategoryId = 1 });
                    idCounter++;
                }
            }
            else
            {
                throw new Exception($"Flashcard fronts and flashcard backs must be equal in number:\nFronts = {domain3Fronts.Count}, Backs = {domain3Backs.Count}");
            }
            newFlashcards.AddRange(domainFlashcards);
            domainFlashcards.Clear();

            // read domain 4 data from files
            string domain4frontsData = File.ReadAllText("../FlasherData/TestData/Security+_Domain_4_Operations_and_Incident_Response_Fronts.txt");
            string domain4backsData = File.ReadAllText("../FlasherData/TestData/Security+_Domain_4_Operations_and_Incident_Response_Backs.txt");
            // parse domain 4 data from files to lists
            List<string> domain4Fronts = domain4frontsData.Split('■').ToList();
            List<string> domain4Backs = domain4backsData.Split('■').ToList();
            // create flashcards from domain 4 data            
            if (domain4Fronts.Count == domain4Backs.Count)
            {
                for (int i = 0; i < domain4Fronts.Count; i++)
                {
                    domainFlashcards.Add(new Flashcard { Id = idCounter, Name = "", Front = domain4Fronts[i], Back = domain4Backs[i], AnsweredCorrectly = false, CategoryId = 1 });
                    idCounter++;
                }
            }
            else
            {
                throw new Exception($"Flashcard fronts and flashcard backs must be equal in number:\nFronts = {domain4Fronts.Count}, Backs = {domain4Backs.Count}");
            }
            newFlashcards.AddRange(domainFlashcards);
            domainFlashcards.Clear();

            // read domain 5 data from files
            string domain5frontsData = File.ReadAllText("../FlasherData/TestData/Security+_Domain_5_Governance_Risk_and_Compliance_Fronts.txt");
            string domain5backsData = File.ReadAllText("../FlasherData/TestData/Security+_Domain_5_Governance_Risk_and_Compliance_Backs.txt");
            // parse domain 5 data from files to lists
            List<string> domain5Fronts = domain5frontsData.Split('■').ToList();
            List<string> domain5Backs = domain5backsData.Split('■').ToList();
            // create flashcards from domain 5 data            
            if (domain5Fronts.Count == domain5Backs.Count)
            {
                for (int i = 0; i < domain5Fronts.Count; i++)
                {
                    domainFlashcards.Add(new Flashcard { Id = idCounter, Name = "", Front = domain5Fronts[i], Back = domain5Backs[i], AnsweredCorrectly = false, CategoryId = 1 });
                    idCounter++;
                }
            }
            else
            {
                throw new Exception($"Flashcard fronts and flashcard backs must be equal in number:\nFronts = {domain5Fronts.Count}, Backs = {domain5Backs.Count}");
            }
            newFlashcards.AddRange(domainFlashcards);
            domainFlashcards.Clear();

            // add flaschard to db
            builder.HasData(newFlashcards);
            
            // flashcard test data
            //new List<Flashcard>
            //{
            //                new Flashcard{ Id = 1, Name = "Flashcard_1", Front = "Front_1", Back = "Back_1", CategoryId = 1},
            //                new Flashcard{ Id = 2, Name = "Flashcard_2", Front = "Front_2", Back = "Back_2", CategoryId = 1},
            //                new Flashcard{ Id = 3, Name = "Flashcard_3", Front = "Front_3", Back = "Back_3", CategoryId = 2},
            //                new Flashcard{ Id = 4, Name = "Flashcard_4", Front = "Front_4", Back = "Back_4", CategoryId = 2},
            //                new Flashcard{ Id = 5, Name = "Flashcard_5", Front = "Front_5", Back = "Back_5", CategoryId = 3},
            //                new Flashcard{ Id = 6, Name = "Flashcard_6", Front = "Front_5", Back = "Back_6", CategoryId = 3},
            //                new Flashcard{ Id = 7, Name = "Flashcard_7", Front = "Front_7", Back = "Back_7", CategoryId = 4},
            //                new Flashcard{ Id = 8, Name = "Flashcard_8", Front = "Front_8", Back = "Back_8", CategoryId = 4}
            //}
        }

    }
}
