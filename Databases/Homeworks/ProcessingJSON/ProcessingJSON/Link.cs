﻿namespace ProcessingJSON
{
    using Newtonsoft.Json;

    public class Link
    {
        [JsonProperty("@rel")]
        public string Rel { get; set; }

         [JsonProperty("@href")]
        public string Href { get; set; }

         public override string ToString()
         {
             return this.Href;
         }
    }
}
