using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace edmi_meters_backend.Models
{
    public partial class Gateways
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int Id { get; set; }
        public int Serial { get; set; }
        public string FirmwareVersion { get; set; }
        public string State { get; set; }
        public string Ip { get; set; }
        public int? Port { get; set; }
    }
}
