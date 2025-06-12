using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Aggregates;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Repositories;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Services;
using ACME.LearningCenterPlatform.API.Shared.Domain.Repositories;

namespace ACME.LearningCenterPlatform.API.Publishing.Application.Internal.CommandServices;

public class TutorialCommandService(
    ITutorialRepository tutorialRepository,
    IUnitOfWork unitOfWork,
    ICategoryRepository categoryRepository) : ITutorialCommandService
{
    public async Task<Tutorial?> Handle(AddVideoAssetToTutorialCommand command)
    {
        var tutorial = await tutorialRepository.FindByIdAsync(command.TutorialId);
        if(tutorial is null) throw new ArgumentException($"Tutorial with ID {command.TutorialId} not found.");
        tutorial.AddVideo(command.VideoUrl);
        await unitOfWork.CompleteAsync();
        return tutorial;
    }

    public async Task<Tutorial?> Handle(AddImageAssetToTutorialCommand command)
    {
        var tutorial = await tutorialRepository.FindByIdAsync(command.TutorialId);
        if(tutorial is null) throw new ArgumentException($"Tutorial with ID {command.TutorialId} not found.");
        tutorial.AddImage(command.ImageUrl);
        await unitOfWork.CompleteAsync();
        return tutorial;
    }

    public async Task<Tutorial?> Handle(AddReadableContentAssetToTutorialCommand command)
    {
        var tutorial = await tutorialRepository.FindByIdAsync(command.TutorialId);
        if(tutorial is null) throw new ArgumentException($"Tutorial with ID {command.TutorialId} not found.");
        tutorial.AddReadableContent(command.Content);
        await unitOfWork.CompleteAsync();
        return tutorial;
    }

    public async Task<Tutorial?> Handle(CreateTutorialCommand command)
    {
        var category = await categoryRepository.FindByIdAsync(command.CategoryId);
        if (category is null) throw new ArgumentException($"Category with ID {command.CategoryId} not found.");

        var tutorial = new Tutorial(command);
        await tutorialRepository.AddAsync(tutorial);
        await unitOfWork.CompleteAsync();
        tutorial.Category = category;
        return tutorial;
    }
}