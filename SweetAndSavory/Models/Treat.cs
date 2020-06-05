using System.Collections.Generic;

namespace SweetAndSavory.Models
{
  public class Treat
  {
    public Treat()
    {
      this.Flavors = new HashSet<FlavorTreat>();
    }

    public int TreatId { get; set; }
    public string Name { get; set; }
    public string Ingredients { get; set; }
    public string Description { get; set; }
    public virtual ApplicationUser User { get; set; }
    public ICollection<FlavorTreat> Flavors { get; }
  }   
}