namespace Lion.AbpSuite.Extensions.Middlewares;

public static class AbpSuiteApplicationBuilderExtensionsExtensions
{
    /// <summary>
    /// 记录请求响应日志
    /// </summary>
    /// <returns></returns>
    public static IApplicationBuilder UseRequestLog(this IApplicationBuilder app)
    {
        return app.UseMiddleware<RequestLogMiddleware>();
    }
}