using _011_TodoItemCrudWithScaffolding_Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _011_TodoItemCrudWithScaffolding_Client
{
    class Program
    {

        static  void Main(string[] args)
        {
            //var t = Task.Run(() => ReadAllDataAndPrint());
            //t.Wait();

            Console.WriteLine("Startübersicht");
            ReadAllDataAndPrint();
            Console.WriteLine("####### PressKey #######");
            Console.ReadKey();


            Console.WriteLine("Insert + Übersicht");
            InsertStupidObject();
            ReadAllDataAndPrint();
            Console.WriteLine("####### PressKey #######");
            Console.ReadKey();


            Console.WriteLine("Update + Übersicht");
            
            //Richtiges rauslesen mit Get(int id);
            TodoItem toUpdate = ReadDataById(3);
            toUpdate.Name = "Neue Aufgabe " + DateTime.Now.ToString();
            

            //Update Statement
            UpdateStupidObject(toUpdate);
            ReadAllDataAndPrint();
            Console.WriteLine("####### PressKey #######");
            Console.ReadKey();

            Console.WriteLine("Delete + Übersicht");
            DeleteStupidObject(8);
            ReadAllDataAndPrint();
            Console.WriteLine("####### PressKey #######");
            Console.ReadKey();



            Console.WriteLine("Fertig mit dem Kurs");
            Console.ReadLine();
        }

        static void  ReadAllDataAndPrint ()
        {
            List<TodoItem> resultList = new List<TodoItem>();

            var address = "https://localhost:44342/api/";
            HttpClient client = new HttpClient();



            var message1 = new HttpRequestMessage(HttpMethod.Get, address + "TodoItems");
            message1.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.SendAsync(message1).Result;

            string jsonText =  response.Content.ReadAsStringAsync().Result;
            //resultList = JsonSerializer.Deserialize<List<TodoItem>>( );

            resultList = JsonConvert.DeserializeObject<List<TodoItem>>(jsonText);


            foreach (TodoItem current in resultList)
            {
                Console.WriteLine(current.Id.ToString() + " " + current.Name + " " + current.IsComplete.ToString());
            }
        }

        static TodoItem ReadDataById(int id)
        {
            TodoItem todoItem = null ;

            string url = "https://localhost:44342/api/TodoItems/" + id;
            using (HttpClient httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(url);

                string jsonTxt = response.Result.Content.ReadAsStringAsync().Result;
                todoItem = JsonConvert.DeserializeObject<TodoItem>(jsonTxt);
            }
            return todoItem;
        }


        static void InsertStupidObject()
        {

            
            var address = "https://localhost:44342/api/TodoItems";
            TodoItem todoItem = new TodoItem{
                Name = "Aufgabe von " + DateTime.Now.ToString(),
                IsComplete = true
            };

            var json = JsonConvert.SerializeObject(todoItem);

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var response =  client.PostAsync(address, data);
                string result = response.Result.Content.ReadAsStringAsync().Result;
            }
        }


        static void UpdateStupidObject(TodoItem toUpdateToDoItem)
        {

            var address = "https://localhost:44342/api/TodoItems/" + toUpdateToDoItem.Id;

            var json = JsonConvert.SerializeObject(toUpdateToDoItem);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var response = client.PutAsync(address, data);

                string result = response.Result.Content.ReadAsStringAsync().Result;
            }
        }

        static void DeleteStupidObject(int id)
        {
            var url = "https://localhost:44342/api/TodoItems/" + id;
          
            using (var client = new HttpClient())
            {
                var response = client.DeleteAsync(url);


                string result = response.Result.Content.ReadAsStringAsync().Result;
            }


            
        }


       
    }
}
