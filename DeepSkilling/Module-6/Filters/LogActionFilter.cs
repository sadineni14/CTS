using Microsoft.AspNetCore.Mvc.Filters;

// Middleware and custom filters sub-topic
public class LogActionFilter : IActionFilter
{
    private readonly ILogger<LogActionFilter> _logger;
    public LogActionFilter(ILogger<LogActionFilter> logger) => _logger = logger;

    public void OnActionExecuting(ActionExecutingContext context)
    {
        _logger.LogInformation("Executing action {Action} with arguments: {@Arguments}",
            context.ActionDescriptor.DisplayName, context.ActionArguments);
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        _logger.LogInformation("Executed action {Action}, status: {Status}",
            context.ActionDescriptor.DisplayName, context.HttpContext.Response.StatusCode);
    }
}

// Register globally in Program.cs:
//   builder.Services.AddControllers(options => options.Filters.Add<LogActionFilter>());
// Or apply to a single controller/action with [ServiceFilter(typeof(LogActionFilter))]
