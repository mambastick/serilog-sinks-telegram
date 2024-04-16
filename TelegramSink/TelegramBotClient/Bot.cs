using Flurl;
using Flurl.Http;
using TelegramSink.TelegramBotClient.Domain;

namespace TelegramSink.TelegramBotClient
{
    public class Bot(BotConfiguration botConfiguration)
    {
        private const string TelegramApiBaseUrl = "https://api.telegram.org";

        public RestResult SendMessage(string message)
        {
            var response = TelegramApiBaseUrl
                .AppendPathSegment($"bot{botConfiguration.ApiKey}/sendMessage")
                .PostJsonAsync(new 
                    {
                        chat_id = botConfiguration.ChatId,
                        message_thread_id = botConfiguration.MessageThreadId, 
                        text = message 
                    })
                .ReceiveJson<RestResult>().Result;

            return response;
        }
    }

    public abstract class RestResult
    {
		public bool Ok { get; set; }
        public Message Result { get; set; }
	}
}
