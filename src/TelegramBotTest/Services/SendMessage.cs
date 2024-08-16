﻿using System.Text.Json.Serialization;

namespace TelegramBotTest.Services
{
    public class SendMessage
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("chat_id")]
        public long? ChatId { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("text")]
        public string? Text { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("reply_markup")]
        public ReplyMarkup? ReplyMarkup { get; set; }
    }
    public class ReplyMarkup
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("keyboard")]
        public List<List<Keyboard>>? Keyboard { get; set; }
       
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("remove_keyboard")]
        public bool? RemoveKeyboard { get; set; }=false;
    }

    public class Keyboard
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("text")]
        public string? Text { get; set; }
    }
}
