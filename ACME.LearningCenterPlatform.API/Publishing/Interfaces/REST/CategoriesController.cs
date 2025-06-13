using System.Net.Mime;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Queries;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Services;
using ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Resources;
using ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST;

/// <summary>
/// The category controller 
/// </summary>
/// <param name="categoryCommandService">
/// The command service for handling category commands.
/// </param>
/// <param name="categoryQueryService">
/// The query service for handling category queries.
/// </param>
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Category Endpoints")]
public class CategoriesController(
    ICategoryCommandService categoryCommandService,
    ICategoryQueryService categoryQueryService) : ControllerBase
{
    /// <summary>
    /// Gets a category by its unique identifier.
    /// </summary>
    /// <param name="categoryId">
    /// The unique identifier of the category to retrieve.
    /// </param>
    /// <returns>
    /// An <see cref="IActionResult"/> containing the category resource if found, or a 404 Not Found response if not found.
    /// </returns>
    [HttpGet("{categoryId:int}")]
    [SwaggerOperation(
        Summary = "Get Category by Id",
        Description = "Returns a category by its unique identifier.",
        OperationId = "GetCategoryById")]
    [SwaggerResponse(StatusCodes.Status200OK, "Category found", typeof(CategoryResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Category not found")]
    public async Task<IActionResult> GetCategoryById(int categoryId)
    {
        var getCategoryByIdQuery = new GetCategoryByIdQuery(categoryId);
        var category = await categoryQueryService.Handle(getCategoryByIdQuery);
        if (category is null) return NotFound();
        var resource = CategoryResourceFromEntityAssembler.ToResourceFromEntity(category);
        return Ok(resource);
    }

    /// <summary>
    /// Creates a new category in the system.
    /// </summary>
    /// <param name="resource">
    /// The resource containing the details of the category to create.
    /// </param>
    /// <returns>
    /// An <see cref="IActionResult"/> containing the created category resource with a 201 Created status code, or a 400 Bad Request if the creation failed.
    /// </returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create Category",
        Description = "Creates a new category in the system.",
        OperationId = "CreateCategory")]
    [SwaggerResponse(StatusCodes.Status201Created, "Category created", typeof(CategoryResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The category could not be created")]   
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryResource resource)
    {
        var createCategoryCommand = CreateCategoryCommandFromResourceAssembler.ToCommandFromResource(resource);
        var category = await categoryCommandService.Handle(createCategoryCommand);
        if (category is null) return BadRequest("Category could not be created.");
        var createdResource = CategoryResourceFromEntityAssembler.ToResourceFromEntity(category);
        return CreatedAtAction(nameof(GetCategoryById), new { categoryId = createdResource.Id }, createdResource);
    }
    
    /// <summary>
    /// Gets all categories in the system.
    /// </summary>
    /// <returns>
    /// An <see cref="IActionResult"/> containing a list of all categories as resources.
    /// </returns>
    [HttpGet]
    [SwaggerOperation( 
        Summary = "Get All Categories",
        Description = "Returns a list of all categories in the system.",
        OperationId = "GetAllCategories")]
    [SwaggerResponse(StatusCodes.Status200OK, "List of categories", typeof(IEnumerable<CategoryResource>))]
    public async Task<IActionResult> GetAllCategories()
    {
        var getAllCategoriesQuery = new GetAllCategoriesQuery();
        var categories = await categoryQueryService.Handle(getAllCategoriesQuery);
        var resources = categories.Select(CategoryResourceFromEntityAssembler.ToResourceFromEntity).ToList();
        return Ok(resources);
    }
    
}