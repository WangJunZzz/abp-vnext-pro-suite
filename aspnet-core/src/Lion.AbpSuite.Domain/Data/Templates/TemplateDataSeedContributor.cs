using Lion.AbpSuite.Files;
using Volo.Abp.Timing;

namespace Lion.AbpSuite.Data.Templates;

public class TemplateDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly ITemplateRepository _templateRepository;
    private readonly IFileLoader _fileLoader;
    private readonly IClock _clock;
    private readonly IGuidGenerator _guidGenerator;
    private readonly ICurrentTenant _currentTenant;

    public TemplateDataSeedContributor(ITemplateRepository templateRepository, IFileLoader fileLoader, IClock clock, IGuidGenerator guidGenerator, ICurrentTenant currentTenant)
    {
        _templateRepository = templateRepository;
        _fileLoader = fileLoader;
        _clock = clock;
        _guidGenerator = guidGenerator;
        _currentTenant = currentTenant;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        await TemplateAsync();
    }

    public async Task TemplateAsync()
    {
        var templateGroup = await _templateRepository.FindByNameAsync(StandardTemplateDataSeedConst.TemplateGroupName);

        if (templateGroup != null) return;

        #region 模板组

        if (templateGroup == null)
        {
            templateGroup = new Template(_guidGenerator.Create(), StandardTemplateDataSeedConst.TemplateGroupName, "系统初始化模板", _currentTenant.Id);
        }

        #endregion

        #region AspNetCore

        TemplateDetail aspNetCore = null;
        if (templateGroup.TemplateDetails.FirstOrDefault(e => e.Name == StandardTemplateDataSeedConst.AspNetCore.Name) == null)
        {
            aspNetCore = AddFolder(templateGroup, StandardTemplateDataSeedConst.AspNetCore.Name);
        }

        #endregion

        #region src

        TemplateDetail src;
        src = AddFolder(templateGroup, StandardTemplateDataSeedConst.AspNetCore.Src.Name, parentId: aspNetCore?.Id);

        #endregion

        #region Controller

        TemplateDetail controller;
        controller = AddFolder(templateGroup, StandardTemplateDataSeedConst.AspNetCore.Src.Controller.Name, parentId: src.Id);
        AddFile(templateGroup,
            StandardTemplateDataSeedConst.AspNetCore.Src.Controller.ControllerName,
            ControlType.Aggregate,
            await _fileLoader.LoadAsync(StandardTemplateDataSeedConst.AspNetCore.Src.Controller.ControllerPath),
            controller.Id);

        #endregion

        #region Application

        TemplateDetail application;
        application = AddFolder(templateGroup, StandardTemplateDataSeedConst.AspNetCore.Src.Application.Name, parentId: src.Id);
        AddFile(templateGroup,
            StandardTemplateDataSeedConst.AspNetCore.Src.Application.ApplicationServiceName,
            ControlType.Aggregate,
            await _fileLoader.LoadAsync(StandardTemplateDataSeedConst.AspNetCore.Src.Application.ApplicationServicePath),
            application.Id);
        AddFile(templateGroup,
            StandardTemplateDataSeedConst.AspNetCore.Src.Application.AutoMapperName,
            ControlType.Global,
            await _fileLoader.LoadAsync(StandardTemplateDataSeedConst.AspNetCore.Src.Application.AutoMapperPath),
            application.Id);

        #endregion

        #region ApplicationContracts

        TemplateDetail applicationContracts;
        applicationContracts = AddFolder(templateGroup, StandardTemplateDataSeedConst.AspNetCore.Src.ApplicationContracts.Name, parentId: src.Id);
        AddFile(templateGroup,
            StandardTemplateDataSeedConst.AspNetCore.Src.ApplicationContracts.IApplicationServiceName,
            ControlType.Aggregate,
            await _fileLoader.LoadAsync(StandardTemplateDataSeedConst.AspNetCore.Src.ApplicationContracts.IApplicationServicePath),
            applicationContracts.Id);
        AddFile(templateGroup,
            StandardTemplateDataSeedConst.AspNetCore.Src.ApplicationContracts.CreateInputName,
            ControlType.Aggregate,
            await _fileLoader.LoadAsync(StandardTemplateDataSeedConst.AspNetCore.Src.ApplicationContracts.CreateInputPath),
            applicationContracts.Id);
        AddFile(templateGroup,
            StandardTemplateDataSeedConst.AspNetCore.Src.ApplicationContracts.UpdateInputName,
            ControlType.Aggregate,
            await _fileLoader.LoadAsync(StandardTemplateDataSeedConst.AspNetCore.Src.ApplicationContracts.UpdateInputPath),
            applicationContracts.Id);
        AddFile(templateGroup,
            StandardTemplateDataSeedConst.AspNetCore.Src.ApplicationContracts.DeleteInputName,
            ControlType.Aggregate,
            await _fileLoader.LoadAsync(StandardTemplateDataSeedConst.AspNetCore.Src.ApplicationContracts.DeleteInputPath),
            applicationContracts.Id);
        AddFile(templateGroup,
            StandardTemplateDataSeedConst.AspNetCore.Src.ApplicationContracts.PageInputName,
            ControlType.Aggregate,
            await _fileLoader.LoadAsync(StandardTemplateDataSeedConst.AspNetCore.Src.ApplicationContracts.PageInputPath),
            applicationContracts.Id);
        AddFile(templateGroup,
            StandardTemplateDataSeedConst.AspNetCore.Src.ApplicationContracts.PageOutputName,
            ControlType.Aggregate,
            await _fileLoader.LoadAsync(StandardTemplateDataSeedConst.AspNetCore.Src.ApplicationContracts.PageOutputPath),
            applicationContracts.Id);

        #endregion

        #region Domain

        TemplateDetail domain;
        domain = AddFolder(templateGroup, StandardTemplateDataSeedConst.AspNetCore.Src.Domain.Name, parentId: src.Id);
        AddFile(templateGroup,
            StandardTemplateDataSeedConst.AspNetCore.Src.Domain.AggregateCodeName,
            ControlType.Aggregate,
            await _fileLoader.LoadAsync(StandardTemplateDataSeedConst.AspNetCore.Src.Domain.AggregateCodePath),
            domain.Id);
        AddFile(templateGroup,
            StandardTemplateDataSeedConst.AspNetCore.Src.Domain.EntityCodeName,
            ControlType.Entity,
            await _fileLoader.LoadAsync(StandardTemplateDataSeedConst.AspNetCore.Src.Domain.EntityCodePath),
            domain.Id);
        AddFile(templateGroup,
            StandardTemplateDataSeedConst.AspNetCore.Src.Domain.AggregateCodeRepositoryName,
            ControlType.Aggregate,
            await _fileLoader.LoadAsync(StandardTemplateDataSeedConst.AspNetCore.Src.Domain.AggregateCodeRepositoryPath),
            domain.Id);
        AddFile(templateGroup,
            StandardTemplateDataSeedConst.AspNetCore.Src.Domain.AggregateCodeManagerName,
            ControlType.Aggregate,
            await _fileLoader.LoadAsync(StandardTemplateDataSeedConst.AspNetCore.Src.Domain.AggregateCodeManagerPath),
            domain.Id);
        AddFile(templateGroup,
            StandardTemplateDataSeedConst.AspNetCore.Src.Domain.AutoMapperName,
            ControlType.Global,
            await _fileLoader.LoadAsync(StandardTemplateDataSeedConst.AspNetCore.Src.Domain.AutoMapperPath),
            domain.Id);

        # endregion

        #region DomainShared

        TemplateDetail domainShared;
        domainShared = AddFolder(templateGroup, StandardTemplateDataSeedConst.AspNetCore.Src.DomainShared.Name, parentId: src.Id);
        AddFile(templateGroup,
            StandardTemplateDataSeedConst.AspNetCore.Src.DomainShared.AggregateCodeName,
            ControlType.Aggregate,
            await _fileLoader.LoadAsync(StandardTemplateDataSeedConst.AspNetCore.Src.DomainShared.AggregateCodePath),
            domainShared.Id);
        AddFile(templateGroup,
            StandardTemplateDataSeedConst.AspNetCore.Src.DomainShared.EntityCodeName,
            ControlType.Entity,
            await _fileLoader.LoadAsync(StandardTemplateDataSeedConst.AspNetCore.Src.DomainShared.EntityCodePath),
            domainShared.Id);
        AddFile(templateGroup,
            StandardTemplateDataSeedConst.AspNetCore.Src.DomainShared.EnumName,
            ControlType.Enum,
            await _fileLoader.LoadAsync(StandardTemplateDataSeedConst.AspNetCore.Src.DomainShared.EnumPath),
            domainShared.Id);

        # endregion

        #region EntityFrameworkCore

        TemplateDetail entityFrameworkCore;
        entityFrameworkCore = AddFolder(templateGroup, StandardTemplateDataSeedConst.AspNetCore.Src.EntityFrameworkCore.Name, parentId: src.Id);
        AddFile(templateGroup,
            StandardTemplateDataSeedConst.AspNetCore.Src.EntityFrameworkCore.IDbContextName,
            ControlType.Global,
            await _fileLoader.LoadAsync(StandardTemplateDataSeedConst.AspNetCore.Src.EntityFrameworkCore.IDbContextPath),
            entityFrameworkCore.Id);
        AddFile(templateGroup,
            StandardTemplateDataSeedConst.AspNetCore.Src.EntityFrameworkCore.DbContextName,
            ControlType.Global,
            await _fileLoader.LoadAsync(StandardTemplateDataSeedConst.AspNetCore.Src.EntityFrameworkCore.DbContextPath),
            entityFrameworkCore.Id);
        AddFile(templateGroup,
            StandardTemplateDataSeedConst.AspNetCore.Src.EntityFrameworkCore.RepositoryName,
            ControlType.Aggregate,
            await _fileLoader.LoadAsync(StandardTemplateDataSeedConst.AspNetCore.Src.EntityFrameworkCore.RepositoryPath),
            entityFrameworkCore.Id);
        AddFile(templateGroup,
            StandardTemplateDataSeedConst.AspNetCore.Src.EntityFrameworkCore.DbContextModelCreatingName,
            ControlType.Global,
            await _fileLoader.LoadAsync(StandardTemplateDataSeedConst.AspNetCore.Src.EntityFrameworkCore.DbContextModelCreatingPath),
            entityFrameworkCore.Id);

        # endregion

        #region Vue3

        TemplateDetail vue3 = null;
        if (templateGroup.TemplateDetails.FirstOrDefault(e => e.Name == StandardTemplateDataSeedConst.Vue3.Name) == null)
        {
            vue3 = AddFolder(templateGroup, StandardTemplateDataSeedConst.Vue3.Name);
        }

        #endregion

        #region src

        TemplateDetail vueSrc;
        vueSrc = AddFolder(templateGroup, StandardTemplateDataSeedConst.AspNetCore.Src.Name, parentId: vue3?.Id);

        #endregion

        #region routes

        TemplateDetail route;
        route = AddFolder(templateGroup, StandardTemplateDataSeedConst.Vue3.Src.Routes.Name, parentId: vueSrc.Id);
        AddFile(templateGroup,
            StandardTemplateDataSeedConst.Vue3.Src.Routes.RouteName,
            ControlType.Aggregate,
            await _fileLoader.LoadAsync(StandardTemplateDataSeedConst.Vue3.Src.Routes.RoutePath),
            route.Id);

        #endregion

        #region views

        TemplateDetail view;
        view = AddFolder(templateGroup, StandardTemplateDataSeedConst.Vue3.Src.Views.Name, parentId: vueSrc.Id);
        AddFile(templateGroup,
            StandardTemplateDataSeedConst.Vue3.Src.Views.IndexName,
            ControlType.Aggregate,
            await _fileLoader.LoadAsync(StandardTemplateDataSeedConst.Vue3.Src.Views.IndexPath),
            view.Id);
        AddFile(templateGroup,
            StandardTemplateDataSeedConst.Vue3.Src.Views.IndexVueName,
            ControlType.Aggregate,
            await _fileLoader.LoadAsync(StandardTemplateDataSeedConst.Vue3.Src.Views.IndexVuePath),
            view.Id);
        AddFile(templateGroup,
            StandardTemplateDataSeedConst.Vue3.Src.Views.CreateVueName,
            ControlType.Aggregate,
            await _fileLoader.LoadAsync(StandardTemplateDataSeedConst.Vue3.Src.Views.CreateVuePath),
            view.Id);
        AddFile(templateGroup,
            StandardTemplateDataSeedConst.Vue3.Src.Views.UpdateVueName,
            ControlType.Aggregate,
            await _fileLoader.LoadAsync(StandardTemplateDataSeedConst.Vue3.Src.Views.UpdateVuePath),
            view.Id);

        #endregion

        await _templateRepository.InsertAsync(templateGroup);
    }

    private TemplateDetail AddFolder(Template template, string name, string description = "Default", Guid? parentId = null)
    {
        var detail = template.AddTemplateDetail(_guidGenerator.Create(), TemplateType.Folder, null, name, description, string.Empty, parentId);
        return detail;
    }

    private TemplateDetail AddFile(Template template, string name, ControlType controlType, string content, Guid parentId, string description = "Default")
    {
        var detail = template.AddTemplateDetail(_guidGenerator.Create(), TemplateType.File, controlType, name, description, content, parentId);
        return detail;
    }
}