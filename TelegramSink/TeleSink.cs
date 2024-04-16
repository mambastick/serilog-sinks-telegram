using System;
using Serilog.Core;
using Serilog.Events;
using TelegramSink.TelegramBotClient;

namespace TelegramSink
{
    public class TeleSink(
        IFormatProvider? formatProvider,
        string telegramApiKey,
        string chatId,
        LogEventLevel minimumLevel,
        string? messageThreadId = null)
        : ILogEventSink
    {
        private readonly Bot _telegramBot = new(botConfiguration: new BotConfiguration
        {
            ChatId = chatId,
            ApiKey = telegramApiKey,
            MessageThreadId = messageThreadId
        });

        public void Emit(LogEvent logEvent)
		{
		    if (logEvent.Level < minimumLevel) return;

            var loggedMessage = logEvent.RenderMessage(formatProvider);
            
            _telegramBot.SendMessage(loggedMessage);
        }
    }
}
