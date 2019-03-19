#include <Servo.h>
#include <ESP8266WiFi.h>
#include <ESP8266HTTPClient.h>

const int MAX_SERVO = 130;
const int MIN_SERVO = 0;

const char WIFI_NAME[] = "";
const char WIFI_PASSWORD[] = "";

const char WEB_URL[] = "/Home/LaunchDart"; 

Servo servo;
HTTPClient http; 

void setup() 
{
    // Setup the servo and move to starting position
    servo.attach(2); //D4
    servo.write(MAX_SERVO);
    delay(2000);

    // Setup the wifi
    Serial.begin(115200);
    Serial.println();

    WiFi.begin(WIFI_NAME, WIFI_PASSWORD);

    Serial.print("Connecting");
    while (WiFi.status() != WL_CONNECTED)
    {
        delay(500);
        Serial.print(".");
    }
    Serial.println();

    Serial.print("Connected, IP address: ");
    Serial.println(WiFi.localIP());
}

void loop() 
{
    Serial.println("Connecting to remote url...");
    http.begin(WEB_URL);
    int httpCode = http.GET();
    String payload = http.getString();

    Serial.print("Http Code: ");
    Serial.println(httpCode);
    Serial.print("Payload: ");
    Serial.println(payload);

    if (httpCode == 200 && payload == "f")
    {
        Serial.println("Successful request, shooting dart");
        
        servo.write(MIN_SERVO);
        delay(1000);
        servo.write(MAX_SERVO);
    }

    // Sleep for 10 seconds before trying again
    delay(10000);
}