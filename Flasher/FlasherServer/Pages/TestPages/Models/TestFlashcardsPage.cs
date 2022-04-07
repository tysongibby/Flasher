using FlasherServer.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherServer.Pages.TestPages.Models
{
    public class TestFlashcardsPage
    {
        public int QuestionNumber { get; set; } 
        public string CardBody { get; set; } = string.Empty;
        public string CardName { get; set; } = string.Empty;
        public string SubjectName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public string CardSide { get; set; } = string.Empty;
        public string ShowButton { get; set; } = string.Empty;
        public bool AnsweredCorrectly { get; set; } = false;
    }
}
