using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace InternetCafeApp.Model
{
    public class Client
    {
        [MaxLength(10), PrimaryKey,AutoIncrement]
        public int oiclient { get; set; }

        [MaxLength(255)]
        public String name { get; set; }
        [MaxLength(1)]
        public Boolean gender { get; set; }
        [MaxLength(255)]
        public String password { get; set; }
        [MaxLength(255)]
        public String description { get; set; }
        [MaxLength(255)]
        public String imageurl { get; set; }
        [MaxLength(1)]
        public Boolean active { get; set; }
        [MaxLength(50)]
        public DateTime lastLogin { get; set; }
        [MaxLength(50)]
        public DateTime modDate { get; set; }
    }
}
