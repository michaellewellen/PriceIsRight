Random rand = new Random();
List<int> numbers = new List<int>(){25,90,5,100,15,80,35,60,20,40,75,55,95,50,85,30,65,10,45,70};
Console.BackgroundColor=ConsoleColor.Black;

int start = 0;
int selection;
int[] player = new int[3];
for (int i = 1; i<=3; i++)
{
    Console.Clear();
    int firstSpin = 0;
    int secondSpin = 0;
    int total = 0;
    Console.Write($"Player {i}, from 1-10, how hard do you want to spin the wheel? ");
    selection = Convert.ToInt32(Console.ReadLine());
    firstSpin = SpinWheel(start, selection, numbers);
    start = numbers.IndexOf(firstSpin)-3;
    if (start < 0)
        start +=20;
    Console.Write($"You spun {firstSpin}, do you want to spin again? ");
    char response = Console.ReadKey(true).KeyChar;
    Console.WriteLine(response);
    if (response == 'y' || response == 'Y')
    {
        Console.Write($"Player {i}, from 1-10, how hard do you want to spin the wheel? ");
        selection = Convert.ToInt32(Console.ReadLine());
        secondSpin = SpinWheel(start,selection, numbers);
        start = numbers.IndexOf(secondSpin)-3;
        if (start < 0)
            start +=20;
    }
    total = firstSpin + secondSpin;
    if (total > 100 )
    {
        Console.WriteLine("\nYou went over.");
        total = 0;         
    }
    else if (total < 100)
    {
        Console.WriteLine($"\nYour total is {total}");        
    }
    player[i-1] = total;
    displayScores(player);
}
for (int i = 0; i<3; i++)
{
    if (player[i] == 100)
    {
        Console.Write($"Player {i}, from 1-10, how hard do you want to spin the wheel? ");   
        selection = Convert.ToInt32(Console.ReadLine());
        start = numbers.IndexOf(4-3);
        int bigMoney = SpinWheel(start,selection, numbers);
        if (bigMoney == 100)
            Console.WriteLine ("You won $10,000 and got 1.00 for the showdown");
        else if (bigMoney == 5 || bigMoney == 15)
            Console.WriteLine ($"You won $5,000 and got {bigMoney} for the showdown");
        else    
            Console.WriteLine ($"You didn't win any money but you got {bigMoney} for the showdown");
    }
}
static void displayScores(int[] player)
{
    Console.SetCursorPosition(0,10);
    Console.WriteLine("Current Standings:");
    for (int i = 0; i<3; i ++)
    {
        Console.WriteLine($"Player {i+1}: {player[i]}");
    }
    Console.WriteLine("Press any key to continue");
    Console.ReadKey();
}
static int SpinWheel(int start, int selection, List<int> numbers)
{
    Random rand = new Random();
    List<int> slowDown = new List<int>(){100,200,300,400,500,600,700,800,900,1000,1200,1500};
    Console.BackgroundColor= ConsoleColor.Black;
    Console.Clear();
    int difficultyFactor = selection switch
    {
        1=>rand.Next(0,9),
        2=>rand.Next(10,19),
        3=>rand.Next(20,29),
        4=>rand.Next(30,39),
        5=>rand.Next(40,49),
        6=>rand.Next(50,59),
        7=>rand.Next(60,69),
        8=>rand.Next(70,79),
        9=>rand.Next(80,99),
        10=>rand.Next(90,99),
        _=>rand.Next(40,49)    
    };
    Queue<int> myQueue = new Queue<int>();
    for(int i = 0; i<difficultyFactor + 8; i ++)
        myQueue.Enqueue(50);
    foreach (int x in slowDown)
        myQueue.Enqueue(x);

        Console.BackgroundColor=ConsoleColor.Black;
        Console.Clear();
    while(myQueue.TryDequeue(out int result))
    {
        Console.SetCursorPosition(0,0);
        int count = start;
        bool tick = true;
        (int left, int top) position;
        string buffer = "";
        position =  Console.GetCursorPosition();
        tick = drawArrow(tick,position);
        for(int i = 0; i<7; i++)
        {
            Console.GetCursorPosition();
            Console.BackgroundColor = ConsoleColor.Black;
            buffer = getBuffer(numbers[count]);
            if(numbers[count] == 100)
            {
                Console.BackgroundColor = ConsoleColor.Red;
            }
            else if(numbers[count] == 5 || numbers[count] == 15)
                Console.BackgroundColor = ConsoleColor.Green;
            else if (count % 2 == 0)
                Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("     " + numbers[count]+ buffer);
            count ++;
            if (count >= 20)
                count = count-20;
        }
        Thread.Sleep(result);
        start ++;
        if (start >= 20)
            start = start - 20;
    }
    int number = 0;
    if (start + 2 >= 20)
        number = start + 2 - 20;
    else    
        number = start + 2;
    Console.BackgroundColor = ConsoleColor.Black;
    return numbers[number];
}
static string getBuffer(int num)
{
    string buffer = "";
    string phrase = num.ToString();
    for (int i = 0; i< 8 - phrase.Length; i++)
        buffer += " ";
    //Console.WriteLine ($"phrase = {phrase} phrase.Length = {phrase.Length} buffer.Length = {buffer.Length}");
    return buffer;
}
static bool drawArrow (bool tick, (int,int) position)
{
    Console.SetCursorPosition(14,3);
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.Red;
    if (tick)
        Console.Write("<--");
    else
        Console.Write("/--");
    Console.SetCursorPosition(position.Item1,position.Item2);
    Console.ForegroundColor = ConsoleColor.White;
    return !tick;
}
