create table if not exists devices
(
    id                              varchar(128)         not null,
    name                            varchar(64)          not null,
    deviceTypeId                    varchar(32)          null,
    failsafe                        tinyint(1) default 0 not null,
    tempMin                         double     default 0 not null,
    tempMax                         double     default 0 not null,
    installationPosition            varchar(64)          null,
    insertInto19InchCabinet         tinyint(1) default 0 not null,
    motionEnable                    tinyint(1) default 0 not null,
    siplusCatalog                   tinyint(1) default 0 not null,
    simaticCatalog                  tinyint(1) default 0 not null,
    rotationAxisNumber              double     default 0 not null,
    positionAxisNumber              double     default 0 not null,
    terminalElement                 tinyint(1) default 0 not null,
    advancedEnvironmentalConditions tinyint(1) default 0 not null,
    primary key (id, name)
);

INSERT INTO inventory.devices (id, name, deviceTypeId, failsafe, tempMin, tempMax, installationPosition, insertInto19InchCabinet, motionEnable, siplusCatalog, simaticCatalog, rotationAxisNumber, positionAxisNumber, advancedEnvironmentalConditions) VALUES ('4fdghjk32gk19hysdb197845', 'S7-7357', '7Test Device', 1, 10, 120, 'vertical', 0, 1, 1, 0, 84.4578, 21.6897, 0);
INSERT INTO inventory.devices (id, name, deviceTypeId, failsafe, tempMin, tempMax, installationPosition, insertInto19InchCabinet, motionEnable, siplusCatalog, simaticCatalog, rotationAxisNumber, positionAxisNumber, advancedEnvironmentalConditions) VALUES ('9anngio34t098ztouinbs', 'S5-7357', '5Test Device', 0, -15, 46, 'diagonal', 1, 0, 0, 0, 45.6215, 76.4556, 1);