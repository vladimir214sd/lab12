namespace EmojiLibrary
{
    public class TPoint<T> where T: IComparable
    {
        public T? Data { get; set; }
        public TPoint<T>? Left { get; set; }
        public TPoint<T>? Right { get; set; }

        public TPoint()
        {
            this.Data = default(T);
            this.Left = null;
            this.Right = null;
        }

        public TPoint(T data)
        {
            this.Data = data;
            this.Left = null;
            this.Right = null;
        }

        public override string? ToString()
        {
            if (Data == null)
                return "";
            else
                return Data.ToString();
        }
        public int CompareTo(TPoint<T> other)
        {
            return Data.CompareTo(other.Data);
        }
    }
}