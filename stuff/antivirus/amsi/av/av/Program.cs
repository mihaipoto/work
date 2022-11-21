

using av;
using System.Net.WebSockets;
using System.Runtime.InteropServices;

var amsi = new AMSI_Provider();

amsi.CallAntimalwareScanInterface();