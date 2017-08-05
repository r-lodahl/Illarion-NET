namespace Illarion.Common.Internal.Communication
{
    public enum Command {
        /**
     * Client command to start attacking another character.
     */
        CmdAttack = 0xFA,

        /**
     * Client command to cast a spell on the map, at the own character or at a item in the inventory or in a showcase.
     */
        CmdCast = 0xFD,

        /**
     * Client command that is used to answer a text request.
     */
        CmdCloseDialogInput = 0x50,
        /**
     * Client command that informs the server that a message dialog was closed.
     */
        CmdCloseDialogMessage = 0x51,

        /**
     * Client command that is used to answer a text request.
     */
        CmdCloseDialogSelection = 0x53,

        /**
     * Client command to close one of the showcases.
     */
        CmdCloseShowcase = 0xE9,

        /**
     * Client command that allows interaction with a trading dialog.
     */
        CmdCraftItem = 0x54,

        /**
     * Client command to drag a item from a inventory slot to another inventory slot.
     */
        CmdDragInvInv = 0xE3,

        /**
     * Client command to drag a item from a inventory slot to a position on the game map.
     */
        CmdDragInvMap = 0xE4,

        /**
     * Client command to drag an item from a inventory slot to a container.
     */
        CmdDragInvSc = 0xE1,

        /**
     * Client command to drag a item from a position on the game map into the inventory.
     */
        CmdDragMapInv = 0xE5,

        /**
     * Client command to drag a item from the map to another location on the map
     */
        CmdDragMapMap = 0xEF,

        /**
     * Client command to drag a item from a position on the game map into a container.
     */
        CmdDragMapSc = 0xE6,

        /**
     * Client command to drag a item from a container into the inventory.
     */
        CmdDragScInv = 0xE2,

        /**
     * Client command to drag a item from a container to a location on the game map.
     */
        CmdDragScMap = 0xE8,

        /**
     * Client command to drag an item from a container to another container.
     */
        CmdDragScSc = 0xE7,

        /**
     * Client command to introduce the character to other characters around.
     */
        CmdIntroduce = 0xF6,

        /**
     * Client command to name a player.
     */
        CmdNamePlayer = 0xF7,

        /**
     * Client command to tell the server that the connection between client and server is still active.
     */
        CmdKeepalive = 0xD8, // NO_UCD

        /**
     * Client command to send the login information.
     */
        CmdLogin = 0x0D,

        /**
     * Client command to tell the server to logout the character.
     */
        CmdLogoff = 0xF1,

        /**
     * Client command to look at a character on the map.
     */
        CmdLookatChar = 0x18,

        /**
     * Client command to look at a item in a showcase.
     */
        CmdLookatContainer = 0xE0,

        /**
     * Client command to look at a item in the inventory.
     */
        CmdLookatInv = 0xDF,

        /**
     * Client command to look at a item in the menu.
     */
        CmdLookatMenu = 0xDC,

        /**
     * Client command to look at a item on a tile.
     */
        CmdLookAtMapItem = 0xFF,

        /**
     * Client command to send the map dimensions the client needs.
     */
        CmdMapdimension = 0xA0,

        /**
     * Client command to move a character. Either the own one or pushing the character of someone else.
     */
        CmdMove = 0x10,

        /**
     * Client command to open the container in the bag slot of the inventory.
     */
        CmdOpenBag = 0xEB,

        /**
     * Client command to open a container on the game map.
     */
        CmdOpenMap = 0xEC,

        /**
     * Client command to open a container in one of the showcases.
     */
        CmdOpenShowcase = 0xEA,

        /**
     * Client command to request the appearance of another yet unknown character.
     */
        CmdRequestAppearance = 0x0E,

        /**
     * Client command to send a spoken text.
     */
        CmdSay = 0xF5,

        /**
     * Client command to send a shouted text.
     */
        CmdShout = 0xF4,

        /**
     * Client command to stop attacking.
     */
        CmdStandDown = 0xDE,

        /**
     * Client command that allows interaction with a trading dialog.
     */
        CmdTradeItem = 0x52,

        /**
     * Client command to turn the player character north.
     */
        CmdTurn = 0x11,

        /**
     * Client command to pick of a item from a specific map location.
     */
        CmdPickUp = 0xED,

        /**
     * Client command to pick up all items around the character.
     */
        CmdPickUpAll = 0xEE,

        /**
     * Client command to perform a use action of one or two items on different locations.
     */
        CmdUse = 0xFE,

        /**
     * Client command to send a whispered text.
     */
        CmdWhisper = 0xF3,

        /**
     * This is the message send by the server in response to the keep alive message.
     */
        MessageKeepAlive = 0x00,

        /**
     * Server message that contains the appearance data of a character.
     */
        MessageAppearance = 0xE1,

        /**
     * Server message that the player attacks a target character.
     */
        MessageAttack = 0xBB,

        /**
     * Server message that contains a attribute of the player character.
     */
        MessageAttribute = 0xB9,

        /**
     * Server message to show a specific book.
     */
        MessageBook = 0xCD,

        /**
     * Server message to change a specified item on a tile.
     */
        MessageChangeItem = 0xD9,

        /**
     * Server message that contains a data of a animation the character has to show.
     */
        MessageCharacterAnimation = 0xCB,

        /**
     * Server message that closes a showcase in the client window.
     */
        MessageCloseDialog = 0x5F,

        /**
     * Server message that closes a showcase in the client window.
     */
        MessageCloseShowcase = 0xC4,

        /**
     * Server message that contains the information about the current date and time.
     */
        MessageDatetime = 0xB6,

        /**
     * Server message that contains the data of a crafting dialog.
     */
        MessageDialogCrafting = 0x54,

        /**
     * Server message that contains the update of a crafting dialog.
     */
        MessageDialogCraftingUpdate = 0x55,

        /**
     * Server message to request a text from the player.
     */
        MessageDialogInput = 0x50,

        /**
     * Server message that contains the data of a merchant dialog.
     */
        MessageDialogMerchant = 0x52,

        /**
     * Server message that contains the data of a message dialog.
     */
        MessageDialogMessage = 0x51,

        /**
     * Server message that contains the data of a selection dialog.
     */
        MessageDialogSelection = 0x53,

        /**
     * Server message that current connection get canceled.
     */
        MessageDisconnect = 0xCC,

        /**
     * Server message that contains the data of a graphical effect that shall be played instantly.
     */
        MessageGraphicFx = 0xC9, // NO_UCD

        /**
     * Server message that contains a information text for the player.
     */
        MessageInform = 0xD8,

        /**
     * Server message that contains the name another character introduced with.
     */
        MessageIntroduce = 0xD4,

        /**
     * Server message that contains the items in the slot of the characters inventory.
     */
        MessageInventory = 0xC1,

        /**
     * Server message that updates the load information of the player character.
     */
        MessageCarryLoad = 0xB0,

        /**
     * Server message that updates the location of the player character on the game map.
     */
        MessageLocation = 0xBD,

        /**
     * Server message that contains the data of a lookat event on a character.
     */
        MessageLookatChar = 0x18,

        /**
     * Client command to look at a dialog item.
     */
        MessageLookatDialogItem = 0xB5,

        /**
     * Server message that contains the data of a lookat event on a inventory slot.
     */
        MessageLookatInv = 0xBE,

        /**
     * Server message that contains the data of a lookat event on a map tile.
     */
        MessageLookatMapitem = 0xC0,

        /**
     * Server message that contains the data of a lookat event on a showcase slot.
     */
        MessageLookatShowcase = 0xBF,

        /**
     * Server message that contains the data of a lookat event on a map tile.
     */
        MessageLookatTile = 0xBC,

        /**
     * Server message that contains the magic flags of the player character.
     */
        MessageMagicFlag = 0xB8,

        /**
     * Server message to mark that a full map update is transfered completly.
     */
        MessageMapComplete = 0xA2,

        /**
     * Server message that contains a map stripe. So all tiles along a stipe and the item on the tiles.
     */
        MessageMapStripe = 0xA1,

        /**
     * Server message for moving a character. That could be the player character or another character. This message
     * handles pushing and walking movements.
     */
        MessageMove = 0xDF,

        /**
     * Server message that says what track of the background music shall be played right now.
     */
        MessageMusic = 0xC8,

        /**
     * Server message that sends the character ID of the player character.
     */
        MessagePlayerId = 0xCA,

        /**
     * Server message to place a new item upon a tile.
     */
        MessagePutItem = 0xC2,

        /**
     * Server message that contains the information about a quest.
     */
        MessageQuest = 0x40,

        /**
     * Server message causes a quest entry to be deleted from the quest log.
     */
        MessageQuestDelete = 0x41,

        /**
     * Server message that contains the location of all quests that are in range.
     */
        MessageQuestAvailability = 0x42,

        /**
     * Server message to remove a character from the screen.
     */
        MessageRemoveChar = 0xE2,

        /**
     * Server message to remove the top item on a tile.
     */
        MessageRemoveItem = 0xC3,

        /**
     * Server message that contains a spoken text or a emote.
     */
        MessageSay = 0xD7,

        /**
     * Server message that contains a shouted text.
     */
        MessageShout = 0xD6,

        /**
     * Server message that sends the contents of a showcase.
     */
        MessageShowcase = 0xC5,

        /**
     * Server message that sends the contents of a single showcase slot.
     */
        MessageShowcaseSingle = 0xCF,

        /**
     * Server message that contains a skill of the player character.
     */
        MessageSkill = 0xD1,

        /**
     * Server message that contains the data of a sound effect that shall be played instantly.
     */
        MessageSoundFx = 0xC7,

        /**
     * Server message that the target of a attack is lost due death or escape and the player character needs to stand
     * down.
     */
        MessageTargetLost = 0xBA,

        /**
     * Server message to turn the character into a specified direction.
     */
        MessageTurnChar = 0xE0,

        /**
     * Server message that contains a full updated list of all items on a tile.
     */
        MessageUpdateItems = 0x19,

        /**
     * Server message that contains the data of the current weather in the game.
     */
        MessageWeather = 0xB7,

        /**
     * Server message that contains a whispered text.
     */
        MessageWhisper = 0xD5,

        /**
     * The default size of the header of each command and each message in byte.
     */
        HeaderSize = 6
    }
}
