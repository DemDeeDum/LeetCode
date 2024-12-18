namespace LeetCode.Tasks.Medium
{
    public class LRUCache
    {
        private int maxCapacity;
        private LinkedList<DataItem> keysUsage;
        private Dictionary<int, LinkedListNode<DataItem>> storedData;

        public LRUCache(int capacity)
        {
            keysUsage = new LinkedList<DataItem>();
            storedData = new Dictionary<int, LinkedListNode<DataItem>>(capacity);
            maxCapacity = capacity;
        }

        public int Get(int key)
        {
            if (storedData.ContainsKey(key))
            {
                var node = storedData[key];
                keysUsage.Remove(node);
                storedData[key] = keysUsage.AddFirst(node.Value);

                return node.Value.Value;
            }

            return -1;
        }

        public void Put(int key, int value)
        {
            if (storedData.ContainsKey(key))
            {
                keysUsage.Remove(storedData[key]);
            }
            else if (maxCapacity <= storedData.Count)
            {
                var oldest = keysUsage.Last!.Value;
                keysUsage.RemoveLast();
                storedData.Remove(oldest.Key);
            }

            storedData[key] = keysUsage.AddFirst(new DataItem { Key = key, Value = value });
        }

        struct DataItem
        {
            public int Key;

            public int Value;
        }
    }
}
