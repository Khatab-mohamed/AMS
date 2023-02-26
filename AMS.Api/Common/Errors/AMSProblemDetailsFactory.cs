namespace AMS.Api.Common.Errors;
public class AmsProblemDetailsFactory : ProblemDetailsFactory
{

#nullable disable
    private readonly ApiBehaviorOptions _options;
    private readonly Action<ProblemDetailsContext> _configure;


#nullable enable
    public AmsProblemDetailsFactory(
      IOptions<ApiBehaviorOptions> options,
      IOptions<ProblemDetailsOptions>? problemDetailsOptions = null)
    {
        _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
        _configure = problemDetailsOptions?.Value?.CustomizeProblemDetails;
    }

    public override ProblemDetails CreateProblemDetails(
      HttpContext httpContext,
      int? statusCode = null,
      string? title = null,
      string? type = null,
      string? detail = null,
      string? instance = null)
    {
        statusCode.GetValueOrDefault();
        if (!statusCode.HasValue)
            statusCode = new int?(500);
        ProblemDetails problemDetails = new ProblemDetails()
        {
            Status = statusCode,
            Title = title,
            Type = type,
            Detail = detail,
            Instance = instance
        };
        ApplyProblemDetailsDefaults(httpContext, problemDetails, statusCode.Value);
        return problemDetails;
    }

    public override ValidationProblemDetails CreateValidationProblemDetails(
      HttpContext httpContext,
      ModelStateDictionary modelStateDictionary,
      int? statusCode = null,
      string? title = null,
      string? type = null,
      string? detail = null,
      string? instance = null)
    {
        if (modelStateDictionary == null)
            throw new ArgumentNullException(nameof(modelStateDictionary));
        statusCode.GetValueOrDefault();
        if (!statusCode.HasValue)
            statusCode = new int?(400);
        ValidationProblemDetails validationProblemDetails1 = new ValidationProblemDetails(modelStateDictionary);
        validationProblemDetails1.Status = statusCode;
        validationProblemDetails1.Type = type;
        validationProblemDetails1.Detail = detail;
        validationProblemDetails1.Instance = instance;
        ValidationProblemDetails validationProblemDetails2 = validationProblemDetails1;
        if (title != null)
            validationProblemDetails2.Title = title;
        ApplyProblemDetailsDefaults(httpContext, validationProblemDetails2, statusCode.Value);
        return validationProblemDetails2;
    }


#nullable disable
    private void ApplyProblemDetailsDefaults(
      HttpContext httpContext,
      ProblemDetails problemDetails,
      int statusCode)
    {
        ProblemDetails problemDetails1 = problemDetails;
        int? status = problemDetails1.Status;
        status.GetValueOrDefault();
        if (!status.HasValue)
        {
            int num = statusCode;
            problemDetails1.Status = new int?(num);
        }
        ClientErrorData clientErrorData;
        if (_options.ClientErrorMapping.TryGetValue(statusCode, out clientErrorData))
        {
            ProblemDetails problemDetails2 = problemDetails;
            string str;
            if (problemDetails2.Title == null)
                problemDetails2.Title = str = clientErrorData.Title;
            ProblemDetails problemDetails3 = problemDetails;
            if (problemDetails3.Type == null)
                problemDetails3.Type = str = clientErrorData.Link;
        }
        string str1 = Activity.Current?.Id ?? httpContext?.TraceIdentifier;
        if (str1 != null)
            problemDetails.Extensions["traceId"] = str1;
        Action<ProblemDetailsContext> configure = _configure;
        if (configure == null)
            return;
        configure(new ProblemDetailsContext()
        {
            HttpContext = httpContext,
            ProblemDetails = problemDetails
        });

        var errors = httpContext?.Items[HttpContextItemKeys.Errors] as List<Error>;
        if (errors is not null)
        {
            problemDetails.Extensions.Add("errorCodes",errors.Select(e=>e.Code));
        }

        problemDetails.Extensions.Add("customProperty", "CustomValue");
    }
}