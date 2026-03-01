using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassLibrary
{
    public class Entrant
    {
        public string Name;
        public string IdNum;
        public double CoursePoints;
        public double AvgPoints;
        public ZNO[] ZnoResults;

        public double TuitionPerMonth { get; set; }
        public double TuitionPerYear { get; set; }
        public double TuitionForPeriod { get; set; }

        public Entrant(string name, string idNum, double coursePoints, double avgPoints, ZNO[] znoResults)
        {
            Name = name;
            IdNum = idNum;
            CoursePoints = coursePoints;
            AvgPoints = avgPoints;
            ZnoResults = znoResults;
        }

        public string GetName()
        {
            return Name;
        }

        public string GetIdNum()
        {
            return IdNum;
        }

        public double GetCoursePoints()
        {
            return CoursePoints;
        }

        public double GetAvgPoints()
        {
            return AvgPoints;
        }

        public ZNO[] GetZNOResults()
        {
            return ZnoResults;
        }

        public double GetCompMark()
        {
            double znoSum = 0;
            foreach (ZNO z in ZnoResults)
            {
                znoSum += z.Points;
            }
            return (znoSum + CoursePoints + AvgPoints) / 3;
        }

        public string GetBestSubject()
        {
            int maxPoints = 0;
            string bestSubject = string.Empty;

            foreach (ZNO z in ZnoResults)
            {
                if (z.Points > maxPoints)
                {
                    maxPoints = z.Points;
                    bestSubject = z.Subject;
                }
            }

            return bestSubject;
        }

        public string GetWorstSubject()
        {
            int minPoints = int.MaxValue;
            string worstSubject = string.Empty;

            foreach (ZNO z in ZnoResults)
            {
                if (z.Points < minPoints)
                {
                    minPoints = z.Points;
                    worstSubject = z.Subject;
                }
            }

            return worstSubject;
        }

        public double GetTuitionPerYear()
        {
            return TuitionPerYear * 10;
        }

        public double GetTuitionFull()
        {
            return TuitionPerMonth * 40;
        }
    }
}