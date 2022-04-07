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

            // read category 1 data from files
            List<Flashcard> categoryFlashcards = new List<Flashcard>();
            string category1frontsData = File.ReadAllText("../FlasherData/TestData/Security+_Category_1_Threats_Attacks_and_Vulnerabilities_Fronts.txt");
            string category1backsData = File.ReadAllText("../FlasherData/TestData/Security+_Category_1_Threats_Attacks_and_Vulnerabilities_Backs.txt");            
            // parse category 1 data from files to lists
            List<string> category1Fronts = category1frontsData.Split('■').ToList();            
            List<string> category1Backs = category1backsData.Split('■').ToList();
            // create flashcards from category 1 data            
            if (category1Fronts.Count == category1Backs.Count)
            {
                for (int i = 0; i < category1Fronts.Count; i++)
                {
                    categoryFlashcards.Add(new Flashcard { Id = idCounter, Name = "", Front = category1Fronts[i], Back = category1Backs[i], CategoryId = 1 });
                    idCounter++;
                }
            }
            else
            {
                throw new Exception($"Flashcard fronts and flashcard backs must be equal in number:\nFronts = {category1Fronts.Count}, Backs = {category1Backs.Count}");
            }
            newFlashcards.AddRange(categoryFlashcards);
            categoryFlashcards.Clear();

            // read category 2 data from files
            string category2frontsData = File.ReadAllText("../FlasherData/TestData/Security+_Category_2_Architecture_and_Design_Fronts.txt");
            string category2backsData = File.ReadAllText("../FlasherData/TestData/Security+_Category_2_Architecture_and_Design_Backs.txt");
            // parse category 2 data from files to lists
            List<string> category2Fronts = category2frontsData.Split('■').ToList();
            List<string> category2Backs = category2backsData.Split('■').ToList();
            // create flashcards from category 2 data            
            if (category2Fronts.Count == category2Backs.Count)
            {
                for (int i = 0; i < category2Fronts.Count; i++)
                {
                    categoryFlashcards.Add(new Flashcard { Id = idCounter, Name = "", Front = category2Fronts[i], Back = category2Backs[i], CategoryId = 2 });
                    idCounter++;
                }
            }
            else
            {
                throw new Exception($"Flashcard fronts and flashcard backs must be equal in number:\nFronts = {category2Fronts.Count}, Backs = {category2Backs.Count}");
            }
            newFlashcards.AddRange(categoryFlashcards);
            categoryFlashcards.Clear();

            // read category 3 data from files
            string category3frontsData = File.ReadAllText("../FlasherData/TestData/Security+_Category_3_Implementation_Fronts.txt");
            string category3backsData = File.ReadAllText("../FlasherData/TestData/Security+_Category_3_Implementation_Backs.txt");
            // parse category 3 data from files to lists
            List<string> category3Fronts = category3frontsData.Split('■').ToList();
            List<string> category3Backs = category3backsData.Split('■').ToList();
            // create flashcards from category 3 data            
            if (category3Fronts.Count == category3Backs.Count)
            {
                for (int i = 0; i < category3Fronts.Count; i++)
                {
                    categoryFlashcards.Add(new Flashcard { Id = idCounter, Name = "", Front = category3Fronts[i], Back = category3Backs[i], CategoryId = 3 });
                    idCounter++;
                }
            }
            else
            {
                throw new Exception($"Flashcard fronts and flashcard backs must be equal in number:\nFronts = {category3Fronts.Count}, Backs = {category3Backs.Count}");
            }
            newFlashcards.AddRange(categoryFlashcards);
            categoryFlashcards.Clear();

            // read category 4 data from files
            string category4frontsData = File.ReadAllText("../FlasherData/TestData/Security+_Category_4_Operations_and_Incident_Response_Fronts.txt");
            string category4backsData = File.ReadAllText("../FlasherData/TestData/Security+_Category_4_Operations_and_Incident_Response_Backs.txt");
            // parse category 4 data from files to lists
            List<string> category4Fronts = category4frontsData.Split('■').ToList();
            List<string> category4Backs = category4backsData.Split('■').ToList();
            // create flashcards from category 4 data            
            if (category4Fronts.Count == category4Backs.Count)
            {
                for (int i = 0; i < category4Fronts.Count; i++)
                {
                    categoryFlashcards.Add(new Flashcard { Id = idCounter, Name = "", Front = category4Fronts[i], Back = category4Backs[i], CategoryId = 4 });
                    idCounter++;
                }
            }
            else
            {
                throw new Exception($"Flashcard fronts and flashcard backs must be equal in number:\nFronts = {category4Fronts.Count}, Backs = {category4Backs.Count}");
            }
            newFlashcards.AddRange(categoryFlashcards);
            categoryFlashcards.Clear();

            // read category 5 data from files
            string category5frontsData = File.ReadAllText("../FlasherData/TestData/Security+_Category_5_Governance_Risk_and_Compliance_Fronts.txt");
            string category5backsData = File.ReadAllText("../FlasherData/TestData/Security+_Category_5_Governance_Risk_and_Compliance_Backs.txt");
            // parse category 5 data from files to lists
            List<string> category5Fronts = category5frontsData.Split('■').ToList();
            //for (int i = 0; i < category5Fronts.Count ; i++)
            //{
            //    category5Fronts[i] = category5Fronts[i].Substring('.');
            //}
            List<string> category5Backs = category5backsData.Split('■').ToList();
            // create flashcards from category 5 data            
            if (category5Fronts.Count == category5Backs.Count)
            {
                for (int i = 0; i < category5Fronts.Count; i++)
                {
                    categoryFlashcards.Add(new Flashcard { Id = idCounter, Name = "", Front = category5Fronts[i], Back = category5Backs[i], CategoryId = 5 });
                    idCounter++;
                }
            }
            else
            {
                throw new Exception($"Flashcard fronts and flashcard backs must be equal in number:\nFronts = {category5Fronts.Count}, Backs = {category5Backs.Count}");
            }
            newFlashcards.AddRange(categoryFlashcards);
            categoryFlashcards.Clear();

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
