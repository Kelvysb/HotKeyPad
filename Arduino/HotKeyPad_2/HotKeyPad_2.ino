#include <EEPROM.h>
#include <Keyboard.h>

const String VER = "HOTKEYPAD;V2.0";
const int BLOCK_SIZE = 85;
const int DEFAULT_DELAY = 10;
const int NUM_OFFSET = 48;
const int CFALSE = 48;
const int CTRUE = 49;
const int CTRL = 128;
const int ALT = 130;
const int SHIFT = 129;
const int GUI = 131;
const int NUL = 0;
const int ACK = 65;
const int READ = 82;
const int SET = 83;
const int CLEAR = 67;
const int VIB = A1;

const int BUTTON_1 = 15;
const int BUTTON_2 = 14;
const int BUTTON_3 = 16;
const int BUTTON_4 = 10;
const int BUTTON_5 = 9;
const int BUTTON_6 = 8;
const int BUTTON_7 = 7;
const int BUTTON_8 = 6;
const int BUTTON_9 = 5;
const int BUTTON_10 = 4;
const int BUTTON_11 = 3;
const int BUTTON_12 = 2;

int holdKey = 0;
bool buttonDown = false;

void setup() { 
  Serial.begin(9600);    
  pinMode(BUTTON_1, INPUT);
  pinMode(BUTTON_2, INPUT);
  pinMode(BUTTON_3, INPUT);
  pinMode(BUTTON_4, INPUT);
  pinMode(BUTTON_5, INPUT);
  pinMode(BUTTON_6, INPUT);
  pinMode(BUTTON_7, INPUT);
  pinMode(BUTTON_8, INPUT);
  pinMode(BUTTON_9, INPUT);
  pinMode(BUTTON_10, INPUT);
  pinMode(BUTTON_11, INPUT);
  pinMode(BUTTON_12, INPUT);
  digitalWrite(BUTTON_1, HIGH);
  digitalWrite(BUTTON_2, HIGH);
  digitalWrite(BUTTON_3, HIGH);
  digitalWrite(BUTTON_4, HIGH);
  digitalWrite(BUTTON_5, HIGH);
  digitalWrite(BUTTON_6, HIGH);
  digitalWrite(BUTTON_7, HIGH);
  digitalWrite(BUTTON_8, HIGH);
  digitalWrite(BUTTON_9, HIGH);
  digitalWrite(BUTTON_10, HIGH);
  digitalWrite(BUTTON_11, HIGH);
  digitalWrite(BUTTON_12, HIGH);
}

void loop() {

  char serialCommand[BLOCK_SIZE+1];
  
  if (Serial.available() > 0) 
  {    
    Serial.readBytes(serialCommand, BLOCK_SIZE+1);
    if(serialCommand[0] == ACK)
    {
      Serial.println(VER);
    }
    if(serialCommand[0] == READ)
    {
      readAllCommands();
    }
    if(serialCommand[0] == SET)
    {
      setCommand(serialCommand);
    }
    if(serialCommand[0] == CLEAR)
    {
      clearCommands();
    }
  }
      
  int currentKey = readButton();
  
  if(currentKey != 0 && holdKey == 0)
  {    
    holdKey = currentKey;
    Serial.print("D:");
    Serial.println(currentKey);
    Keyboard.begin();
    execCommand(currentKey-1);
    analogWrite(VIB, 512);
    delay(100);
    analogWrite(VIB, 0);
  } else if(currentKey == 0 && holdKey != 0)
  {    
    Keyboard.releaseAll();   
    Keyboard.end();
    Serial.print("U:");
    Serial.println(holdKey);    
    holdKey = 0;
  }
}

void execCommand(int key)
{
  char command[BLOCK_SIZE];
  readCommand(command, key);
  
  bool sequenceMode = command[0] == CTRUE;
  int pressTime = (command[1] - NUM_OFFSET) * 100;
  int betweenTime = (command[2] - NUM_OFFSET) * 100;
  bool ctrl = command[3] == CTRUE;
  bool alt = command[4] == CTRUE;
  bool shift = command[5] == CTRUE;
  bool gui = command[6] == CTRUE;

  if(pressTime == 0)
  {
    pressTime = DEFAULT_DELAY;
  }

  if(betweenTime == 0)
  {
    betweenTime = DEFAULT_DELAY;
  }

  if(ctrl)
  {
    Keyboard.press(CTRL);  
  }
  if(alt)
  {
    Keyboard.press(ALT);  
  }
  if(shift)
  {
    Keyboard.press(SHIFT);  
  }
  if(gui)
  {
    Keyboard.press(GUI);  
  }

  for(int i = 7; i < BLOCK_SIZE; i++)
  {
    if(command[i] == NUL)
    {
      break;
    }
    if(!sequenceMode)
    {      
      Keyboard.press(command[i]);
    }else
    {      
      Keyboard.press(command[i]);
      delay(pressTime);
      Keyboard.release(command[i]);
      delay(betweenTime);
    }    
  }   
}

void readCommand(char (& command)[BLOCK_SIZE], int key)
{
  int pos = key * BLOCK_SIZE;
  int index = 0;
  
  for(int i = pos; i < pos + BLOCK_SIZE; i++)
  {
     command[index] = EEPROM.read(i);
     index++;
  }
}

void setCommand(char serialCommand[BLOCK_SIZE])
{  
  if(validate(serialCommand))
  {
    int key = serialCommand[1] - NUM_OFFSET;  
    int pos = key * BLOCK_SIZE;    
    bool fill = false;
    int index = 2;
    for(int i = pos; i < pos + BLOCK_SIZE; i++)
    {              
      if(!fill){
        fill = serialCommand[index] == NUL;
        EEPROM.write(i, serialCommand[index]);
        index++;       
      }else{      
        EEPROM.write(i, 0);   
      }     
    }
    Serial.println("OK");
    Serial.println("POS-" + String(pos));
  }else
  {
    Serial.println("FAIL");
  }  
}

bool validate(char serialCommand[BLOCK_SIZE])
{  
  if(serialCommand[1] - NUM_OFFSET < 0 || serialCommand[1] - NUM_OFFSET > 11)
  {
    Serial.println("ERR1");
    return false;  
  }
  if(serialCommand[2] != CTRUE && serialCommand[2] != CFALSE)
  {
    Serial.println("ERR2");
    return false;  
  }
  if(serialCommand[3] - NUM_OFFSET < 0 || serialCommand[3] - NUM_OFFSET > 9)
  {
    Serial.println("ERR3");
    return false;  
  }
  if(serialCommand[4] - NUM_OFFSET < 0 || serialCommand[4] - NUM_OFFSET > 9)
  {
    Serial.println("ERR4");
    return false;  
  }
  for(int i = 5; i <= 7; i++ )
  {
    if(serialCommand[i] != CTRUE && serialCommand[i] != CFALSE)
    {     
      Serial.println("ERR5X");
      return false;
    }
  }  
  return true;
}

void readAllCommands()
{
  char result[BLOCK_SIZE];
  int com = 0;
  for(int i = 0; i < (BLOCK_SIZE * 12); i = i + BLOCK_SIZE)
  {
    Serial.print("C:");
    Serial.print(com);
    Serial.print(":");
    for(int index = i; index < i + BLOCK_SIZE; index++)
    {
      result[i] =  EEPROM.read(index);
      Serial.print(result[i]);
    }
    Serial.println("");
    com++;
  } 
}

void clearCommands()
{
  for(int i = 0; i < EEPROM.length(); i++)
  {  
    EEPROM.write(i, 0);
  }
  Serial.println("OK");
}

int readButton(){
  int result = 0;
  if(!digitalRead(BUTTON_1)){
    result = 1;
  }
  if(!digitalRead(BUTTON_2)){
    result = 2;
  }
  if(!digitalRead(BUTTON_3)){
    result = 3;
  }
  if(!digitalRead(BUTTON_4)){
    result = 4;
  }
  if(!digitalRead(BUTTON_5)){
    result = 5;
  }
  if(!digitalRead(BUTTON_6)){
    result = 6;
  }
  if(!digitalRead(BUTTON_7)){
    result = 7;
  }
  if(!digitalRead(BUTTON_8)){
    result = 8;
  }
  if(!digitalRead(BUTTON_9)){
    result = 9;
  }
  if(!digitalRead(BUTTON_10)){
    result = 10;
  }
  if(!digitalRead(BUTTON_11)){
    result = 11;
  }  
  if(!digitalRead(BUTTON_12)){
    result = 12;
  }      
  return result;
}
