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
        [Inject]
        NavigationManager NavManager { get; set; }
        private IList<Superset> Supersets { get; set; } = new List<Superset>();
        private Superset SelectedSuperset { get; set; } = new Superset();
        private int SelectedSupersetId { get; set; }
       

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
            NavManager.NavigateTo($"/category/{SelectedSupersetId}");
        }
    }
}
