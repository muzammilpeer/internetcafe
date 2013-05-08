using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetCafeApp.Model
{
    public class SettingModel
    {
        [MaxLength(10), PrimaryKey, AutoIncrement]
        public int oiSettingsData { get; set; }

        [MaxLength(255)]
        public String key { get; set; }
        [MaxLength(255)]
        public String value { get; set; }
        [MaxLength(1)]
        public Boolean active { get; set; }
        [MaxLength(50)]
        public DateTime modDate { get; set; } 
    }
}
