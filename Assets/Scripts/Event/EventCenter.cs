using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EventCenter
{
    public static Dictionary<EventType, Delegate> eventTable = new Dictionary<EventType, Delegate>();
    //无参添加监听
    public static void AddListener(EventType eventType, EventHandler eventHandler)
    {

        //如果eventTable不包含这个key, 先增加一个key
        if (!eventTable.ContainsKey(eventType))
        {
            eventTable.Add(eventType, null);
        }

        Delegate d = eventTable[eventType];

        //如果给的eventhandler与存的不一致就抛出异常
        if (d != null && d.GetType() != eventHandler.GetType())
        {
            throw new Exception(string.Format("添加监听错误:事件{0}对应的委托类型为{1},给予的为{2}", eventType, d.GetType(), eventHandler.GetType()));
        }

        //
        eventTable[eventType] = (EventHandler)eventTable[eventType] + eventHandler;

    }
    public static void RemoveListener(EventType eventType, EventHandler eventHandler)
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
        eventTable[eventType] = (EventHandler)eventTable[eventType] - eventHandler;
        // eventTable.Remove (eventType);
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

        //如果eventTable不包含这个key, 先增加一个key
        if (!eventTable.ContainsKey(eventType))
        {
            eventTable.Add(eventType, null);
        }

        Delegate d = eventTable[eventType];

        //如果给的eventhandler与存的不一致就抛出异常
        if (d != null && d.GetType() != eventHandler.GetType())
        {
            throw new Exception(string.Format("事件{0}需要的委托类型为{1},给予的为{2}", eventType, d.GetType(), eventHandler.GetType()));
        }

        //
        eventTable[eventType] = (EventHandler<T>)eventTable[eventType] + eventHandler;
    }
    public static void RemoveListener<T>(EventType eventType, EventHandler<T> eventHandler)
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
        eventTable[eventType] = (EventHandler<T>)eventTable[eventType] - eventHandler;


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
}