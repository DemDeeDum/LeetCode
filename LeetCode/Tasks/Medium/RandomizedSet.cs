namespace LeetCode.Tasks.Medium
{
    public class RandomizedSet
    {
        private HashSet<int> _data;
        private Random _random;

        public RandomizedSet()
        {
            _data = new HashSet<int>();
            _random = new Random();
        }

        public bool Insert(int val)
        {
            var result = !_data.Contains(val);
            if (result)
            {
                _data.Add(val);
            }

            return result;
        }

        public bool Remove(int val)
        {
            var result = _data.Contains(val);
            if (result)
            {
                _data.Remove(val);
            }

            return result;
        }

        public int GetRandom()
        {
            return _data.ElementAt(_random.Next(0, _data.Count));
        }
    }

    /**
     * Your RandomizedSet object will be instantiated and called as such:
     * RandomizedSet obj = new RandomizedSet();
     * bool param_1 = obj.Insert(val);
     * bool param_2 = obj.Remove(val);
     * int param_3 = obj.GetRandom();
     */
}
