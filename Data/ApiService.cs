using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BlazorExam.Data
{
  


  
  public class ApiUrls
  {
    public string name { get; set; }
    public string url { get; set; }
  }

  
  public class JsonData
  {

    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("userId")]
    public int UserId { get; set; }
    [JsonProperty("body")]
    public string Body { get; set; }
    [JsonProperty("completed")]
    public bool Completed { get; set; }

  }


  public class ApiService
  {
    public static List<ApiUrls> MyApiUrls = new List<ApiUrls>
    {
      new ApiUrls{name = "Posts", url = "https://jsonplaceholder.typicode.com/posts"},
      // new ApiUrls{name = "Comments", url = "https://jsonplaceholder.typicode.com/comments"},
      new ApiUrls{name = "Photos", url = "https://jsonplaceholder.typicode.com/photos"},
      new ApiUrls{name = "Albums", url = "https://jsonplaceholder.typicode.com/albums"},
      new ApiUrls{name = "Todos", url = "https://jsonplaceholder.typicode.com/todos"},
      // new ApiUrls{name = "Users", url = "https://jsonplaceholder.typicode.com/users"},
    };
    public static async Task<string> GetDataFromUrl(string url)
    {
      //Define your base url
      try
      {
        //Now we will have our using directives which would have a HttpClient 
        using (HttpClient client = new HttpClient())
        {
          //Now get your response from the client from get request to baseurl.
          //Use the await keyword since the get request is asynchronous, and want it run before next asychronous operation.
          using (HttpResponseMessage res = await client.GetAsync(url))
          {
            //Now we will retrieve content from our response, which would be HttpContent, retrieve from the response Content property.
            using (HttpContent content = res.Content)
            {
              //Retrieve the data from the content of the response, have the await keyword since it is asynchronous.
              string data = await content.ReadAsStringAsync();
              //If the data is not null, parse the data to a C# object, then create a new instance of PokeItem.
              if (data != null)
              {

                return data;

              }
              else
              {
                //If data is null log it into console.
                Console.WriteLine("Data is null!");
              }
            }
          }
        }
        //Catch any exceptions and log it into the console.
        return "response";
      }
      catch (Exception exception)
      {
        Console.WriteLine(exception);
        return "response";
      }
    }
    




  }


}