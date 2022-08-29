using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.TreeModel
{
    public class Node<TData>
    {
	    public TData Data { get; set; }
	    public IList<Node<TData>> Children { get; set; }

	    public Node(TData value, IEnumerable<Node<TData>> children)
	    {
		    this.Data = value;
		    this.Children = new List<Node<TData>>(children);
	    }
    }
}
