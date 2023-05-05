using Cadmus.Graph;
using CadmusGraphStudioApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace CadmusGraphStudioApi.Controllers;

[ApiController]
[Route("api/mappings")]
public sealed class MappingController : ControllerBase
{
    private readonly JsonNodeMapper _mapper;

    public MappingController()
    {
        _mapper = new();
    }

    [HttpPost("run")]
    public ErrorWrapper<GraphSet> Run([FromBody] RunMappingBindingModel model)
    {
        try
        {
            // setup context
            GraphSet set = new();
            _mapper.Data.Clear();

            // mock metadata from item
            _mapper.Data["item-id"] = Guid.NewGuid().ToString();
            if (model.ItemEid != null) _mapper.Data["item-eid"] = model.ItemEid;
            _mapper.Data["item-uri"] = model.ItemUri;
            _mapper.Data["item-label"] = model.ItemLabel;
            if (model.GroupId != null) _mapper.Data["group-id"] = model.GroupId;
            _mapper.Data["facet-id"] = model.FacetId;
            if (model.Flags != null) _mapper.Data["flags"] = model.Flags;
            // mock metada from part
            _mapper.Data["part-id"] = Guid.NewGuid().ToString();

            // apply mappings
            foreach (var mapping in model.Mappings)
                _mapper.Map(model.Source, mapping.ToNodeMapping(), set);

            return new ErrorWrapper<GraphSet> { Value = set };
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.ToString());
            return new ErrorWrapper<GraphSet> { Error = ex.Message };
        }
    }
}
