using System;

namespace Illarion.Common.Internal.Communication
{
    public interface ISubscriber
    {
        void ActionInvoked(object sender, EventArgs args);
    }
}
