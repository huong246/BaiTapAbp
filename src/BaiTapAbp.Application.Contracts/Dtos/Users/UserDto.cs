using System;
using BaiTapAbp.Entities.Enum;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace BaiTapAbp.Dtos;

public class UserDto : IdentityUserDto
{
    public string FullName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public decimal Balance { get; set; }
    public Gender Gender { get; set; }
}

