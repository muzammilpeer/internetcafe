using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace InternetCafeApp.Model
{
    public class Record
    {
        [MaxLength(10), PrimaryKey, AutoIncrement]
        public int oirecord { get; set; }

        [MaxLength(10)] //foreign key
        public int oiclient { get; set; }
        [MaxLength(10)] //foreign key
        public int oiroom { get; set; }

        [MaxLength(50)]
        public DateTime checkIn { get; set; }
        [MaxLength(50)]
        public DateTime checkOut { get; set; }
        [MaxLength(10)]
        public String isWebCam { get; set; }
        [MaxLength(10)]
        public String isCardReader { get; set; }
        [MaxLength(11)]
        public Double totalAmount { get; set; }
        [MaxLength(11)]
        public Double recievedAmount { get; set; }
        [MaxLength(1)]
        public Boolean active { get; set; }
        [MaxLength(50)]
        public DateTime modDate { get; set; }

    }
}
