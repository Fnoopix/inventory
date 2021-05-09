using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace inventory.Models
{
    public class InventoryContext
    {
        #region ---- DATABASE CONNECTION -------------------------------------------------------------------------------
        private string ConnectionString { get; set; }
        public InventoryContext(string connectionString)    
        {    
            this.ConnectionString = connectionString;    
        }
        private MySqlConnection GetConnection()    
        {    
            return new MySqlConnection(ConnectionString);    
        } 
        #endregion
        #region ----    GET METHODS ------------------------------------------------------------------------------------
        public List<Inventory.Device> GetDeviceList()
        {
            List<Inventory.Device> devices = new List<Inventory.Device>();
            using (MySqlConnection connection = GetConnection() )
            {
                connection.Open();
                MySqlCommand sqlCommand = new MySqlCommand("SELECT id, name, deviceTypeId, failsafe, tempMin, tempMax, installationPosition, insertInto19InchCabinet, motionEnable, siplusCatalog, simaticCatalog, rotationAxisNumber, positionAxisNumber, terminalElement, advancedEnvironmentalConditions FROM devices;", connection);
                using (var reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        devices.Add(new Inventory.Device()
                        {
                            id = reader.GetString("id"),
                            name = reader.GetString("name"),
                            deviceTypeId = reader["deviceTypeId"].Equals(DBNull.Value) ? "" : reader.GetString("deviceTypeId"),
                            failsafe = reader.GetBoolean("failsafe"),
                            tempMin = reader.GetDouble("tempMin"),
                            tempMax = reader.GetDouble("tempMax"),
                            installationPosition = reader["installationPosition"].Equals(DBNull.Value) ? "" : reader.GetString("installationPosition"),
                            insertInto19InchCabinet = reader.GetBoolean("insertInto19InchCabinet"),
                            motionEnable = reader.GetBoolean("motionEnable"),
                            siplusCatalog = reader.GetBoolean("siplusCatalog"),
                            simaticCatalog = reader.GetBoolean("simaticCatalog"),
                            rotationAxisNumber = reader.GetDouble("rotationAxisNumber"),
                            positionAxisNumber = reader.GetDouble("positionAxisNumber"),
                            terminalElement = reader.GetBoolean("terminalElement"),
                            advancedEnvironmentalConditions = reader.GetBoolean("advancedEnvironmentalConditions"),
                        });
                    }
                }
            }
            return devices;
        } 
        #endregion
        #region ----    SET METHODS ------------------------------------------------------------------------------------
        public void SetDevice(Inventory.Device device)
        {
            using ( MySqlConnection connection = GetConnection())
            {
                connection.Open();
                MySqlCommand sqlCommand = new MySqlCommand("INSERT INTO devices (id, name, deviceTypeId, failsafe, tempMin, tempMax, installationPosition, insertInto19InchCabinet, motionEnable, siplusCatalog, simaticCatalog, rotationAxisNumber, positionAxisNumber, terminalElement, advancedEnvironmentalConditions)"
                                                           + "    VALUES(@id, @name, @deviceTypeId, @failsafe, @tempMin, @tempMax, @installationPosition, @insertInto19InchCabinet, @motionEnable, @siplusCatalog, @simaticCatalog, @rotationAxisNumber, @positionAxisNumber, @terminalElement, @advancedEnvironmentalConditions)"
                                                           + "ON DUPLICATE KEY UPDATE deviceTypeId = @deviceTypeId,"
                                                           + "                        failsafe = @failsafe,"
                                                           + "                        tempMin = @tempMin,"
                                                           + "                        tempMax = @tempMax,"
                                                           + "                        installationPosition = @installationPosition,"
                                                           + "                        insertInto19InchCabinet = @insertInto19InchCabinet,"
                                                           + "                        motionEnable = @motionEnable,"
                                                           + "                        siplusCatalog = @siplusCatalog,"
                                                           + "                        simaticCatalog = @simaticCatalog,"
                                                           + "                        rotationAxisNumber = @rotationAxisNumber,"
                                                           + "                        positionAxisNumber = @positionAxisNumber,"
                                                           + "                        terminalElement = @terminalElement,"
                                                           + "                        advancedEnvironmentalConditions = @advancedEnvironmentalConditions;", connection);
                sqlCommand.Parameters.AddWithValue("@id", device.id);
                sqlCommand.Parameters.AddWithValue("@name", device.name);
                sqlCommand.Parameters.AddWithValue("@deviceTypeId", device.deviceTypeId);
                sqlCommand.Parameters.AddWithValue("@failsafe", device.failsafe);
                sqlCommand.Parameters.AddWithValue("@tempMin", device.tempMin);
                sqlCommand.Parameters.AddWithValue("@tempMax", device.tempMax);
                sqlCommand.Parameters.AddWithValue("@installationPosition", device.installationPosition);
                sqlCommand.Parameters.AddWithValue("@insertInto19InchCabinet", device.insertInto19InchCabinet);
                sqlCommand.Parameters.AddWithValue("@motionEnable", device.motionEnable);
                sqlCommand.Parameters.AddWithValue("@siplusCatalog", device.siplusCatalog);
                sqlCommand.Parameters.AddWithValue("@simaticCatalog", device.simaticCatalog);
                sqlCommand.Parameters.AddWithValue("@rotationAxisNumber", device.rotationAxisNumber);
                sqlCommand.Parameters.AddWithValue("@positionAxisNumber", device.positionAxisNumber);
                sqlCommand.Parameters.AddWithValue("@terminalElement", device.terminalElement);
                sqlCommand.Parameters.AddWithValue("@advancedEnvironmentalConditions", device.advancedEnvironmentalConditions);
                sqlCommand.Prepare();
                sqlCommand.ExecuteNonQuery();
            }
        }
        #endregion
        #region ----    DELETE METHODS  --------------------------------------------------------------------------------
        public void DeleteDevice(Inventory.Device device)
        {
            using ( MySqlConnection connection = GetConnection())
            {
                connection.Open();
                MySqlCommand sqlCommand = new MySqlCommand("DELETE FROM devices WHERE devices.id = @id AND devices.name = @name;", connection);
                sqlCommand.Parameters.AddWithValue("@id", device.id);
                sqlCommand.Parameters.AddWithValue("@name", device.name);
                sqlCommand.Prepare();
                sqlCommand.ExecuteNonQuery();
            }
        }
        #endregion
    }
}