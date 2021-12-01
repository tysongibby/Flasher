using FlasherData.Repositories.Interfaces;
using FlasherServer.Data.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using FlasherData.Models;

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
       

        protected override void OnInitialized()
        {
            SelectedSuperset.Id = 0;
            SelectedSet.Id = 0;

            IList<SupersetModel> _supersetModels = UnitOfWork.Supersets.GetAll();
            foreach(SupersetModel _supersetModel in _supersetModels)
            {
                Supersets.Add(Mapper.Map<Superset>(_supersetModel));
            }

            IList<SetModel> _setModels = UnitOfWork.Sets.GetAll();
            foreach(SetModel _setModel in _setModels)
            {
                Sets.Add(Mapper.Map<Set>(_setModel));
            }
            
        }
    }
}
