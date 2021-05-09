# inventory


## Installation
Damit Inventory richtig funktioniert, wird eine MySql Datenbank benötigt.
Führe dann das create.inventory.sql auf der Datenbank aus.
Damit werden die benötigten Tabellen angelegt und bereits mit Beispieldaten gefüllt.

Nun noch die Datenbankverbindung in der appsettings.json anpassen.

````
"ConnectionStrings": {
    "Inventory" : "Database=deineDatenbank;Data Source=deinMySQLServer;User Id=deinDatenbankBenutzer;Password=PasswortfürdenNutzer"
  }
````
