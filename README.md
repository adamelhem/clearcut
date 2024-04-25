# clearcut

Home test clear cut

1.	This is part of the code in a hardware device:
/// Definitions :

public ConcurrentDictionary<string, float data> TemeratureData;
		private readonly AutoResetEvent _autoResetEventTempData = new AutoResetEvent(false);
		private HardwareConnection _c3poRt = new HardwareConnection();
	
// first function	
public CallResult<double> Read(string sensorId)
        {
            
            double data = -999.99;
            
            if (TemeratureData.IsEmpty)
            {
                 _autoResetEventTempData.Reset();
                _c3poRt.GetTemperature(); // calling hardware function. 
                
                if (!_autoResetEventTempData.WaitOne(5000)
                {
                    HardwareLog.Log(DateTime.Now, LogType.Info,
                        $"NewTempSensor : GetTemperatures(string {sensorId}) no response exit on time out {GetmSecTime2Wait()}");
                    return CallResult<double>.Error(ErrorCodeEnum.C3poNoResponceRecived,
                        $"GetTemperatures(string {sensorId}) no value check enable state");
                }
                
            }

            var realVal = 0;
            if (TemeratureData.TryGetValue(sensorId, out realVal))
            {
                if (CheckIfErrorData(realVal))
                {
                    return CallResult<double>.Error(ErrorCodeEnum.C3poResponceError,
                        $"GetTemperatures(string {sensorId}) ErrorValue");
                }
                data = CalculateTempMag(realVal);
            }
            else
                return CallResult<double>.Error(ErrorCodeEnum.C3poNoResponceRecived,
                    $"GetTemperatures(string {sensorId}) no value check enable state");

            return data;
        }

// second  function
 public virtual bool prepare4NextTemperatureRead()
        {
            if (TemeratureData != null)
                TemeratureData.Clear();
            else
                TemeratureData = new ConcurrentDictionary<string, float data>();
			return true;
        }
	
The call _c3poRt.GetTemperature() connects to an real hardware device and fills the TemeratureData with values and when done set the auto reset event 

•	The following command are called from the main service :
o	prepare4NextTemperatureRead()
o	Read(“clear”)
o	Read (“Cut”);
o	prepare4NextTemperatureRead()
o	Read(“clearcut”)
a.	Explain what happens in the code when the command are called
b.	Why do you think that  ConcurrentDictionary was selected to be used
c.	
2.	In the attached zip TestLines.7z is a csv file with 3 types x,y,touse for example a line can be 7,7,false or 5,5,true
 
a.	Write a WPF MvvM application in .net framework 4.7 that opens the csv file and for all the values that the touse value is true shows the max in x,y the average in x,y the sun in x,y and the min in x,y in the WPF gui

b.	Extra points for reading the zip file directly

c.	Extra points if the GUI does not hang when reading the data

d.	Extra point for loading the file from the GUI by browse button

e.	Extra point for readably code 

f.	Extra point for compiling in debug and release  as any cpu

The answer should be a sln with all projects needed that can be opened in Visual studio compiled and run 
If additional read me file is needed ad it to the sln.
NOTE – the sln file is part of the test
For any questions on the work send a mail to matan@clrcut.com 	

