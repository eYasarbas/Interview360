using AutoMapper;
using Interview360.Application.Features.Auth.Commands.Login;
using Interview360.Application.Features.Auth.Commands.Register;
using Interview360.Application.Features.Auth.Commands.ResetPassword;
using Interview360.Application.Features.Auth.Dtos;
using Interview360.Application.Features.Categories.Commands.CreateCategory;
using Interview360.Application.Features.Categories.Dtos;
using Interview360.Domain.AppEntities.Content;
using Interview360.Domain.Identity;

namespace Interview360.Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Category mappings
        CreateMap<Category, CategoryResponseDto>();
        CreateMap<CreateCategoryCommand, Category>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(dest => dest.CreateDateTime, opt => opt.MapFrom(src => DateTime.UtcNow));

        // User mappings
        CreateMap<ApplicationUser, UserResponseDto>()
            .ForMember(dest => dest.Token, opt => opt.Ignore());
        CreateMap<LoginCommand, LoginDto>();
        CreateMap<RegisterCommand, RegisterDto>();
        CreateMap<ResetPasswordCommand, ResetPasswordDto>();
    }
} 