using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Refit;

namespace xamarin_monthly_01.Core.Api.Services
{
    public class ServiceBase
    {
        protected ILogger Logger { get; }

        public ServiceBase(ILogger logger)
        {
            Logger = logger;
        }

        protected virtual async Task<ErrorRestResult<TError>> InvokeWebRequest<TError>(Func<Task<IApiResponse<object>>> func, Func<Exception, Task> onError = null)
        {
            try
            {
                var response = await func();

                return new()
                {
                    Success = response.IsSuccessStatusCode,
                    Error = response.Error?.HasContent == true
                        ? await response.Error.GetContentAsAsync<RestError<TError>>()
                        : default,
                };
            }
            catch (ApiException ex)
            {
                Logger.LogError(nameof(InvokeWebRequest), ex);
                if (onError is not null)
                {
                    await onError(ex);
                }
                return new()
                {
                    Success = false,
                    Exception = ex,
                    Error = ex.HasContent
                        ? await ex.GetContentAsAsync<RestError<TError>>()
                        : default,
                };
            }
        }

        protected virtual async Task<RestResult<TEntity, TError>> InvokeWebRequest<TEntity, TError>(Func<Task<IApiResponse<TEntity>>> func, Func<Exception, Task> onError = null)
        {
            try
            {
                var response = await func();

                return new()
                {
                    Entity = response.Content ?? default,
                    Success = response.IsSuccessStatusCode,
                    Error = response.Error?.HasContent == true
                        ? await response.Error.GetContentAsAsync<RestError<TError>>()
                        : default,
                };
            }
            catch (ApiException ex)
            {
                Logger.LogError(nameof(InvokeWebRequest), ex);
                if (onError != null)
                {
                    await onError(ex);
                }
                return new()
                {
                    Entity = default,
                    Success = false,
                    Exception = ex,
                    Error = ex.HasContent
                        ? await ex.GetContentAsAsync<RestError<TError>>()
                        : default,
                };
            }
        }

        protected virtual async Task<RestResult<TEntity>> InvokeWebRequest<TEntity>(Func<Task<IApiResponse<TEntity>>> func, Func<Exception, Task> onError = null)
        {
            try
            {
                var response = await func();

                return new()
                {
                    Entity = response.Content ?? default,
                    Success = response.IsSuccessStatusCode,
                    Error = response.Error?.HasContent == true
                        ? await response.Error.GetContentAsAsync<RestError>()
                        : default,
                };
            }
            catch (ApiException ex)
            {
                Logger.LogError(nameof(InvokeWebRequest), ex);
                if (onError != null)
                {
                    await onError(ex);
                }
                return new()
                {
                    Entity = default,
                    Success = false,
                    Exception = ex,
                    Error = ex.HasContent
                        ? await ex.GetContentAsAsync<RestError>()
                        : default,
                };
            }
        }

        protected virtual async Task<RestResult> InvokeWebRequest(Func<Task<IApiResponse>> func, Func<Exception, Task> onError = null)
        {
            try
            {
                var response = await func();
                return new()
                {
                    Success = response.IsSuccessStatusCode,
                    Error = response.Error?.HasContent == true
                        ? await response.Error.GetContentAsAsync<RestError>()
                        : default
                };
            }
            catch (ApiException ex)
            {
                Logger.LogError(nameof(InvokeWebRequest), ex);
                if (onError != null)
                {
                    await onError(ex);
                }
                return new()
                {
                    Success = false,
                    Exception = ex,
                    Error = ex.HasContent
                        ? await ex.GetContentAsAsync<RestError>()
                        : default,
                };
            }
        }
    }
}
