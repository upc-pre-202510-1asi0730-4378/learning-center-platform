using System.Net.Mime;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Queries;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Services;
using ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST;

[ApiController]
[Route("api/v1/categories/{categoryId:int}/tutorials")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Categories")]
public class CategoryTutorialsController(
    ITutorialQueryService tutorialQueryService) : ControllerBase
{
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all tutorials) by category ID",
        Description = "Retrieves all tutorials associated with a specific category ID.",
        OperationId = "GetTutorialsByCategoryId")]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns a list of tutorials for the specified category ID.")]
    public async Task<IActionResult> GetTutorialsByCategoryId(int categoryId)
    {
        var getAllTutorialsByCategoryIdQuery = new GetAllTutorialsByCategoryIdQuery(categoryId);
        var tutorials = await tutorialQueryService.Handle(getAllTutorialsByCategoryIdQuery);
        var resources = tutorials.Select(TutorialResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}