using System.Collections.Generic;
using System.Linq;
using System;

namespace ProjectsManager
{
    interface IForecast
    {
        void MakeForecast(double[] x, double[] y, out double[] resX, out double[] resY, int count);
    }

    class LiniarForecast : IForecast
    {
        #region IForecast Members

        public void MakeForecast(double[] x, double[] y, out double[] resX, out double[] resY, int count )
        {
            double xmin = x.Min();
            List<double> x_ = new List<double>();
            for (int i = 0; i < x.Count(); i++)
                x_.Add(x[i] - xmin+1);
            double ymin = y.Min();
            double xmin_ = x_.Min();
            double sumX = x_.Sum(xi => xi/xmin_ - 1);
            double sumY = y.Sum(yi => yi/ymin - 1);
            double b = sumY/sumX;
            var listY = new List<double>();
            var listX = new List<double>();
            for(int i = 0;i<x.Length+count-1;i++)
            {
                listX.Add(i+xmin);
                listY.Add(ymin*(1 + b*i));
            }
            resX = listX.ToArray();
            resY = listY.ToArray();
        }

        #endregion
    }

    class LiniarDownForecast : IForecast
    {
        #region IForecast Members

        public void MakeForecast(double[] x, double[] y, out double[] resX, out double[] resY, int count)
        {
            double xmin = x.Min();
            List<double> x_ = new List<double>();
            for (int i = 0; i < x.Count(); i++)
                x_.Add(x[i] - xmin + 1);
            double ymax = y.Max();
            double xmin_ = x_.Min();
            double sumX = x_.Sum(xi => xi / xmin_ - 1);
            double sumY = y.Sum(yi => 1 - yi / ymax );
            double b = sumY / sumX;
            var listY = new List<double>();
            var listX = new List<double>();
            for (int i = 0; i < x.Length + count - 1; i++)
            {
                listX.Add(i + xmin);
                listY.Add(ymax * (1 - b * i));
            }
            resX = listX.ToArray();
            resY = listY.ToArray();
        }

        #endregion
    }

    class ExpForecast : IForecast
    {
        #region IForecast Members

        public void MakeForecast(double[] x, double[] y, out double[] resX, out double[] resY, int count)
        {
            double xmin = x.Min();
            double n = y.Length;
            List<double> x_ = new List<double>();
            for (int i = 0; i < x.Count()-1; i++)
                x_.Add(x[i] - xmin + 1);

            double sum_log_yt = y.Sum(yt => Math.Log(yt));
            double sum_t_2 = x_.Sum(t => t*t);
            double sum_t = x_.Sum(t => t);
            double sum_log_yt_t = x_.Sum(t => Math.Log(y[(int) t - 1])*t);

            double B = (sum_log_yt*sum_t - n*sum_log_yt_t)/(sum_t*sum_t - n*sum_t_2);
            double A = (sum_log_yt*sum_t_2 - sum_log_yt_t*sum_t)/(n*sum_t_2 - sum_t*sum_t);
            //double B = (sum_t*sum_log_yt - n*sum_log_yt_t)/(sum_t*sum_t - n*sum_t_2);
            //double A = 1/n*(sum_log_yt - sum_t*B);
            double a = Math.Exp(A);
            double b = Math.Exp(B);

            List<double> listX = new List<double>();
            List<double> listY = new List<double>();

            for (int i = 0; i < x.Length + count-1; i++)
            {
                listX.Add(i + xmin);
                listY.Add(a*Math.Pow(b, i));
            }

            resX = listX.ToArray();
            resY = listY.ToArray();
        }

        #endregion
    }

    class ParabolForecast : IForecast
    {

        #region IForecast Members

        public void MakeForecast(double[] x, double[] y, out double[] resX, out double[] resY, int count)
        {
            double xmin = x.Min();
            double n = y.Length;
            List<double> x_ = new List<double>();
            for (int i = 0; i < x.Count() - 1; i++)
                x_.Add(x[i] - xmin + 1);

            double sum_yt = y.Sum();
            double sum_t2 = x_.Sum(t => t*t);
            double sum_yt_t2 = x_.Sum(t => y[(int) t - 1]*t*t);
            double sum_t4 = x_.Sum(t => t*t*t*t);
            double sum_y_t = x_.Sum(t => y[(int) t - 1]*t);

            double a0 = sum_yt/n - sum_t2/n*((n*sum_yt_t2 - sum_t2*sum_yt)/(n*sum_t4 - sum_t2*sum_t2));
            double a1 = sum_y_t/sum_t2;
            double a2 = (n*sum_yt_t2 - sum_t2*sum_yt)/(n*sum_t4 - sum_t2*sum_t2);

            List<double> listX = new List<double>();
            List<double> listY = new List<double>();

            for (int i = 0; i < x.Length + count - 1; i++)
            {
                listX.Add(i + xmin);
                listY.Add(a0 + a1*i + a2*i*i);
            }

            resX = listX.ToArray();
            resY = listY.ToArray();

        }

        #endregion
    }

    class HiperbolForecast : IForecast
    {
        #region IForecast Members

        public void MakeForecast(double[] x, double[] y, out double[] resX, out double[] resY, int count)
        {
            double xmin = x.Min();
            List<double> x_ = new List<double>();
            for (int i = 0; i < x.Count()-1; i++)
                x_.Add(x[i] - xmin + 1);
            double ymax = y.Max();
            double xmin_ = x_.Min();
            double sumX = x_.Sum(xi => 1/xmin_ - 1/xi);
            double sumY = y.Sum(yi => 1 - yi/ymax);
            double b = sumY / sumX;
            var listY = new List<double>();
            var listX = new List<double>();
            for (int i = 0; i < x.Length + count - 1; i++)
            {
                listX.Add(i + xmin);
                listY.Add(ymax * (1 - b * ( 1.0 - 1.0/(i+1))));
            }
            resX = listX.ToArray();
            resY = listY.ToArray();
        }

        #endregion
    }



}