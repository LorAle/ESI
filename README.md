## ESI

Repo für das ESI-Project

## Description
Ich empfehle euch Visual Studio installieren. Die Community-Version ist kostenfrei.
Downloadlink: 
https://visualstudio.microsoft.com/de/downloads/?rr=https%3A%2F%2Fwww.google.com%2F

Bei der Installation unter "Web und Cloud" ASP.NET und Webentwicklung hinzufügen.
Nun müsstet ihr noch zwei Dinge installieren.
1. "MySQL for Visual Studio" v2.0.5 CTP - https://dev.mysql.com/downloads/file/?id=470092
2.  "Connector/NET" v6.9.10 - https://dev.mysql.com/downloads/file/?id=474110

MySQL ist leider nicht im Standardpaket von Visual Studio enthalten.

Sobald ihr das Projekt aus Git heruntergeladen habt und mit Visual Studio geöffnet habt, solltet ihr die Solution
mit den fünf Teilprojekten sehen. Für jede Gruppe eine ClassLibrary. Den ESI_Context könnt ihr ignorieren.
Innerhalb des Projektes ESI_Web_Api findet ihr dann in dem Ordner "Controller" die Schnittstellen für die einzelnen Gruppen,

Sobald dies geschehen ist könnt ihr versuchen das Projekt zu starten.
Unter der Url localhost..../swagger/ui/index findet ihr eine benutzerfreundliche Oberflache für die Rest-Api.
Hier könnt ihr dann testen ob alles funktioniert. 
Bspw. PROD>GET
Bei Auführung sollte ein JSON-Array mit drei Objekten zurückgeliefert werden.

Hiernach sollte es nun hoffentlich funktionieren.
Alles Weitere dann später.

