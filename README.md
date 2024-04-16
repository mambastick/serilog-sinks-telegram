# Serilog.Sinks.Telegram

Writes [Serilog](https://serilog.net/) events to a given Telegram chat being it a private chat or a group.

# Install
```

Install-Package Serilog.Sinks.Telegram
```
Note that a Telegram bot api key is required in order to configure the sink, if you don't know how the bot creation process works please [refer to the official documentation](https://core.telegram.org/bots#3-how-do-i-create-a-bot).

# Configuration
To configure the sink simply add "TeleSink" using the "WriteTo" method on the Serilog logger configuration.

```c#

new LoggerConfiguration()
   .MinimumLevel.Information()
   .WriteTo.TeleSink(
      telegramApiKey:"my-bot-api-key",
      telegramChatId:"the target chat id")
   .CreateLogger();
```

Optionally a minimum log level can be specified:

```c#

new LoggerConfiguration()
   .MinimumLevel.Information()
   .WriteTo.TeleSink(
      telegramApiKey:"my-bot-api-key",
      telegramChatId:"the target chat id",
      minimumLevel:LogEventLevel.Warning)
   .CreateLogger();

```

Optionally a telegram forum topic can be specified:
```csharp
new LoggerConfiguration()
   .MinimumLevel.Information()
   .WriteTo.TeleSink(
      telegramApiKey:"my-bot-api-key",
      telegramChatId:"the target chat id",
      telegramMessageThreadId: "the target topic id")
   .CreateLogger();

```

### Q.A.
**How do i discover the chat id parameter?**

Once your bot is created simply open a chat towards it (or include it into a group), then you can use the Telegram API to get the last updates for your bot:

```

curl -X GET \
  https://api.telegram.org/bot<my-bot-api-key>/getUpdates \
  -H 'Cache-Control: no-cache'
```

The response should report the last conversations your bot had along with their chat ids:

```javascript

{
    "ok": true,
    "result": [
        {
            "update_id": 123456789,
            "message": {
                "message_id": 2,
                "from": {
                    "id": 000000,
                    "is_bot": false,
                    "first_name": "XXX",
                    "last_name": "XXX",
                    "username": "XXX",
                    "language_code": "XX"
                },
                "chat": {
                    "id": 0000000,
                    "first_name": "XXX",
                    "last_name": "XXX",
                    "username": "XXX",
                    "type": "private"
                },
                "date": 1531306919,
                "text": "hello dear bot!"
            }
        }
    ]
}
```

**How can i run unit tests?**

You need an api key and a chat id in order to run the unit tests. You can add them to the *Configuration/TestConfig.json* config file or (better solution) you can add another config file named */Configuration/TestConfig_private.json* and use it to store you secrets. This is the preferred solution if you want to make a pull request or fork & push the code to another repo since that path is already ignored.