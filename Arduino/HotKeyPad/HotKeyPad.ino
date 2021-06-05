#include <EEPROM.h>
#include <Keyboard.h>

const String VER = "HOTKEYPAD;V1.0";
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
int holdKey = 0;

void setup() { 
  Serial.begin(9600);    
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
  }else
  {
    Serial.println("FAIL");
  }  
}

bool validate(char serialCommand[BLOCK_SIZE])
{  
  if(serialCommand[1] - NUM_OFFSET < 0 || serialCommand[1] - NUM_OFFSET > 11)
  {
    return false;  
  }
  if(serialCommand[2] != CTRUE && serialCommand[2] != CFALSE)
  {
    return false;  
  }
  if(serialCommand[3] - NUM_OFFSET < 0 || serialCommand[3] - NUM_OFFSET > 9)
  {
    return false;  
  }
  if(serialCommand[4] - NUM_OFFSET < 0 || serialCommand[4] - NUM_OFFSET > 9)
  {
    return false;  
  }
  for(int i = 5; i <= 7; i++ )
  {
    if(serialCommand[i] != CTRUE && serialCommand[i] != CFALSE)
    {     
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
  int keyValue = analogRead(A0);  
  if(keyValue >= 1014){
    return 1;
  }
  if(keyValue >= 921 && keyValue <= 941){
    return 2;
  }
  if(keyValue >= 844 && keyValue <= 864){
    return 3;
  }
  if(keyValue >= 775 && keyValue <= 795){
    return 4;
  }
  if(keyValue >= 720 && keyValue <= 740){
    return 5;
  }
  if(keyValue >= 671 && keyValue <= 691){
    return 6;
  }
  if(keyValue >= 627 && keyValue <= 647){
    return 7;
  }
  if(keyValue >= 590 && keyValue <= 610){
    return 8;
  }
  if(keyValue >= 557 && keyValue <= 577){
    return 9;
  }
  if(keyValue >= 526 && keyValue <= 546){
    return 10;
  }
  if(keyValue >= 500 && keyValue <= 520){
    return 11;
  }  
  if(keyValue >= 476 && keyValue <= 496){
    return 12;
  }    
  return 0; 
}
