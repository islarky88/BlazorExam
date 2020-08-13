using System.Net.Http;

namespace BlazorExam.Data
{
  public class PokemonService
  {

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
                PokeItem pokeItem = new PokeItem(name: $"{dataObj["name"]}");
                //Log your pokeItem's name to the Console.
                Console.WriteLine("Pokemon Name: {0}", pokeItem.Name);
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