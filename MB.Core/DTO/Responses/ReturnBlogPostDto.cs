using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Manager.DTO.Responses;

public class ReturnBlogPostDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
}