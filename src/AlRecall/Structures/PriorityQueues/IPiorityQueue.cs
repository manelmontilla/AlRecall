namespace Alrecall.Structures.PriorityQueues
{
    public interface IPriorityQueue<T>
    {
        void EnqueueElement(T Element);
        T PeekElement();
        T DequeueElement();
    }
}