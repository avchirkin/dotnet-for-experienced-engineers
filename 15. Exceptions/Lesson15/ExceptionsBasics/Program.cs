using ExceptionsBasics;

// 1. Try-catch конструкции

// TryCatchSimple("not_a_number");
// TryCatchWithExceptionType("not_a_number");
// TryCatchWithMultipleExceptionTypes("");
/*
try
{
    TryCatchWithExceptionInstance("not_a_number");
}
catch(Exception ex)
{
    Console.WriteLine($"Catched: {ex.Message}");
}
*/

// 2. Try-catch-finally конструкции

/*
var lockObj = new object();
var threadOne = new Thread(() => TryCatchFinally(lockObj, "one"));
var threadTwo = new Thread(() => TryCatchFinally(lockObj, "two"));
threadOne.Start();
threadTwo.Start();
*/

// 3. Try-finally конструкции
/*
var threadThree = new Thread(() => TryFinally(lockObj, "one"));
var threadFour = new Thread(() => TryFinally(lockObj, "two"));
threadThree.Start();
threadFour.Start();
*/

// 4. Exception-фильтры

// TryWithFilters(new Customer("Petr", 16));
// TryWithFilters(new Customer("", 25));

void TryCatch(string input)
{
    // Блок try содержит в себе оборачиваемый потенциально выбрасывающий исключение код. Блок является обязательным в
    // механизме обработки исключений
    try
    {
        var number = int.Parse(input);
        Console.WriteLine($"{number} is number!");
    }
    // Блок catch служит для описания логики поведения в случае, если код в блоке try выбросил исключение.
    // Блок является опциональным
    catch
    {
        Console.WriteLine($"'{input}' is NOT a number!");
    }
}

void TryCatchWithExceptionType(string input)
{
    try
    {
        var number = int.Parse(input);
        Console.WriteLine($"{number} is number!");
    }
    // catch перехватит исключение только типа FormatException. Остальные исключения будут выброшены вверх по стеку
    catch(FormatException)
    {
        Console.WriteLine($"'{input}' is NOT a number!");
    }
}

void TryCatchWithMultipleExceptionTypes(string input)
{
    try
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentException("Empty argument", nameof(input));
        }

        var number = int.Parse(input);
        Console.WriteLine($"{number} is number!");
    }
    catch (ArgumentException)
    {
        Console.WriteLine("Input string was empty");
    }
    catch (FormatException)
    {
        Console.WriteLine($"'{input}' is NOT a number!");
    }
    catch (Exception)
    {
        Console.WriteLine("Something went wrong");
    }
}

void TryCatchWithExceptionInstance(string input)
{
    try
    {
        var number = int.Parse(input);
        Console.WriteLine($"{number} is number!");
    }
    catch (FormatException fex)
    {
        Console.WriteLine(fex.Message);
        // Залогировали исключение и повторно выбросили его вверх по стеку
        throw;
        // throw fex; // Если выбросить исключение с текущим инстансом - потеряем StackTrace исходного исключения
    }
}

void TryCatchFinally(object locker, string message)
{
    try
    {
        Monitor.Enter(locker);
        Console.WriteLine(message);
        throw new Exception();
    }
    catch (Exception)
    {
        Console.WriteLine("Exception has been thrown!");
    }
    // В блоке finally размещается recovery-логика
    finally
    {
        Monitor.Exit(locker);
    }
}

void TryFinally(object locker, string message)
{
    try
    {
        Monitor.Enter(locker);
        Console.WriteLine(message);
    }
    finally
    {
        Monitor.Exit(locker);
    }
}

void TryWithFilters(Customer customer)
{
    try
    {
        if (customer.Age < 18)
        {
            throw new CustomerValidationException(nameof(customer.Age));
        }
        
        if (customer.Name == string.Empty)
        {
            throw new CustomerValidationException(nameof(customer.Name));
        }
    }
    catch (CustomerValidationException ex) when (ex.Criteria == nameof(customer.Age))
    {
        Console.WriteLine($"This content is not avalable to customer with age {customer.Age}");
    }
    catch (CustomerValidationException ex) when (ex.Criteria == nameof(customer.Name))
    {
        Console.WriteLine("Incorrect customer name");
    }
}