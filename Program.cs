Start();


// Меню начало


const string FORTYSEVEN = "47";
const string FIFTY = "50";
const string FIFTYTWO = "52";
const string QUIT = "q";

void Start()
{
    Console.WriteLine("Введите номер задачи (47, 50, 52) или 'q' что бы выйти:");

    switch (isValidInputMenu(Console.ReadLine()))
    {
        case FORTYSEVEN:
            Task47(true);
            Start();
            break;
        case FIFTY:
            Task47(false); // Схитрил =) Но скорее всего так делать не правильно, просто решил потренироваться!
            Start();
            break;
        case FIFTYTWO:
            Task52();
            Start();
            break;
        case QUIT:
            Console.WriteLine("Пока!");
            break;
    }
}

string isValidInputMenu(string userInput)
{
    userInput = userInput.ToLower();

    if (userInput == FORTYSEVEN
     || userInput == FIFTY
     || userInput == FIFTYTWO
     || userInput == QUIT)
    {
        return userInput;
    }
    else
    {
        Console.WriteLine("Введите номер задачи (47, 50, 52) или 'q' что бы выйти:");
        isValidInputMenu(Console.ReadLine());
    }
    return "";
}


// Меню конец

// Задача 47 начало


void Task47(bool isFortyseven)
{
    // Ветвление на задания, на истину выдает заголовок 47 задачи, на ложь 50 задачи.
    if (isFortyseven) Console.WriteLine("Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.");
    else Console.WriteLine("Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.");

    // Определяем размер массивов.
    int row = new Random().Next(1, 10);
    int cell = new Random().Next(1, 10);

    // Создаем массив.
    double[,] matrix = new double[row, cell];

    // Этим переменным будут присвоины входные данные от пользователя на поиск значения в двумерном массиве в задаче 50.
    int inputRow = 0;
    int inputCell = 0;

    Console.WriteLine($"\nm = {row}, n = {cell}.\n");

    // Заполняем массив.
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < cell; j++)
        {
            matrix[i, j] = new Random().NextDouble() + new Random().Next(1, 10);
        }
    }

    // Печатаем массив.
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < cell; j++)
        {
            Console.Write($"{Math.Round(matrix[i, j], 1)} ");
        }
        Console.WriteLine("");
    }
    Console.WriteLine("");

    // Вводим и проверяем данные для 50 задачи.
    if (!isFortyseven)
    {
        Console.Write("Введите номер строки элемента: \n");
        inputRow = inputParametrs(Console.ReadLine());
        Console.Write("Введите номер столбца элемента: \n");
        inputCell = inputParametrs(Console.ReadLine());


        if (inputRow > row || inputCell > cell)
        {
            Console.WriteLine("Такого числа в массиве нет.");
        }
    }

    // Печатаем положительный результат к задаче 50.
    if (!isFortyseven) Console.WriteLine(matrix[inputRow - 1, inputCell - 1]);
}

// Конец 47 задачи.

// Начало 50 задачи.

int inputParametrs(string userInput)
{
    int result = 0;
    if (Int32.TryParse(userInput, out result))
    {
        return result;
    }
    else
    {
        Console.WriteLine("Введите целое число");
        inputParametrs(Console.ReadLine());
    }
    return -1;
}


// Конец 50 задачи.


// Начало 52 задачи.


void Task52()
{
    int result;
    int row = new Random().Next(5, 10);
    int cell = row;

    int[,] matrix = new int[row, cell];
    int[] results = new int[cell];

    // Заполняем массивы.
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < cell; j++)
        {
            matrix[i, j] = new Random().Next(1, 10);
            results[j] += matrix[i, j];
        }
    }

    // Подсчитываем среднее арифметическое столбцов.
    for (int i = 0; i < cell; i++)
    {
        results[i] /= cell;
    }

    // Печатаем матрицу.
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < cell; j++)
        {
            Console.Write($"{matrix[i, j]} ");
        }
        Console.WriteLine("");
    }

    Console.WriteLine("");

    // Печатаем среднее арифметическое.
    foreach (int value in results)
    {
        Console.Write($"{value} ");
    }
    Console.WriteLine("\n");
}

// Конец 52 задачи.