using AutoMapper;
using FlasherData.DataModels;
using FlasherData.Repositories.Interfaces;
using FlasherServer.Data.Dtos;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherServer.Pages.Continue
{
    public partial class ContinueTest
    {
        [Inject]
        private IMapper Mapper { get; set; }
        [Inject]
        private IUnitOfWork UnitOfWork { get; set; }

        private ContinueTestPage Page { get; set; } = new ContinueTestPage();
        private string SelectedTest { get; set; }
        private List<TestDto> TestDtos { get; set; } = new List<TestDto>();

        protected override void OnInitialized()
        {
            List<Test> tests = UnitOfWork.Tests.GetAll().Where(t => t.Archived != true).ToList();
            foreach (Test test in tests)
            {
                TestDtos.Add(Mapper.Map<TestDto>(test));
            }
            
        }

        private void OnValidSubmit()
        {

        }
    }
}
