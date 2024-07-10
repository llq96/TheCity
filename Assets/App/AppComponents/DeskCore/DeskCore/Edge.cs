namespace DeskCore
{
    public class Edge<TElem>
    {
        public TElem First { get; }
        public TElem Second { get; }
        public float Weight { get; }

        public Edge(TElem first, TElem second, float weight = 0f)
        {
            First = first;
            Second = second;
            Weight = weight;
        }

        public bool Contains(TElem elem)
        {
            return First.Equals(elem) || Second.Equals(elem);
        }

        public bool ContainsBoth(TElem first, TElem second)
        {
            return Contains(first) && Contains(second);
        }
    }
}