using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace JTV
{
    class Program
    {
        static void Main(string[] args)
        {

            //Leemos SaveLog_URL de primer parámetro de entrada
            string sConfig_URL = "";
            string sSaveLog_URL = "";
            Utils oJTV_Utils = new Utils();

            string sIP_List;
            string sPing_Timing_In_Secs = "3600";
            string sWarnOn_List = "";
            string sInmortal = "true";
            List<string> colIPs = new List<string>();
            List<string> colWarnOnIPs = new List<string>();

            string sMSG = "";

            //sConfig_URL = System.IO.Directory.GetCurrentDirectory() + "\\JTV_IPs.config";
            sConfig_URL = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\JTV_IPs.config";

            sSaveLog_URL = oJTV_Utils.GetConfigItem(sConfig_URL, "JTV_Log_FullURL");
            sIP_List = oJTV_Utils.GetConfigItem(sConfig_URL, "JTV_IPs");
            sPing_Timing_In_Secs = oJTV_Utils.GetConfigItem(sConfig_URL, "JTV_Ping_Timing");
            sWarnOn_List = oJTV_Utils.GetConfigItem(sConfig_URL, "JTV_WarnOn");
            sInmortal = oJTV_Utils.GetConfigItem(sConfig_URL, "JTV_Inmortal").ToLower();

            sIP_List = sIP_List.Replace(" ", "");
            colIPs = sIP_List.Split(',').ToList();

            sWarnOn_List = sWarnOn_List.Replace(" ", "");
            colWarnOnIPs = sWarnOn_List.Split(',').ToList();


            //if (args.Length == 1)
            //{
                //sSaveLog_URL = args[0];

                do
                {
                    //sMSG = "--------------------" + Environment.NewLine + DateTime.Now;
                    //sMSG = sMSG + Environment.NewLine + "--------------------" + Environment.NewLine;

                    foreach (string IP in colIPs)
                    {
                        if (oJTV_Utils.PingIP(IP))
                        {
                            sMSG = sMSG + Environment.NewLine + DateTime.Now + "; " + IP + "; UP" + Environment.NewLine;
                            Console.WriteLine(Environment.NewLine + DateTime.Now + "; " + IP + "; UP");
                        }
                        else
                        {
                            sMSG = sMSG + Environment.NewLine + DateTime.Now + "; " + IP + "; DOWN" + Environment.NewLine;
                            Console.WriteLine(Environment.NewLine + DateTime.Now + "; " + IP + "; DOWN");
                            if ((IP != "") && colWarnOnIPs.Exists(e => e == IP))
                            {
                                Console.Beep(5000, 1000);
                            }
                        }
                    }
                    //Abrimos Log
                    System.IO.StreamWriter oLog = new System.IO.StreamWriter(sSaveLog_URL,true);
                    //Escribimos en log
                    oLog.WriteLine(sMSG);
                    //Liberamos recurso
                    oLog.Close();

                    //Esperamos
                    if (sInmortal == "true") System.Threading.Thread.Sleep((Convert.ToInt32(sPing_Timing_In_Secs)) * 1000);
                } while (sInmortal == "true");

            }
        }


    //}
}
