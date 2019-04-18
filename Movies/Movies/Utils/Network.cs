using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Connectivity;

namespace Movies.Utils
{
    public class Network
    {
        public static bool isConnected()
        {
            return CrossConnectivity.Current.IsConnected;
        }
    }
}
