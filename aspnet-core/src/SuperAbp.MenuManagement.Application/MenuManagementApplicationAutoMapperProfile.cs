using AutoMapper;
using SuperAbp.MenuManagement.Menus;

namespace SuperAbp.MenuManagement;

public class MenuManagementApplicationAutoMapperProfile : Profile
{
    public MenuManagementApplicationAutoMapperProfile()
    {
        CreateMap<Menu, MenuListDto>();
        CreateMap<MenuCreateDto, Menu>()
            .ForMember(entity => entity.Id,
                opt => opt.Ignore())
            .ForMember(entity => entity.Parent,
                opt => opt.Ignore())
            .ForMember(entity => entity.CreatorId,
                opt => opt.Ignore())
            .ForMember(entity => entity.CreationTime,
                opt => opt.Ignore())
            .ForMember(entity => entity.DeleterId,
                opt => opt.Ignore())
            .ForMember(entity => entity.DeletionTime,
                opt => opt.Ignore())
            .ForMember(entity => entity.IsDeleted,
                opt => opt.Ignore())
            .ForMember(entity => entity.LastModifierId,
                opt => opt.Ignore())
            .ForMember(entity => entity.LastModificationTime,
                opt => opt.Ignore());
        CreateMap<MenuUpdateDto, Menu>()
            .ForMember(entity => entity.Id,
                opt => opt.Ignore())
            .ForMember(entity => entity.Parent,
                opt => opt.Ignore())
            .ForMember(entity => entity.CreatorId,
                opt => opt.Ignore())
            .ForMember(entity => entity.CreationTime,
                opt => opt.Ignore())
            .ForMember(entity => entity.DeleterId,
                opt => opt.Ignore())
            .ForMember(entity => entity.DeletionTime,
                opt => opt.Ignore())
            .ForMember(entity => entity.IsDeleted,
                opt => opt.Ignore())
            .ForMember(entity => entity.LastModifierId,
                opt => opt.Ignore())
            .ForMember(entity => entity.LastModificationTime,
                opt => opt.Ignore());
        CreateMap<Menu, MenuTreeNodeDto>()
            .ForMember(entity => entity.IsLeaf,
                opt => opt.Ignore());
        CreateMap<Menu, GetMenuForEditorOutput>();


    }
}
