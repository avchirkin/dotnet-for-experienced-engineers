namespace NestedClassesAndMethods
{
    public class OtherExpressionEvaluator
    {
        public double Evaluate(string rawExpression)
        {
            var tokens = Parse(rawExpression);

            // ...

            return 0;

            // Вложенный метод виден только в пределах родительского метода
            string[] Parse(string rawExpression)
            {
                return rawExpression.Split(new char[] { '+', '-', '*', '/' });
            }
        }
    }
}
