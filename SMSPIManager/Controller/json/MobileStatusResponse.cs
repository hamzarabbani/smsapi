using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineSMSender.controller.json
{
    public class BatteryInfo
    {
        public string health { get; set; }
        public string technology { get; set; }
        public string status { get; set; }
        public string plugType { get; set; }
        public int level { get; set; }
        public bool isPresent { get; set; }
        public int temperature { get; set; }
        public int voltage { get; set; }
    }

    public class GsmCellLocation
    {
        public int cid { get; set; }
        public int lac { get; set; }
        public int psc { get; set; }
    }

    public class SignalStrength
    {
        public int cdmaDbm { get; set; }
        public int cdmaEcio { get; set; }
        public int evdoDbm { get; set; }
        public int evdoEcio { get; set; }
        public int evdoSnr { get; set; }
        public int gsmBitErrorRate { get; set; }
        public int gsmSignalStrength { get; set; }
        public bool isGsm { get; set; }
    }

    public class NetworkInfo
    {
        public string cellLocationType { get; set; }
        public string connectionType { get; set; }
        public string deviceId { get; set; }
        public string deviceSoftwareVersion { get; set; }
        public GsmCellLocation gsmCellLocation { get; set; }
        public string ipAddress { get; set; }
        public string voiceMailNumber { get; set; }
        public string subscriberId { get; set; }
        public string networkCountryIso { get; set; }
        public string networkOperator { get; set; }
        public string networkOperatorName { get; set; }
        public string networkType { get; set; }
        public string phoneNumber { get; set; }
        public string phoneType { get; set; }
        public SignalStrength signalStrength { get; set; }
        public string simCountryIso { get; set; }
        public string simOperator { get; set; }
        public string simOperatorName { get; set; }
        public string simSerialNumber { get; set; }
        public string simState { get; set; }
        public bool isNetworkRoaming { get; set; }
        public bool isConnected { get; set; }
    }

    public class MobileStatusResponse
    {
        public BatteryInfo batteryInfo { get; set; }
        public NetworkInfo networkInfo { get; set; }
        public string description { get; set; }
        public string requestMethod { get; set; }
        public bool isSuccessful { get; set; }
    }
}
