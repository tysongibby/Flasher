using AutoMapper;
using FlasherData.Models;
using FlasherData.Repositories.Interfaces;
using FlasherServer.Data.Dtos;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherServer.Pages
{
    public partial class Category
    {
        [Inject]
        private IUnitOfWork UnitOfWork { get; set; }
        [Inject]
        private IMapper Mapper { get; set; }
        [Inject]
        private NavigationManager NavManager { get; set; }
        [Parameter]
        public string selectedsupersetid { get; set; }
        private int SelectedSuperSetId { get; set; }
        private Set SelectedSet { get; set; } = new Set();

        private List<int> SelectedSetIds { get; set; } = new List<int>();
        private List<Set> Sets { get; set; } = new List<Set>();

        
        protected override void OnInitialized()
        {
            // get url parameters
            SelectedSuperSetId = Int32.Parse(selectedsupersetid);

            // get sets form superset
            List<SetModel> _setModels = UnitOfWork.Sets.Where(s => s.SupersetId == SelectedSuperSetId).ToList();
            foreach (SetModel _setModel in _setModels)
            {
                Sets.Add(Mapper.Map<Set>(_setModel));
            }
            
        }

        private void CheckboxClicked(int? setId, object checkedValue)
        {
            int _setId = (int)setId;
            if ((bool)checkedValue)
            {
                if (!SelectedSetIds.Contains(_setId))
                {
                    SelectedSetIds.Add(_setId);
                }
            }
            else
            {
                if (SelectedSetIds.Contains(_setId))
                {
                    SelectedSetIds.Remove(_setId);
                }
            }
        }

        private void HandleOnValidSubmit()
        {
            NavManager.NavigateTo($"/category/{SelectedSetIds}");
            // create flashscards list from sets chosen from superset
        }
    }
}
