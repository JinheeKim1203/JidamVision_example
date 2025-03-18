using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JidamVision.Algorithm
{
    public class FmInspAlgorithm : InspAlgorithm
    {

        public int DifferanceGv { get; set; } = 50;

        public int SizeX { get; set; } = 10;
        public int SizeY { get; set; } = 10;


        public override bool DoInspect()
        {
            return true;
        }
    }
}
