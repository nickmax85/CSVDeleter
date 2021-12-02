using CsvHelper;
using CSVReader.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;

namespace CSVReader
{
    class Read
    {
        public Read(string file)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //string file = "logging-2021.10.07.csv";

            using (var reader = new StreamReader(file))
            using (var csv = new CsvReader(reader, CultureInfo.CurrentCulture))
            {
                var records = csv.GetRecords<Log>();

                //foreach (var item in records)
                //{
                //    Debug.WriteLine(item.Te_WE_VL1);
                //    Debug.WriteLine(item.WMZ_actn);
                //    Debug.WriteLine(item.Te_KO_SG);
                //    Debug.WriteLine(item.Te_KO_HG);
                //    Debug.WriteLine(item.Te_KO_VD_p);
                //    Debug.WriteLine(item.SM_OefWert);
                //}

               
                using (var writer = new StreamWriter(path + @"\" + Path.GetFileName(file) + "_NEW.csv"))
                using (var item = new CsvWriter(writer, CultureInfo.CurrentCulture))
                {
                    item.WriteRecords(records);
                }
            }





        }
    }
}
