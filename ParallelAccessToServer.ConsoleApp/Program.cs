using ParallelAccessToServer.ConsoleApp;

try
{
    Parallel.For(1, 50, i =>
    {
        if (i % 4 == 0)
            Server.AddToCount(2);
        else
            Console.WriteLine(Server.GetCount());
    });

    //По окончанию ожидаем, что count = 24
    Console.WriteLine(Server.GetCount());
    Console.WriteLine("End.");
}
catch
{
    Console.WriteLine("Error");
}

Console.ReadKey();