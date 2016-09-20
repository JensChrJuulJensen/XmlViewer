using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlFiller
{
    public class tagBag
    {
        public tagBag()
        {

        }
        public tagBag(Type feltType)
        {
            FeltType = feltType;
        }


        public Type FeltType { get; set; }
        public object DataIndhold { get; set; }
        public string Navn { get; set; }
    }
}
