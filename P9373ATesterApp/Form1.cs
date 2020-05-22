using Agilent.AgNA.Interop;
using P9374A_Api;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using static P9374A_Api.P937XA;

namespace P9374ATesterApp
{
    public partial class Form1 : Form
    {
        P937XA m_vna = null;
        LineItem[] SparamsCurve = new LineItem[4];
        PointPairList[] points = new PointPairList[4];
        public Form1()
        {
            InitializeComponent();
            AppSettings.Instance.Load("P9374ATesterApp.json");

            cmbFormat.Items.Add("AgNAMeasurementLogMag");
            cmbFormat.Items.Add("AgNAMeasurementLinMag");
            cmbFormat.Items.Add("AgNAMeasurementPhase");
            cmbFormat.Items.Add("AgNAMeasurementGroupDelay");
            cmbFormat.Items.Add("AgNAMeasurementSWR");
            cmbFormat.Items.Add("AgNAMeasurementReal");
            cmbFormat.Items.Add("AgNAMeasurementImag");
            cmbFormat.Items.Add("AgNAMeasurementPolar");
            cmbFormat.Items.Add("AgNAMeasurementSmith");
            cmbFormat.Items.Add("AgNAMeasurementSLinear");
            cmbFormat.Items.Add("AgNAMeasurementSLogarithmic");
            cmbFormat.Items.Add("AgNAMeasurementSComplex");
            cmbFormat.Items.Add("AgNAMeasurementSAdmittance");
            cmbFormat.Items.Add("AgNAMeasurementPLinear");
            cmbFormat.Items.Add("AgNAMeasurementPLogarithmic");
            cmbFormat.Items.Add("AgNAMeasurementUPhase");
            cmbFormat.Items.Add("AgNAMeasurementPPhase");

            cmbTriggerSource.Items.Add("AgNATriggerSourceInternal");
            cmbTriggerSource.Items.Add("AgNATriggerSourceExternal");
            cmbTriggerSource.Items.Add("AgNATriggerSourceBus");
            cmbTriggerSource.Items.Add("AgNATriggerSourceManual");


            cmbMarkerSearch.Items.Add("AgNAMarkerSearchTypeTarget");
            cmbMarkerSearch.Items.Add("AgNAMarkerSearchTypeTargetLeft");
            cmbMarkerSearch.Items.Add("AgNAMarkerSearchTypeTargetRight");
            cmbMarkerSearch.Items.Add("AgNAMarkerSearchTypeMax");
            cmbMarkerSearch.Items.Add("AgNAMarkerSearchTypeMin");
            cmbMarkerSearch.Items.Add("AgNAMarkerSearchTypePeak");
            cmbMarkerSearch.Items.Add("AgNAMarkerSearchTypePeakLeft");
            cmbMarkerSearch.Items.Add("AgNAMarkerSearchTypePeakRight");


            cmbTriggerMode.Items.Add("AgNATriggerModeContinuous");
            cmbTriggerMode.Items.Add("AgNATriggerModeHold");

            Color[] colors = { Color.Red, Color.Black, Color.Green, Color.Blue };
            string[] Names = { "CHANNEL1", "CHANNEL2", "CHANNEL3", "CHANNEL4" };

            for (int i = 0; i < Names.Length; i++)
            {
                CreateGraphs(zg,
                              i,
                              colors[i],
                              Names[i]);
            }

            zg.GraphPane.Title.Text = "Sparameters";
            zg.GraphPane.Legend.Position = ZedGraph.LegendPos.Right;

            zg.GraphPane.Legend.FontSpec.Size = 8.0f;
            zg.GraphPane.Legend.FontSpec.Family = "Arial, Narrow";

            zg.GraphPane.YAxis.Title.FontSpec.Size = 10.0f;
            zg.GraphPane.YAxis.Scale.FontSpec.Family = "Arial, Narrow";

            zg.GraphPane.XAxis.Title.FontSpec.Size = 10.0f;
            zg.GraphPane.XAxis.Scale.FontSpec.Family = "Arial, Narrow";

            zg.GraphPane.Legend.IsVisible = AppSettings.Instance.Config.ShowLegend;

            zg.GraphPane.YAxis.Title.Text = "Y";
            zg.GraphPane.XAxis.Title.Text = "X";

            RefreshGraph();

        }
        void RefreshGraph()
        {
            zg.AxisChange();
            zg.Refresh();
            zg.Invalidate();
        }
        void CreateGraphs(ZedGraphControl zg,
                          int zgIndex,
                          Color colors,
                          string Names)
        {

            Random rand = new Random();
 
            SparamsCurve[zgIndex] = zg.GraphPane.AddCurve(Names, points[zgIndex], colors, SymbolType.None);
            SparamsCurve[zgIndex].Line.IsVisible = AppSettings.Instance.Config.LineOrDot == LineOrDot.Line ? true : false;
            SparamsCurve[zgIndex].Line.Width = AppSettings.Instance.Config.LineWidth;

            if (AppSettings.Instance.Config.LineOrDot == LineOrDot.Dot)
            {
                SparamsCurve[zgIndex].Symbol.Type = SymbolType.Circle;
                SparamsCurve[zgIndex].Symbol.Size = 3;
                SparamsCurve[zgIndex].Symbol.Border.Width = 2.0F;
                SparamsCurve[zgIndex].Symbol.Border.Color = colors;
                SparamsCurve[zgIndex].Symbol.Fill = new Fill(colors);
                SparamsCurve[zgIndex].Symbol.Fill.Type = FillType.Solid;
            } 
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings s = new Settings();
            if (s.ShowDialog() == DialogResult.OK)
            {
                if (m_vna != null)
                {
                    m_vna.Close();
                    m_vna = null;
                }
            }

        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_vna == null)
            {
                this.Cursor = Cursors.WaitCursor;
                if (AppSettings.Instance.Config.visaName == string.Empty || AppSettings.Instance.Config.visaName ==null)
                {
                    MessageBox.Show("Visa name not provided");
                    return;
                }
                m_vna = new P937XA(AppSettings.Instance.Config.visaName);
                if (m_vna.Initialize(out string outMessage, 
                                     false, 
                                     false,
                                     "",
                                     out P937XADriverStatistics stat, false) == true)
                {
                    this.Text = "P9374A Tester App - " + stat.SerialNumber;

                    m_vna.CreateChannel(SPARAMS.S21,
                                        CHANNEL.CHANNEL1,
                                        WINDOW.WINDOW0,
                                        MEASUREMENT.LIKE_CHANNEL);

                    m_vna.TriggerSource = AgNATriggerSourceEnum.AgNATriggerSourceInternal;
                    m_vna.SetTriggerMode(AgNATriggerModeEnum.AgNATriggerModeContinuous, CHANNEL.CHANNEL1);
                    //m_vna.MeasureFormat(AgNAMeasurementFormatEnum.AgNAMeasurementLogMag, CHANNEL.CHANNEL1);
                     
                    double startFreq = m_vna.GetStartFrequency(CHANNEL.CHANNEL1);
                    txtStartFrequency.Text = startFreq.ToString();

                    double stopFreq = m_vna.GetStopFrequency(CHANNEL.CHANNEL1);
                    txtStopFrequency.Text = stopFreq.ToString();

                    double centerFreq = m_vna.GetCenterFrequency(CHANNEL.CHANNEL1);
                    txtCenterFrequency.Text = centerFreq.ToString();

                    double spanFreq = m_vna.GetSpanFrequency(CHANNEL.CHANNEL1);
                    txtSpanFrequency.Text = spanFreq.ToString();

                    int numberOfPoints = m_vna.GetNumberOfPoints(CHANNEL.CHANNEL1);
                    txtNumberOfPoints.Text = numberOfPoints.ToString();

                    AgNAMeasurementFormatEnum mf = m_vna.GetMeasureFormat(CHANNEL.CHANNEL1, MEASUREMENT.LIKE_CHANNEL);
                    cmbFormat.SelectedIndex = (int)mf;
                    cmbTriggerMode.SelectedIndex = (int)m_vna.GetTriggerMode(CHANNEL.CHANNEL1);
                    cmbTriggerSource.SelectedIndex = (int)m_vna.TriggerSource;

                    m_vna.RecallState(txtVnaState.Text);

                    /*
                    m_vna.CreateChannel(SPARAMS.S21,
                                       CHANNEL.CHANNEL2,
                                       WINDOW.WINDOW1,
                                       MEASUREMENT.LIKE_CHANNEL);
                     */

                    this.Cursor = Cursors.Default;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(outMessage);
                }
            }
        }

        bool[] m_first = { true, true, true, true };
        private void btnMeasure_Click(object sender, EventArgs e)
        {
            if (m_vna == null)
                return;
            try
            {
                
                int si = cmbChannel.SelectedIndex;
                MEASUREMENT measurement = (MEASUREMENT)cmbMeasurement.SelectedIndex;
                m_vna.GetMeasureSparams((CHANNEL)si + 1, measurement);
                m_vna.MeasureSparam((CHANNEL)si + 1, out float[] data, out double[] freq,
                                    out int points,
                                    measurement,
                                    false);

                IPointList p = zg.GraphPane.CurveList[si].Points;

                for (int i = 0; i < points; i++)
                {
                    if (m_first[si] == true)
                    {
                        zg.GraphPane.CurveList[si].AddPoint(freq[i], data[i]);
                    }
                    else
                    {
                        p[i].X = freq[i];
                        p[i].Y = data[i];
                    }
                    
                }
                m_first[si] = false;
                RefreshGraph();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnStartFrequency_Click(object sender, EventArgs e)
        {
            if (m_vna == null)
                return;
            m_vna.SetStartFrequency((CHANNEL)(cmbChannel.SelectedIndex + 1) , double.Parse(txtStartFrequency.Text));
        }

        private void btnStopFrequency_Click(object sender, EventArgs e)
        {
            if (m_vna == null)
                return;
            m_vna.SetStopFrequency((CHANNEL)(cmbChannel.SelectedIndex + 1), double.Parse(txtStopFrequency.Text));
        }

        private void btnSpanFrequency_Click(object sender, EventArgs e)
        {
            if (m_vna == null)
                return;
            m_vna.SetSpanFrequency((CHANNEL)(cmbChannel.SelectedIndex + 1), double.Parse(txtSpanFrequency.Text));
        }

        private void btnCenterFrequency_Click(object sender, EventArgs e)
        {
            if (m_vna == null)
                return;
            m_vna.SetCenterFrequency((CHANNEL)(cmbChannel.SelectedIndex + 1), double.Parse(txtCenterFrequency.Text));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_vna != null)
                m_vna.Close();
            m_vna = null;
        }

        void ShowParams(CHANNEL channel)
        {
            double startFreq = m_vna.GetStartFrequency(channel);
            txtStartFrequency.Text = startFreq.ToString();

            double stopFreq = m_vna.GetStopFrequency(channel);
            txtStopFrequency.Text = stopFreq.ToString();

            double centerFreq = m_vna.GetCenterFrequency(channel);
            txtCenterFrequency.Text = centerFreq.ToString();

            double spanFreq = m_vna.GetSpanFrequency(channel);
            txtSpanFrequency.Text = spanFreq.ToString();

            int numberOfPoints = m_vna.GetNumberOfPoints(channel);
            txtNumberOfPoints.Text = numberOfPoints.ToString();

            AgNAMeasurementFormatEnum mf = m_vna.GetMeasureFormat(channel, MEASUREMENT.LIKE_CHANNEL);
            cmbFormat.SelectedIndex = (int)mf;
            cmbTriggerMode.SelectedIndex = (int)m_vna.GetTriggerMode(channel);
        }
        private void cmbChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowParams((CHANNEL)(cmbChannel.SelectedIndex + 1));
        }

        private void connect2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_vna == null)
            {
                if (AppSettings.Instance.Config.visaName == string.Empty || AppSettings.Instance.Config.visaName == null)
                {
                    MessageBox.Show("Visa name not provided");
                    return;
                }
                m_vna = new P937XA(AppSettings.Instance.Config.visaName);
                if (m_vna.Initialize(out string outMessage,
                                     false,
                                     false,
                                     "d:\\vna2.sta",
                                     out P937XADriverStatistics stat, false) == true)
                {
                    this.Text = "P9374A Tester App - " + stat.SerialNumber;

                    m_vna.CreateChannel(SPARAMS.S11,
                                        CHANNEL.CHANNEL1,
                                        WINDOW.WINDOW8,
                                        MEASUREMENT.MEASUREMENT1);

                    m_vna.TriggerSource = AgNATriggerSourceEnum.AgNATriggerSourceInternal;
                    m_vna.SetTriggerMode(AgNATriggerModeEnum.AgNATriggerModeContinuous, CHANNEL.CHANNEL1);
                    //m_vna.MeasureFormat(AgNAMeasurementFormatEnum.AgNAMeasurementLogMag, CHANNEL.CHANNEL1);

                    double startFreq = m_vna.GetStartFrequency(CHANNEL.CHANNEL1);
                    txtStartFrequency.Text = startFreq.ToString();

                    double stopFreq = m_vna.GetStopFrequency(CHANNEL.CHANNEL1);
                    txtStopFrequency.Text = stopFreq.ToString();

                    double centerFreq = m_vna.GetCenterFrequency(CHANNEL.CHANNEL1);
                    txtCenterFrequency.Text = centerFreq.ToString();

                    double spanFreq = m_vna.GetSpanFrequency(CHANNEL.CHANNEL1);
                    txtSpanFrequency.Text = spanFreq.ToString();

                    int numberOfPoints = m_vna.GetNumberOfPoints(CHANNEL.CHANNEL1);
                    txtNumberOfPoints.Text = numberOfPoints.ToString();

                    AgNAMeasurementFormatEnum mf = m_vna.GetMeasureFormat(CHANNEL.CHANNEL1, MEASUREMENT.MEASUREMENT1);
                    cmbFormat.SelectedIndex = (int)mf;
                    cmbTriggerMode.SelectedIndex = (int)m_vna.GetTriggerMode(CHANNEL.CHANNEL1);
                    cmbTriggerSource.SelectedIndex = (int)m_vna.TriggerSource;


                    m_vna.CreateChannel(SPARAMS.S21,
                                       CHANNEL.CHANNEL1,
                                       WINDOW.WINDOW1,
                                       MEASUREMENT.MEASUREMENT2);

                }
                else
                {
                    MessageBox.Show(outMessage);
                }
            }
        }

        private void btnActivateMarker_Click(object sender, EventArgs e)
        {
            if (m_vna == null)
                return;

            int si = cmbChannel.SelectedIndex;
            MEASUREMENT measurement = (MEASUREMENT)cmbMeasurement.SelectedIndex;
            CHANNEL ch = (CHANNEL)(si + 1);

            m_vna.MarkerActivate(ch, measurement, (MARKERS)cmbMarkers.SelectedIndex);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (m_vna == null)
                return;

            int si = cmbChannel.SelectedIndex;
            MEASUREMENT measurement = (MEASUREMENT)cmbMeasurement.SelectedIndex;
            CHANNEL ch = (CHANNEL)(si + 1);

            m_vna.GetMarkerCount(ch, measurement, out int count);
            lblMarkerCount.Text = count.ToString();
        }

        private void chkEnableMarker_CheckedChanged(object sender, EventArgs e)
        {
            if (m_vna == null)
                return;

            int si = cmbChannel.SelectedIndex;
            MEASUREMENT measurement = (MEASUREMENT)cmbMeasurement.SelectedIndex;
            CHANNEL ch = (CHANNEL)(si + 1);
            m_vna.MarkerEnable(ch, measurement, (MARKERS)cmbMarkers.SelectedIndex, chkEnableMarker.Checked);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (m_vna == null)
                return;

            int si = cmbChannel.SelectedIndex;
            MEASUREMENT measurement = (MEASUREMENT)cmbMeasurement.SelectedIndex;
            CHANNEL ch = (CHANNEL)(si + 1);
            if (m_vna.GetMarkerTargetValue(ch, measurement, (MARKERS)cmbMarkers.SelectedIndex, out double value, out string outMessage) == false)
            {
                MessageBox.Show("Failed to get marker target value: " + outMessage);
                return;
            }
            txtMarkerValue.Text = value.ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (m_vna == null)
                return;

            int si = cmbChannel.SelectedIndex;
            MEASUREMENT measurement = (MEASUREMENT)cmbMeasurement.SelectedIndex;
            CHANNEL ch = (CHANNEL)(si + 1);
            if (m_vna.GetMarkerBandwidthThreshold(ch, measurement, (MARKERS)cmbMarkers.SelectedIndex, out double value, out string outMessage) == false)
            {
                MessageBox.Show("Failed to get marker target value: " + outMessage);
                return;
            }
            textBox1.Text = value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (m_vna == null)
                return;

            int si = cmbChannel.SelectedIndex;
            MEASUREMENT measurement = (MEASUREMENT)cmbMeasurement.SelectedIndex;
            CHANNEL ch = (CHANNEL)(si + 1);

            if (m_vna.GetMarkerNames(ch, measurement, out string[] names, out string outMessage) == true)
            {

            }
            else
            {
                MessageBox.Show("failed to get names");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (m_vna == null)
                return;

            int si = cmbChannel.SelectedIndex;
            MEASUREMENT measurement = (MEASUREMENT)cmbMeasurement.SelectedIndex;
            CHANNEL ch = (CHANNEL)(si + 1);

            if (m_vna.GetMarkerPeakExcursion(ch, measurement, 
                                             (MARKERS)cmbMarkers.SelectedIndex, 
                                             out double Value) == true)
            {

            }
            else
            {
                MessageBox.Show("failed to get names");
            }

        }

        private void cmbMarkerSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_vna == null)
                return;

            int si = cmbChannel.SelectedIndex;
            MEASUREMENT measurement = (MEASUREMENT)cmbMeasurement.SelectedIndex;
            CHANNEL ch = (CHANNEL)(si + 1);

            if (m_vna.MarkerSearch(ch, measurement,
                                   (MARKERS)cmbMarkers.SelectedIndex,
                                   (AgNAMarkerSearchTypeEnum)cmbMarkerSearch.SelectedIndex) == true)
            {

            }
            else
            {
                MessageBox.Show("failed to get names");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (m_vna == null)
                return;

            int si = cmbChannel.SelectedIndex;
            MEASUREMENT measurement = (MEASUREMENT)cmbMeasurement.SelectedIndex;
            CHANNEL ch = (CHANNEL)(si + 1);

            double pRealVal = 0;
            double pImagVal = 0;

            if (m_vna.MarkerQueryValue(ch, measurement,
                                   (MARKERS)cmbMarkers.SelectedIndex,
                                   ref pRealVal, ref pImagVal) == true)
            {
                MessageBox.Show("Marker value: " + pRealVal.ToString());
            }
            else
            {
                MessageBox.Show("failed to get names");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (m_vna == null)
                return;

            int si = cmbChannel.SelectedIndex;
            MEASUREMENT measurement = (MEASUREMENT)cmbMeasurement.SelectedIndex;
            CHANNEL ch = (CHANNEL)(si + 1);


            double pBandWidthVal = 0;
            double pCenterFreqVal = 0;
            double pQVal = 0;
            double pLossVal = 0;


            if (m_vna.MarkerQueryBandwidth(ch, measurement,
                                   (MARKERS)cmbMarkers.SelectedIndex,
                                   ref pBandWidthVal,
                                   ref pCenterFreqVal,
                                   ref pQVal,
                                   ref pLossVal) == true)
            {

            }
            else
            {
                MessageBox.Show("failed to get names");
            }
        }

        private void btnMarkerStimulus_Click(object sender, EventArgs e)
        {
            if (m_vna == null)
                return;

            int si = cmbChannel.SelectedIndex;
            MEASUREMENT measurement = (MEASUREMENT)cmbMeasurement.SelectedIndex;
            CHANNEL ch = (CHANNEL)(si + 1);

             
            double frequency = double.Parse(txtMarkerStimulus.Text);

            if (m_vna.GetMarkerStimulus(ch, measurement,
                                   (MARKERS)cmbMarkers.SelectedIndex,
                                    out double s) == true)
            {

            }
            else
            {
                MessageBox.Show("failed to GetMarkerStimulus");
            }

            if (m_vna.SetMarkerStimulus(ch, measurement,
                                   (MARKERS)cmbMarkers.SelectedIndex,
                                    frequency) == true)
            {

            }
            else
            {
                MessageBox.Show("failed to SetMarkerStimulus");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (m_vna == null)
                return;
            int si = cmbChannel.SelectedIndex;
            MEASUREMENT measurement = (MEASUREMENT)cmbMeasurement.SelectedIndex;
            CHANNEL ch = (CHANNEL)(si + 1);
            m_vna.AutoScale(ch, measurement);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (m_vna == null)
                return;
            m_vna.RecallState(txtVnaState.Text);
        }

        private void fastCalibrateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_vna == null)
                return;

            try
            {
                int si = cmbChannel.SelectedIndex;
                MEASUREMENT measurement = (MEASUREMENT)cmbMeasurement.SelectedIndex;
                CHANNEL ch = (CHANNEL)(si + 1);
                m_vna.FastCalibrate(ch, measurement);
                m_vna.SaveState(txtVnaState.Text);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
