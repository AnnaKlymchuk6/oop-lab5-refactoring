using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassLibrary
{
    public class ZNO
    {
        public string Subject;
        public int Points;

        public ZNO() { }

        public ZNO(string subject, int points)
        {
            Subject = subject;
            Points = points;
        }

        public ZNO(ZNO other)
        {
            Subject = other.Subject;
            Points = other.Points;
        }

        public void SetSubject(string subject) { Subject = subject; }
        public string GetSubject() { return Subject; }

        public void SetPoints(int points) { Points = points; }
        public int GetPoints() { return Points; }
    }
}