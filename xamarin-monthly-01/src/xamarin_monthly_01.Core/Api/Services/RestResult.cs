using System;
using System.Collections.Generic;
using System.Text;

namespace xamarin_monthly_01.Core.Api.Services
{
    public class RestResult
    {
        public bool Success { get; set; }
        public Exception Exception { get; set; }
        public RestError Error { get; set; }
    }

    public class RestResult<TEntity> : RestResult
    {
        public TEntity Entity { get; set; }
    }

    public class RestResult<TEntity, TError> : RestResult<TEntity>
    {
        public new RestError<TError> Error { get; set; }
    }

    public class ErrorRestResult<TError> : RestResult
    {
        public new RestError<TError> Error { get; set; }
    }

    public class RestError
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public string TraceId { get; set; }
    }

    public class RestError<TError> : RestError
    {
        public TError Errors { get; set; }
    }
}
