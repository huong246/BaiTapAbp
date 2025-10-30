using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace BaiTapAbp.Dtos;

public class ShopDto : EntityDto<int>
{
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public DateTime CreateTime { get; set; }
}

 