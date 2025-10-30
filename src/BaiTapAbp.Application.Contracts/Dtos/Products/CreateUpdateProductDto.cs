using System;

namespace BaiTapAbp.Dtos;

public class CreateUpdateProductDto
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
}
public class BookPagedRequestDto: BasePagedResultRequestDto
{
    
}