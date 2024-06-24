using ABCofRealEstate.Data.Enums;
using Bogus.DataSets;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Runtime.Serialization;

namespace ABCofRealEstate.WebApi.Controllers;

[ApiController]
[Route("api/v1.2")]
public class EntityController : Controller
{
    [HttpGet("Entities")]
    public Task<IActionResult> GetEntities()
        => Task.FromResult(GetArrayNamesEnum<EnumObject>());

    [HttpGet("ConditionHouses")]
    public Task<IActionResult> GetConditionHouses()
        => Task.FromResult(GetArrayNamesEnum<EnumConditionHouse>());

    [HttpGet("JobTitles")]
    public Task<IActionResult> GetJobTitles()
        => Task.FromResult(GetArrayNamesEnum<EnumJobTitleEmployee>());

    [HttpGet("Localities")]
    public Task<IActionResult> GetLocalities()
        => Task.FromResult(GetArrayNamesEnum<EnumLocality>());

    [HttpGet("MaterialHouses")]
    public Task<IActionResult> GetMaterialHouses()
        => Task.FromResult(GetArrayNamesEnum<EnumMaterialHouse>());

    [HttpGet("TypeSales")]
    public Task<IActionResult> GetTypeSales()
        => Task.FromResult(GetArrayNamesEnum<EnumTypeSale>());
    //private IActionResult GetArrayNamesEnum<TEnum>() where TEnum : Enum
    //   => Ok(Enum.GetNames(typeof(TEnum)).Select(e => typeof(TEnum).GetField(e)?
    //        .GetCustomAttribute<EnumMemberAttribute>()?.Value ?? e));

    private IActionResult GetArrayNamesEnum<TEnum>() where TEnum : Enum
       => Ok(Enum.GetNames(typeof(TEnum)).Select(e => e.ToString()));
}