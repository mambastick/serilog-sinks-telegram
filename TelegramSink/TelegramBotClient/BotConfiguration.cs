namespace TelegramSink.TelegramBotClient
{
	public class BotConfiguration()
	{
		public string ChatId { get; set; }
		public string? MessageThreadId { get; set; }
		public string ApiKey { get; set; }
	}
}