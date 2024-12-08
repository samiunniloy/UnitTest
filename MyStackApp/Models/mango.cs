using System.Xml.Linq;

namespace MyStackApp.Models
{
    public class mango
    {
     public   int? weight { get; set; }
     public   string? isRipe {  get; set; }
        public mango(int? Weight, string? IsRipe)
        {
            weight = Weight;
           isRipe = IsRipe;            
        }
    }
}
