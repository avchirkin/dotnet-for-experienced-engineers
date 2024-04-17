namespace InOutRefKeywords
{
    internal class PointProcessor
    {
        public void IncreasePoint(Point point)
        {
            point.X++;
            point.Y++;
        }

        public void IncreasePoint(ref Point point)
        {
            point.X++;
            point.Y++;
        }

        public void DoNothing(in Point point)
        {
            // Ошибка! point доступна только для чтения (readonly)
            // point.X++;
            // point.Y++;

            Console.WriteLine(point);
        }
    }
}
