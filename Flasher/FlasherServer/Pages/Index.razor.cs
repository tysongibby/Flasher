using FlasherData.Repositories.Interfaces;
using FlasherServer.Data.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using FlasherData.Models;
using Microsoft.AspNetCore.Components.Web;

namespace FlasherServer.Pages
{
    public partial class Index
    {
        [Inject]
        private IUnitOfWork UnitOfWork { get; set; }
        [Inject]
        private IMapper Mapper { get; set; }
        private IList<Superset> Supersets { get; set; } = new List<Superset>();
        private Superset SelectedSuperset { get; set; } = new Superset();
        private IList<Set> Sets { get; set; } = new List<Set>();
        private Set SelectedSet { get; set; } = new Set();
        private int SelectedSupersetId { get; set; } = 0;
        private int SelectedSetId { get; set; } = 0;        
        private bool SupersetSelectDisabled { get; set; } = true;
       

        protected override void OnInitialized()
        {
            IList<SupersetModel> _supersetModels = UnitOfWork.Supersets.GetAll();
            foreach(SupersetModel _supersetModel in _supersetModels)
            {
                Supersets.Add(Mapper.Map<Superset>(_supersetModel));
            }            
        }

        private void HandleOnValidSubmit()
        {            
            IList<SetModel> _setModels = UnitOfWork.Sets.GetAll();
            foreach (SetModel _setModel in _setModels)
            {
                Sets.Add(Mapper.Map<Set>(_setModel));
            }
            SupersetSelectDisabled = false;
        }
    }
}
