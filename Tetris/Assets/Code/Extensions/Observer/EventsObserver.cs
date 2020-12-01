using System;
using System.Collections.Generic;
using UnityEngine;

public static class EventsObserver
{
    private class CHandler
    {
        public CHandler(Handler<IEvent> listener)
        {
            Listener = listener;
        }

        public Handler<IEvent> Listener { get; }
    }

    #region Delegates

    public delegate void Handler<T>(T e) where T : IEvent;

    #endregion

    private static readonly Dictionary<Type, List<KeyValuePair<object, CHandler>>> Listeners =
        new Dictionary<Type, List<KeyValuePair<object, CHandler>>>();

    private static readonly List<IDeferredAction> DeferredActions = new List<IDeferredAction>();

    private static bool _isLocked;

    private static void Lock(bool value)
    {
        _isLocked = value;
    }

    private static void AddDeferredAction(IDeferredAction action)
    {
        DeferredActions.Add(action);
    }

    private static List<KeyValuePair<object, CHandler>> GetHandlersByType(Type type)
    {
        Listeners.TryGetValue(type, out var handlers);

        return handlers;
    }

    public static void AddEventListener<TEvent>(Handler<TEvent> listener) where TEvent : IEvent
    {
        Type eventType = typeof(TEvent);

        if (!Listeners.ContainsKey(eventType))
        {
            Listeners.Add(eventType, new List<KeyValuePair<object, CHandler>>());
        }

        var handlers = GetHandlersByType(eventType);

        if (handlers != null)
        {
            void ListenerCasted666(IEvent x) => listener.Invoke((TEvent) x);
            CHandler handler = new CHandler(ListenerCasted666);
            var handlerPair = new KeyValuePair<object, CHandler>(listener, handler);

            handlers.Add(handlerPair);
        }
    }

    public static void RemoveEventListener<TEvent>(Handler<TEvent> listener) where TEvent : IEvent
    {
        if (_isLocked)
        {
            AddDeferredAction(new RemoveDeferredAction(() => { RemoveEvenListenerInternal(listener); }));
            return;
        }

        Lock(true);

        RemoveEvenListenerInternal(listener);

        ProcessDeferredActions();

        Lock(false);
    }

    private static void ProcessDeferredActions()
    {
        foreach (var t in DeferredActions)
        {
            switch (t.ActionType())
            {
                case global::DeferredActions.Remove:
                    (t as RemoveDeferredAction)?.RemoveHandlerAction();
                    break;
                case global::DeferredActions.Publish:
                    PublishInternal((t as PublishDeferredAction)?.Event);
                    break;
            }
        }

        DeferredActions.Clear();
    }

    public static void Publish<TEvent>(TEvent _event) where TEvent : IEvent
    {
        if (_isLocked)
        {
            AddDeferredAction(new PublishDeferredAction(_event));
            return;
        }

        Lock(true);

        PublishInternal(_event);

        ProcessDeferredActions();

        Lock(false);
    }


    public static void Clear()
    {
        Listeners.Clear();
    }

    private static void RemoveEvenListenerInternal<TEvent>(Handler<TEvent> listener) where TEvent : IEvent
    {
        foreach (var listeners in Listeners.Values)
        {
            listeners.RemoveAll(keyValuePair => listener.Equals(keyValuePair.Key));
        }
    }

    private static void PublishInternal<TEvent>(TEvent @event) where TEvent : IEvent
    {
        List<KeyValuePair<object, CHandler>> handlers = GetHandlersByType(@event.GetType());

        if (handlers == null) return;

        for (int i = 0; i < handlers.Count; i++)
        {
            try
            {
                handlers[i].Value.Listener(@event);
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
            }
        }
    }
}