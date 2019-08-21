using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using MyCompany.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorApp1.Pages
{ 
    public class EditFieldsBase : ComponentBase
    {
        [Inject] IJSRuntime JsRuntime { get; set; }
        [Inject] HttpClient HttpClient { get; set; }

        [Parameter] public string Title { get; set; }

        [Parameter] public Func<Task<ThirdPartyDistributor>> GetDistributor { get; set; }

        [Parameter] public Func<ThirdPartyDistributor,Task> SaveDistributor { get; set; }


        protected ElementReference EditFormElement { get; set; }


        protected ThirdPartyDistributor Distributor { get; set; } = null;        
        protected string NameValidation = "Required";
        protected bool SubmitDisabled { get; set; } = true;
        protected string ErrorMessage = "";

        protected Dictionary<string, string> WarehouseLookup { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (GetDistributor == null) return;
            Distributor = await GetDistributor();
            WarehouseLookup = new Dictionary<string,string>() {
	     {"100","Main Warehouse"},
	     {"200","Other Warehouse"}
	    };
        }

        protected override void OnAfterRender()
        {
            Validate();
        }


        public void CanSubmit()
        {
            SubmitDisabled = false;
        }

        public void CannotSubmit()
        {
            SubmitDisabled = true;
        }

        protected override async Task OnAfterRenderAsync()
        {
            if (JsRuntime == null) return;
            await JsRuntime.InvokeAsync<bool>("setInputToChange");
        }

        protected void ValidateDistributorName(UIChangeEventArgs e)
        {
            if (Distributor != null)
            {
                Distributor.Name = e.Value.ToString();
            }
            Validate();
        }

        public void Validate()
        {
            Console.WriteLine("Validate");
            if (Distributor == null)
            {
                Console.WriteLine("Distributor is null.  cnanot validate");
                SubmitDisabled = true;
                return;
            }
            ValidationContext ctx = new ValidationContext(Distributor, serviceProvider: null, items: null);
            Console.WriteLine("Validate ctx " + ctx);
            List<ValidationResult> results = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(Distributor, ctx, results, validateAllProperties: true);

            string lastNameValidation = NameValidation;
            bool lastSubmitDisabled = SubmitDisabled;
            if (results != null)
            {
                NameValidation = "";
                foreach (var result in results)
                {
                    if (result.MemberNames.Contains(nameof(ThirdPartyDistributor.Name)))
                    {
                        NameValidation += result.ErrorMessage;
                        Console.WriteLine(result.ErrorMessage);
                    }
                }
            }
            Console.WriteLine("Called Validate");
            SubmitDisabled = !valid;
            if (lastNameValidation != NameValidation || SubmitDisabled != lastSubmitDisabled) { 
                StateHasChanged();
            }
        }

        public void SetWarehouseCode(UIChangeEventArgs e)
        {
            if (Distributor != null)
            {
                Distributor.WarehouseCode = e.Value.ToString();
            }
            Validate();
        }

        public async Task OnSave()
        {
            Console.WriteLine("EditFieldsBase OnSave");
            try
            {
                if ( Distributor == null )
                {
                    ErrorMessage = "Distributor is null.  Cannot save.";
                    return;
                }
                if (SaveDistributor != null)
                {
                    await SaveDistributor(Distributor);
                }
                else
                {
                    throw new Exception("No method was configured to SaveDistributor");
                }
            } catch (Exception e)
            {
                ErrorMessage = e.ToString();
            }
        }

    }
}
