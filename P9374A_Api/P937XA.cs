using Agilent.AgNA.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P9374A_Api
{
    public enum SPARAMS
    {
        S11,
        S12,
        S21,
        S22
    }

    public class P937XA
    { 

        public struct P937XADriverStatistics
        {
            public string Identifier;
            public string Revision;
            public string Vendor;
            public string Description;
            public string InstrumentModel;
            public string InstrumentFirmwareRevision;
            public string SerialNumber;
            public bool Simulate;
        }

        AgNA driver = null;
        string initOptions = "QueryInstrStatus=true, Simulate=false, DriverSetup= Model=, Trace=false";
        string resourceDesc;
        bool idquery = true;

        bool m_initialize = false;
        IAgNAChannel[] agNAChannel = new IAgNAChannel[8];
        IAgNASystemScpiPassThrough ptrScpi;

        public P937XA(string cs)
        {
            resourceDesc = cs;
        }
        public enum WINDOW
        {
            WINDOW0,
            WINDOW1,
            WINDOW2,
            WINDOW3,
            WINDOW4,
            WINDOW5,
            WINDOW6,
            WINDOW7,
            WINDOW8,
        }
        public enum CHANNEL
        {
            CHANNEL1 = 1,
            CHANNEL2 = 2,
            CHANNEL3 = 3,
            CHANNEL4 = 4,
            CHANNEL5 = 5,
            CHANNEL6 = 6,
            CHANNEL7 = 7,
            CHANNEL8 = 8,
        }
        P937XADriverStatistics m_ds;
        public bool Initialize(out string outMessgae,
                                bool reset,
                                bool simulate,
                                string recallState,
                                out P937XADriverStatistics ds,
                                bool trace = false)
        {
            outMessgae = string.Empty;
            if (m_initialize == true)
            {
                outMessgae = "Already Initialize";
                ds = m_ds;
                return true;
            }
            try
            {
                if (simulate)
                {
                    initOptions = "QueryInstrStatus=true, Simulate=true, DriverSetup= Model=, Trace=false";
                }

                driver = new Agilent.AgNA.Interop.AgNA();
                driver.Initialize(resourceDesc, idquery, reset, initOptions);

                ds.Identifier = driver.Identity.Identifier;
                ds.Revision = driver.Identity.Revision;
                ds.Vendor = driver.Identity.Vendor;
                ds.Description = driver.Identity.Description;
                ds.InstrumentModel = driver.Identity.InstrumentModel;
                ds.InstrumentFirmwareRevision = driver.Identity.InstrumentFirmwareRevision;
                ds.SerialNumber = driver.System.SerialNumber;
                ds.Simulate = driver.DriverOperation.Simulate;
                ptrScpi = driver.System.ScpiPassThrough;
                m_ds = ds;
                DeleteAllChannels();
                if (recallState != string.Empty)
                {
                    RecallState(recallState);
                }                
                m_initialize = true;
                return true;
            }
            catch (Exception err)
            {
                ds = new P937XADriverStatistics();
                outMessgae = err.Message;
                return false;
            }            
        }
        public void DeleteAllChannels()
        {
            driver.Channels.DeleteAll();
        }
        public void Preset()
        {
            driver.System.Preset();
        }

        public void RecallState(string state)
        {
            driver.System.RecallState(state);
        }
        public void SaveState(string state)
        {
            driver.System.SaveState(state);
        }
 
        public void SetStartFrequency(CHANNEL channel, double value)
        {            
              agNAChannel[(int)channel - 1].StandardStimulus.FrequencyRange.Start = value;                 
        }
         
        public double GetStartFrequency(CHANNEL channel)
        {
            return agNAChannel[(int)channel - 1].StandardStimulus.FrequencyRange.Start;
        }

        public double GetStopFrequency(CHANNEL channel)
        {           
             return agNAChannel[(int)channel - 1].StandardStimulus.FrequencyRange.Stop;             
        }

        public void SetNumberOfPoints(CHANNEL channel, int value)
        {
            agNAChannel[(int)channel - 1].StandardStimulus.Points = value;
        }
        public int GetNumberOfPoints(CHANNEL channel)
        {
            return agNAChannel[(int)channel - 1].StandardStimulus.Points;
        }

        public void SetStopFrequency(CHANNEL channel, double value)
        {             
            agNAChannel[(int)channel - 1].StandardStimulus.FrequencyRange.Stop = value;            
        }
        public void SetCenterFrequency(CHANNEL channel, double value)
        {
            agNAChannel[(int)channel - 1].StandardStimulus.FrequencyRange.Center = value;         
        }
        public double GetCenterFrequency(CHANNEL channel)
        {
            return agNAChannel[(int)channel - 1].StandardStimulus.FrequencyRange.Center;
        }

        public void SetSpanFrequency(CHANNEL channel, double value)
        {

            agNAChannel[(int)channel - 1].StandardStimulus.FrequencyRange.Span = value;            
        }
        public double GetSpanFrequency(CHANNEL channel)
        {
            return agNAChannel[(int)channel - 1].StandardStimulus.FrequencyRange.Span;
        }

        public enum MARKERS
        {
            MARKER1,
            MARKER2,
            MARKER3,
            MARKER4,
            MARKER5,
            MARKER6,
            MARKER7,         
        }
        string getMarker(MARKERS m)
        {
            switch (m)
            {
                case MARKERS.MARKER1:
                    return "MARKER1";
                case MARKERS.MARKER2:
                    return "MARKER2";
                case MARKERS.MARKER3:
                    return "MARKER3";
                case MARKERS.MARKER4:
                    return "MARKER4";
                case MARKERS.MARKER5:
                    return "MARKER5";
                case MARKERS.MARKER6:
                    return "MARKER6";
                case MARKERS.MARKER7:
                    return "MARKER7";
            }
            throw (new SystemException("marker is not correct"));
        }
        public bool MarkerActivate(CHANNEL channel, MEASUREMENT measurement, MARKERS marker)
        {
            try
            {
                IAgNAMeasurement chMeasurement;
                if (measurement != MEASUREMENT.LIKE_CHANNEL)
                    chMeasurement = agNAChannel[(int)channel - 1].Measurements.get_Item("Measurement" + (int)measurement);
                else
                {
                    chMeasurement = agNAChannel[(int)channel - 1].Measurements.get_Item("Measurement" + (int)channel);
                }
                
                chMeasurement.Markers.Item[getMarker(marker)].Activate();                
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        
        public bool SetMarkerBandwidthThreshold(CHANNEL channel, MEASUREMENT measurement, MARKERS marker, double t)
        {

             
            try
            {
                IAgNAMeasurement chMeasurement;
                if (measurement != MEASUREMENT.LIKE_CHANNEL)
                    chMeasurement = agNAChannel[(int)channel - 1].Measurements.get_Item("Measurement" + (int)measurement);
                else
                {
                    chMeasurement = agNAChannel[(int)channel - 1].Measurements.get_Item("Measurement" + (int)channel);
                }

                chMeasurement.Markers.Item[getMarker(marker)].BandwidthThreshold = t;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool GetMarkerBandwidthThreshold(CHANNEL channel, MEASUREMENT measurement, MARKERS marker, out double value, out string outMessage)
        {

            outMessage = string.Empty;
            value = 0;
            try
            {
                IAgNAMeasurement chMeasurement;
                if (measurement != MEASUREMENT.LIKE_CHANNEL)
                    chMeasurement = agNAChannel[(int)channel - 1].Measurements.get_Item("Measurement" + (int)measurement);
                else
                {
                    chMeasurement = agNAChannel[(int)channel - 1].Measurements.get_Item("Measurement" + (int)channel);
                }

                value = chMeasurement.Markers.Item[getMarker(marker)].BandwidthThreshold;
                return true;
            }
            catch (Exception err)
            {
                outMessage = err.Message;
                return false;
            }
        }

        public bool GetMarkerTargetValue(CHANNEL channel, 
                                         MEASUREMENT measurement, 
                                         MARKERS marker, 
                                         out double targetValue,
                                         out string outMessage)
        {
            targetValue = 0;
            outMessage = string.Empty;
            try
            {
                IAgNAMeasurement chMeasurement;
                if (measurement != MEASUREMENT.LIKE_CHANNEL)
                    chMeasurement = agNAChannel[(int)channel - 1].Measurements.get_Item("Measurement" + (int)measurement);
                else
                {
                    chMeasurement = agNAChannel[(int)channel - 1].Measurements.get_Item("Measurement" + (int)channel);
                }

                targetValue = chMeasurement.Markers.Item[getMarker(marker)].TargetValue;
                return true;
            }
            catch (Exception err)
            {
                outMessage = err.Message;
                return false;
            }
        }
        public bool GetMarkerPeakExcursion(CHANNEL channel, MEASUREMENT measurement, MARKERS marker, out double targetValue)
        {
            targetValue = 0;
            try
            {
                IAgNAMeasurement chMeasurement;
                if (measurement != MEASUREMENT.LIKE_CHANNEL)
                    chMeasurement = agNAChannel[(int)channel - 1].Measurements.get_Item("Measurement" + (int)measurement);
                else
                {
                    chMeasurement = agNAChannel[(int)channel - 1].Measurements.get_Item("Measurement" + (int)channel);
                }

                targetValue = chMeasurement.Markers.Item[getMarker(marker)].PeakExcursion;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public bool SetMarkerStimulus(CHANNEL channel,
                                   MEASUREMENT measurement, 
                                   MARKERS marker,        
                                   double stimulus)
        {
             
            try
            {
                IAgNAMeasurement chMeasurement;
                if (measurement != MEASUREMENT.LIKE_CHANNEL)
                    chMeasurement = agNAChannel[(int)channel - 1].Measurements.get_Item("Measurement" + (int)measurement);
                else
                {
                    chMeasurement = agNAChannel[(int)channel - 1].Measurements.get_Item("Measurement" + (int)channel);
                }

                chMeasurement.Markers.Item[getMarker(marker)].Stimulus = stimulus;
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool GetMarkerStimulus(CHANNEL channel,
                                      MEASUREMENT measurement,
                                      MARKERS marker,
                                      out double stimulus)
        {
            stimulus = 0;
            try
            {
                IAgNAMeasurement chMeasurement;
                if (measurement != MEASUREMENT.LIKE_CHANNEL)
                    chMeasurement = agNAChannel[(int)channel - 1].Measurements.get_Item("Measurement" + (int)measurement);
                else
                {
                    chMeasurement = agNAChannel[(int)channel - 1].Measurements.get_Item("Measurement" + (int)channel);
                }

                stimulus = chMeasurement.Markers.Item[getMarker(marker)].Stimulus;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool MarkerQueryBandwidth(CHANNEL channel, MEASUREMENT measurement, MARKERS marker,
                                        ref double pBandWidthVal, 
                                        ref double pCenterFreqVal, 
                                        ref double pQVal, 
                                        ref double pLossVal)
        {
            try
            {
                IAgNAMeasurement chMeasurement;
                if (measurement != MEASUREMENT.LIKE_CHANNEL)
                    chMeasurement = agNAChannel[(int)channel - 1].Measurements.get_Item("Measurement" + (int)measurement);
                else
                {
                    chMeasurement = agNAChannel[(int)channel - 1].Measurements.get_Item("Measurement" + (int)channel);
                }

                chMeasurement.Markers.Item[getMarker(marker)].QueryBandwidth(ref pBandWidthVal, ref pCenterFreqVal, ref pQVal, ref  pLossVal);

            
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool MarkerQueryValue(CHANNEL channel, MEASUREMENT measurement, MARKERS marker,
                                     ref double pRealVal, ref double pImagVal)
        {
            try
            {
                IAgNAMeasurement chMeasurement;
                if (measurement != MEASUREMENT.LIKE_CHANNEL)
                    chMeasurement = agNAChannel[(int)channel - 1].Measurements.get_Item("Measurement" + (int)measurement);
                else
                {
                    chMeasurement = agNAChannel[(int)channel - 1].Measurements.get_Item("Measurement" + (int)channel);
                }

                chMeasurement.Markers.Item[getMarker(marker)].QueryValue(ref pRealVal, ref pImagVal);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool MarkerSearch(CHANNEL channel, MEASUREMENT measurement, MARKERS marker, AgNAMarkerSearchTypeEnum s)
        {
            try
            {
                IAgNAMeasurement chMeasurement;
                if (measurement != MEASUREMENT.LIKE_CHANNEL)
                    chMeasurement = agNAChannel[(int)channel - 1].Measurements.get_Item("Measurement" + (int)measurement);
                else
                {
                    chMeasurement = agNAChannel[(int)channel - 1].Measurements.get_Item("Measurement" + (int)channel);
                }

                chMeasurement.Markers.Item[getMarker(marker)].Search(s);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool MarkerEnable(CHANNEL channel, MEASUREMENT measurement, MARKERS marker, bool enable)
        {
            try
            {
                IAgNAMeasurement chMeasurement;
                if (measurement != MEASUREMENT.LIKE_CHANNEL)
                    chMeasurement = agNAChannel[(int)channel - 1].Measurements.get_Item("Measurement" + (int)measurement);
                else
                {
                    chMeasurement = agNAChannel[(int)channel - 1].Measurements.get_Item("Measurement" + (int)channel);
                }
                
                chMeasurement.Markers.Item[getMarker(marker)].Enabled = enable;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool SetMarkerTrackEnabled(CHANNEL channel, MEASUREMENT measurement, MARKERS marker, bool te)
        {
            
            try
            {
                IAgNAMeasurement chMeasurement;
                if (measurement != MEASUREMENT.LIKE_CHANNEL)
                    chMeasurement = agNAChannel[(int)channel - 1].Measurements.get_Item("Measurement" + (int)measurement);
                else
                {
                    chMeasurement = agNAChannel[(int)channel - 1].Measurements.get_Item("Measurement" + (int)channel);
                }

                chMeasurement.Markers.Item[getMarker(marker)].MarkerTrackEnabled = te;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        
        public bool GetMarkerNames(CHANNEL channel,
                                   MEASUREMENT measurement,
                                   out string [] names,
                                   out string outMessage)
        {

            names = null;
            outMessage = string.Empty;
            try
            {
                IAgNAMeasurement chMeasurement;
                if (measurement != MEASUREMENT.LIKE_CHANNEL)
                    chMeasurement = agNAChannel[(int)channel - 1].Measurements.get_Item("Measurement" + (int)measurement);
                else
                {
                    chMeasurement = agNAChannel[(int)channel - 1].Measurements.get_Item("Measurement" + (int)channel);
                }

                int markerCount = chMeasurement.Markers.Count;
                names = new string[markerCount];
                for (int i = 0; i < markerCount; i++)
                {
                    names[i] = chMeasurement.Markers.Name[i];
                }
                return true;
            }
            catch (Exception err)
            {
                outMessage = err.Message;
                return false;
            }
        }

        public bool GetMarkerCount(CHANNEL channel, 
                                   MEASUREMENT measurement, 
                                   out int markerCount)
        {
            markerCount = -1;
            try
            {
                IAgNAMeasurement chMeasurement;
                if (measurement != MEASUREMENT.LIKE_CHANNEL)
                    chMeasurement = agNAChannel[(int)channel - 1].Measurements.get_Item("Measurement" + (int)measurement);
                else
                {
                    chMeasurement = agNAChannel[(int)channel - 1].Measurements.get_Item("Measurement" + (int)channel);
                }
                
                markerCount = chMeasurement.Markers.Count;
                return true;
            }
            catch (Exception)
            { 
                return false;
            }

        }
        public AgNATriggerSourceEnum TriggerSource
        {
            set
            {
                driver.Trigger.Source = value;
            }
            get
            {
                return driver.Trigger.Source;
            }
        }
        public void SetTriggerMode(AgNATriggerModeEnum triggerMode, CHANNEL channel)
        {
            agNAChannel[(int)channel - 1].TriggerMode = triggerMode;
        }
        public AgNATriggerModeEnum GetTriggerMode(CHANNEL channel)
        {
            return agNAChannel[(int)channel - 1].TriggerMode;
        }
        public void SetMeasureFormat(AgNAMeasurementFormatEnum measureFormat , CHANNEL channel, MEASUREMENT measurement)
        {

            IAgNAMeasurement chMeasurement;
            if (measurement != MEASUREMENT.LIKE_CHANNEL)
                chMeasurement = agNAChannel[(int)channel - 1].Measurements.get_Item("Measurement" + (int)measurement);
            else
            {
                chMeasurement = agNAChannel[(int)channel - 1].Measurements.get_Item("Measurement" + (int)channel);
            }

            chMeasurement.Format = measureFormat;
            
        }
        public AgNAMeasurementFormatEnum GetMeasureFormat(CHANNEL channel, MEASUREMENT measurement)
        {
            
            IAgNAMeasurement chMeasurement;
            if (measurement != MEASUREMENT.LIKE_CHANNEL)
                chMeasurement = agNAChannel[(int)channel - 1].Measurements.get_Item("Measurement" + (int)measurement);
            else
            {
                chMeasurement = agNAChannel[(int)channel - 1].Measurements.get_Item("Measurement" + (int)channel);
            }
            return chMeasurement.Format;
        }

        string[] SparamName = { "S11", "S12", "S21", "S22" };
        string GetChannelName(CHANNEL channel)
        {
            switch (channel)
            {
                case CHANNEL.CHANNEL1:
                    return "Channel1";
                case CHANNEL.CHANNEL2:
                    return "Channel2";
                case CHANNEL.CHANNEL3:
                    return "Channel3";
                case CHANNEL.CHANNEL4:
                    return "Channel4";
                case CHANNEL.CHANNEL5:
                    return "Channel5";
                case CHANNEL.CHANNEL6:
                    return "Channel6";
                case CHANNEL.CHANNEL7:
                    return "Channel7";
                case CHANNEL.CHANNEL8:
                    return "Channel8";
            }
            throw (new SystemException("Invalid channel"));
        }
        public enum MEASUREMENT
        {
            LIKE_CHANNEL = 0,
            MEASUREMENT1 = 1,
            MEASUREMENT2 = 2,
            MEASUREMENT3 = 3,
            MEASUREMENT4 = 4,
            MEASUREMENT5 = 5,
            MEASUREMENT6 = 6,
            MEASUREMENT7 = 7,
            MEASUREMENT8 = 8,
            MEASUREMENT9 = 9,
            MEASUREMENT10 = 10,
            MEASUREMENT11 = 11,
            MEASUREMENT12 = 12,
            MEASUREMENT13 = 13,
            MEASUREMENT14 = 14,
            MEASUREMENT15 = 15,
        }
        Dictionary<Tuple<CHANNEL, MEASUREMENT>, SPARAMS> m_measureChannelDic = new Dictionary<Tuple<CHANNEL, MEASUREMENT>, SPARAMS>();
        public SPARAMS GetMeasureSparams(CHANNEL channel, MEASUREMENT measurement)
        {
            Tuple<CHANNEL, MEASUREMENT> t = new Tuple<CHANNEL, MEASUREMENT>(channel, measurement);
            return m_measureChannelDic[t];
        }
        public void CreateChannel(SPARAMS sp, 
                                  CHANNEL channel, 
                                  WINDOW window,
                                  MEASUREMENT measurement)
        {

            Tuple<CHANNEL, MEASUREMENT> t = new Tuple<CHANNEL, MEASUREMENT>(channel, measurement);
            if (m_measureChannelDic.ContainsKey(t) == true)
                return;

            driver.Channels.AddMeasurement("Standard", SparamName[(int)sp], (int)channel, (int)window);
            // Setup convineient pointers to Channels and Measurements
            agNAChannel[(int)channel - 1] = driver.Channels.get_Item(GetChannelName(channel));
            IAgNAMeasurement chMeasurement;

            if (measurement != MEASUREMENT.LIKE_CHANNEL)
            {
                chMeasurement = agNAChannel[(int)channel - 1].Measurements.get_Item("Measurement" + (int)measurement);
                m_measureChannelDic.Add(new Tuple<CHANNEL, MEASUREMENT>(channel, measurement) , sp);
            }
            else
            {
                chMeasurement = agNAChannel[(int)channel - 1].Measurements.get_Item("Measurement" + (int)channel);
                m_measureChannelDic.Add(new Tuple<CHANNEL, MEASUREMENT>(channel, (MEASUREMENT)channel), sp);
            }
            

        }

        public void MeasureSparam(CHANNEL channel,
                                  out float[] data,
                                  out double[] freq,                               
                                  out int points,
                                  MEASUREMENT measurement,
                                  bool autoScale = true)
        {
            IAgNAMeasurement chMeasurement;
            if (measurement != MEASUREMENT.LIKE_CHANNEL)
                chMeasurement = agNAChannel[(int)channel - 1].Measurements.get_Item("Measurement" + (int)measurement);
            else
            {
                chMeasurement = agNAChannel[(int)channel - 1].Measurements.get_Item("Measurement" + (int)channel);
            }

            agNAChannel[(int)channel - 1].TriggerSweep(2000); // Take sweep and wait up to 2 seconds for sweep to complete
            if (autoScale)
                chMeasurement.Trace.AutoScale();

            // Read and output data
            data = chMeasurement.FetchFormatted();
            freq = chMeasurement.FetchX();
            points = data.Length;
        }
        public void AutoScale(CHANNEL channel, MEASUREMENT measurement)
        {
            IAgNAMeasurement chMeasurement;
            if (measurement != MEASUREMENT.LIKE_CHANNEL)
                chMeasurement = agNAChannel[(int)channel - 1].Measurements.get_Item("Measurement" + (int)measurement);
            else
            {
                chMeasurement = agNAChannel[(int)channel - 1].Measurements.get_Item("Measurement" + (int)channel);
            }

            chMeasurement.Trace.AutoScale();
        }
        public void WriteSCPI(string cmd)
        {
            ptrScpi.WriteString(cmd);
        }
        public void Close()
        {
            if (driver != null)
                driver.Close();
            m_initialize = false;
            driver = null;
        }

        public string GetIDN()
        {
            WriteSCPI("*IDN?");
            string myIDN = ptrScpi.ReadString();
            return myIDN;
        }

        public bool FastCalibrate(CHANNEL channel, MEASUREMENT measurement)
        {

            try
            {
                IAgNAMeasurement chMeasurement;
                if (measurement != MEASUREMENT.LIKE_CHANNEL)
                    chMeasurement = agNAChannel[(int)channel - 1].Measurements.get_Item("Measurement" + (int)measurement);
                else
                {
                    chMeasurement = agNAChannel[(int)channel - 1].Measurements.get_Item("Measurement" + (int)channel);
                }

                chMeasurement.DataToMemory();
                chMeasurement.TraceMath = AgNAMeasurementTraceMathEnum.AgNAMeasurementTraceMathDivided;                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

