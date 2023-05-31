using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CadmusGraphStudioApi.Models;

public sealed class RunMappingBindingModel
{
    [Required]
    [MaxLength(50000)]
    public string Source { get; set; }

    [Required]
    public List<NodeMappingBindingModel> Mappings { get; set; }

    public string ItemId { get; set; }
    public string PartId { get; set; }
    public string? PartTypeId { get; set; }
    public string? RoleId { get; set; }
    public string FacetId { get; set; }
    public string? ItemTitle { get; set; }
    public string ItemUri { get; set; }
    public string ItemLabel { get; set; }
    public string? ItemEid { get; set; }
    public string? MetadataPid { get; set; }
    public string? GroupId { get; set; }
    public string? Flags { get; set; }

    public RunMappingBindingModel()
    {
        Source = "";
        Mappings = new List<NodeMappingBindingModel>();
        FacetId = "";
        ItemId = Guid.NewGuid().ToString();
        ItemUri = "";
        ItemLabel = "";
        PartId = Guid.NewGuid().ToString();
    }
}
