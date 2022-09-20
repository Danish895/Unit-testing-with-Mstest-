using Microsoft.Extensions.Primitives;
using Serilog;
using System.Linq;

namespace StructureOfProject.MIddlewares;
public class HttpInformationMiddleware
{
    private readonly ILogger<HttpInformationMiddleware> _logger;
    private readonly RequestDelegate _next;

    public HttpInformationMiddleware(ILogger<HttpInformationMiddleware> logger, RequestDelegate next )
    {
        _logger = logger;
        _next = next;
    }

    public async Task Invoke(HttpContext httpcontext)
    {
        _logger.LogInformation("I am before Middelware");

        var originalBodyStream = httpcontext.Response.Body;
        var memoryBodyStream = new MemoryStream();
        httpcontext.Response.Body = memoryBodyStream;

        httpcontext.Request.EnableBuffering();
        _logger.LogInformation(await new System.IO.StreamReader(httpcontext.Request.Body).ReadToEndAsync());
        httpcontext.Request.Body.Seek(0, SeekOrigin.Begin);

        _logger.LogInformation(httpcontext.Request.Method.ToString());
        _logger.LogInformation(httpcontext.Request.Path.ToString());
        //Console.WriteLine(await new System.IO.StreamReader(httpcontext.Request.Body).ReadToEndAsync());
        string headerData = String.Empty;
        foreach (StringValues keys in httpcontext.Request.Headers.Keys)
        {
            string strr = keys;
            string str = "Key :" + keys + "Values :" + httpcontext.Request.Headers[keys];
            headerData = headerData + str;
           // _logger.BeginScope(new Dictionary<string, object> { ["RequestHeaders"] = new Dictionary<string, object> { [(strr)] = httpcontext.Request.Headers[strr].ToString() } }) ;     
        }

        Log.ForContext("RequestHeaders", httpcontext.Request.Headers.ToDictionary(h => h.Key, h => h.Value), destructureObjects: true);
            
        _logger.LogInformation(headerData);
        

        //Sending request to next method in program.cs class
        await _next.Invoke( httpcontext );


        _logger.LogInformation("I am after Middelware");

        memoryBodyStream.Seek(0, SeekOrigin.Begin);
        string responseBody = await new StreamReader(memoryBodyStream).ReadToEndAsync();
        memoryBodyStream.Seek(0, SeekOrigin.Begin);

        await memoryBodyStream.CopyToAsync(originalBodyStream);

        _logger.LogInformation(httpcontext.Response.StatusCode.ToString());
        using (_logger.BeginScope(responseBody))
        {
            _logger.LogInformation(responseBody);
        }
    }
}

