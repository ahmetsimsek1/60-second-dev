using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2021_01_08_razor_pages_ajax.Pages
{
    public class PeopleModel : PageModel
    {
        [BindProperty]
        public Person Person { get; set; }

        public List<Person> People { get; set; }

        public async Task OnGet()
        {
            await Task.Delay(500);
            People = Program.People;
        }

        public async Task OnPost()
        {
            await Task.Delay(1000);
            People = Program.People;
            People.Add(Person);
        }
    }
}
