using System.Net.Mime;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Queries;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Services;
using ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Resources;
using ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Tutorial Endpoints")]
public class TutorialsController(
    ITutorialCommandService tutorialCommandService,
    ITutorialQueryService tutorialQueryService) : ControllerBase
{
    [HttpGet("{tutorialId:int}")]
    [SwaggerOperation( 
        Summary = "Get Tutorial by Id",
        Description = "Returns a tutorial by its unique identifier.",
        OperationId = "GetTutorialById")]
    [SwaggerResponse(StatusCodes.Status200OK, "Tutorial found", typeof(TutorialResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Tutorial not found")]
    public async Task<IActionResult> GetTutorialById([FromRoute] int tutorialId)
    {
        var getTutorialByIdQuery = new GetTutorialByIdQuery(tutorialId);
        var tutorial = await tutorialQueryService.Handle(getTutorialByIdQuery);
        if (tutorial is null) return NotFound();
        var resource = TutorialResourceFromEntityAssembler.ToResourceFromEntity(tutorial);
        return Ok(resource);
    }

    [HttpPost]
    [SwaggerOperation( 
        Summary = "Create a new Tutorial",
        Description = "Creates a new tutorial in the system.",
        OperationId = "CreateTutorial")]
    [SwaggerResponse(StatusCodes.Status201Created, "Tutorial created", typeof(TutorialResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Failed to create tutorial")]
    public async Task<IActionResult> CreateTutorial([FromBody] CreateTutorialResource resource)
    {
        var createTutorialCommand = CreateTutorialCommandFromResourceAssembler.ToCommandFromResource(resource);
        var tutorial = await tutorialCommandService.Handle(createTutorialCommand);
        if (tutorial is null) return BadRequest("Failed to create tutorial.");
        var createdResource = TutorialResourceFromEntityAssembler.ToResourceFromEntity(tutorial);
        return CreatedAtAction(nameof(GetTutorialById), new { tutorialId = createdResource.Id }, createdResource);
    }

    [HttpGet]
    [SwaggerOperation( 
        Summary = "Get All Tutorials",
        Description = "Returns a list of all tutorials.",
        OperationId = "GetAllTutorials")]
    [SwaggerResponse(StatusCodes.Status200OK, "List of tutorials", typeof(IEnumerable<TutorialResource>))]
    public async Task<IActionResult> GetAllTutorials()
    {
        var getAllTutorialsQuery = new GetAllTutorialsQuery();
        var tutorials = await tutorialQueryService.Handle(getAllTutorialsQuery);
        var resources = tutorials.Select(TutorialResourceFromEntityAssembler.ToResourceFromEntity).ToList();
        return Ok(resources);
    }

    [HttpPost("{tutorialId:int}/videos")]
    [SwaggerOperation( 
        Summary = "Add Video to Tutorial",
        Description = "Adds a video asset to an existing tutorial.",
        OperationId = "AddVideoToTutorial")]
    [SwaggerResponse(StatusCodes.Status201Created, "Video added to tutorial", typeof(TutorialResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Failed to add video to tutorial")]
    public async Task<IActionResult> AddVideoToTutorial([FromBody] AddVideoAssetToTutorialResource resource,
        [FromRoute] int tutorialId)
    {
        var addVideoAssetToTutorialCommand = AddVideoAssetToTutorialCommandFromResourceAssembler
            .ToCommandFromResource(resource, tutorialId);
        var tutorial = await tutorialCommandService.Handle(addVideoAssetToTutorialCommand);
        if (tutorial is null) return BadRequest("Failed to add video to tutorial.");
        var updatedResource = TutorialResourceFromEntityAssembler.ToResourceFromEntity(tutorial);
        return CreatedAtAction(nameof(GetTutorialById), new { tutorialId = updatedResource.Id }, updatedResource);
    }
}