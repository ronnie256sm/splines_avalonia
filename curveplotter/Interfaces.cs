using System.ComponentModel;
using System.Threading.Tasks;
using Avalonia.Media;

namespace CurvePlotter
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Point (double x, double y)
        {
            X = x;
            Y = y;
        }
    }

    public interface ICurve : INotifyPropertyChanged
    {
        string? Name { get; set; }
        string Type { get; }
        string? FunctionString { get; set; }
        string? SplineType { get; }
        double[]? Grid { get; }
        Point[]? ControlPoints { get; }
        string? ControlPointsFile { get; set; }
        string? GridFile { get; set; }
        bool IsVisible { get; set; }
        string? SmoothingCoefficientAlpha { get; set; }
        string? SmoothingCoefficientBeta { get; set; }
        double CalculateFunctionValue(double x);
        bool IsPossible { get; set; }
        Color Color { get; set; }
        string? Start { get; set; }
        string? End { get; set; }
        double ParsedStart { get; set; }
        double ParsedEnd { get; set; }
        bool ShowControlPoints { get; set; }
        void GetLimits();
        double Thickness { get; set; }
    }

    public interface ILogic
    {
        public Task<ICurve?> CreateFunction(string functionString);
        public ICurve? CreateInterpolatingSpline(Point[] controlPoints, int type);
        public ICurve? CreateSmoothingSpline(double[] grid, Point[] controlPoints, string smoothingCoefficientAlpha, string smoothingCoefficientBeta);
        public ICurve? CreateLinearSpline(Point[] controlPoints);
    }
}