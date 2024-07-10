using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DeskCore
{
    public class Graph<TElem> : IEnumerable<TElem>
    {
        private readonly List<TElem> _elements = new();
        private readonly List<Edge<TElem>> _edges = new();

        public ReadOnlyCollection<TElem> Elements => _elements.AsReadOnly();
        public ReadOnlyCollection<Edge<TElem>> Edges => _edges.AsReadOnly();
        
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

        public IEnumerator<TElem> GetEnumerator() => _elements.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}