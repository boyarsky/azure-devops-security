﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Waddle.Dtos
{
    public partial class VstsAclList
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("value")]
        public VstsAclEntry[] Value { get; set; }
    }

    public partial class VstsAclEntry
    {
        [JsonProperty("inheritPermissions")]
        public bool InheritPermissions { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("acesDictionary")]
        public Dictionary<string, VstsAcesDictionaryEntry> AcesDictionary { get; set; }

        public override string ToString()
        {
            return $"Token: {Token}";
        }
    }

    public partial class VstsAcesDictionaryEntry
    {
        [JsonProperty("descriptor")]
        public string Descriptor { get; set; }

        [JsonProperty("allow")]
        public long Allow { get; set; }

        [JsonProperty("deny")]
        public long Deny { get; set; }

        public override string ToString()
        {
            return $"{Descriptor} Allow:{Allow} Deny: {Deny}";
        }
    }
}
