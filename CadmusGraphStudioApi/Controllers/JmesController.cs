using CadmusGraphStudioApi.Models;
using DevLab.JmesPath;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace CadmusGraphStudioApi.Controllers;

[ApiController]
[Route("jmes")]
public sealed class JmesController : ControllerBase
{
    [HttpPost("transform")]
    public ErrorWrapper<string> Transform([FromBody] JmesTransformBindingModel model)
    {
        try
        {
            JmesPath jmes = new();
            string result = jmes.Transform(model.Json, model.Expression);
            return new ErrorWrapper<string> { Value = result };
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.ToString());
            return new ErrorWrapper<string> { Error = ex.Message };
        }
    }
}
