#JTV_IPs
  
###Descripción
Versión de JTV que monitoriza una lista de IPs registrando en un log si los equipos están accesibles o no.
Los equipos indicados en la lista 'JTV_WarnOn' avisan con un Beep en caso de dejar de estar accesibles.

'''
#CONFIG

#Where do we save results
JTV_Log_FullURL: C:\Users\javier.rico\Desktop\Logs\Pruebas\JTV_UPs.log

#What do we watch
JTV_IPs: as-sp3d-app-01, as-sp3d-app-02, 10.14.20.60, 10.14.20.34, AS-SPMAT-BD-01, AS-SSO-BD-DEV, JAVIERRICO2W7
JTV_WarnOn: as-sp3d-app-01, as-sp3d-app-02, 10.14.20.60, 10.14.20.34, AS-SPMAT-BD-01, AS-SSO-BD-DEV, JAVIERRICO2W7

#How often it is executed
JTV_Ping_Timing: 10
JTV_Inmortal: true
'''