using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_4_array
{
    internal class Program
    {
        static void ViewList(int[] list)//Функция Показа списка
        {
            try
            {
                if (list.Length == 0) //Проверка на пустой массив
                {
                    throw new ArgumentException();//Создаём ошибку если массив пустой
                }
                foreach (int elementOfArray in list)//Перебор элементов списка
                {
                    Console.Write(elementOfArray + " ");
                }
                Console.WriteLine();//Для вывода следующего текста с новой строки
            }
            catch (ArgumentException)
            {
                Console.WriteLine($"Ошибка при выводе списка: Массив Пуст");//Выводить сообщение об ошибке при наличии ошибки
                Console.WriteLine($"Заполните массив заново");
                AddClava(list);
            }
        }//Блок-схема Есть+
        static int CheckIntBigger0(string text)//функция Проверки числа на целое и больше 0
        {
            int intNumber;//Входные данные(число больше 0)
            do
            {
                try
                {
                    Console.WriteLine(text);//Выводим сообщение о данных, которые надо получить
                    intNumber = int.Parse(Console.ReadLine());//Преобразуем в int
                    if (intNumber < 1)//если число не положительное
                    {
                        throw new ArgumentException();
                    }
                }
                catch (FormatException)//Если введено не целое число
                {
                    Console.WriteLine("Ошибка: введите целое число больше 0.");
                    intNumber = -1;
                }
                catch (ArgumentException)//Если введено не целое число
                {
                    Console.WriteLine("Ошибка(Введено не положительное число): введите целое число больше 0.");
                    intNumber = -1;
                }
                catch (OverflowException)//Если введено число слишком большое или слишком маленькое, выходит за пределы int
                {
                    Console.WriteLine($"Ошибка: Введённое число слишком большое или слишком маленькое." +
                        $"\nВведите число в пределах [{int.MinValue}, {int.MaxValue}]");
                    intNumber = -1;
                }
                catch (Exception ex)//Другие ошибки, которые могу появиться
                {
                    Console.WriteLine($"Неожиданная ошибка: {ex.Message}");
                    intNumber = -1;
                }
            } while (intNumber < 1);//Цикл работает пока не получит целое число больше 0
            return intNumber;//Возвращаем значение
        }//Блок-схема Есть+

        static int CheckIntAny(string text)//Функция Проверки числа на целое
        {
            int intNumber = 0;//Входные данные(число)
            bool isValidInput;//Для проверки корректности ввода целого числа
            do
            {
                try
                {
                    Console.WriteLine(text);//Выводим сообщение о данных, которые надо получить
                    intNumber = int.Parse(Console.ReadLine());//Преобразуем в int
                    isValidInput = true;//Если получилось, то программа присвоит true и вследствие, выйдет из цикла
                }
                catch (FormatException)//Если введено не целое число
                {
                    Console.WriteLine("Ошибка: введите целое число.");
                    isValidInput = false;//Мы попали в блок с ошибкой, тогда формат число не корректен 
                }
                catch (OverflowException)//Если введено число слишком большое или слишком маленькое, выходит за пределы инта
                {
                    Console.WriteLine($"Ошибка: Введённое число слишком большое или слишком маленькое." +
                        $"\nВведите число в пределах [{int.MinValue}, {int.MaxValue}]");
                    isValidInput = false;//Мы попали в блок с ошибкой, тогда формат число не корректен 
                }
                catch (Exception ex)//Другие ошибки, которые могу появиться
                {
                    Console.WriteLine($"Неожиданная ошибка: {ex.Message}");
                    isValidInput = false;//Мы попали в блок с ошибкой, тогда формат число не корректен 
                }
            } while (!isValidInput);//Если число целое

            return intNumber;//Возвращаем целое число
        }//Блок схема есть+

        static int[] ListClava()//Функция Создания списка вручную
        {
            try
            {
                int lengthList = CheckIntBigger0("Введите длину массива");//Получаем длину массива
                int[] list = new int[lengthList];//создаём массив 
                Console.WriteLine("Учтите что все элементы массива целые");
                for (int i = 0; i < lengthList; i++)
                {
                    list[i] = CheckIntAny($"Введите {i + 1} элемент массива");//заполняем массив элементами, с клавиатуры 
                }
                ViewList(list);//Выводим массив
                return list;//возвращаем массив для дальнейшей работы
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при создании массива: {ex.Message}");//Выводим ошибку
                Console.WriteLine($"Значение по умолчанию массив от 0 до 9 включительно");//Предупреждаем пользователя
                int[] list = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                return list;
            }
        }//Блок-схема есть+

        static int[] ListКRandom()//Функция Создания списка случайно
        {
            try
            {
                int lengthList = CheckIntBigger0("Введите длину массива");//Получаем длину массива
                int[] list = new int[lengthList];
                Random random = new Random();//Подключаем модуль Random, для заполнения случайными данными
                for (int i = 0; i < lengthList; i++)//создаём массив из случайных чисел от -100 до 100 
                {
                    list[i] = random.Next(-100, 101);//заполняем элементами
                }
                ViewList(list);//Показываем список(Для наглядности)
                return list;//Возвращаем этот список
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при создании массива случайных чисел: {ex.Message}");//Выводим ошибку
                Console.WriteLine($"Значение по умолчанию массив от 0 до 9 включительно");//Предупреждаем пользователя
                int[] list = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };//Список по умолчанию
                return list;//Возвращаем список
            }
        }//Блок-схема есть+

        static int[] DeleteElemet(int[] starList)//Функция которая Удаляет N элементов списка начинай с K-ого элемента
        {
            ViewList(starList);//Выводим список для наглядности и удобства работать с ним
            try
            {
                int N = CheckIntBigger0("Введите кол-во элементов, которые надо удалить");//Запрашиваем N
                int K = CheckIntBigger0("Введите индекс элемента с которого надо удалить включительно") - 1;//Запрашиваем K
                if (K + N > starList.Length)//Проверяем возможность удалить элементы из массива(Входят ли они в массив)
                {
                    throw new ArgumentException();//Создаём собственное исключение
                }

                int[] list = new int[starList.Length - N];//Создаем новый массив с нужным кол-вом элементов
                for (int i = 0, j = 0; i < starList.Length; i++)//Цикл проходит по списку и удаляет необходимые элементы
                {
                    if (i < K || i >= K + N)//Если элемент не входит диапазон удаление
                    {
                        list[j++] = starList[i];//Присваиваем в элементу нового списка элемент старого
                    }
                }
                ViewList(list);//Выводим для удобства
                return list;//Возвращаем список
            }
            catch (ArgumentException)
            {
                Console.WriteLine($"Ошибка при удалении элементов: Нельзя удалить элементы, которые не входят в массив.");//При наличие ошибки
                Console.WriteLine($"Значение по умолчанию массив от 0 до 9 включительно");
                int[] list = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };//Список по умолчанию
                return list;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при удалении элементов: {ex.Message}");//При наличие ошибки
                Console.WriteLine($"Значение по умолчанию массив от 0 до 9 включительно");
                int[] list = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };//Список по умолчанию
                return list;

            }
        }//Блок схема есть+

        static int[] AddClava(int[] starList)//Функция которая добавляет K элементов в начало списка вручную
        {
            try
            {
                int K = CheckIntBigger0("Введите кол-во элементов, которые хотите добавить");//Запрашиваем K
                int[] list = new int[starList.Length + K];//Создаём список длинной Старого + K
                for (int i = 0, j = 0; i < list.Length; i++)//Перебираем элементы нового списка
                {
                    if (i < K)//Если элемент стоит до кол-во элементов старого списка
                    {
                        list[i] = CheckIntAny($"Введите {i + 1} элемент, который хотите добавить");//запрашиваем элемент у пользователя
                    }
                    else
                    {
                        list[i] = starList[j++];//Присваиваем элементу элемент из старого списка
                    }
                }
                ViewList(list);//Выводим для наглядности список
                return list;//Возвращаем список
            }
            catch (OverflowException)
            {
                Console.WriteLine($"Ошибка при добавлении случайных элементов: Длина массива слишком большая");//При наличие ошибки
                Console.WriteLine($"Значение по умолчанию массив от 0 до 9 включительно");
                int[] list = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };//Список по умолчанию
                return list;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при добавлении элементов: {ex.Message}");//При наличие ошибки
                Console.WriteLine($"Значение по умолчанию массив от 0 до 9 включительно");
                int[] list = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };//Список по умолчанию
                return list;//Возвращаем список
            }
        }//Блок-схема есть+

        static int[] AddRandom(int[] starList)//Функция которая добавляет K элементов в начало списка случайно
        {
            try
            {
                int K = CheckIntBigger0("Введите кол-во элементов, которые хотите добавить");//Запрашиваем K
                int[] list = new int[starList.Length + K];//Создаём список длинной Старого + K
                Random rand = new Random();//Подключаем модуль Random, для заполнения случайными данными
                for (int i = 0, j = 0; i < list.Length; i++)//Перебираем элементы нового списка
                {
                    if (i < K)//Если элемент стоит до кол-во элементов старого списка
                    {
                        list[i] = rand.Next(-100, 101);//Присваиваем элементу случайное значение от -100 до 100 
                    }
                    else
                    {
                        list[i] = starList[j++];//Присваиваем элементу элемент из старого списка
                    }
                }
                ViewList(list);//Выводим для наглядности список
                return list;//Возвращаем список
            }
            catch (OverflowException)
            {
                Console.WriteLine($"Ошибка при добавлении случайных элементов: Длина массива слишком большая");//При наличие ошибки
                Console.WriteLine($"Значение по умолчанию массив от 0 до 9 включительно");
                int[] list = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };//Список по умолчанию
                return list;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при добавлении случайных элементов: {ex.Message}");//При наличие ошибки
                Console.WriteLine($"Значение по умолчанию массив от 0 до 9 включительно");
                int[] list = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };//Список по умолчанию
                return list;//Возвращаем список
            }
            
        }//Блок-схема есть+

        static int[] Exchange(int[] list)//Функция которая меняет Минимальный и Максимальные элементы списка местами //По 2 мин и 2 макс как сделать лучше?
        {
            try//Начало отслеживания ошибок
            {
                int maxIndex = 0, minIndex = 0, countMax=0, countMin=0;//индексы минимальных, максимальных и счётчиков значений списка
                for (int i = 0; i < list.Length; i++)//Перебор элементов списка
                {
                    if (list[i] >= list[maxIndex])//Проверка на максимальный элемент
                    {
                        if (list[i] == list[maxIndex])//Проверка на  равенство максимальному элемент
                        {
                            countMax++;/
                        }
                        else
                        {
                            maxIndex = i;
                            countMax = 1;
                        }
                    }
                    if (list[i] <= list[minIndex])//Проверка на минимальный элемент
                    {
                        if (list[i] == list[minIndex])//Проверка на равенство минимальному элементу
                        {
                            countMin++;
                        }
                        else
                        {
                            minIndex = i;
                            countMin = 1;
                        }
                    }
                }
                int maxElement = list[maxIndex];
                int minElement = list[minIndex];
                if (countMax == countMin)//Кол-во мин и макс элементов равны, то просто перезаписываем их
                {
                    for (int i = 0; i < list.Length; i++)
                    {
                        if (list[i] == minElement)
                        {
                            list[i] = maxElement;
                            continue;
                        }
                        if (list[i] == maxElement)
                        {
                            list[i] = minElement;
                            continue;
                        }
                    }
                }
                else
                {
                    (list[maxIndex], list[minIndex]) = (list[minIndex], list[maxIndex]);//Меняем элементы местами(Первые входы)
                }
                Console.WriteLine("Учтите смена элементов выполнена согласно следующим правилам:\nЕсли кол-во мин и макс элементов равны, то они все меняются местами\nЕсли не равны то меняются только первый мин и первый макс");
                ViewList(list);//Выводим список для наглядности
                return list;//Возвращаем список

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обмене элементов: {ex.Message}");//При наличие ошибки
                Console.WriteLine($"Значение по умолчанию массив от 0 до 9 включительно");
                int[] newlist = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };//Выводим список для наглядности
                return newlist;//Возвращаем список
            }
        }//Блок-схема есть+

        static void FindFirstChet(int[] list)//Функция которая находит первый чётный элемент списка
        {
            try//Начало отслеживания ошибок
            {
                for (int i = 0; i < list.Length; i++)//Перебор элементов списка
                {
                    if (list[i] % 2 == 0)//Проверка на чётность
                    {
                        Console.WriteLine($"Первый чётный элемент массива стоит на {i + 1} месте и равен {list[i]}");
                        Console.WriteLine($"Кол-во итераций равно порядковому номеру элемента то есть {i + 1}");
                        return;//Возвращаем ничего
                    }
                }
                Console.WriteLine("Чётных элементов в массиве нет.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при поиске чётного элемента: {ex.Message}");
            }
        }//Блок-схеа есть+

        static int[] Sorting(int[] list)//Функция которая сортирует массив
        {
            try//Начало отслеживания ошибки
            {
                int sort = CheckIntAny("Для сортировки от меньшего к большему введите 1, для обратной сортировки введите 0");//Узнаём от пользователя порядок сортировки
                if (sort == 0)//Проверяем условие сортировки
                {
                    for (int i = 0; i < list.Length - 1; i++)//Перебор элементов списка
                    {
                        bool isSorted = false;//Отвечает за проверку сортировки массива
                        for (int j = 0; j < list.Length - 1 - i; j++)//Проход по элементам, после которого самый большой уходит в конец
                        {
                            if (list[j] < list[j + 1])//сравниваем элементы
                            {
                                (list[j], list[j + 1]) = (list[j + 1], list[j]);//меняем элементы
                                isSorted = true;//сообщаем что что-то поменялось
                            }
                        }
                        if (!isSorted)//Проверка, если ничего не изменилось, значит массив отсортирован
                        {
                            break;//Прерываем работу
                        }
                    }
                }
                else if (sort == 1)//Проверяем условие сортировки
                {
                    for (int i = 0; i < list.Length - 1; i++)//Перебор элементов списка 
                    {
                        bool isSorted = false;//Отвечает за проверку сортировки массива
                        for (int j = 0; j < list.Length - 1 - i; j++)//Проход по элементам, после которого самый маленький уходит в конец
                        {
                            if (list[j] > list[j + 1])//сравниваем элементы
                            {
                                (list[j], list[j + 1]) = (list[j + 1], list[j]);//меняем элементы
                                isSorted = true;//сообщаем что что-то поменялось
                            }
                        }
                        if (!isSorted)//Проверка, если ничего не изменилось, значит массив отсортирован
                        {
                            break;//Прерываем работу
                        }
                    }
                }
                else//Если не то и не другое
                {
                    Console.WriteLine("Ошибка ввода. Введите только 1 или 0");
                    Console.WriteLine("Ваш список не изменён попробуйте ещё раз отсортировать");//Сообщаем о некорректности ввода
                    return list;//Возвращаем изначальный массив
                }
                ViewList(list);//Выводим для наглядности
                return list;//Возвращаем отсортированный массив
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сортировке: {ex.Message}");//При наличие ошибки
                int[] newlList = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };//Выводим список для наглядности
                Console.WriteLine($"Значение по умолчанию массив от 0 до 9 включительно");
                return newlList;//Возвращаем массив по умолчанию
            }
        }//Блок-схема есть+
        static void Find(int[] list)//Функция, которая бинарным поиском находит элемент массива
        {
            try
            {
                bool isSortedStart = true;
                for (int i = 0; i < list.Length - 1; i++)//Перебор элементов списка 
                {
                    bool isSorted = false;//Отвечает за проверку сортировки массива
                    for (int j = 0; j < list.Length - 1 - i; j++)//Проход по элементам, после которого самый маленький уходит в конец
                    {
                        if (list[j] > list[j + 1])//сравниваем элементы
                        {
                            (list[j], list[j + 1]) = (list[j + 1], list[j]);//меняем элементы
                            isSorted = true;//сообщаем что что-то поменялось
                            isSortedStart = false;
                        }
                    }
                    if (!isSorted)//Проверка, если ничего не изменилось, значит массив отсортирован
                    {
                        break;//Прерываем работу
                    }
                }
                if (!isSortedStart)
                {
                    Console.WriteLine("Сказано же было в отсортированном");
                    Console.Write("Вот отсортировал для вас: ");
                }
                ViewList(list);//Выводим для наглядности}

                int x = CheckIntAny("Введите число которое хотите найти");
                int left = 0;//Левая граница поиска
                int right = list.Length - 1;//Правая граница поиска
                int countOfIteration = 0;//Счётчик итерация
                while (left <= right)//Проверка корректности границ
                {
                    countOfIteration++;//увеличиваем счётчик итераций
                    int center = (left + right) / 2;//находим центральный элемент
                    if (list[center] == x)//Если текущий элемент совпал с желаемым
                    {
                        Console.WriteLine($"Элемент найден. {x} находиться на {center + 1} месте. Количество итераций = {countOfIteration}");//Выводим ответ
                        return;//Заканчиваем работу функции
                    }
                    else if (list[center] < x)//Если текущий элемент меньше желаемого 
                    {
                        left = center + 1;//двигаем левую границу
                    }
                    else//значит больше 
                    {
                        right = center - 1;//двигаем правую границу
                    }
                }
                Console.WriteLine("Элемент в списке не найден");//Если нет элемента в списке
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");//Выводим ошибку если есть
            }
        }//Блок-схема есть+

        static int[] SortningShaker(int[] list)
        {
            bool isSwapped = true;
            int end = list.Length-1;
            int start = 0;
            while (isSwapped)
            {
                isSwapped= false;
                for (int i = start; i <= end-1; i++)
                {
                    if (list[i] > list[i + 1])
                    {
                        int temp = list[i];
                        list[i] = list[i+1];
                        list[i+1] = temp;
                        isSwapped = true;
                    }
                }
                if (!isSwapped)
                {
                    break;
                }
                end --;
                isSwapped = false;
                for (int i = end-1; i>=start+1; i--)
                {
                    if (list[i] < list[i - 1])
                    {
                        int temp = list[i];
                        list[i] = list[i - 1];
                        list[i - 1] = temp;
                        isSwapped = true;
                    }
                }
                start ++;
            }
            ViewList(list);
            return list;
        }
        static bool NextAction(ref int[] list)//Функция через которую происходит навигация в текстовом меню
        {
            try//Начало отслеживания ошибок
            {
                Console.WriteLine("Введите номер функции, которую хотите применить");
                Console.WriteLine("0 - показать список\n1 - создать массив вручную\n2 - создать массив случайно\n3 - удалить N элементов массива, начиная с номера K\n" +
                                  "4 - добавить K элементов в начало списка вручную\n5 - добавить K элементов в начало списка случайно\n6 - Поменять местами максимальный и минимальный элементы списка\n" +
                                  "7 - найти первый чётный элемент списка\n8 - Отсортировать массив\n9 - Найти элемент в отсортированном массиве\n10 - шейкер сортировка\nКонец - Закончить работу программы");

                string action = Console.ReadLine();//Приём числа(Навигация в меню)
                switch (action)//Выбор исполняемой функции
                {
                    case "0":
                        ViewList(list);//Показать список
                        break;
                    case "1":
                        list = ListClava();//Создать список вручную
                        break;
                    case "2":
                        list = ListКRandom();//Создать список случайно
                        break;
                    case "3":
                        list = DeleteElemet(list);//Удалить N элементов списка начинай с K-ого элемента
                        break;
                    case "4":
                        list = AddClava(list);//Добавить K элементов в начало списка вручную
                        break;
                    case "5":
                        list = AddRandom(list);//Добавить K элементов в начало списка случайно
                        break;
                    case "6":
                        list = Exchange(list);//Поменять Минимальный и Максимальные элементы списка(Первые вхождения)
                        break;
                    case "7":
                        FindFirstChet(list);//Найти первый чётный элемент списка
                        break;
                    case "8":
                        list = Sorting(list);//Отсортировать список
                        break;
                    case "10":
                        list = SortningShaker(list);//Отсортировать список
                        break;
                    case "9":
                        Find(list);//Найти элементы бинарным поиском(Только первое вхождение)
                        break;
                    case "Конец":
                        return false;//Конец работы программы
                    default:
                        Console.WriteLine("Введена неправильная функция, попробуйте ещё раз");//Если введены другие значения
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");//Выводить сообщение об ошибке при наличии ошибки
            }

            return true;
        }//Блок-схема есть+
        static void Main()
        {
            int[] list = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Console.WriteLine("Значение по умолчанию — это массив от 0 до 9 включительно");

            bool continueRunning = true;
            while (continueRunning)
            {
                continueRunning = NextAction(ref list);
            }
            Console.WriteLine("Конец работы программы");
        }//Блок-схема есть
    }
}
