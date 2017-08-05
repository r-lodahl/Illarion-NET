using System.Collections.Generic;
using UnityEngine;

namespace Illarion.Common.Internal.Communication
{
    /// <summary>
    /// Allows objects to listen to events of other objects they do not know and with which they are no even directly connected by Main.
    /// Attention: It is important that all subscribables are registered before subscribers are registered!
    /// </summary>
    public static class EventManager
    {
        private static readonly Dictionary<Command, ISubscribable> KnownSubscribables = new Dictionary<Command, ISubscribable>();
        
        public static void Subscribe(Command subscription, ISubscriber subscriber)
        {
            if (KnownSubscribables.ContainsKey(subscription))
            {
                KnownSubscribables[subscription].EventMessage += subscriber.ActionInvoked;
            }
        }

        public static void Publish(Command command, ISubscribable creator)
        {
            if (KnownSubscribables.ContainsKey(command))
            {
                Debug.LogError(string.Format("Tried to add {0} to the eventManager, but it is already present!",
                    command));
            }
            else
            {
                KnownSubscribables.Add(command, creator);
            }
        }

    }
}
