using System.Collections.Generic;

namespace SweetAndSavory.Models
{
  public class Flavor
  {
    public Flavor()
    {
      this.Recipes = new HashSet<FlavorTreat>();
    }

    public int FlavorId { get; set; }
    public string Name { get; set; }
    public ICollection<FlavorTreat> Treats { get; set; }
  }
}