// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

bool FindElem(int[,,] matr, int xRand, int lBound, int hBound)  //  работа с матрицей - поиск xRand в матрице для исключения повторения случайного числа
{
    for (int i = 0; i < matr.GetLength(0); i++)
        for (int j = 0; j < matr.GetLength(1); j++)
            for (int k = 0; k < matr.GetLength(2); k++)
                if (matr[i, j, k] == xRand)                     
                    return true;                                //  нашли
    return false;                                               //  не нашли
}

int[,,] FillMatrix(int[,,] matr, int lBound, int hBound)        //  работа с матрицей - наполнение неповторяющимися случайными двузначными целыми числами
{
    for (int i = 0; i < matr.GetLength(0); i++)                 //  цикл по всем трем измерениям
        for (int j = 0; j < matr.GetLength(1); j++)
            for (int k = 0; k < matr.GetLength(2); k++)
            {
                int xRand = new Random().Next(lBound, hBound);  //  пробное случайное число
                while (FindElem(matr, xRand, lBound, hBound))   //  проверка сгенерированного случайного числа на повторяемость в матрице
                    xRand = new Random().Next(lBound, hBound);  //  пока не найдём
                matr[i, j, k] = xRand;                          //  нашли
            }
    return matr;
}

void PrintMatrix(int[,,] matr)                                   //  форматированный вывод матрицы в консоль построчно по ширине стороны матрицы
{
    for (int i = 0; i < matr.GetLength(0); i++)                  //  цикл по всем трем измерениям
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            for (int k = 0; k < matr.GetLength(2); k++)
                Console.Write($"\t{matr[i, j, k]} ({i},{j},{k})");
            Console.WriteLine();
        }
}

Console.Clear();				                                //  очистка консоли
Console.WriteLine("Введите ширину стороны трехмерной квадратной матрицы (от 2 до 4): ");	    //  запрос ширины стороны матрицы
int m = Convert.ToInt32(Console.ReadLine());
if (m < 2 || m > 4)
    Console.WriteLine("Число должно быть от 2 до 4 включительно.");	//  проверка введённого значения ширины матрицы
else
{
    int[,,] matrix = new int[m, m, m];                              //  инициализация матрицы
    FillMatrix(matrix, 10, 100);                                    //  наполнение матрицы случайными целыми числами в заданном диапазоне (от 1 до 100)
    PrintMatrix(matrix);                                            //  вывод матрицы в консоль    
}