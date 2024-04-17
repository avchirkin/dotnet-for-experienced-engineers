namespace StaticClassesExamples.Singletones
{
    // Статические классы - это классы, представленные одним экземпляром в приложении. Новые экземпляры статического класса
    // создать нельзя. Могут содержать только статические члены (поля, свойства, методы).
    internal class Singletone<T> where T : new()
    {
        private static T? _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new T();
                }

                return _instance;
            }
        }
    }
}
