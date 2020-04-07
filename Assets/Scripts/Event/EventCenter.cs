using System;
using System.Collections.Generic;
public class EventCenter
{
    private static Dictionary<EventType, Delegate> eventTable = new Dictionary<EventType, Delegate>();

    private static void OnListenerAdding(EventType eventType, Delegate eventHandler)
    {
        if (!eventTable.ContainsKey(eventType))
        {
            eventTable.Add(eventType, null);
        }
        Delegate d = eventTable[eventType];
        if (d != null && d.GetType() != eventHandler.GetType())
        {
            throw new Exception(string.Format("添加监听错误:事件{0}对应的委托类型为{1},给予的为{2}", eventType, d.GetType(), eventHandler.GetType()));
        }
    }
    private static void OnListenerRemoving(EventType eventType, Delegate eventHandler)
    {
        if (!eventTable.ContainsKey(eventType))
        {
            throw new Exception(string.Format("移除监听错误:事件{0}不存在", eventType));
        }
        Delegate d = eventTable[eventType];
        if (d == null)
        {
            throw new Exception(string.Format("移除监听错误:事件{0}对应的委托已经为空", eventType));
        }
        else if (d.GetType() != eventHandler.GetType())
        {
            throw new Exception(string.Format("移除监听错误:事件{0}对应的委托类型为{1},给予的类型为{2}", eventType, d.GetType(), eventHandler.GetType()));
        }
    }
    private static void OnListenerRemoved(EventType eventType)
    {
        if (eventTable[eventType] == null)
        {
            eventTable.Remove(eventType);
        }
    }
    public static void AddListener(EventType eventType, EventHandler eventHandler)
    {

        OnListenerAdding(eventType, eventHandler);
        eventTable[eventType] = (EventHandler)eventTable[eventType] + eventHandler;


    }
    public static void RemoveListener(EventType eventType, EventHandler eventHandler)
    {
        OnListenerRemoving(eventType, eventHandler);
        eventTable[eventType] = (EventHandler)eventTable[eventType] - eventHandler;
        OnListenerRemoved(eventType);
    }
    public static void BroadCast(EventType eventType)
    {
        Delegate d;
        if (eventTable.TryGetValue(eventType, out d))
        {
            EventHandler eventHandler = d as EventHandler;
            if (eventHandler != null)
            {
                eventHandler();
            }
            else
            {
                throw new Exception(string.Format("事件广播错误::事件{0}对应的委托类型为{1},给予的类型为{2}", eventType, eventHandler.GetType(), d.GetType()));
            }
        }
        else
        {
            throw new Exception(string.Format("事件广播错误::事件{0}不存在", eventType));
        }

    }

    public static void AddListener<T>(EventType eventType, EventHandler<T> eventHandler)
    {

        OnListenerAdding(eventType, eventHandler);
        eventTable[eventType] = (EventHandler<T>)eventTable[eventType] + eventHandler;
    }

    public static void RemoveListener<T>(EventType eventType, EventHandler<T> eventHandler)
    {
        OnListenerRemoving(eventType, eventHandler);
        eventTable[eventType] = (EventHandler<T>)eventTable[eventType] - eventHandler;
        OnListenerRemoved(eventType);

    }
    public static void BroadCast<T>(EventType eventType, T arg)
    {
        Delegate d;
        if (eventTable.TryGetValue(eventType, out d))
        {
            EventHandler<T> eventHandler = d as EventHandler<T>;
            if (eventHandler != null)
            {
                eventHandler(arg);
            }
            else
            {
                throw new Exception(string.Format("事件广播错误::事件{0}对应的委托类型为{1},给予的类型为{2}", eventType, eventHandler.GetType(), d.GetType()));
            }
        }
        else
        {
            throw new Exception(string.Format("事件广播错误::事件{0}不存在", eventType));
        }

    }
    public static void AddListener<T1, T2>(EventType eventType, EventHandler<T1, T2> eventHandler)
    {

        OnListenerAdding(eventType, eventHandler);
        eventTable[eventType] = (EventHandler<T1, T2>)eventTable[eventType] + eventHandler;
    }

    public static void RemoveListener<T1, T2>(EventType eventType, EventHandler<T1, T2> eventHandler)
    {
        OnListenerRemoving(eventType, eventHandler);
        eventTable[eventType] = (EventHandler<T1, T2>)eventTable[eventType] - eventHandler;
        OnListenerRemoved(eventType);

    }
    public static void BroadCast<T1, T2>(EventType eventType, T1 arg1, T2 arg2)
    {
        Delegate d;
        if (eventTable.TryGetValue(eventType, out d))
        {
            EventHandler<T1, T2> eventHandler = d as EventHandler<T1, T2>;
            if (eventHandler != null)
            {
                eventHandler(arg1, arg2);
            }
            else
            {
                throw new Exception(string.Format("事件广播错误::事件{0}对应的委托类型为{1},给予的类型为{2}", eventType, eventHandler.GetType(), d.GetType()));
            }
        }
        else
        {
            throw new Exception(string.Format("事件广播错误::事件{0}不存在", eventType));
        }

    }
}
