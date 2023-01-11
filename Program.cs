//Sinan Peherstorfer
int time = 0;
int counter = 0;
bool isDone = false;

PrintWelcome();

do
{
    Console.WriteLine($"Parkzeit bisher: {PrintParkingTime()}");
    Console.Write("Ihre Eingabe: ");
    string input = Console.ReadLine()!;
    counter++;
    isDone = EnterCoins(input, counter);
} while (!isDone);

void PrintWelcome()
{
    Console.WriteLine("Wilkommen beim Parkautomat!");
    Console.WriteLine("Zulässige Münzen: 50 (Cents), 10 (Cents), 20 (Cents), 50 (Cents), 1 (Euro), 2 (Euro)");
    Console.WriteLine("Parkschein drucken mit d oder D");
    System.Console.WriteLine();

}

bool EnterCoins(string input, int counter)
{
    if (input == "d" || input == "D")
        if (counter == 1)
        {
            Console.WriteLine("Mindesteinwurf 50 Cent");
            return false;
        }
        else
        {
            Console.WriteLine($"Sie dürfen {PrintParkingTime()} parken");
            return true;
        }
    else
    {
        AddParkingTime(input);
        if (time >= 130)
        {
            Console.WriteLine(PrintParkingTime());
            PrintDonation();
            return true;
        }
        else
        {
            return false;
        }
    }
}

int AddParkingTime(string input)
{
    switch (input)
    {
        case "5": time += 3; break;
        case "10": time += 6; break;
        case "20": time += 12; break;
        case "50": time += 30; break;
        case "1": time += 60; break;
        case "2": time += 120; break;
        default: time += 0; break;
    }
    return time;
}

string PrintParkingTime()
{
    int hours = time / 60;
    if (hours > 1)
        return $"Sie dürfen 01:30 Stunden parken";
    else
        return $"{hours}:{time - (hours * 60)}";
}

void PrintDonation()
{
    double donation = Convert.ToDouble(time / 60.00 - 1.50);
    Console.WriteLine($"Danke für Ihre Spende in Höhe von {donation:f2} Euro!");
}