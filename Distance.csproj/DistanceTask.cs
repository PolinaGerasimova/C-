using System;

namespace DistanceTask
{
	public static class DistanceTask
	{
        static double angle = 0;
        // Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
        public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
        {
            if (DistanceToPoint(x, y, ax, ay) < (DistanceToPoint(x, y, bx, by)))
            {
                angle = Angle(x, y, ax, ay, bx, by);
                if (angle < 1.57) return GetDistance(x, y, ax, ay);
                else return DistanceToPoint(x, y, ax, ay);
            }
            else
            {
                angle = Angle(x, y, bx, by, ax, ay);
                if (angle < 1.57) return GetDistance(x, y, bx, by);
                else return DistanceToPoint(x, y, bx, by);
            }
        }

        public static double GetDistance(double ax, double ay, double x, double y)
        {
            return Math.Sin(angle) * DistanceToPoint(x, y, ax, ay);
        }

        public static double DistanceToPoint(double x, double y, double aX, double aY)
        {
            return Math.Sqrt(Math.Pow((aX - x), 2) + Math.Pow((aY - y), 2));
        }
        public static double Angle(double x, double y, double ax, double ay, double bx, double by)
        {
            double abX = ax - bx;
            double abY = ay - by;
            double xaX = ax - x;
            double xaY = ay - y;
            double varAB = GetVariant(abX, abY);
            double varXA = GetVariant(xaX, xaY);
            return Math.Acos(((abX * xaX) + (abY * xaY)) / (varAB * varXA));
        }
        public static double GetVariant(double i, double j)
        {
        return Math.Sqrt((Math.Pow(i, 2) + Math.Pow(j, 2)));
        }
    }
}