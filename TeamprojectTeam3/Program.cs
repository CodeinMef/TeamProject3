using System.Diagnostics;

public class Program
{
    public static void Main(string[] args)
    {
        Magazine magazine = new Magazine("Ежемесячный технический журнал", Frequency.Monthly, DateTime.Now, 5000);
        Console.WriteLine(magazine.ToShortString());
        Console.WriteLine($"Еженедельно: {magazine[Frequency.Weekly]}");
        Console.WriteLine($"Ежемесячно: {magazine[Frequency.Monthly]}");
        Console.WriteLine($"Ежегодно: {magazine[Frequency.Yearly]}");
        magazine.Title = "Еженедельный научный журнал";
        magazine.Frequency = Frequency.Weekly;
        magazine.ReleaseDate = new DateTime(2024, 12, 31);
        magazine.Circulation = 3000;
        Console.WriteLine(magazine.ToString());
        Article article1 = new Article(new Person("Илья", "Ilya@example.com"), "Будущее искусственного интеллекта", 4.8);
        Article article2 = new Article(new Person("Макар", "Makar@example.com"), "Космонавтика", 4.5);
        magazine.AddArticles(article1, article2);
        Console.WriteLine(magazine.ToString());
        int numberOfArticles = 1000;
        Article[] oneDimensionalArray = new Article[numberOfArticles];
        Article[,] twoDimensionalArray = new Article[10, 100];
        Article[][] jaggedArray = new Article[10][];
        for (int i = 0; i < jaggedArray.Length; i++)
        {
            jaggedArray[i] = new Article[100];
        }

        for (int i = 0; i < numberOfArticles; i++)
        {
            Article article = new Article(new Person($"Author {i}", $"author{i}@example.com"), $"Article {i}", 4.0 + (i % 5) * 0.1);
            oneDimensionalArray[i] = article;
            twoDimensionalArray[i / 100, i % 100] = article;
            jaggedArray[i / 100][i % 100] = article;
        }
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        foreach (var article in oneDimensionalArray)
        {
            var title = article.Title;
        }
        stopwatch.Stop();
        Console.WriteLine($"One-dimensional array time: {stopwatch.ElapsedMilliseconds} ms");

        stopwatch.Restart();
        for (int i = 0; i < twoDimensionalArray.GetLength(0); i++)
        {
            for (int j = 0; j < twoDimensionalArray.GetLength(1); j++)
            {
                var title = twoDimensionalArray[i, j].Title;
            }
        }
        stopwatch.Stop();
        Console.WriteLine($"Two-dimensional array time: {stopwatch.ElapsedMilliseconds} ms");
        stopwatch.Restart();
        for (int i = 0; i < jaggedArray.Length; i++)
        {
            for (int j = 0; j < jaggedArray[i].Length; j++)
            {
                var title = jaggedArray[i][j].Title;
            }
        }
        stopwatch.Stop();
        Console.WriteLine($"Jagged array time: {stopwatch.ElapsedMilliseconds} ms");
    }
}

