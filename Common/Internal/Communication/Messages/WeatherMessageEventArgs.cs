using System;
using System.IO;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class WeatherMessageEventArgs : EventArgs
    {
        /**
         * The new value for the clouds.
         */
        private readonly byte _clouds;

        /**
         * The new value for the fog.
         */
        private readonly byte _fog;

        /**
         * The new value for the gust strength.
         */
        private readonly byte _gusts;

        /**
         * The new value for the lightning intensity.
         */
        private readonly byte _lightning;

        /**
         * The new value for the precipitation strength.
         */
        private readonly byte _precipitation;

        /**
         * The new value for the precipitation type.
         */
        private readonly byte _precType;

        /**
         * The new value for the temperature.
         */
        private readonly sbyte _temperature;

        /**
         * The new wind value.
         */
        private readonly sbyte _wind;


        public WeatherMessageEventArgs(BinaryReader reader)
        {
            _clouds = reader.ReadByte();
            _fog = reader.ReadByte();
            _wind = reader.ReadSByte();
            _gusts = reader.ReadByte();
            _precipitation = reader.ReadByte();
            _precType = reader.ReadByte();
            _lightning = reader.ReadByte();
            _temperature = reader.ReadSByte();
        }

        // public ServerReplyResult Execute() {
        // GameUpdater.setWeather(_fog, _lightning, _precType, _precipitation, _wind, _gusts, _clouds, _temperature);
        // return ServerReplyResult.Success;
        //}

        public override string ToString()
        {
            return "[WeatherMessage clouds: " + _clouds + " fog: " + _fog + " wind: " + _wind +
                   " gusts: " + _gusts + " precipitation: " + _precipitation + " precType: " + _precType +
                   " lightning: " + _lightning + " temperature: " + _temperature + "]";
        }
    }
}
