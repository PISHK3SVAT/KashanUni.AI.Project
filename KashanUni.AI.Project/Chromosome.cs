namespace KashanUni.AI.Project
{
    public class Chromosome<T>(int n, List<T> allel)
    {
        private T[] values=new T[n];
        public readonly List<T> allel = allel;
        public T[] Values 
        { 
            get => values;
            set
            {
                if (value.Length != n)
                    throw new ArgumentException($"input lenght is wrong, it should be equal to {n}");
                for (int i = 0; i < n; i++)
                    values[i] = value[i];
            }
        }
        public T this[int index]
        {
            get => values[index];
            set
            {
                if (!allel.Contains(value))
                    throw new ArgumentOutOfRangeException("value is not in allel so it's not valid!");
                values[index] = value;
            }
        }

        public override string ToString()
        {
            var result = "";
            foreach (var v in Values)
                result += v.ToString() + "|";
            result=result.Remove(result.Length - 1);
            return result;
        }
    }
}
