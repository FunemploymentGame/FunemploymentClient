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
    public class PlayerAllAnswersViewModel
    {
        public List<Answer> BehaviorAnswers { get; set; }
        public List<Answer> TechnicalAnswers { get; set; }
        public List<BehaviorQuestion> BehaviorQuestions { get; set; }
        public List<TechnicalQuestion> TechnicalQuestions { get; set; }
        public Player Player { get; set; }

        public static async Task<PlayerAllAnswersViewModel> FromPlayerIDAsync(int id, FunemploymentDbContext context, List<Answer> bQanswers, List<Answer> tQanswer)
        {
            PlayerAllAnswersViewModel paavm = new PlayerAllAnswersViewModel();

            paavm.Player = await context.PlayerTable.FirstOrDefaultAsync(p => p.ID == id);

            paavm.BehaviorAnswers = bQanswers;

            //await context.AnswerTable.Where(a => a.PID == id && a.BQID != 0).Select(s => s).ToListAsync();

            paavm.TechnicalAnswers = tQanswer;

            List<BehaviorQuestion> bqList = new List<BehaviorQuestion>();
            List<TechnicalQuestion> tqList = new List<TechnicalQuestion>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://funemploymentapi.azurewebsites.net");

                foreach (var item in paavm.BehaviorAnswers)
                {
                    var response = client.GetAsync($"/api/behavior/{item.BQID}").Result;

                    if (response.EnsureSuccessStatusCode().IsSuccessStatusCode)
                    {
                        var stringResult = await response.Content.ReadAsStringAsync();
                        BehaviorQuestion bq = JsonConvert.DeserializeObject<BehaviorQuestion>(stringResult);
                        bqList.Add(bq);
                    }
                }
                var newBqlist = bqList.GroupBy(g => g.Content).Select(s => s.First());
                paavm.BehaviorQuestions = newBqlist.ToList();

                foreach (var item in paavm.TechnicalAnswers)
                {
                    var response = client.GetAsync($"/api/technical/{item.TQID}").Result;

                    if (response.EnsureSuccessStatusCode().IsSuccessStatusCode)
                    {
                        var stringResult = await response.Content.ReadAsStringAsync();
                        TechnicalQuestion tq = JsonConvert.DeserializeObject<TechnicalQuestion>(stringResult);
                        tqList.Add(tq);
                    }
                }
                var newTqlist = tqList.GroupBy(g => g.ProblemDomain).Select(s => s.First());
                paavm.TechnicalQuestions = newTqlist.ToList();
            }
            return paavm;
        }
    }
}
