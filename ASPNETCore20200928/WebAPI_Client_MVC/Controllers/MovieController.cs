using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SharedLibrary.Models;


namespace WebAPI_Client_MVC.Controllers
{
    public class MovieController : Controller
    {
        string baseAdress = "http://localhost:61894/api/Movie/";
        public MovieController()
        {
            
        }

        // GET: Movie
        public async Task<IActionResult> Index()
        {
            List<Movie> resultList = new List<Movie>();
            
            HttpClient client = new HttpClient();
            var message1 = new HttpRequestMessage(HttpMethod.Get, baseAdress);
            message1.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.SendAsync(message1);
            string jsonText = await response.Content.ReadAsStringAsync();

            resultList = JsonConvert.DeserializeObject<List<Movie>>(jsonText);
            
            return View(resultList);
        }

        // GET: Movie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie movie = null;

            string url = baseAdress + id.ToString();

            using (HttpClient httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(url);

                string jsonTxt = await response.Result.Content.ReadAsStringAsync();
                movie = JsonConvert.DeserializeObject<Movie>(jsonTxt);
            }




            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movie/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,ReleaseDate,Genre,Price")] Movie movie)
        {

            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(movie);

                var data = new StringContent(json, Encoding.UTF8, "application/json");
                
                using (var client = new HttpClient())
                {
                    var response = client.PostAsync(baseAdress, data);

                    string result = await response.Result.Content.ReadAsStringAsync(); //Result soll inen HTTP Code bekommen (200) 
                }

                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            Movie movie = null;

            string url = baseAdress + id.ToString();

            using (HttpClient httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(url);

                string jsonTxt = await response.Result.Content.ReadAsStringAsync();
                movie = JsonConvert.DeserializeObject<Movie>(jsonTxt);
            }


            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            if (id != movie.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string url = baseAdress + id.ToString();

                    var json = JsonConvert.SerializeObject(movie);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");

                    using (var client = new HttpClient())
                    {
                        var response = await client.PutAsync(url, data);
                        string result = await response.Content.ReadAsStringAsync(); //Erwarte ein 200er Ergebnis
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie movie = null;

            string url = baseAdress + id.ToString();

            using (HttpClient httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(url);

                string jsonTxt = await response.Result.Content.ReadAsStringAsync();
                movie = JsonConvert.DeserializeObject<Movie>(jsonTxt);
            }

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            string url = baseAdress + id.ToString();

            using (var client = new HttpClient())
            {
                var response = await client.DeleteAsync(url);


                string result = await response.Content.ReadAsStringAsync();
            }


            return RedirectToAction(nameof(Index));
        }

        
    }
}
