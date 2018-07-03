using Funemployment.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Funemployment.Models
{
    public class OneBQViewModel
    {
        public IEnumerable<Answer> Answers { get; set; }
        public BehaviorQuestion behaviorQuestion { get; set; }

        public static async Task<OneBQViewModel> FromIDAsync(int id, FunemploymentDbContext context)
        {
            OneBQViewModel oneBQView = new OneBQViewModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://funemploymentapi.azurewebsites.net");

                var response = client.GetAsync($"/api/behavior/{id}").Result;

                if (response.EnsureSuccessStatusCode().IsSuccessStatusCode)
                {
                    var stringResult = await response.Content.ReadAsStringAsync();

                    oneBQView.behaviorQuestion = JsonConvert.DeserializeObject<BehaviorQuestion>(stringResult);
                }
                
            }

            oneBQView.Answers = await context.AnswerTable.Where(a => a.BQID == id).Select(s => s).ToListAsync();

            return oneBQView;
        }
    }
}
