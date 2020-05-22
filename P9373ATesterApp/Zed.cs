using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;

namespace N9020ATesterApp
{
    public class Zed
    {
        PointPairList pointPairList;
        LineItem lineItem;
        ZedGraphControl m_zed;
        double m_minPointY;
        double m_maxPointY;
        public Zed(ZedGraphControl zed)
        {
            m_zed = zed;
        }
        public struct ZTITLE
        {
            public string title;
            public string xtitle;
            public string ytitle;
        }
        public void AddCurve(
                        Color color, 
                        int lineWidth ,
                        ZTITLE title,
                        SymbolType symbol = SymbolType.None)
        {

            pointPairList = new PointPairList();
            lineItem = m_zed.GraphPane.AddCurve(title.title, pointPairList, color, symbol);
            lineItem.Line.Width = lineWidth;
            m_zed.GraphPane.Title.Text = title.title;
            m_zed.GraphPane.YAxis.Title.Text = title.xtitle;
            m_zed.GraphPane.XAxis.Title.Text = title.ytitle;
            Rescale();
        }
        public void ScaleY()
        {
            double min;
            double max;
          
            if (m_maxPointY < 0)
            {
                max = m_maxPointY - m_maxPointY * .3;
            }
            else
            {
                max = m_maxPointY + m_maxPointY * .03;
            }

            if (m_minPointY < 0)
            {
                min = m_minPointY + m_minPointY * .05;
            }
            else
            {
                min = m_minPointY + m_minPointY * .05;
            }

            m_zed.GraphPane.YAxis.Scale.Min = min;
            m_zed.GraphPane.YAxis.Scale.Max = max;

        }
        public void Rescale()
        {
            m_minPointY = double.MaxValue;
            m_maxPointY = double.MinValue;
        }
        public void DrawPoint(ZedGraph.ZedGraphControl zgc, int graph, PointPair p)
        {
            m_zed.GraphPane.CurveList[graph].AddPoint(p);
        }
        public void DrawPoint(int graph, PointPair p)
        {
            m_zed.GraphPane.CurveList[graph].AddPoint(p);
        }
        public void DrawPoint(int graph, double x, double y)
        {
            PointPair p = new PointPair
            {
                 X = x,
                 Y = y
            };
            m_zed.GraphPane.CurveList[graph].AddPoint(p);

            if (y < m_minPointY)
                m_minPointY = y;

            if (y > m_maxPointY)
                m_maxPointY = y;

        }

        public void OverwritePoint(int graph, int i , double y)
        {
            m_zed.GraphPane.CurveList[graph].Points[i].Y = y;
        }

        public void Update()
        {
            m_zed.AxisChange();
            m_zed.Invalidate();
        }
    }
}
