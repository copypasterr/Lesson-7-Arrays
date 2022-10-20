using System;

namespace ConsoleApp5
{

    internal class Program
    {
        /// <summary>
        /// Selection of sorting algorithm
        /// </summary>
        enum SortAlgorithmType
        {
            selection,
            bubble,
            insertion
        }

        /// <summary>
        /// Sort order
        /// </summary>
        enum OrderBy
        {
            Asc,
            Desc
        }

        static int[] Selection(int[] array, OrderBy type)
        {
            int buffer;
            switch (type)
            {
                case OrderBy.Asc:
                    for (int externalCycle = 0; externalCycle < array.Length; externalCycle++)
                    {

                        int minIndex = externalCycle;

                        for (int internalCycle = externalCycle + 1; internalCycle < array.Length; internalCycle++)
                        {
                            if (array[internalCycle] < array[minIndex])
                                minIndex = internalCycle;
                        }

                        buffer = array[minIndex];
                        array[minIndex] = array[externalCycle];
                        array[externalCycle] = buffer;

                    }
                    return array;

                case OrderBy.Desc:
                    for (int externalCycle = 0; externalCycle < array.Length; externalCycle++)
                    {

                        int minIndex = externalCycle;

                        for (int internalCycle = externalCycle + 1; internalCycle < array.Length; internalCycle++)
                        {
                            if (array[internalCycle] > array[minIndex])
                                minIndex = internalCycle;
                        }

                        buffer = array[minIndex];
                        array[minIndex] = array[externalCycle];
                        array[externalCycle] = buffer;

                    }
                    return array;

            }

            return array;
        }

        static int[] Bubble(int[] array, OrderBy type)
        {
            int buffer;

            switch (type) {
                case OrderBy.Asc:
                    for (int externalCycle = 0; externalCycle < array.Length - 1; externalCycle++)
                        for (int internalCycle = 0; internalCycle < array.Length - externalCycle - 1; internalCycle++)
                        {
                            if (array[internalCycle] > array[internalCycle + 1])
                            {
                                buffer = array[internalCycle];
                                array[internalCycle] = array[internalCycle + 1];
                                array[internalCycle + 1] = buffer;
                            }
                        }
                    return array;

                 case OrderBy.Desc:
                    for (int externalCycle = 0; externalCycle < array.Length - 1; externalCycle++)
                        for (int internalCycle = 0; internalCycle < array.Length - externalCycle - 1; internalCycle++)
                        {
                            if (array[internalCycle] < array[internalCycle + 1])
                            {
                                buffer = array[internalCycle];
                                array[internalCycle] = array[internalCycle + 1];
                                array[internalCycle + 1] = buffer;
                            }
                        }
                    return array;

            }


        
            return array;
        }

        static int[] Insertion(int[] array, OrderBy type)
        {
            switch (type)
            {
                case OrderBy.Asc:
                    for (int externalCycle = 0; externalCycle < array.Length; externalCycle++)
                    {
                        int key = externalCycle;
                        int internalIndex = externalCycle - 1;

                        while (internalIndex >= 0 && array[internalIndex] < key)
                        {
                            array[internalIndex + 1] = array[internalIndex];
                            internalIndex = internalIndex - 1;
                        }

                        array[internalIndex + 1] = key;
                    }
                    return array;

                case OrderBy.Desc:
                    for (int externalCycle = 0; externalCycle < array.Length; externalCycle++)
                    {
                        int key = externalCycle;
                        int internalIndex = externalCycle - 1;

                        while (internalIndex >= 0 && array[internalIndex] > key)
                        {
                            array[internalIndex + 1] = array[internalIndex];
                            internalIndex = internalIndex - 1;
                        }

                        array[internalIndex + 1] = key;
                    }
                    return array;

            }
            return array;
        }

        /// <summary>
        /// Selection of sorting algorithm and sorting order. 
        /// Returns a sorted array
        /// </summary>
        /// <param name="array"></param>
        /// <param name="type"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        static int[] Sort (int[] array, SortAlgorithmType type, OrderBy key)
        {
            switch (type)
            {
                case SortAlgorithmType.selection:
                    return Selection(array, key);

                case SortAlgorithmType.bubble:
                    return Bubble(array, key);

                case SortAlgorithmType.insertion:
                    return Insertion(array, key);
            }

            return null;
        }

        /// <summary>
        /// Fills an array with random numbers within a bounded limit
        /// </summary>
        /// <param name="array"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        static int[] ArrayGenerator(int[] array, int limit)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i] = random.Next() % limit;
            return array;
        }

        static void Main(string[] args)
        {
            int elements = 100;
            int limit = 100;

            int[] array = new int[elements];
            array = ArrayGenerator(array, limit);
            array = Sort(array, SortAlgorithmType.insertion, OrderBy.Asc);

            for (int i = 0; i < array.Length; i++)
                Console.WriteLine(i + "--" + array[i]);



        }
    }
}
