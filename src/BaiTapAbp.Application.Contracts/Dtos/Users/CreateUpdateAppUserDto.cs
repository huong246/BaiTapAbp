using System.ComponentModel.DataAnnotations;
using BaiTapAbp.Entities.Enum;
using Volo.Abp.Identity;

namespace BaiTapAbp.Dtos;

public class CreateUpdateAppUserDto :IdentityUserCreateOrUpdateDtoBase
{
    [Required]
    [MaxLength(100)]
    public string FullName { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    [MaxLength(100)]
    public string Address { get; set; } = string.Empty;
    public decimal Balance { get; set; }
}