using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class MapDimensionCommandEventArgs : AbstractCommandEventArgs
    {
        /**
         * The map height that is requested from the server.
         */
        private readonly byte _mapHeight;

        /**
         * The map width that is requested from the server.
         */
        private readonly byte _mapWidth;

        /**
         * Default constructor for the map dimension command.
         *
         * @param width the half of the needed width in stripes - 1
         * @param height the half of the needed height in stripes - 1
         */
        public MapDimensionCommandEventArgs(int width, int height) : base(Command.CmdMapdimension)
        {
            _mapWidth = (byte) width;
            _mapHeight = (byte) height;
        }

        public override void Encode(IEncoder encoder, Stream stream)
        {
            //writer.Write(_mapWidth);
            //writer.Write(_mapHeight);
        }

        public override string ToString()
        {
            return "[MapDimensionCommand Width: " + _mapWidth + " Height: " + _mapHeight + "]";
        }
    }
}
