using System.Collections.Generic;
using System.Linq;

namespace DeskCore
{
    public class Graph<TElem>
    {
        private List<TElem> _elements;
        private List<Edge<TElem>> _edges;

        public void AddElement(TElem elem)
        {
            _elements.Add(elem);
        }

        public void RemoveElement(TElem elem)
        {
            _elements.Remove(elem);
        }

        public void AddEdge(TElem first, TElem second, float weight = 0f)
        {
            AddEdge(new Edge<TElem>(first, second, weight));
        }

        private void AddEdge(Edge<TElem> edge)
        {
            _edges.Add(edge);
        }

        private void RemoveEdge(TElem first, TElem second)
        {
            var edges = _edges.Where(x => x.ContainsBoth(first, second)).ToList();
            foreach (var edge in edges)
            {
                RemoveEdge(edge);
            }
        }

        private void RemoveEdge(Edge<TElem> edge)
        {
            _edges.Remove(edge);
        }

        public bool Contains(TElem elem)
        {
            return _elements.Contains(elem);
        }
    }
}