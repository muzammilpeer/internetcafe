using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace InternetCafeApp.Model
{
    public class Room
    {
        [MaxLength(10), PrimaryKey,AutoIncrement]
        public int oiroom { get; set; }
        [MaxLength(10)]
        public int oirecord { get; set; } //Forigen Key


        [MaxLength(10)]
        public int roomNo { get; set; }
        [MaxLength(255)]
        public String ipaddress { get; set; }
        [MaxLength(255)]
        public String computerDescription { get; set; }
        [MaxLength(255)]
        public String remarks { get; set; }
        [MaxLength(1)]
        public Boolean active { get; set; }
        [MaxLength(1)]
        public Boolean isAvailable { get; set; }  //isavilable for reservation
        [MaxLength(50)]
        public DateTime modDate { get; set; } 
    }
}
