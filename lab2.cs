using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
//kk
public class Lab2
{
    private const int Size = 100000;
    private const int Repeats = 5;
    private readonly List<int> data = Enumerable.Range(0, Size).ToList();

    public void Run()
    {
        Console.WriteLine("Лабораторная работа №2. Тестирование коллекций\n");
        Console.WriteLine($"Количество элементов: {Size}");
        Console.WriteLine($"Количество повторов: {Repeats}\n");

        TestList();
        TestLinkedList();
        TestQueue();
        TestStack();
        TestImmutableList();
    }

    private double Measure(Action action)
    {
        var times = new List<long>();
        
        for (int i = 0; i < Repeats; i++)
        {
            var sw = Stopwatch.StartNew();
            action();
            sw.Stop();
            times.Add(sw.ElapsedMilliseconds);
        }
        
        return times.Average();
    }

    private void TestList()
    {
        Console.WriteLine("List<int>");
        var list = new List<int>(data);

        Console.WriteLine($"Добавление в конец: {Measure(() => list.Add(999)):F2} мс");
        Console.WriteLine($"Добавление в начало: {Measure(() => list.Insert(0, 999)):F2} мс");
        Console.WriteLine($"Добавление в середину: {Measure(() => list.Insert(Size/2, 999)):F2} мс");
        Console.WriteLine($"Удаление с конца: {Measure(() => list.RemoveAt(list.Count-1)):F2} мс");
        Console.WriteLine($"Удаление из начала: {Measure(() => list.RemoveAt(0)):F2} мс");
        Console.WriteLine($"Удаление из середины: {Measure(() => list.RemoveAt(Size/2)):F2} мс");
        Console.WriteLine($"Поиск элемента: {Measure(() => list.Contains(Size/2)):F2} мс");
        Console.WriteLine($"Доступ по индексу: {Measure(() => { var x = list[Size/2]; }):F2} мс");
        Console.WriteLine();
    }

    private void TestLinkedList()
    {
        Console.WriteLine("LinkedList<int>");
        var list = new LinkedList<int>(data);

        Console.WriteLine($"Добавление в конец: {Measure(() => list.AddLast(999)):F2} мс");
        Console.WriteLine($"Добавление в начало: {Measure(() => list.AddFirst(999)):F2} мс");
        
        Console.WriteLine($"Добавление в середину: {Measure(() => 
        {
            var node = list.Find(data[Size/2]);
            if (node != null) list.AddAfter(node, 999);
        }):F2} мс");
        
        Console.WriteLine($"Удаление с конца: {Measure(() => list.RemoveLast()):F2} мс");
        Console.WriteLine($"Удаление из начала: {Measure(() => list.RemoveFirst()):F2} мс");
        Console.WriteLine($"Удаление из середины: {Measure(() => list.Remove(Size/2)):F2} мс");
        Console.WriteLine($"Поиск элемента: {Measure(() => list.Contains(Size/2)):F2} мс");
        
        Console.WriteLine($"Доступ по индексу: {Measure(() => 
        {
            var node = list.First;
            for (int i = 0; i < Size/2; i++) node = node?.Next;
        }):F2} мс");
        Console.WriteLine();
    }

    private void TestQueue()
    {
        Console.WriteLine("Queue<int>");
        var queue = new Queue<int>(data);

        Console.WriteLine($"Добавление: {Measure(() => queue.Enqueue(999)):F2} мс");
        Console.WriteLine($"Удаление: {Measure(() => queue.Dequeue()):F2} мс");
        Console.WriteLine($"Поиск элемента: {Measure(() => queue.Contains(Size/2)):F2} мс");
        Console.WriteLine();
    }

    private void TestStack()
    {
        Console.WriteLine("Stack<int>");
        var stack = new Stack<int>(data);

        Console.WriteLine($"Добавление: {Measure(() => stack.Push(999)):F2} мс");
        Console.WriteLine($"Удаление: {Measure(() => stack.Pop()):F2} мс");
        Console.WriteLine($"Поиск элемента: {Measure(() => stack.Contains(Size/2)):F2} мс");
        Console.WriteLine();
    }

    private void TestImmutableList()
    {
        Console.WriteLine("ImmutableList<int>");
        var list = ImmutableList.CreateRange(data);

        Console.WriteLine($"Добавление в конец: {Measure(() => list.Add(999)):F2} мс");
        Console.WriteLine($"Добавление в начало: {Measure(() => list.Insert(0, 999)):F2} мс");
        Console.WriteLine($"Добавление в середину: {Measure(() => list.Insert(Size/2, 999)):F2} мс");
        Console.WriteLine($"Удаление с конца: {Measure(() => list.RemoveAt(list.Count-1)):F2} мс");
        Console.WriteLine($"Удаление из начала: {Measure(() => list.RemoveAt(0)):F2} мс");
        Console.WriteLine($"Удаление из середины: {Measure(() => list.RemoveAt(Size/2)):F2} мс");
        Console.WriteLine($"Поиск элемента: {Measure(() => list.Contains(Size/2)):F2} мс");
        Console.WriteLine($"Доступ по индексу: {Measure(() => { var x = list[Size/2]; }):F2} мс");
        Console.WriteLine();
    }
}