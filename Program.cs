using System.Globalization;

class Program
{
    // Добавьте студенту s все оценки из массива scores.
    // Используйте метод s.AddScore(...). Проверять диапазон 0–100 не нужно:
    // это уже делает класс Student (неверные оценки он не примет).
    static void AddScores(Student s, int[] scores)
    {
    foreach (int score in scores)
        s.AddScore(score);
    }
    // Верните строку списка: "<номер>. <имя>: <средний балл, округлённый до 0,1>".
    // Если у студента нет оценок: "<номер>. <имя>: нет оценок".
    // Пример: FormatLine(1, студент Сериков Дамир с оценками 72, 65, 80) → "1. Сериков Дамир: 72,3"
    static string FormatLine(int number, Student s)
    {
    if (!s.HasScores)
          return $"{number}. {s.Name}: нет оценок";
    return $"{number}. {s.Name}: {Math.Round(s.Average, 1)}";
    }
    // Выведите весь список группы: по одной строке FormatLine на студента, нумерация с 1.
    static void PrintList(Student[] group)
    {
    int number = 1;
         foreach (Student s in group)
{
    Console.WriteLine(FormatLine(number, s));
    number++;
}
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        CultureInfo.CurrentCulture = new CultureInfo("ru-RU"); // дробная часть через запятую

        string groupName = "Ис-25-26б";
        Student[] group =
        {
            new Student("Сериков Дамир", groupName),
            new Student("Ахметова Айгерим", groupName),
            new Student("Ким Анна", groupName),
            new Student("Петровых Александр", groupName),
            new Student("Бекова Мадина", groupName),
            new Student("Ли Виктор", groupName),
            new Student("Жумабаев Нурлан", groupName),
            new Student("Денисова Ольга", groupName),
        };
        AddScores(group[0], new[] { 72, 65, 80 });
        AddScores(group[1], new[] { 95, 88, 92 });
        AddScores(group[2], new[] { 100, 90 });
        AddScores(group[3], new[] { 60, 55, 70, 59 });
        AddScores(group[4], new[] { 85, 90, 78 });
        AddScores(group[5], new int[0]);              // у Ли Виктора пока нет оценок
        AddScores(group[6], new[] { 88, 92 });
        AddScores(group[7], new[] { 85, 85 });

        Check("Сериков Дамир: Count", group[0].Count, 3);
        Check("Сериков Дамир: Average", group[0].Average, 72.33);
        Check("Ким Анна: Average", group[2].Average, 95);

        var test = new Student("Тестов Тест", groupName);
        AddScores(test, new[] { 50, 150, 70, -10, 90 });
        Check("Тестов Тест: Count (150 и -10 не принимаются)", test.Count, 3);
        Check("Тестов Тест: Average", test.Average, 70);

        var many = new Student("Много Оценок", groupName);
        AddScores(many, new[] { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 });
        Check("Много Оценок: Count (не больше 10)", many.Count, 10);

        Check("FormatLine(1, Сериков Дамир)", FormatLine(1, group[0]), "1. Сериков Дамир: 72,3");
        Check("FormatLine(2, Ахметова Айгерим)", FormatLine(2, group[1]), "2. Ахметова Айгерим: 91,7");
        Check("FormatLine(3, Ким Анна)", FormatLine(3, group[2]), "3. Ким Анна: 95");
        Check("FormatLine(6, Ли Виктор)", FormatLine(6, group[5]), "6. Ли Виктор: нет оценок");

        Console.WriteLine();
        Console.WriteLine($"Список группы {groupName}:");
        PrintList(group);
    }

    static void Check(string what, int result, int expected)
    {
        string status = result == expected ? "OK" : "ОШИБКА";
        Console.WriteLine($"{what}: получено {result}, ожидалось {expected} - {status}");
    }

    static void Check(string what, double result, double expected)
    {
        string status = Math.Abs(result - expected) < 0.005 ? "OK" : "ОШИБКА";
        Console.WriteLine($"{what}: получено {Math.Round(result, 2)}, ожидалось {expected} - {status}");
    }

    static void Check(string what, string result, string expected)
    {
        string status = result == expected ? "OK" : "ОШИБКА";
        Console.WriteLine($"{what}: получено {result}, ожидалось {expected} - {status}");
    }
}
