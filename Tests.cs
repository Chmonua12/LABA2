using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
//dkmsl
public class Tests
{
    public static void RunAllTests()
    {
        Console.WriteLine("Тестинг");
        
        TestList();
        TestLinkedList();
        TestQueue();
        TestStack();
        TestImmutableList();
        
        Console.WriteLine("Все тесты пройдены");
    }

    static void TestList()
    {
        var list = new List<int>();

        list.Add(1);
        list.Add(2);
        if (list.Count != 2) throw new Exception("List: Ошибка добавления");
        
        list.RemoveAt(0);
        if (list[0] != 2) throw new Exception("List: Ошибка удаления");

        if (!list.Contains(2)) throw new Exception("List: Ошибка поиска");

        if (list[0] != 2) throw new Exception("List: Ошибка доступа по индексу");
    }

    static void TestLinkedList()
    {
        var list = new LinkedList<int>();
        
        list.AddLast(1);
        list.AddLast(2);
        if (list.Last.Value != 2) throw new Exception("LinkedList: Ошибка добавления");
        
        list.RemoveFirst();
        if (list.First.Value != 2) throw new Exception("LinkedList: Ошибка удаления");
        
        if (!list.Contains(2)) throw new Exception("LinkedList: Ошибка поиска");
    }

    static void TestQueue()
    {
        var queue = new Queue<int>();
        
        queue.Enqueue(1);
        queue.Enqueue(2);
        if (queue.Peek() != 1) throw new Exception("Queue: Ошибка добавления");
        
        queue.Dequeue();
        if (queue.Peek() != 2) throw new Exception("Queue: Ошибка удаления");
        
        if (!queue.Contains(2)) throw new Exception("Queue: Ошибка поиска");
    }

    static void TestStack()
    {
        var stack = new Stack<int>();
        
        stack.Push(1);
        stack.Push(2);
        if (stack.Peek() != 2) throw new Exception("Stack: Ошибка добавления");
        
        stack.Pop();
        if (stack.Peek() != 1) throw new Exception("Stack: Ошибка удаления");
        
        if (!stack.Contains(1)) throw new Exception("Stack: Ошибка поиска");
    }

    static void TestImmutableList()
    {
        var list = ImmutableList<int>.Empty;
        
        list = list.Add(1);
        list = list.Add(2);
        if (list.Count != 2) throw new Exception("ImmutableList: Ошибка добавления");
        
        list = list.Remove(1);
        if (list[0] != 2) throw new Exception("ImmutableList: Ошибка удаления");
        
        if (!list.Contains(2)) throw new Exception("ImmutableList: Ошибка поиска");
        
        if (list[0] != 2) throw new Exception("ImmutableList: Ошибка доступа по индексу");
    }
}