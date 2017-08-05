/*
 * This file is part of the Illarion project.
 *
 * Copyright © 2016 - Illarion e.V.
 *
 * Illarion is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Affero General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * Illarion is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 */

/**
 * This abstract command contains the shared code of all dragging operations.
 *
 * @author Martin Karing &lt;nitram@illlarion.org&gt;
 */

using System.ComponentModel;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public abstract class AbstractDragCommandEventArgs : AbstractCommandEventArgs {
        /**
     * The amount of items that are supposed to be moved.
     */
        private readonly int _count;

        /**
     * The constructor of a command. This is used to set the ID of the command.
     *
     * @param commId the ID of the command
     * @param count the amount of items to drag at once
     */
        protected AbstractDragCommandEventArgs(Command command, int count) : base(command) {
            _count = count;
        }

        /**
     * Get the amount of items that are supposed to be moved.
     *
     * @return the items to be moved
     */
        protected ushort GetCount() {
            return (ushort) _count;
        }
    }
}
