using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Exceptions;

namespace Task2.Controllers;

[ApiController]
[Route("api.telegram.org/bot8083931685:AAFMubAlDXhrpsHeAkBwPJJs_l-MvZD4QVE")]
public class TelegramController : ControllerBase
{
    private readonly string token = "8083931685:AAFMubAlDXhrpsHeAkBwPJJs_l-MvZD4QVE";
    private readonly long chatId = 1100986435;

    [HttpPost("sendMessage")]
    public async Task<IActionResult> SendMessage()
    {
        try
        {
            string message = "Привет!";
            var client = new TelegramBotClient(token);
            await client.SendTextMessageAsync(chatId, message);
            return Ok($"Сообщение \"{message}\" отправлено");
        }
        catch (ApiRequestException ex)
        {
            return StatusCode(ex.ErrorCode, ex.Message);
        }
    }
}