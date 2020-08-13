using System;

namespace BlazorExam.Data
{
  public class WeatherForecast
  {
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string Summary { get; set; }
  }

  public class Todos
  {

    public int UserId { get; set; }

    public int Id { get; set; }

    public string Title { get; set; }

    public bool Completed { get; set; }
  }
}
