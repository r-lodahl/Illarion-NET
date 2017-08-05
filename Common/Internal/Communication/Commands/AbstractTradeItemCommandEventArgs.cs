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
 * This abstract command is shared by all commands that refer to a trading dialog.
 *
 * @author Martin Karing &lt;nitram@illarion.org&gt;
 */

using System.IO;
using Illarion.Common.Internal.Serialization;

namespace Illarion.Common.Internal.Communication.Commands
{
    public abstract class AbstractTradeItemCommandEventArgs : AbstractCommandEventArgs {
        /**
     * The ID of the referenced trading dialog
     */
        private readonly int _dialogId;

        /**
     * The ID of the sub-command.
     */
        private readonly byte _subCommandId;

        /**
     * Default constructor for the trade item command.
     *
     * @param dialogId the ID of the dialog to buy the item from
     * @param subCommandId the ID of the sub command
     */
        protected AbstractTradeItemCommandEventArgs(int dialogId, int subCommandId) : base(Command.CmdTradeItem) {
            _dialogId = dialogId;
            _subCommandId = (byte) subCommandId;
        }

        public override void Encode(IEncoder encoder, Stream stream) {
            //writer.Write(_dialogId);
            //writer.Write(_subCommandId);
        }
        
        public override string ToString() {
            return "dialog ID: " + _dialogId;
        }
    }
}
