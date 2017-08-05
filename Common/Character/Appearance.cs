using System;
using Assets.Common.Character;
using UnityEngine;

namespace Illarion.Common.Character
{
    public class Appearance
    {
        private const float ScaleMod = 100f;
        private const ushort FemaleRaceShift = 1000;

        private float _scale;
        private string _name, _customName;
        private Race _race;
        private byte _hair, _beard;
        private Color _skinColor, _hairColor;

        public Appearance(string name, string customName, ushort race, bool male, byte size, byte hairId, byte beardId,
            byte skinColorRed, byte skinColorGreen, byte skinColorBlue, byte skinColorAlpha, byte hairColorRed,
            byte hairColorGreen, byte hairColorBlue, byte hairColorAlpha)
        {
            _name = name;
            _customName = customName;

            _scale = size / ScaleMod;
            _hair = hairId;
            _beard = beardId;
            _skinColor = new Color(skinColorRed, skinColorGreen, skinColorBlue, skinColorAlpha);
            _hairColor = new Color(hairColorRed, hairColorGreen, hairColorBlue, hairColorAlpha);

            var raceSex = male ? race : race + FemaleRaceShift;
            _race = Enum.IsDefined(typeof(Race), raceSex) ? (Race) raceSex : Race.Unknown;
        }
    }
}
