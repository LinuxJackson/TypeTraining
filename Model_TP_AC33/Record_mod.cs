using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model_TP_AC33
{
    public class Record_mod
    {
        private int length;
        private int speed;
        private DateTime recordTime;

        public int Length
        {
            get
            {
                return length;
            }

            set
            {
                length = value;
            }
        }

        public int Speed
        {
            get
            {
                return speed;
            }

            set
            {
                speed = value;
            }
        }

        public DateTime RecordTime
        {
            get
            {
                return recordTime;
            }

            set
            {
                recordTime = value;
            }
        }
    }
}
