using System;

namespace Illarion.Common.Internal.Communication
{
    public interface ISubscribable
    {
        event EventHandler EventMessage;
    }
}
