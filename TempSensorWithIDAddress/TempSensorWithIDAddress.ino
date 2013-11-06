#include <OneWire.h>
#include <DallasTemperature.h>
#define ONE_WIRE_BUS 10
OneWire oneWire(ONE_WIRE_BUS);
 int x= 0;

DallasTemperature sensors(&oneWire);
DeviceAddress insideThermometer;

void setup(void)
{
  Serial.begin(9600);

  sensors.begin(); 
  
  sensors.getAddress(insideThermometer, 0);
  //printAddress(insideThermometer);
  //Serial.println();
}

void printAddress(DeviceAddress deviceAddress)
{
  for (uint8_t i = 0; i < 8; i++)
  {
    if (deviceAddress[i] < 16) Serial.print("0");
    Serial.print(deviceAddress[i], HEX);
  }
}

void loop(void)
{ 
  //Serial.print("C Degree...");
  sensors.requestTemperatures(); 
  //Serial.println("DONE");
  //Serial.print("Temperature for Server room is: ");
  printAddress(insideThermometer);
  Serial.write ("_Temp_");
  Serial.print(sensors.getTempCByIndex(0)); 
  Serial.println();
  delay(2000);
}
