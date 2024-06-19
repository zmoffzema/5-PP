using System;
using System.Text.RegularExpressions;

class TextAnalyzer
{
    static void Main()
    {
        Console.WriteLine("Анализ текста");

        // Запрашиваем ввод текста у пользователя
        Console.WriteLine("Введите текст (завершите ввод пустой строкой):");
        string input;
        string text = "";
        while ((input = Console.ReadLine()) != null && input != "")
        {
            text += input + "\n";
        }

        // Считаем количество слов
        int wordCount = CountWords(text);

        // Считаем количество предложений
        int sentenceCount = CountSentences(text);

        // Считаем количество абзацев
        int paragraphCount = CountParagraphs(text);

        // Выводим результаты
        Console.WriteLine($"Количество слов: {wordCount}");
        Console.WriteLine($"Количество предложений: {sentenceCount}");
        Console.WriteLine($"Количество абзацев: {paragraphCount}");
    }

    static int CountWords(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return 0;

        // Используем регулярное выражение для поиска слов
        MatchCollection matches = Regex.Matches(text, @"\b\w+\b");
        return matches.Count;
    }

    static int CountSentences(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return 0;

        // Используем регулярное выражение для поиска предложений
        MatchCollection matches = Regex.Matches(text, @"[.!?]\s");
        return matches.Count + 1; // Добавляем 1 для последнего предложения, если текст не пустой
    }

    static int CountParagraphs(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return 0;

        // Используем регулярное выражение для поиска абзацев
        string[] paragraphs = text.Split(new[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        return paragraphs.Length;
    }
}
