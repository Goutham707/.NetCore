using System.ComponentModel.DataAnnotations;

namespace FirstProject.Dtos{
public class UpdateDto
{
[Required]
public string HowTo { get; set; }
[Required]
public string Line { get; set; }
[Required]
public string Platform { get; set; }

}
}