# DESCRIPTION
Utility that monitors a list of IP addresses and warns with a Beep in case some IP stops responding in the established time window.
   
# PLATFORM AND REQUIREMENTS
   - Windows
   - Visual Studio
   - .NET Framework 4.5


# CONFIG (JTV_IPs.config)
   
### Where do we save results

JTV_Log_FullURL: C:\Users\javier.rico\Desktop\Logs\Pruebas\JTV_UPs.log

### What do we watch

JTV_IPs: 10.14.20.60, 10.14.20.34   
JTV_WarnOn: 10.14.20.60

### How often it is executed

JTV_Ping_Timing: 10   
JTV_Inmortal: true
