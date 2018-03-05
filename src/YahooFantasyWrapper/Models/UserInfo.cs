using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace YahooFantasyWrapper.Models
{
    [Serializable]
    public class UserInfo
    {
        [JsonProperty("profile")]
        public Profile Profile { get; set; }
    }
    [Serializable]
    public class Profile
    {
        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        [JsonProperty("guid")]
        public string Guid { get; set; }

        [JsonProperty("bdRestricted")]
        public bool BdRestricted { get; set; }

        [JsonProperty("ageCategory")]
        public string AgeCategory { get; set; }

        [JsonProperty("cache")]
        public bool Cache { get; set; }

        [JsonProperty("isConnected")]
        public bool IsConnected { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("jurisdiction")]
        public string Jurisdiction { get; set; }

        [JsonProperty("profileStatus")]
        public string ProfileStatus { get; set; }

        [JsonProperty("profileMode")]
        public string ProfileMode { get; set; }

        [JsonProperty("profileHidden")]
        public bool ProfileHidden { get; set; }

        [JsonProperty("profilePermission")]
        public string ProfilePermission { get; set; }

        [JsonProperty("searchable")]
        public bool Searchable { get; set; }

        [JsonProperty("profileUrl")]
        public string ProfileUrl { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }
    [Serializable]
    public class Image
    {
        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }
    }

}
