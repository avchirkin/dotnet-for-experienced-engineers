namespace ClassExamples
{
    public class ExpressionEvaluator
    {
        public double Evaluate(string rawExpression)
        {
            var parser = new ExpressionParser();
            var tokens = parser.Parse(rawExpression);
            
            // ...

            return 0;
        }

        // Приватный nested-класс виден только из родительского метода, однако модификатор доступа можно расширить,
        // чтобы внутренний класс можно было использовать извне.
        private class ExpressionParser
        {
            public string[] Parse(string rawExpression)
            {
                return rawExpression.Split(new char[] { '+', '-', '*', '/' });
            }
        }
    }
}
