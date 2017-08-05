namespace Illarion.Common.UiHelper
{
    public class Tooltip
    {
        private string _name, _description, _craftedBy, _type, _qualityText, _durabilityText;
        private byte _rareness, _level, _durabilityValue;
        private bool _usable;
        private ushort _weight;
        private uint _worth;
        private byte _diamondLevel,
            _emeraldLevel,
            _rubyLevel,
            _sapphireLevel,
            _amethystLevel,
            _obsidianLevel,
            _topazLevel,
            _bonus;

        public Tooltip(string name, byte rareness, string description, string craftedBy, string type, byte level,
            bool usable, ushort weight, uint worth, string qualityText, string durabilityText, byte durabilityValue,
            byte diamondLevel, byte emeraldLevel, byte rubyLevel, byte sapphireLevel, byte amethystLevel,
            byte obsidianLevel, byte topazLevel, byte bonus)
        {
            _name = name;
            _description = description;
            _craftedBy = craftedBy;
            _type = type;
            _qualityText = qualityText;
            _durabilityText = durabilityText;

            _rareness = rareness;
            _level = level;
            _usable = usable;
            _weight = weight;
            _worth = worth;
            _durabilityValue = durabilityValue;

            _diamondLevel = diamondLevel;
            _emeraldLevel = emeraldLevel;
            _rubyLevel = rubyLevel;
            _sapphireLevel = sapphireLevel;
            _amethystLevel = amethystLevel;
            _obsidianLevel = obsidianLevel;
            _topazLevel = topazLevel;
            _bonus = bonus;
        }

    }
}
