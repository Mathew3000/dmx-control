using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading.Tasks;

namespace DMXControl
{
    class DMXNode
    {
        #region LocalVariables
        private List<int> _channels = new List<int>();
        #endregion

        #region Properties
        /// <summary>
        /// A name for the DMX node
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The starting address for the DMX node
        /// </summary>
        public int StartAddress { get; private set; }

        /// <summary>
        /// The number of DMX channels for this DMX node
        /// </summary>
        public int ChannelCount { get; private set; }
        
        /// <summary>
        /// A flag representing whether the property has unsend changes
        /// </summary>
        public bool HasChanged { get; private set; }
        #endregion

        #region PublicMembers
        /// <summary>
        /// Initialises a new DMX node
        /// </summary>
        /// <param name="name">the nodes name</param>
        /// <param name="startAddr">the startaddress of the DMX node</param>
        /// <param name="channels">how many channels the node contains</param>
        public DMXNode(string name,  int startAddr, int channels)
        {
            // Name
            Name = name;

            // StartAddress
            if ((startAddr > 0) && (startAddr < 512))
            {
                StartAddress = startAddr;
            }
            else
            {
                throw new IndexOutOfRangeException("address out of bounds");
            }

            // Channels
            if ((channels > 0) && ((channels + StartAddress - 1) <= 512))
            {
                ChannelCount = channels;

            }
            else
            {
                ChannelCount = 1;
                throw new IndexOutOfRangeException("length out of bounds");
            }

            // ChannelList
            _channels = new List<int>(new int[ChannelCount]);
        }


        /// <summary>
        /// Returns the value of the given channel
        /// </summary>
        /// <param name="channelNr">the channel to return</param>
        /// <returns></returns>
        public int GetChannel(int channelNr)
        {
            if (channelNr < ChannelCount)
            {
                return _channels[channelNr];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        
        /// <summary>
        /// Sets a given channel to a given value
        /// </summary>
        /// <param name="channelNr">the channel to set</param>
        /// <param name="value">the target value</param>
        public void SetChannel(int channelNr, int value)
        {
            if((channelNr < ChannelCount) && (value < 256))
            {
                _channels[channelNr] = value;
            }
        }
        
        /// <summary>
        /// Clears the changedFlag after it was sent
        /// </summary>
        /// <param name="dmxInterface"></param>
        public void ClearChangedFlag(DMXInterface dmxInterface)
        {
            if (dmxInterface != null)
                HasChanged = true;
        }
        #endregion

        #region PrivateMember
        #endregion
    }


    class DMXInterface
    {
        #region PrivateVariables
        string _port = "";
        SerialPort serial = new SerialPort();
        #endregion

        #region PublicMember
        /// <summary>
        /// Creates a new DMX Interface at given SerialPort
        /// </summary>
        /// <param name="port">the name of the serial port</param>
        public DMXInterface(string port)
        {
            _port = port;
            // setup serial
            serial.PortName = port;
            serial.BaudRate = 115200;
            serial.ReadTimeout = 1000;
            serial.WriteTimeout = 1000;
            serial.NewLine = "\n";
        }

        /// <summary>
        /// Opens a connection to DMX interface
        /// </summary>
        public void Open()
        {
            serial.Open();
        }

        /// <summary>
        /// Closes a connection to DMX interface
        /// </summary>
        public void Close()
        {
            serial.Close();
        }
        #endregion
    }
}
