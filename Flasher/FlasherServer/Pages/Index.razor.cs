using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherServer.Pages
{
    public partial class Index
    {
        [Inject]
        private NavigationManager NavManager { get; set; }

        public void ContinueTest()
        {
            NavManager.NavigateTo($"/continuetest");
        }

        public void NewTest()
        {
            NavManager.NavigateTo($"/studysubject");
        }
    }
}
