using FlasherShared.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherWeb.Pages
{
    public partial class EditFlashCards
    {
        private string text1;
        private string text2;
        //private FlashCard flashCard;
        private int TextAreaRows { get; set; }
        protected string Text
        {
            get => text1;
            set
            {
                text1 = value;
                CalculateSize(value);
            }
        }
        protected string Text2
        {
            get => text2;
            set
            {
                text2 = value;
                CalculateSize(value);
            }
        }

        private void CalculateSize(string value)
        {
            TextAreaRows = Math.Max(value.Split('\n').Length, value.Split('\r').Length);
            TextAreaRows = Math.Max(TextAreaRows, 2);

        }

        public void Submit(string textForFronts, string textForBacks)
        {
            List<string> newFlashCardFronts = textForFronts.Split('■').ToList();
            List<string> newFlashCardBacks = textForFronts.Split('■').ToList();
            foreach (string fc in newFlashCardFronts)
            {
                Console.WriteLine(fc);
            }
            foreach (string bc in newFlashCardBacks)
            {
                Console.WriteLine(bc);
            }
        }
    }
}
