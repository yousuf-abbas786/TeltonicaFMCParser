using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeltonicaFMCParser
{
    public class AVLDataHex
    {
        public TimeStamp TimeStamp { get; set; } = new TimeStamp();
        public Priority Priority { get; set; } = new Priority();
        public Longitude Longitude { get; set; } = new Longitude();
        public Latitude Latitude { get; set; } = new Latitude();
        public Altitude Altitude { get; set; } = new Altitude();
        public Angle Angle { get; set; } = new Angle();
        public Satellite Satellite { get; set; } = new Satellite();
        public Speed Speed { get; set; } = new Speed();
        public EventIOID EventIOID { get; set; } = new EventIOID();
        public NOfTotalID NOfTotalID { get; set; } = new NOfTotalID();
        public Dictionary<string, string> N1IOHexKeyVal { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> N2IOHexKeyVal { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> N4IOHexKeyVal { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> N8IOHexKeyVal { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> NXIOHexKeyVal { get; set; } = new Dictionary<string, string>();
    }

    public class TimeStamp
    {
        public string ValueHexa { get; set; }
        public DateTime Value { get; set; }
    }

    public class Priority
    {
        public string ValueHexa { get; set; }
        public PriorityEnum Value { get; set; }
    }

    public class Longitude
    {
        public string ValueHexa { get; set; }
        public decimal Value { get; set; }
    }

    public class Latitude
    {
        public string ValueHexa { get; set; }
        public decimal Value { get; set; }
    }

    public class Altitude
    {
        public string ValueHexa { get; set; }
        public int Value { get; set; }
    }

    public class Angle
    {
        public string ValueHexa { get; set; }
        public int Value { get; set; }
    }

    public class Satellite
    {
        public string ValueHexa { get; set; }
        public int Value { get; set; }
    }

    public class Speed
    {
        public string ValueHexa { get; set; }
        public int Value { get; set; }
    }

    public class EventIOID
    {
        public string ValueHexa { get; set; }
        public int Value { get; set; }
    }

    public class NOfTotalID
    {
        public string ValueHexa { get; set; }
        public int Value { get; set; }
    }

    public class DeviceData
    {
        public CodecID CodecID { get; set; } = new CodecID();
        public DataFieldLength DataFieldLength { get; set; } = new DataFieldLength();
        public NumberOfData1 NumberOfData1 { get; set; } = new NumberOfData1();
        public NumberOfData2 NumberOfData2 { get; set; } = new NumberOfData2();
        public CRC16 CRC16 { get; set; } = new CRC16();

        public List<AVLDataHex> AVLRecords = new List<AVLDataHex>();
    }

    public class CodecID
    {
        public string ValueHexa { get; set; }
        public int Value { get; set; }
    }
    public class DataFieldLength
    {
        public string ValueHexa { get; set; }
        public int Value { get; set; }
    }
    public class NumberOfData1
    {
        public string ValueHexa { get; set; }
        public int Value { get; set; }
    }
    public class CRC16
    {
        public string ValueHexa { get; set; }
        public int Value { get; set; }
    }

    public class NumberOfData2
    {
        public string ValueHexa { get; set; }
        public int Value { get; set; }
    }

    public enum PriorityEnum
    {
        Low,
        High,
        Panic
    }

    public class DeviceFile
    {
        public string IMEI { get; set; }
        public string Path { get; set; }

        public List<DeviceMessage> Messages = new List<DeviceMessage>();
    }

    public class DeviceMessage
    {
        public string[] LineSplitArr { get; set; }
        public string Message { get; set; }
    }
}
