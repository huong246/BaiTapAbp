using System;
using System.ComponentModel.DataAnnotations;

namespace BaiTapAbp.Dtos;

public class CreateUpdateProductDto
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    [Required]
    [Range(0, (double)decimal.MaxValue)]
    public decimal Price { get; set; }
    [Range(0, int.MaxValue)]
    public int Stock { get; set; }
    [Required]
    public int ShopId { get; set; }
}
public class BookPagedRequestDto: BasePagedResultRequestDto
{
    
}