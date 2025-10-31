using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using BaiTapAbp.Authorization;
using BaiTapAbp.Entities;
using BaiTapAbp.Entities.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Volo.Abp.Account;
using Volo.Abp.Account.Emailing;
using Volo.Abp.Identity;

namespace BaiTapAbp.Services;

public class UserAccountService(
    IdentityUserManager userManager,
    IIdentityRoleRepository roleRepository,
    IAccountEmailer accountEmailer,
    IdentitySecurityLogManager identitySecurityLogManager,
    IOptions<IdentityOptions> identityOptions)
    : AccountAppService(userManager, roleRepository, accountEmailer, identitySecurityLogManager, identityOptions)
{
     public class UserRegisterDto: RegisterDto
     {
         [Required] [MaxLength(100)] public string FullName { get; set; } = string.Empty;
         public Gender Gender { get; set; }
         [MaxLength(100)]
         public string Address { get; set; } = string.Empty;
     }

     public async Task<IdentityUserDto> RegisterUserAsync(UserRegisterDto input)
     {
         var user = new UserEntity(
             GuidGenerator.Create(),
             input.UserName,
             input.EmailAddress,
             CurrentTenant.Id)
         {
             FullName = input.FullName,
             Address = input.Address,
             Gender = input.Gender,
         };
         (await UserManager.CreateAsync(user, input.Password)).CheckErrors();
         (await UserManager.AddToRoleAsync(user, UserRole.Customer)).CheckErrors();
         return ObjectMapper.Map<UserEntity, IdentityUserDto>(user);
     }
}