using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetCafeApp.Model
{
    public class RecordInt
    {
        public int oirecord { get; set; }

        public String name { get; set; }
        public Boolean gender { get; set; }
        public int roomNo { get; set; }

        public DateTime checkIn { get; set; }
        public DateTime checkOut { get; set; }
        public String isWebCam { get; set; }
        public String isCardReader { get; set; }
        public Double totalAmount { get; set; }
        public Double recievedAmount { get; set; }
        public Boolean active { get; set; }
        public DateTime modDate { get; set; }
        public String Image { get; set; }
    }
}
