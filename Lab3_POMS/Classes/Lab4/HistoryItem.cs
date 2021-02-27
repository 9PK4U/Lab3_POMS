using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Lab3_POMS.Classes.Lab4
{
    [Table("History")]
    public class HistoryItem
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public float Weight { get; set; }
        public float Growth { get; set; }
        public float IBM { get; set; }

        public  string Date { get; set; }

        //public string Text { get {
        //        return ToString();
        //    }
        //    set
        //    {
        //        Text = value;
        //    }
        //}
        public string DetailText { get; set; }
        //public HistoryItem(float weight, float heigh, float ibm, string detail)
        //{
        //    this.weight = weight;
        //    this.heigh = heigh;
        //    this.ibm = ibm;
        //    this.date = DateTime.Now;
        //    DetailText = detail;
        //}
        //static public HistoryItem Builder(float weight, float heigh, float ibm, string detail)
        //{
        //    var item = new HistoryItem();
        //    item.Weight = weight;
        //    item.Growth = heigh;
        //    item.IBM = ibm;
        //    item.Date = DateTime.Now.ToString();
        //    item.DetailText = detail;

            
        //    return item;

        //}
        public override string ToString()
        {
            return $"Рост:{Math.Round(Weight)}\tВес:{Math.Round(Growth)}\tИMT:{Math.Round(IBM)}";
        }
    }
}
