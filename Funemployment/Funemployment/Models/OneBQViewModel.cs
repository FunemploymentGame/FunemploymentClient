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


        /// <summary>
        /// From the id of the BQ, find all answers associated with it and make it into a list of answers
        /// Find the BQ from the id from the API and deserialize
        /// </summary>
        /// <param name="id">ID of the BQ</param>
        /// <param name="context">DBContext</param>
        /// <returns>ViewModel</returns>
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
