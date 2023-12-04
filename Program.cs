List<int> numbers = new List<int>(){25,90,5,100,15,80,35,60,20,40,75,55,95,50,85,30,65,10,45,70};
List<int> hard10 = new List<int>(){100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,200,300,400,500,600,700,800,900,1000,1200,1500};
List<int> hard9= new List<int>(){100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,200,300,400,500,600,700,800,900,1000,1200,1500};
List<int> hard8 = new List<int>(){100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,200,300,400,500,600,700,800,900,1000,1200,1500};
List<int> hard7 = new List<int>(){100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,200,300,400,500,600,700,800,900,1000,1200,1500};
List<int> hard6 = new List<int>(){100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,200,300,400,500,600,700,800,900,1000,1200,1500};
List<int> hard5 = new List<int>(){100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,200,300,400,500,600,700,800,900,1000,1200,1500};
List<int> hard4 = new List<int>(){100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,200,300,400,500,600,700,800,900,1000,1200,1500};
List<int> hard3 = new List<int>(){100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,200,300,400,500,600,700,800,900,1000,1200,1500};
List<int> hard2 = new List<int>(){100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,200,300,400,500,600,700,800,900,1000,1200,1500};
List<int> hard1 = new List<int>(){100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,200,300,400,500,600,700,800,900,1000,1200,1500};
Console.Write("From 1-10, how hard do you want to spin the wheel? ");
int selection = Convert.ToInt32(Console.ReadLine());
List<int> selectedList = selection switch
{
    1=>hard1,
    2=>hard2,
    3=>hard3,
    4=>hard4,
    5=>hard5,
    6=>hard6,
    7=>hard7,
    8=>hard8,
    9=>hard9,
    10=>hard10,
    _=>hard10
};
Queue<int> myQueue = new Queue<int>(selectedList);


int start = 0;
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

Console.SetCursorPosition(0,10);
Console.WriteLine($"You spun {numbers[number]}");


string getBuffer(int num)
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
