using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace InternetCafeApp.Model
{
    
    public class Person
    {

        [MaxLength(5), PrimaryKey]

        public String name { get; set; }
        [MaxLength(255)]
        public String address { get; set; }
        [MaxLength(11)]
        public Double phone { get; set; }
    }
}
