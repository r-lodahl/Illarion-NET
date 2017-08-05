using System;
using System.IO;
using Illarion.Common.Character;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class AppearanceMessageEventArgs : EventArgs
    {

        /**
         * ID of the character this message is about.
         */
        private readonly int _charId;

        /**
         * The new Appearance of the updated Char
         */
        private readonly Appearance _updatedAppearance;

        /**
         * The new Equipment of the updated Char
         */
        private readonly ushort[] _updateEquipment;
        private readonly ushort _updatedHitPoints;
        private readonly bool _updatedIsDead;

        //TODO: Find an appropiate place for this constant
        private const int InventorySlots = 18;

        public AppearanceMessageEventArgs(BinaryReader reader)
        {
            // The sequence of decoding is of importance!
            // CharId, Name, CustomName, Race, Male, Appearance, HitPoints
            // Size, HairID, BeardID, HairColor, SkinColor, item[], deadFlag
            _charId = reader.Read();
            var name = reader.ReadString();
            var customName = reader.ReadString();

            var race = reader.ReadUInt16();
            var male = reader.ReadByte() == 0;
            _updatedHitPoints = reader.ReadUInt16();
            var size = reader.ReadByte();
            var hairId = reader.ReadByte();
            var beardId = reader.ReadByte();
            var hairColorRed = reader.ReadByte();
            var hairColorGreen = reader.ReadByte();
            var hairColorBlue = reader.ReadByte();
            var hairColorAlpha = reader.ReadByte();
            var skinColorRed = reader.ReadByte();
            var skinColorGreen = reader.ReadByte();
            var skinColorBlue = reader.ReadByte();
            var skinColorAlpha = reader.ReadByte();
            var wornItems = new ushort[InventorySlots];
            for (var i = 0; i < InventorySlots; i++)
            {
                wornItems[i] = reader.ReadUInt16();
            }
            _updatedIsDead = reader.ReadByte() == 1;

            _updatedAppearance = new Appearance(name, customName, race, male, size, hairId,
                beardId, skinColorRed, skinColorGreen, skinColorBlue, skinColorAlpha, hairColorRed,
                hairColorGreen, hairColorBlue, hairColorAlpha);

            _updateEquipment = wornItems;
        }

        // public ServerReplyResult Execute() {
//        if (!EntityUpdater.checkExistence(_charId)) {
        //          log.error("Received appearance message for non-existing character: {}", _charId);
        // return ServerReplyResult.Failed;
        //    }

        // TODO: Put in character, updatePaperdoll()
        //  EntityUpdater.updateAppearance(_charId, _updatedAppearanceMessageEventArgs : EventArgs);
        // EntityUpdater.updateEquipment(_charId, _updateEquipmentMessageEventArgs : EventArgs);
        //EntityUpdater.updateAttribute(_charId, "HitPoints", _updatedHitPoints);
        //EntityUpdater.updateIsDeadStatus(_charId, _updatedIsDead);

        //log.debug("Updated appearance/equipment/stats for {}", _charId);

        // return ServerReplyResult.Success;
        //}

        public override string ToString()
        {
            return "[AppearanceMessage charId: " + _charId + "]";
        }
    }
}