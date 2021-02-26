using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3_POMS.Classes.Lab4
{
    public class HistoryItem
    {
        float weight;
        float heigh;
        float ibm;
        DateTime date;

        public string Date
        {
            get
            {
                return date.ToString();
            }
 
        }
        public string Text { get
            {
                return this.ToString();
            }
            set
            {
                Text = ToString();
            }
        }
        public string DetailText { get; set;}
        public HistoryItem(float weight, float heigh, float ibm, string detail)
        {
            this.weight = weight;
            this.heigh = heigh;
            this.ibm = ibm;
            this.date = DateTime.Now;
            DetailText = detail;
        }

        public override string ToString()
        {
            return $"Рост:{Math.Round(weight)}\tВес:{Math.Round(heigh)}\tИMT:{Math.Round(ibm)}";
        }
    }
}
