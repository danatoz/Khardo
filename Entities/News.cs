using Entities.Base;

namespace Entities
{
    public class News : Entity
	{
	    public string Title { get; set; }
	    public string Url { get; set; }
	    public string Content { get; set; }
	    public DateTime CreationDate { get; set; }
    }
}
