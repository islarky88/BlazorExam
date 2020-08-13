namespace BlazorExam.Data
{
  //Make your class public, since by default it is internal.
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
}