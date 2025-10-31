
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BaiTapAbp.Authorization;
using BaiTapAbp.Entities.Enum;
using Volo.Abp.Identity;

namespace BaiTapAbp.Entities;
[Table("AbpUsers")]
public class UserEntity :  IdentityUser
{

    [Required]
    [MaxLength(100)]
    public string FullName { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    [MaxLength(100)]
    public string Address { get; set; } = string.Empty;
    public UserEntity() 
        : base()
    {
    }
    public UserEntity(
        Guid id, 
        string userName, 
        string email, 
        Guid? tenantId = null)
        : base(id, userName, email, tenantId) 
    {
    }
    
    
}