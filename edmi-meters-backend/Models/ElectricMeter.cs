using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace edmi_meters_backend.Models
{
    public partial class ElectricMeter
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int Id { get; set; }
        public int Serial { get; set; }
        public string FirmwareVersion { get; set; }
        public string State { get; set; }
    }
}
