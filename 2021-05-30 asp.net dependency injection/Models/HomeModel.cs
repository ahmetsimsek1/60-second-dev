using Microsoft.Extensions.Logging;

public record HomeModel(ILogger Logger, string GameName, string CarModel);
