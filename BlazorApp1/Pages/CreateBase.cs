using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MyCompany.Schema;


namespace BlazorApp1.Pages
{ 
    public class CreateBase : ComponentBase
    {
        [Inject] private HttpClient Http { get; set; }
        [Inject] IUriHelper UriHelper { get; set; }

        protected async Task<ThirdPartyDistributor> GetDistributor()
        {
            Console.WriteLine("GetDistributor");
            ThirdPartyDistributor distributor = new ThirdPartyDistributor();
            Console.WriteLine($"GotDistributor {distributor.ToString()}");
            return await Task.FromResult(distributor);
        }

        protected async Task SaveDistributor(ThirdPartyDistributor distributor)
        {
            Console.WriteLine("Save Distrib " + distributor);
            // save code removed.  Not relevant to bug.
        }        
    }
}
