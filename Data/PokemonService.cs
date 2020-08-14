using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace BlazorExam.Data
{


  public class PokeItem
  {
    //Define the constructor of your PokeItem which is the same name as class, and is not returning anything.
    //Will take a string name, and url as a argument.
    public PokeItem(string name, string url)
    {
      Name = name;
    }
    //Your Properties are auto-implemented.
    public string Name { get; set; }
  }
  public class PokemonService
  {
   
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
                //Then create a new instance of PokeItem, and string interpolate your name property to your JSON object.
                //Which will convert it to a string, since each property value is a instance of JToken.
                // PokeItem pokeItem = new PokeItem(name: $"{dataObj["name"]}");
                //Log your pokeItem's name to the Console.
                // Console.WriteLine("Pokemon Name:");
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
        return "test response";
      }
      catch (Exception exception)
      {
        Console.WriteLine(exception);
        return "test response";
      }
    }
    public static async void GetPokemon()
    {
      //Define your baseUrl
      string baseUrl = "http://pokeapi.co/api/v2/pokemon/";
      //Have your using statements within a try/catch block
      try
      {
        //We will now define your HttpClient with your first using statement which will implements a IDisposable interface.
        using (HttpClient client = new HttpClient())
        {
          //In the next using statement you will initiate the Get Request, use the await keyword so it will execute the using statement in order.
          using (HttpResponseMessage res = await client.GetAsync(baseUrl))
          {
            //Then get the content from the response in the next using statement, then within it you will get the data, and convert it to a c# object.
            using (HttpContent content = res.Content)
            {
              //Now assign your content to your data variable, by converting into a string using the await keyword.
              var data = await content.ReadAsStringAsync();
              //If the data isn't null return log convert the data using newtonsoft JObject Parse class method on the data.
              if (content != null)
              {
                //Now log your data object in the console
                Console.WriteLine("data------------{0}", JObject.Parse(data)["results"]);
              }
              else
              {
                Console.WriteLine("NO Data----------");
              }
            }
          }
        }
      }
      catch (Exception exception)
      {
        Console.WriteLine("Exception Hit------------");
        Console.WriteLine(exception);
      }
    }


    public static async void GetOnePokemon(int pokeId)
    {
      //Define your base url
      string baseURL = $"http://pokeapi.co/api/v2/pokemon/{pokeId}/";
      //Have your api call in try/catch block.
      try
      {
        //Now we will have our using directives which would have a HttpClient 
        using (HttpClient client = new HttpClient())
        {
          //Now get your response from the client from get request to baseurl.
          //Use the await keyword since the get request is asynchronous, and want it run before next asychronous operation.
          using (HttpResponseMessage res = await client.GetAsync(baseURL))
          {
            //Now we will retrieve content from our response, which would be HttpContent, retrieve from the response Content property.
            using (HttpContent content = res.Content)
            {
              //Retrieve the data from the content of the response, have the await keyword since it is asynchronous.
              string data = await content.ReadAsStringAsync();
              //If the data is not null, parse the data to a C# object, then create a new instance of PokeItem.
              if (data != null)
              {


                //Parse your data into a object.
                var dataObj = JObject.Parse(data);
                //Then create a new instance of PokeItem, and string interpolate your name property to your JSON object.
                //Which will convert it to a string, since each property value is a instance of JToken.
                // PokeItem pokeItem = new PokeItem(name: $"{dataObj["name"]}");
                //Log your pokeItem's name to the Console.
                Console.WriteLine("Pokemon Name:");
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
      }
      catch (Exception exception)
      {
        Console.WriteLine(exception);
      }
    }



  }


}