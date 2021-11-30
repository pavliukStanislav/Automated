using Newtonsoft.Json;
using Polly;
using Polly.Retry;
using Serilog;
using System.Reflection;

namespace Automated.API.Services
{
    public abstract class BaseService
    {
        protected BaseService(ILogger logger, string? token)
        {
            Logger = logger;
            Token = token ?? string.Empty;
        }

        protected ILogger Logger { get; }

        protected string Token { get; }

        protected string? ServiceName { get; init; }

        private RetryPolicy HttpRetryPolicy { get; } = Policy
                                                   .Handle<Exception>(
                                                     r => r.Message.Contains("524 (Origin Time-out)", StringComparison.Ordinal) ||
                                                          r.Message.Contains("403 (Forbidden)", StringComparison.Ordinal))
                                                   .WaitAndRetry(5, retryAttempt => TimeSpan.FromSeconds(retryAttempt));

        protected T ApiResponse<T>(Task<T> task)
        {
            try
            {
                T response = HttpRetryPolicy.Execute(() => task.ConfigureAwait(false).GetAwaiter().GetResult());

                Logger.Information($"RESPONSE {ServiceName}: {JsonConvert.SerializeObject(response)}");

                return response;
            }
            catch (Exception e)
            {
                Logger.Error(ErrorMessageTemplate(e));

                throw;
            }
        }

        private string ErrorMessageTemplate(Exception e) =>
            $"EXCEPTION in {MethodBase.GetCurrentMethod()?.Name}" +
            $"{e.Message}{(e.InnerException != null ? Environment.NewLine + e.InnerException : string.Empty)}";
    }
}
