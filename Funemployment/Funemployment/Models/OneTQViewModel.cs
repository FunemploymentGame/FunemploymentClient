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
  public class OneTQViewModel
  {
    public IEnumerable<Answer> Answers { get; set; }
    public TechnicalQuestion technicalQuestion { get; set; }

    public static async Task<OneTQViewModel> FromIDAsync(int? id, FunemploymentDbContext context)
    {
      OneTQViewModel oneTQView = new OneTQViewModel();
      using (var client = new HttpClient())
      {
        client.BaseAddress = new Uri("http://funemploymentapi.azurewebsites.net");
        var response = client.GetAsync($"/api/technical/{id}").Result;
        if (response.EnsureSuccessStatusCode().IsSuccessStatusCode)
        {
          var stringResult = await response.Content.ReadAsStringAsync();
          oneTQView.technicalQuestion = JsonConvert.DeserializeObject<TechnicalQuestion>(stringResult);
        }
        oneTQView.Answers = await context.AnswerTable.Where(a => a.TQID == id).Select(s => s).ToListAsync();
        return oneTQView;
      }
    }
  }
}
