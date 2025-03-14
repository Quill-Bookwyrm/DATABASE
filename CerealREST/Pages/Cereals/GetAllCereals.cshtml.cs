using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CerealREST.Models;
using CerealREST.Services.Interfaces;

namespace CerealREST.Pages.Cereals
{
    public class GetAllCerealsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int FilterCriteria { get; set; }
        public List<Cereal> Cereals { get; private set; }
        private ICerealService cerealService;
        public GetAllCerealsModel(ICerealService cService)
        {
            this.cerealService = cService;
        }
        public void OnGet()
        {
            if (FilterCriteria < 0)
            {
                Cereals.Add(cerealService.GetCerealFromId(FilterCriteria));
            }
            else
            {
                Cereals = cerealService.GetAllCereal();
            }
        }
    }
}
