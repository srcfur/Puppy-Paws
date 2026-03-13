
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class InteractionRegistry
{
    public static InteractionRegistry singleton;
    private List<InteractionInterest> registeredInterests = new List<InteractionInterest>();
    public InteractionsResult getAllInterests()
    {
        return new InteractionsResult
        {
            interests = registeredInterests.ToArray(),
            count = registeredInterests.Count()
        };
    }
    public void Register(InteractionInterest interest)
    {
        if (registeredInterests.Contains(interest)) { Debug.LogError("Interaction interest registered twice!"); }
        registeredInterests.Add(interest);
    }
    public void Unregister(InteractionInterest interest)
    {
        if (registeredInterests.Contains(interest))
        {
            registeredInterests.Remove(interest);
            return;
        }
        Debug.LogError("Interaction interest tried unregistering, while not in registry!");
    }
    public struct InteractionsResult : IDisposable
    {
        public InteractionInterest[] interests;
        public int count;
        public void Dispose()
        {
            interests = null;
            count = 0;
            
        }
        public InteractionsResult sortByDistance(Vector3 position)
        {
            List<InteractionInterest> result = new List<InteractionInterest>();
            result.AddRange(interests);
            result.Sort((I, V) => { return (int)((I.getGameObject().transform.position - position).magnitude - (V.getGameObject().transform.position - position).magnitude); });
            interests = result.ToArray();
            return this;
        }
    }
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void OwO()
    {
        singleton = new InteractionRegistry();
    }
}