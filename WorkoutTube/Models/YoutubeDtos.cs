namespace WorkoutTube.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public partial class YoutubeDto
    {
        [JsonProperty("items")]
        public List<VideoItem> Items { get; set; }
    }

    public partial class VideoItem
    {
        [JsonProperty("id")]
        public Id Id { get; set; }

        [JsonProperty("snippet")]
        public Snippet Snippet { get; set; }
    }

    public partial class Snippet
    {
        [JsonProperty("publishedAt")]
        public DateTimeOffset PublishedAt { get; set; }

        [JsonProperty("channelId")]
        public string ChannelId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("thumbnails")]
        public Thumbnails Thumbnails { get; set; }

        [JsonProperty("channelTitle")]
        public string ChannelTitle { get; set; }
    }

    public partial class Thumbnails
    {
        [JsonProperty("default")]
        public Default Default { get; set; }

        [JsonProperty("medium")]
        public Default Medium { get; set; }

        [JsonProperty("high")]
        public Default High { get; set; }
    }

    public partial class Default
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }
    }

    public partial class Id
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("videoId")]
        public string VideoId { get; set; }
    }
}