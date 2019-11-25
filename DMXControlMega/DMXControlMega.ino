#include <DMXSerial.h>
#include <Arduino.h>

String recvString;
bool humanMode = false;
int currentChannel = 1;
int currentValue = 0;

 void setup()
 {
    // Init serial DMX controller    
    DMXSerial.init(DMXController);
    // Start serial communication to pc
    Serial.begin(115200);
    // reserve space for received data
    recvString.reserve(50);
 }


 void loop()
 {


 }

 void serialEvent()
 {
     while(Serial.available())
     {
         char inChar = (char)Serial.read();
         if(inChar == '\n')
         {
             parseCmd();
         }
         else
         {     
             recvString += inChar;
         }         
     }
 }


 void parseCmd()
 {
     // Check humanModeCMD
     if(recvString == "human")
     {
         humanMode = !humanMode;
         if(humanMode)
            Serial.println("HumanMode active!");
     }
     // Special parser for humanMode
     else if((humanMode) && (recvString.length() == 4))
     {
         if(recvString[0] == 'c')
         {
             int tmp = recvString.substring(1).toInt();
             if((tmp > 0)&&(tmp < 512))
             {
                 currentChannel = tmp;
                 Serial.print("Channel::");
                 Serial.println(currentChannel);
             }
             else
             {
                 Serial.println("Channel::Rejected");
             }
             
         }
         else if(recvString[0] == 'v')
         {
             int tmp = recvString.substring(1).toInt();
             if((tmp < 256)&&(tmp >= 0))
             {
                currentValue = tmp;
                Serial.print("Value::");
                Serial.println(currentValue);
                DMXSerial.write(currentChannel, currentValue);
             }
             else
             {
                 Serial.println("Value::Rejected");
             }
             
         }
     }
     // Help
     else if((humanMode) && ((recvString == "?")||(recvString == "help")))
     {
         Serial.println("Use the following commands:");
         Serial.println("cXXX to select a DMX channel from 1 to 511");
         Serial.println("vXXX to set the value of the currently selected channel (default channel is 1)");
         Serial.println("rs to reset all channels to 0");
         Serial.println("You can also directly set a channel by writing: CCCVVV where CCC is the channel and VVV the value");
         Serial.println("The parser will check for value overflow");
     }
     // Command has to be exactly 6 characters
     else if(recvString.length() == 6)
     {
        // First 3 chars are channel, last 3 chars are value
        int channel = recvString.substring(0,3).toInt();
        int value = recvString.substring(3).toInt();
        // Sanity Check
        if((channel >= 512)||(value >= 256)||(channel < 1)||(value < 0))
        {
            if(humanMode)
            {
                Serial.println("Parser::ValueOverflow");
            }
        }
        else
        {
            if(humanMode)
            {
                Serial.print("Parser::Channel::");
                Serial.print(channel);
                Serial.print("|Value::");
                Serial.println(value);
            }
            DMXSerial.write(channel, (uint8_t)value);
        }
        
     }
     // Special functions are 2 characters
     else if(recvString.length() == 2)
     {
         if (recvString == "rs")
         {
             resetUniverse();
         }
         
     }
    // clear recvString
    recvString = "";
 }

// DMX Commands
void resetUniverse()
{
    if(humanMode)
    {
        Serial.println("ResetUniverse");
    }

    for(int i = 1; i < 512; i++)
    {
        DMXSerial.write(i, 0);
    }
}
