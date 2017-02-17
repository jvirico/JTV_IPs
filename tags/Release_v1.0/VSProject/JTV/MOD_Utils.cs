using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;


namespace JTV
{
    class Utils
    {

        public bool PingIP(string IP)
        {
            bool result = false;
            try
            {
                Ping ping = new Ping();
                PingReply pingReply = ping.Send(IP);
                if (pingReply.Status == IPStatus.Success)
                    result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }



        public string GetConfigItem(string sFileConfig_URL, string sSettingName)
        {
            StreamReader S = new StreamReader(sFileConfig_URL);
            string Result = "";
            bool bFinded = false;

            try
            {
                do{
                    string Line = S.ReadLine();
                    if (Line.ToLower().StartsWith(sSettingName.ToLower() + ":")){
                        if (Line.Length > sSettingName.Length + 2){
                            Result = Line.Substring(sSettingName.Length + 2);
                            bFinded = true;
                            break;
                        }
                        else
                        {
                            Result = "";
                        }
                    }
                }while(S.Peek() != -1 && !bFinded);

                return Result;
            }
            catch
            {
                return "";
            }


        }

    }
}
