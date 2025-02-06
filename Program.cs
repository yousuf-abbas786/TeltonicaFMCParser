using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeltonicaFMCParser
{
    public class Program
    {
        static Dictionary<int, string> IOElementsMap;
        public static async Task Main(string[] args)
        {
            IOElementsMap = new Dictionary<int, string>
            {
                { 1, "Digital Input 1" },
                { 2, "Digital Input 2" },
                { 3, "Digital Input 3" },
                { 4, "Pulse Counter Din1" },
                { 5, "Pulse Counter Din2" },
                { 6, "Analog Input 2" },
                { 9, "Analog Input 1" },
                { 10, "SD Status" },
                { 11, "ICCID1" },
                { 12, "Fuel Used GPS" },
                { 13, "Fuel Rate GPS" },
                { 14, "ICCID2" },
                { 15, "Eco Score" },
                { 16, "Total Odometer" },
                { 17, "Axis X" },
                { 18, "Axis Y" },
                { 19, "Axis Z" },
                { 21, "GSM Signal" },
                { 22, "Total Odometer" },
                { 24, "Speed" },
                { 25, "Data Mode" },
                { 26, "Operator Code" },
                { 27, "Cell ID" },
                { 28, "Area Code" },
                { 29, "GSM Signal" },
                { 30, "Device Temperature" },
                { 33, "Trip Odometer" },
                { 36, "iButton ID" },
                { 61, "Geofence zone 06" },
                { 62, "Geofence zone 07" },
                { 63, "Geofence zone 08" },
                { 64, "Geofence zone 09" },
                { 65, "Geofence zone 10" },
                { 66, "External Voltage" },
                { 67, "Battery Voltage" },
                { 68, "Battery Current" },
                { 69, "GNSS Status" },
                { 70, "Geofence zone 11" },
                { 71, "Dallas Temperature 4" },
                { 72, "Dallas Temperature 1" },
                { 73, "Dallas Temperature 2" },
                { 74, "Dallas Temperature 3" },
                { 75, "Dallas Temperature 4" },
                { 76, "Dallas Temperature ID 1" },
                { 77, "Dallas Temperature ID 2" },
                { 78, "iButton" },
                { 79, "Dallas Temperature ID 3" },
                { 80, "Data Mode" },
                { 88, "Geofence zone 12" },
                { 91, "Geofence zone 13" },
                { 92, "Geofence zone 14" },
                { 93, "Geofence zone 15" },
                { 94, "Geofence zone 16" },
                { 95, "Geofence zone 17" },
                { 96, "Geofence zone 18" },
                { 97, "Geofence zone 19" },
                { 98, "Geofence zone 20" },
                { 99, "Geofence zone 21" },
                { 113, "Battery Level" },
                { 150, "Event IO ID" },
                { 153, "Geofence zone 22" },
                { 154, "Geofence zone 23" },
                { 155, "Geofence zone 01" },
                { 156, "Geofence zone 02" },
                { 157, "Geofence zone 03" },
                { 158, "Geofence zone 04" },
                { 159, "Geofence zone 05" },
                { 175, "Auto Geofence" },
                { 179, "Digital Output 1" },
                { 180, "Digital Output 2" },
                { 181, "GNSS PDOP" },
                { 182, "GNSS HDOP" },
                { 183, "GNSS VDOP" },
                { 184, "GNSS TDOP" },
                { 185, "GNSS Horizontal Accuracy" },
                { 186, "GNSS Vertical Accuracy" },
                { 187, "GNSS Speed Accuracy" },
                { 188, "GNSS Satellites" },
                { 189, "GNSS Fix Type" },
                { 190, "Geofence zone 24" },
                { 191, "Geofence zone 25" },
                { 192, "Geofence zone 26" },
                { 193, "Geofence zone 27" },
                { 194, "Geofence zone 28" },
                { 195, "Geofence zone 29" },
                { 196, "Geofence zone 30" },
                { 197, "Geofence zone 31" },
                { 198, "Geofence zone 32" },
                { 199, "Trip Odometer" },
                { 200, "Sleep Mode" },
                { 201, "LLS 1 Fuel Level" },
                { 202, "LLS 1 Temperature" },
                { 203, "LLS 2 Fuel Level" },
                { 204, "LLS 2 Temperature" },
                { 205, "GSM Cell ID" },
                { 206, "GSM Area Code" },
                { 207, "RFID" },
                { 208, "Geofence zone 33" },
                { 209, "Geofence zone 34" },
                { 210, "LLS 3 Fuel Level" },
                { 211, "LLS 3 Temperature" },
                { 212, "LLS 4 Fuel Level" },
                { 213, "LLS 4 Temperature" },
                { 214, "LLS 5 Fuel Level" },
                { 215, "LLS 5 Temperature" },
                { 216, "Geofence zone 35" },
                { 217, "Geofence zone 36" },
                { 218, "Geofence zone 37" },
                { 219, "Geofence zone 38" },
                { 220, "Geofence zone 39" },
                { 221, "Geofence zone 40" },
                { 222, "Geofence zone 41" },
                { 223, "Geofence zone 42" },
                { 224, "Geofence zone 43" },
                { 225, "Geofence zone 44" },
                { 226, "Geofence zone 45" },
                { 227, "Geofence zone 46" },
                { 228, "Geofence zone 47" },
                { 229, "Geofence zone 48" },
                { 230, "Geofence zone 49" },
                { 231, "Geofence zone 50" },
                { 236, "Alarm" },
                { 237, "Network Type" },
                { 238, "User ID" },
                { 239, "Ignition" },
                { 240, "Movement" },
                { 241, "Active GSM Operator" },
                { 243, "Green driving event duration" },
                { 246, "Towing" },
                { 247, "Crash detection" },
                { 248, "Immobilizer" },
                { 249, "Jamming" },
                { 250, "Trip" },
                { 251, "Idling" },
                { 252, "Unplug" },
                { 253, "Green driving type" },
                { 254, "Green Driving Value" },
                { 255, "Over Speeding" },
                { 257, "Crash trace data" },
                { 258, "EcoMaximum" },
                { 259, "EcoAverage" },
                { 260, "EcoDuration" },
                { 263, "BT Status" },
                { 264, "Barcode ID" },
                { 283, "Driving State" },
                { 284, "Driving Records" },
                { 285, "Blood alcohol content" },
                { 303, "Instant Movement" },
                { 317, "Crash event counter" },
                { 318, "GNSS Jamming" },
                { 327, "UL202-02 Sensor Fuel level" },
                { 329, "AIN Speed" },
                { 380, "Digital output 3" },
                { 381, "Ground Sense" },
                { 383, "AXL Calibration Status" },
                { 387, "Ground Sense" },
                { 391, "Private mode" },
                { 403, "Driver Name" },
                { 404, "Driver card license type" },
                { 405, "Driver Gender" },
                { 406, "Driver Card ID" },
                { 407, "Driver card expiration date" },
                { 408, "Driver Card place of issue" },
                { 409, "Driver Status Event" },
                { 449, "Ignition On Counter" },
                { 451, "BLE RFID #1" },
                { 452, "BLE RFID #2" },
                { 453, "BLE RFID #3" },
                { 454, "BLE RFID #4" },
                { 455, "BLE Button 1 state #1" },
                { 456, "BLE Button 1 state #2" },
                { 457, "BLE Button 1 state #3" },
                { 458, "BLE Button 1 state #4" },
                { 459, "BLE Button 2 state #1" },
                { 460, "BLE Button 2 state #2" },
                { 461, "BLE Button 2 state #3" },
                { 462, "BLE Button 2 state #4" },
                { 483, "UL202-02 Sensor Status" },
                { 500, "MSP500 vendor name" },
                { 501, "MSP500 vehicle number" },
                { 502, "MSP500 speed sensor" },
                { 622, "Frequency DIN1" },
                { 623, "Frequency DIN2" },
                { 636, "UMTS/LTE Cell ID" },
                { 637, "Wake Reason" },
                { 1412, "Motorcycle Fall Detection" },
                { 10800, "EYE Temperature 1" },
                { 10801, "EYE Temperature 2" },
                { 10802, "EYE Temperature 3" },
                { 10803, "EYE Temperature 4" },
                { 10804, "EYE Humidity 1" },
                { 10805, "EYE Humidity 2" },
                { 10806, "EYE Humidity 3" },
                { 10807, "EYE Humidity 4" },
                { 10808, "EYE Magnet 1" },
                { 10809, "EYE Magnet 2" },
                { 10810, "EYE Magnet 3" },
                { 10811, "EYE Magnet 4" },
                { 10812, "EYE Movement 1" },
                { 10813, "EYE Movement 2" },
                { 10814, "EYE Movement 3" },
                { 10815, "EYE Movement 4" },
                { 10816, "EYE Pitch 1" },
                { 10817, "EYE Pitch 2" },
                { 10818, "EYE Pitch 3" },
                { 10819, "EYE Pitch 4" },
                { 10820, "EYE Low Battery 1" },
                { 10821, "EYE Low Battery 2" },
                { 10822, "EYE Low Battery 3" },
                { 10823, "EYE Low Battery 4" },
                { 10824, "EYE Battery Voltage 1" },
                { 10825, "EYE Battery Voltage 2" },
                { 10826, "EYE Battery Voltage 3" },
                { 10827, "EYE Battery Voltage 4" },
                { 10832, "EYE Roll 1" },
                { 10833, "EYE Roll 2" },
                { 10834, "EYE Roll 3" },
                { 10835, "EYE Roll 4" },
                { 10836, "EYE Movement count 1" },
                { 10837, "EYE Movement count 2" },
                { 10838, "EYE Movement count 3" },
                { 10839, "EYE Movement count 4" },
                { 10840, "EYE Magnet count 1" },
                { 10841, "EYE Magnet count 2" },
                { 10842, "EYE Magnet count 3" },
                { 10843, "EYE Magnet count 4" },





            };

            string projectRoot = Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.FullName;
            string hexaFolderPath = Path.Combine(projectRoot, @"20250106\hexa");
            string rawFolderPath = Path.Combine(projectRoot, @"20250106\Parser\Raw");
            string dataFolderPath = Path.Combine(projectRoot, @"20250106\Parser\Data");

            //var deviceFiles = GetMessagesFromFiles(hexaFolderPath);

            string path = @"C:\Projects\TeltonicaFMCParser\20250106\hexa\357544372173589.hexa";
            var deviceFile = GetMessagesFromFile(path);
            ProcessDeviceFile(rawFolderPath, deviceFile, "raw");
            ProcessDeviceFile(dataFolderPath, deviceFile, "data");

            //await GenerateLogsAsync(rawFolderPath, deviceFiles);
            //await GenerateLogsAsync(dataFolderPath, deviceFiles, "data");
            Console.WriteLine("process finished");
            Console.ReadLine();
        }

        static string DecodeImei(string encodedMessage)
        {
            // Skip the first 4 characters (length prefix)
            string imeiHex = encodedMessage.Substring(4);

            // Convert hex pairs to ASCII characters
            var imeiBuilder = new StringBuilder();
            for (int i = 0; i < imeiHex.Length; i += 2)
            {
                // Take two characters (1 byte) and convert to an integer
                string hexPair = imeiHex.Substring(i, 2);
                int asciiValue = Convert.ToInt32(hexPair, 16);
                imeiBuilder.Append((char)asciiValue);
            }

            return imeiBuilder.ToString();
        }

        static DeviceData ParseCodec8MessageHex(string imei, string dataHex)
        {
            //List<string> retVal = new List<string>();

            DeviceData dataHexx = new DeviceData();

            if (!dataHex.StartsWith("00000000"))
            {
                if (dataHex.StartsWith("FF"))
                {
                    int iindex = 0;
                    for (int k = 0; k < dataHex.Length; k++)
                    {
                        if (dataHex[k] == 'F')
                        {
                            iindex++;
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                    dataHex = dataHex.Substring(iindex);
                }
            }

            if (string.IsNullOrEmpty(dataHex))
            {
                return dataHexx;
            }

            //removing first 4 zero bytes
            dataHex = dataHex.Substring(8, dataHex.Length - 8);

            dataHexx.CRC16.ValueHexa = dataHex.Substring(dataHex.Length - 8);
            dataHexx.CRC16.Value = HexToDecimal(dataHexx.CRC16.ValueHexa);

            dataHexx.NumberOfData2.ValueHexa = dataHex.Substring(dataHex.Length - 10, 2);
            dataHexx.NumberOfData2.Value = HexToDecimal(dataHexx.NumberOfData2.ValueHexa);

            dataHexx.DataFieldLength.ValueHexa = dataHex.Substring(0, 8);
            dataHexx.DataFieldLength.Value = HexToDecimal(dataHexx.DataFieldLength.ValueHexa);

            dataHexx.CodecID.ValueHexa = dataHex.Substring(8, 2);
            dataHexx.CodecID.Value = HexToDecimal(dataHexx.CodecID.ValueHexa);

            if (!new List<string> { "08", "8E" }.Contains(dataHexx.CodecID.ValueHexa))
            {
                return dataHexx;
            }

            dataHexx.NumberOfData1.ValueHexa = dataHex.Substring(10, 2);
            dataHexx.NumberOfData1.Value = HexToDecimal(dataHexx.NumberOfData1.ValueHexa);

            //validating dataFieldLength by removing data field length, CRC and number of data 2
            string allData = dataHex.Substring(8, dataHex.Length - 16);

            if (dataHexx.DataFieldLength.Value == allData.Length / 2 && dataHexx.NumberOfData1.Value == dataHexx.NumberOfData2.Value)
            {
                string avlDataHex = allData.Substring(4, allData.Length - 6);
                int avlIndex = 0;
                for (int j = 0; j < dataHexx.NumberOfData1.Value; j++)
                {
                    int index = 4 + 2;
                    AVLDataHex avlDataHexx = new AVLDataHex();

                    // parsing AVL Data
                    avlDataHexx.TimeStamp.ValueHexa = avlDataHex.Substring(avlIndex, 16);
                    avlDataHexx.TimeStamp.Value = HexToDateTime(avlDataHexx.TimeStamp.ValueHexa);
                    avlIndex = avlIndex + 16;

                    avlDataHexx.Priority.ValueHexa = avlDataHex.Substring(avlIndex, 2);
                    avlDataHexx.Priority.Value = (PriorityEnum)HexToDecimal(avlDataHexx.Priority.ValueHexa);
                    avlIndex = avlIndex + 2;

                    string gpsDataHex = avlDataHex.Substring(avlIndex, 30);
                    avlIndex = avlIndex + 30;

                    string ioElementHex = avlDataHex.Substring(avlIndex, avlDataHex.Length - avlIndex);

                    // parsing GPS Data
                    avlDataHexx.Longitude.ValueHexa = gpsDataHex.Substring(0, 8);
                    avlDataHexx.Longitude.Value = CalculateCoordinate(avlDataHexx.Longitude.ValueHexa);

                    avlDataHexx.Latitude.ValueHexa = gpsDataHex.Substring(8, 8);
                    avlDataHexx.Latitude.Value = CalculateCoordinate(avlDataHexx.Latitude.ValueHexa);

                    avlDataHexx.Altitude.ValueHexa = gpsDataHex.Substring(16, 4);
                    avlDataHexx.Altitude.Value = HexToDecimal(avlDataHexx.Altitude.ValueHexa);

                    avlDataHexx.Angle.ValueHexa = gpsDataHex.Substring(20, 4);
                    avlDataHexx.Angle.Value = HexToDecimal(avlDataHexx.Angle.ValueHexa);

                    avlDataHexx.Satellite.ValueHexa = gpsDataHex.Substring(24, 2);
                    avlDataHexx.Satellite.Value = HexToDecimal(avlDataHexx.Satellite.ValueHexa);

                    avlDataHexx.Speed.ValueHexa = gpsDataHex.Substring(26, 4);
                    avlDataHexx.Speed.Value = HexToDecimal(avlDataHexx.Speed.ValueHexa);

                    //parsing IO Element

                    if (dataHexx.CodecID.ValueHexa == "08")
                        avlDataHexx.EventIOID.ValueHexa = ioElementHex.Substring(0, 2);

                    else if (dataHexx.CodecID.ValueHexa == "8E")
                        avlDataHexx.EventIOID.ValueHexa = ioElementHex.Substring(0, 4);

                    avlDataHexx.EventIOID.Value = HexToDecimal(avlDataHexx.EventIOID.ValueHexa);

                    if (dataHexx.CodecID.ValueHexa == "08")
                        avlDataHexx.NOfTotalID.ValueHexa = ioElementHex.Substring(2, 2);
                    else if (dataHexx.CodecID.ValueHexa == "8E")
                        avlDataHexx.NOfTotalID.ValueHexa = ioElementHex.Substring(4, 4);

                    avlDataHexx.NOfTotalID.Value = HexToDecimal(avlDataHexx.NOfTotalID.ValueHexa);

                    int nOfTotalIO = HexToDecimal(avlDataHexx.NOfTotalID.ValueHexa);

                    if (nOfTotalIO > 0)
                    {
                        string n1OfOneByteIOHex = string.Empty;
                        if (dataHexx.CodecID.ValueHexa == "08")
                            n1OfOneByteIOHex = ioElementHex.Substring(4, 2);
                        else if (dataHexx.CodecID.ValueHexa == "8E")
                            n1OfOneByteIOHex = ioElementHex.Substring(8, 4);

                        int n1OfOneByteIO = HexToDecimal(n1OfOneByteIOHex);

                        if (dataHexx.CodecID.ValueHexa == "8E")
                        {
                            index = 8 + 4;
                        }

                        if (n1OfOneByteIO > 0)
                        {
                            for (int i = 0; i < n1OfOneByteIO; i++)
                            {
                                if (dataHexx.CodecID.ValueHexa == "08")
                                {
                                    avlDataHexx.N1IOHexKeyVal.Add($"{i}IOId", ioElementHex.Substring(index, 2));
                                    index = index + 2;
                                }
                                else if (dataHexx.CodecID.ValueHexa == "8E")
                                {
                                    avlDataHexx.N1IOHexKeyVal.Add($"{i}IOId", ioElementHex.Substring(index, 4));
                                    index = index + 4;
                                }

                                avlDataHexx.N1IOHexKeyVal.Add($"{i}IOVal", ioElementHex.Substring(index, 2));
                                index = index + 2;
                            }
                        }

                        string n2OfTwoBytesIOHex = string.Empty;

                        if (dataHexx.CodecID.ValueHexa == "08")
                        {
                            n2OfTwoBytesIOHex = ioElementHex.Substring(index, 2);
                            index = index + 2;
                        }
                        else if (dataHexx.CodecID.ValueHexa == "8E")
                        {
                            n2OfTwoBytesIOHex = ioElementHex.Substring(index, 4);
                            index = index + 4;
                        }

                        int n2OfTwoBytesIO = HexToDecimal(n2OfTwoBytesIOHex);


                        if (n2OfTwoBytesIO > 0)
                        {
                            for (int i = 0; i < n2OfTwoBytesIO; i++)
                            {
                                if (dataHexx.CodecID.ValueHexa == "08")
                                {
                                    avlDataHexx.N2IOHexKeyVal.Add($"{i}IOId", ioElementHex.Substring(index, 2));
                                    index = index + 2;
                                }
                                else if (dataHexx.CodecID.ValueHexa == "8E")
                                {
                                    avlDataHexx.N2IOHexKeyVal.Add($"{i}IOId", ioElementHex.Substring(index, 4));
                                    index = index + 4;
                                }

                                avlDataHexx.N2IOHexKeyVal.Add($"{i}IOVal", ioElementHex.Substring(index, 4));
                                index = index + 4;
                            }
                        }

                        string n4OfFourBytesIOHex = string.Empty;

                        if (dataHexx.CodecID.ValueHexa == "08")
                        {
                            n4OfFourBytesIOHex = ioElementHex.Substring(index, 2);
                            index = index + 2;
                        }
                        else if (dataHexx.CodecID.ValueHexa == "8E")
                        {
                            n4OfFourBytesIOHex = ioElementHex.Substring(index, 4);
                            index = index + 4;
                        }

                        int n4OfFourBytesIO = HexToDecimal(n4OfFourBytesIOHex);

                        if (n4OfFourBytesIO > 0)
                        {
                            for (int i = 0; i < n4OfFourBytesIO; i++)
                            {
                                if (dataHexx.CodecID.ValueHexa == "08")
                                {
                                    avlDataHexx.N4IOHexKeyVal.Add($"{i}IOId", ioElementHex.Substring(index, 2));
                                    index = index + 2;
                                }
                                else if (dataHexx.CodecID.ValueHexa == "8E")
                                {
                                    avlDataHexx.N4IOHexKeyVal.Add($"{i}IOId", ioElementHex.Substring(index, 4));
                                    index = index + 4;
                                }

                                avlDataHexx.N4IOHexKeyVal.Add($"{i}IOVal", ioElementHex.Substring(index, 8));
                                index = index + 8;
                            }
                        }

                        string n8OfEightBytesIOHex = string.Empty;

                        if (dataHexx.CodecID.ValueHexa == "08")
                        {
                            n8OfEightBytesIOHex = ioElementHex.Substring(index, 2);
                            index = index + 2;
                        }
                        else if (dataHexx.CodecID.ValueHexa == "8E")
                        {
                            n8OfEightBytesIOHex = ioElementHex.Substring(index, 4);
                            index = index + 4;
                        }

                        int n8OfEightBytesIO = HexToDecimal(n8OfEightBytesIOHex);


                        if (n8OfEightBytesIO > 0)
                        {
                            for (int i = 0; i < n8OfEightBytesIO; i++)
                            {
                                if (dataHexx.CodecID.ValueHexa == "08")
                                {
                                    avlDataHexx.N8IOHexKeyVal.Add($"{i}IOId", ioElementHex.Substring(index, 2));
                                    index = index + 2;
                                }
                                else if (dataHexx.CodecID.ValueHexa == "8E")
                                {
                                    avlDataHexx.N8IOHexKeyVal.Add($"{i}IOId", ioElementHex.Substring(index, 4));
                                    index = index + 4;
                                }

                                avlDataHexx.N8IOHexKeyVal.Add($"{i}IOVal", ioElementHex.Substring(index, 16));
                                index = index + 16;
                            }
                        }

                        if (dataHexx.CodecID.ValueHexa == "8E")
                        {
                            string nXOfXBytesIOHex = ioElementHex.Substring(index, 4);

                            long nXOfXBytesIO = HexToDecimal(nXOfXBytesIOHex);

                            index = index + 4;

                            if (nXOfXBytesIO > 0)
                            {
                                for (int i = 0; i < nXOfXBytesIO; i++)
                                {
                                    avlDataHexx.NXIOHexKeyVal.Add($"{i}IOId", ioElementHex.Substring(index, 4));
                                    index = index + 4;

                                    string nxIOHexLengthHex = ioElementHex.Substring(index, 4);

                                    int nxIOHexLength = HexToDecimal(nxIOHexLengthHex);
                                    index = index + 4;

                                    avlDataHexx.NXIOHexKeyVal.Add($"{i}IOVal", ioElementHex.Substring(index, nxIOHexLength * 2));

                                    index = index + nxIOHexLength * 2;
                                }
                            }
                        }

                        avlIndex = avlIndex + index;
                    }

                    dataHexx.AVLRecords.Add(avlDataHexx);
                }

            }

            return dataHexx;
        }

        static List<DeviceFile> GetMessagesFromFiles(string hexaFolderPath)
        {
            List<DeviceFile> retVal = new List<DeviceFile>();
            var txtFiles = Directory.EnumerateFiles(hexaFolderPath, "*.hexa", SearchOption.TopDirectoryOnly);

            foreach (string currentFile in txtFiles)
            {
                StringBuilder fileStringBuilder = new StringBuilder();

                string imei = string.Empty;
                var lines = File.ReadAllLines(currentFile);
                DeviceFile deviceFile = new DeviceFile();
                foreach (string line in lines)
                {
                    var lineSPlitArr = line.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);

                    var message = lineSPlitArr.Last().Trim();

                    if (message.Length == 50)
                    {
                        imei = DecodeImei(message.Replace("-", ""));
                    }
                    else if (message.Length > 100)
                    {
                        if (string.IsNullOrEmpty(imei))
                        {
                            imei = currentFile.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries).First().Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries).Last();
                        }

                        deviceFile.IMEI = imei;
                        deviceFile.Path = currentFile;
                        deviceFile.Messages.Add(new DeviceMessage { LineSplitArr = lineSPlitArr, Message = message });

                    }
                }
                retVal.Add(deviceFile);
            }

            Console.WriteLine("All files read !");
            return retVal;
        }

        static DeviceFile GetMessagesFromFile(string currentFile)
        {
            StringBuilder fileStringBuilder = new StringBuilder();

            string imei = string.Empty;
            var lines = File.ReadAllLines(currentFile);
            DeviceFile deviceFile = new DeviceFile();
            foreach (string line in lines)
            {
                var lineSPlitArr = line.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);

                var message = lineSPlitArr.Last().Trim();

                if (message.Length == 50)
                {
                    imei = DecodeImei(message.Replace("-", ""));
                }
                else if (message.Length > 100)
                {
                    if (string.IsNullOrEmpty(imei))
                    {
                        imei = currentFile.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries).First().Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries).Last();
                    }

                    deviceFile.IMEI = imei;
                    deviceFile.Path = currentFile;
                    deviceFile.Messages.Add(new DeviceMessage { LineSplitArr = lineSPlitArr, Message = message });

                }
            }
            

            Console.WriteLine("All files read !");
            return deviceFile;
        }

        static void ProcessDeviceFile(string path, DeviceFile deviceFile, string type)
        {
            StringBuilder fileStringBuilder = new StringBuilder();

            foreach (var deviceMessage in deviceFile.Messages)
            {
                deviceMessage.Message = deviceMessage.Message.Replace("-", "");

                var data = ParseCodec8MessageHex(deviceFile.IMEI, deviceMessage.Message);

                string timeStampFromLog = $"{deviceMessage.LineSplitArr[0]}:{deviceMessage.LineSplitArr[1]}:{deviceMessage.LineSplitArr[2]}".Trim();

                DateTime dateTime = DateTime.ParseExact(timeStampFromLog, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                string formattedDate = dateTime.ToString("yyyy/MM/dd hh:mm:ss tt", CultureInfo.InvariantCulture);

                StringBuilder sb = new StringBuilder();

                foreach (var avlRecord in data.AVLRecords.OrderBy(a => a.TimeStamp.Value))
                {
                    if (type == "raw")
                    {
                        sb.Append(deviceFile.IMEI).Append(",");
                        sb.Append(avlRecord.TimeStamp.Value.ToString("yyyyMMddHHmmss")).Append(",");
                        sb.Append(avlRecord.Latitude.Value.ToString().Replace(".", "").PadRight(9, '0')).Append(",");
                        sb.Append(avlRecord.Longitude.Value.ToString().Replace(".", "").PadRight(9, '0')).Append(",");
                        sb.Append(avlRecord.Speed.Value).Append(",");
                        sb.Append(avlRecord.Angle.Value).Append(",");
                        sb.Append(avlRecord.Satellite.Value).Append(",");
                        sb.Append(avlRecord.Altitude.Value).Append(",");
                        sb.Append(avlRecord.Priority.Value).Append(",");
                        sb.Append("IOData").Append(",");
                        sb.Append($"IOEventID:{avlRecord.EventIOID.Value}").Append(",");

                        string n1Str = string.Empty;
                        foreach (var item in avlRecord.N1IOHexKeyVal)
                        {
                            if (item.Key.Contains("IOId"))
                            {
                                n1Str += $"{HexToDecimal(item.Value, false)}:";
                            }
                            else if (item.Key.Contains("IOVal"))
                            {
                                n1Str += $"{HexToDecimal(item.Value)},";
                            }
                        }
                        n1Str = n1Str.TrimEnd(',');
                        sb.Append(n1Str).Append(",");

                        string n2Str = string.Empty;
                        foreach (var item in avlRecord.N2IOHexKeyVal)
                        {
                            if (item.Key.Contains("IOId"))
                            {
                                n2Str += $"{HexToDecimal(item.Value, false)}:";
                            }
                            else if (item.Key.Contains("IOVal"))
                            {
                                n2Str += $"{HexToDecimal(item.Value)},";
                            }
                        }
                        n2Str = n2Str.TrimEnd(',');
                        sb.Append(n2Str).Append(",");

                        string n4Str = string.Empty;
                        foreach (var item in avlRecord.N4IOHexKeyVal)
                        {
                            if (item.Key.Contains("IOId"))
                            {
                                n4Str += $"{HexToDecimal(item.Value, false)}:";
                            }
                            else if (item.Key.Contains("IOVal"))
                            {
                                n4Str += $"{HexToDecimal(item.Value)},";
                            }
                        }
                        n4Str = n4Str.TrimEnd(',');
                        sb.Append(n4Str).Append(",");

                        string n8Str = string.Empty;
                        int dec = 0;
                        foreach (var item in avlRecord.N8IOHexKeyVal)
                        {
                            if (item.Key.Contains("IOId"))
                            {
                                dec = HexToDecimal(item.Value, false);
                                n8Str += $"{dec}:";
                            }
                            else if (item.Key.Contains("IOVal"))
                            {
                                if (dec == 78)
                                {
                                    n8Str += $"{item.Value},";
                                }
                                else
                                {
                                    try
                                    {
                                        n8Str += $"{HexToDecimal(item.Value)},";
                                    }
                                    catch (OverflowException ofe)
                                    {
                                        n8Str += $"{item.Value},";
                                    }
                                }
                            }
                        }
                        n8Str = n8Str.TrimEnd(',');
                        sb.Append(n8Str).Append(",");

                        if (data.CodecID.ValueHexa == "8E")
                        {
                            string nXStr = string.Empty;
                            foreach (var item in avlRecord.NXIOHexKeyVal)
                            {
                                if (item.Key.Contains("IOId"))
                                {
                                    nXStr += $"{HexToDecimal(item.Value, false)}:";
                                }
                                else if (item.Key.Contains("IOVal"))
                                {
                                    nXStr += $"{HexToDecimal(item.Value)},";
                                }
                            }
                            nXStr = nXStr.TrimEnd(',');
                            if (!string.IsNullOrEmpty(nXStr))
                            {
                                sb.Append(nXStr).Append(",");
                            }
                        }
                    }
                    else
                    {
                        sb.Append($"IMEI: {deviceFile.IMEI}").Append(", ");

                        string TimeStamp = $"TimeStamp: {avlRecord.TimeStamp.Value.ToString("yyyyMMddHHmmss")}";
                        sb.Append(TimeStamp).Append(", ");

                        string Latitude = $"Latitude: {avlRecord.Latitude.Value.ToString().Replace(".", "").PadRight(9, '0')}";
                        sb.Append(Latitude).Append(", ");

                        string Longitude = $"Longitude: {avlRecord.Longitude.Value.ToString().Replace(".", "").PadRight(9, '0')}";
                        sb.Append(Longitude).Append(", ");

                        string Speed = $"Speed: {avlRecord.Speed.Value}";
                        sb.Append(Speed).Append(", ");

                        string Angle = $"Angle: {avlRecord.Angle.Value}";
                        sb.Append(Angle).Append(", ");

                        string Satellite = $"Satellite: {avlRecord.Satellite.Value}";
                        sb.Append(Satellite).Append(", ");

                        string Altitude = $"Altitude: {avlRecord.Altitude.Value}";
                        sb.Append(Altitude).Append(", ");

                        string Priority = $"Priority: {avlRecord.Priority.Value}";
                        sb.Append(Priority).Append(", ");

                        string TriggeredEvent = "";
                        if (avlRecord.EventIOID.Value == 0 || !IOElementsMap.ContainsKey(avlRecord.EventIOID.Value))
                        {
                            TriggeredEvent = "0";
                        }
                        else
                        {
                            TriggeredEvent = IOElementsMap[avlRecord.EventIOID.Value];
                        }
                        sb.Append($"IOEventID:{TriggeredEvent}").Append(", ");

                        string n1Str = string.Empty;
                        foreach (var item in avlRecord.N1IOHexKeyVal)
                        {
                            if (item.Key.Contains("IOId"))
                            {
                                string eventVal = "";
                                if (string.IsNullOrEmpty(item.Value) || !IOElementsMap.ContainsKey(HexToDecimal(item.Value, false)))
                                {
                                    eventVal = "Unknown";
                                }
                                else
                                {
                                    eventVal = IOElementsMap[HexToDecimal(item.Value, false)];
                                }
                                n1Str += $"{eventVal}:{HexToDecimal(item.Value, false)}: ";
                            }
                            else if (item.Key.Contains("IOVal"))
                            {
                                n1Str += $"{HexToDecimal(item.Value)}, ";
                            }
                        }
                        n1Str = n1Str.TrimEnd(',');
                        sb.Append(n1Str).Append(", ");

                        string n2Str = string.Empty;
                        foreach (var item in avlRecord.N2IOHexKeyVal)
                        {
                            if (item.Key.Contains("IOId"))
                            {
                                string eventVal = "";
                                if (string.IsNullOrEmpty(item.Value) || !IOElementsMap.ContainsKey(HexToDecimal(item.Value, false)))
                                {
                                    eventVal = "Unknown";
                                }
                                else
                                {
                                    eventVal = IOElementsMap[HexToDecimal(item.Value, false)];
                                }
                                n2Str += $"{eventVal}:{HexToDecimal(item.Value, false)}: ";
                            }
                            else if (item.Key.Contains("IOVal"))
                            {
                                n2Str += $"{HexToDecimal(item.Value)}, ";
                            }
                        }
                        n2Str = n2Str.TrimEnd(',');
                        sb.Append(n2Str).Append(", ");

                        string n4Str = string.Empty;
                        foreach (var item in avlRecord.N4IOHexKeyVal)
                        {
                            if (item.Key.Contains("IOId"))
                            {
                                string eventVal = "";
                                if (string.IsNullOrEmpty(item.Value) || !IOElementsMap.ContainsKey(HexToDecimal(item.Value, false)))
                                {
                                    eventVal = "Unknown";
                                }
                                else
                                {
                                    eventVal = IOElementsMap[HexToDecimal(item.Value, false)];
                                }
                                n4Str += $"{eventVal}:{HexToDecimal(item.Value, false)}: ";
                            }
                            else if (item.Key.Contains("IOVal"))
                            {
                                n4Str += $"{HexToDecimal(item.Value)}, ";
                            }
                        }
                        n4Str = n4Str.TrimEnd(',');
                        sb.Append(n4Str).Append(", ");

                        string n8Str = string.Empty;
                        int dec = 0;
                        foreach (var item in avlRecord.N8IOHexKeyVal)
                        {
                            if (item.Key.Contains("IOId"))
                            {
                                dec = HexToDecimal(item.Value, false);

                                string eventVal = "";
                                if (string.IsNullOrEmpty(item.Value) || !IOElementsMap.ContainsKey(dec))
                                {
                                    eventVal = "Unknown";
                                }
                                else
                                {
                                    eventVal = IOElementsMap[dec];
                                }

                                n8Str += $"{eventVal}:{dec}: ";
                            }
                            else if (item.Key.Contains("IOVal"))
                            {
                                if (dec == 78)
                                {
                                    n8Str += $"{item.Value}, ";
                                }
                                else
                                {
                                    try
                                    {
                                        n8Str += $"{HexToDecimal(item.Value)}, ";
                                    }
                                    catch (OverflowException ofe)
                                    {
                                        n8Str += $"{item.Value}, ";
                                    }
                                }
                            }
                        }
                        n8Str = n8Str.TrimEnd(',');
                        sb.Append(n8Str).Append(", ");

                        if (data.CodecID.ValueHexa == "8E")
                        {
                            string nXStr = string.Empty;
                            foreach (var item in avlRecord.NXIOHexKeyVal)
                            {
                                if (item.Key.Contains("IOId"))
                                {
                                    string eventVal = "";
                                    if (string.IsNullOrEmpty(item.Value) || !IOElementsMap.ContainsKey(HexToDecimal(item.Value, false)))
                                    {
                                        eventVal = "Unknown";
                                    }
                                    else
                                    {
                                        eventVal = IOElementsMap[HexToDecimal(item.Value, false)];
                                    }

                                    nXStr += $"{eventVal}:{HexToDecimal(item.Value, false)}: ";
                                }
                                else if (item.Key.Contains("IOVal"))
                                {
                                    nXStr += $"{HexToDecimal(item.Value)}, ";
                                }
                            }
                            nXStr = nXStr.TrimEnd(',');
                            if (!string.IsNullOrEmpty(nXStr))
                            {
                                sb.Append(nXStr).Append(", ");
                            }
                        }


                    }

                    string fileEntry = $"{timeStampFromLog} : {formattedDate} >> Teletonika_FMC130>> {sb.ToString()}\n\n{timeStampFromLog} : ---------------------------------------------";
                    fileStringBuilder.Append(fileEntry).Append("\n\n");

                    sb.Clear();
                }
            }

            string filePath = $@"{path}\{deviceFile.IMEI}";
            System.IO.File.WriteAllText(filePath, $"{fileStringBuilder.ToString()}");
        }
        static async Task GenerateLogsAsync(string path, List<DeviceFile> deviceFiles, string type = "raw")
        {
            var tasks = deviceFiles.Select(deviceFile => Task.Run(() => ProcessDeviceFile(path, deviceFile, type))).ToList();

            await Task.WhenAll(tasks);

            Console.WriteLine($"All files generated - {type}");
        }
        static int HexToDecimal(string hexval, bool signed = true)
        {
            int decimalValue = 0;

            if (!signed)
            {
                decimalValue = int.Parse(hexval, System.Globalization.NumberStyles.HexNumber);
            }
            else
            {
                decimalValue = int.Parse(hexval, System.Globalization.NumberStyles.HexNumber);
                // Determine the bit length based on the length of the hex string
                int bitLength = hexval.Length * 4;

                // Calculate the maximum value for the given bit length
                long maxValue = (1L << (bitLength - 1)) - 1; // Max positive value

                // Check if the number is negative in two's complement
                if (decimalValue > maxValue)
                {
                    decimalValue -= (int)(1L << bitLength);
                }
            }

            return decimalValue;
        }

        static DateTime HexToDateTime(string hexTimestamp)
        {
            if (hexTimestamp.Length != 16)
            {
                throw new ArgumentException("Hexadecimal timestamp must be 16 characters long (8 bytes).");
            }

            byte[] timestampBytes = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                timestampBytes[i] = Convert.ToByte(hexTimestamp.Substring(i * 2, 2), 16);
            }

            Array.Reverse(timestampBytes);

            long timestampMilliseconds = BitConverter.ToInt64(timestampBytes, 0);

            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return epoch.AddMilliseconds(timestampMilliseconds);
        }

        static decimal CalculateCoordinate(string hexValue)
        {
            int intValue = HexToDecimal(hexValue);

            if ((intValue & 0x80000000) != 0)
            {
                intValue = (int)(intValue - 0x100000000);
            }

            const decimal precision = 10000000m;
            decimal coordinate = intValue / precision;

            var res = coordinate;//Math.Round(coordinate, 7);

            return res;
        }
    }
}
