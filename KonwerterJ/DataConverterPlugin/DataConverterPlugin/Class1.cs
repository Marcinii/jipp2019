using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KonwerterJ.Services;
namespace DataConverterPlugin
{

    class KonwerterPlugin
    {

        class Class1 : IConverter
    {




        public string Name => "Data";
        public List<string> Units => new List<string>(new[] { "B", "kB", "MB", "GB" });
        public decimal Convert(string FromCombobox, string ToCombobox, decimal valueFrom)
        {
            decimal kB2B(decimal bajt) =>
             bajt * 1024;
            decimal B2kB(decimal kilobajt) =>
             kilobajt / 1024;
            decimal MB2kB(decimal kilobajt) =>
             kilobajt * 1024M;
            decimal kB2MB(decimal megabajt) =>
            megabajt / 1024M;
            decimal GB2MB(decimal gigabajt) =>
             gigabajt * 1024;
            decimal MB2GB(decimal megabajt) =>
             megabajt / 1024;




            switch (FromCombobox)
            {
                case "B":
                    switch (ToCombobox)
                    {
                        case "kB":
                            return B2kB(valueFrom);
                        case "MB":
                            return B2kB(kB2MB(valueFrom));
                        case "GB":
                            return B2kB(kB2MB(MB2GB(valueFrom)));
                    }
                    break;
                case "kB":
                    switch (ToCombobox)
                    {
                        case "B":
                            return kB2B(valueFrom);
                        case "MB":
                            return kB2MB(valueFrom);
                        case "GB":
                            return kB2MB(MB2GB(valueFrom));
                    }
                    break;
                case "MB":
                    switch (ToCombobox)
                    {
                        case "B":
                            return MB2kB(kB2B(valueFrom));
                        case "kB":
                            return MB2kB(valueFrom);
                        case "GB":
                            return MB2GB(valueFrom);
                    }
                    break;
                case "GB":
                    switch (ToCombobox)
                    {
                        case "B":
                            return GB2MB(MB2kB(kB2B(valueFrom)));
                        case "kB":
                            return GB2MB(MB2kB(valueFrom));
                        case "MB":
                            return GB2MB(valueFrom);

                    }
                    break;

            }
            return 0;


        }
    }
}
}


