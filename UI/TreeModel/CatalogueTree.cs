using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Models;

namespace UI.TreeModel
{
	public static class CatalogueTree
	{
		public static IEnumerable<Node<TData>> Hierarchize<TData, TKey>(
			this IEnumerable<TData> elements,
			TKey topMostKey,
			Func<TData, TKey> keySelector,
			Func<TData, TKey> parentKeySelector)
		{
			var families = elements.ToLookup(parentKeySelector);
			var childrenFetcher = default(Func<TKey, IEnumerable<Node<TData>>>);
			childrenFetcher = parentId => families[parentId]
				.Select(x => new Node<TData>(x, childrenFetcher(keySelector(x))));

			return childrenFetcher(topMostKey);
		}

		public static void PrintNode(Node<CatalogModel> node, int level)
		{
			Console.WriteLine(node.Data?.Name);
			foreach (Node<CatalogModel> child in node.Children)
			{
				PrintNode(child, level + 1); //<-- recursive
			}
		}
	}
}
