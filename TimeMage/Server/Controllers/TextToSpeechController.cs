using Microsoft.AspNetCore.Mvc;
using Microsoft.CognitiveServices.Speech;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;
using TimeMage.Shared.Dtos;

namespace TimeMage.Server.Controllers
{
    [Route("texttospeech")]
    [ApiController]
    public class TextToSpeechController : Controller
    {
        private readonly IDistributedCache _distributedCache;
        private readonly ILogger<TextToSpeechController> _logger;
        private readonly SpeechConfig _speechConfig;

        public TextToSpeechController(
            IDistributedCache distributedCache,
            IConfiguration configuration,
            ILogger<TextToSpeechController> logger)
        {
            _distributedCache = distributedCache;
            _speechConfig = SpeechConfig.FromSubscription(configuration["Speech:SubscriptionKey"], configuration["Speech:Region"]);
            _logger = logger;
        }

        [HttpPost("getspeech")]
        public async Task<IActionResult> GetSpeech([FromBody] TextDto textDto)
        {
            try
            {
                var text = textDto.Text;
                var audioData = await _distributedCache.GetAsync(text);

                if (audioData != null)
                {
                    return Ok(audioData);
                }

                using var synthesizer = new SpeechSynthesizer(_speechConfig);
                using var result = await synthesizer.SpeakTextAsync(text);

                if (result.Reason == ResultReason.SynthesizingAudioCompleted)
                {
                    _logger.LogInformation($"Speech synthesized to speaker for text [{text}]");
                    audioData = result.AudioData;
                    await _distributedCache.SetAsync(text, audioData);
                    return Ok(audioData);
                }
                else if (result.Reason == ResultReason.Canceled)
                {
                    var cancellation = SpeechSynthesisCancellationDetails.FromResult(result);
                    _logger.LogWarning($"CANCELED: Reason={cancellation.Reason}");

                    if (cancellation.Reason == CancellationReason.Error)
                    {
                        _logger.LogWarning($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                        _logger.LogWarning($"CANCELED: ErrorDetails=[{cancellation.ErrorDetails}]");
                        _logger.LogWarning($"CANCELED: Did you update the subscription info?");
                    }

                    return StatusCode((int)HttpStatusCode.InternalServerError, cancellation);
                }

                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

    }
}
