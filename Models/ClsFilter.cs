using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Oxyzen8SelectorServer.Models
{
    public class ClsFilter : ClsComponent
    {
        private int intJobID = 0;
        private int intUnitNo = 0;
        private int intComponentID = 0;
        //private int intSupplierID = 0;
        private int intLocationID = 0;
        private int intTypeID = 0;
        private int intModelID = 0;
        private int intOptionID = 0;
        private double dblPressureDrop = 0d;
        private double dblPressureDropMin = 0d;
        private double dblPressureDropMax = 0d;
        //private double dblSupplyPD = 0d;
        //private double dblExhaustPD = 0d;

        private string strLocation = "";
        private string strType = "";
        private string strModel = "";
        private string strOption = "";
        private string strMounting = "";

        private double dblDepth = 0d;

        public ClsFilter()
        {
        }

        public ClsFilter(int _intJobID,
                                    int _intUnitNo,
                                    int _intLocationID,
                                    int _intModelID,
                                    double _dblPressureDrop)
        {
            intJobID = _intJobID;
            intUnitNo = _intUnitNo;
            //intComponentID = ClsID.intCompFilterID;
            //intSupplierID = ClsID.intSupplierDAFCO_ID;
            //intLocationID = _intLocationID;
            intModelID = _intModelID;
            //dblPressureDrop = 0.1d;
            dblPressureDrop = _dblPressureDrop;

            setInputData();
        }


        public void setInputData()
        {
            //strLocation = ClsDB.get_dtByID(ClsDBT.strSelFilterLocation, intLocationID).Rows[0]["items"].ToString();
            DataTable dt = ClsDB.get_dtByID(ClsDBT.strSelFilterModel, intModelID);
            strModel = dt.Rows[0]["items"].ToString();
            dblDepth = Convert.ToDouble(dt.Rows[0]["depth"]);
            //dblPressureDrop = Convert.ToDouble(dt.Rows[0]["pressure_drop"]);
            dblPressureDropMin = Convert.ToDouble(dt.Rows[0]["pressure_drop_min"]);
            dblPressureDropMax = Convert.ToDouble(dt.Rows[0]["pressure_drop_max"]);
        }

        public void CalculatePerformance()
        {
        }

        public override int get_intComponentID()
        {
            return intComponentID;
        }

        //public override string get_strDescription()
        //{
        //    return strLocation + " - " + strModel;
        //}


        public double get_dblPressureDrop()
        {
            return dblPressureDrop;
        }


        public double get_dblPressureDropMin()
        {
            return dblPressureDropMin;
        }

        public double get_dblPressureDropMax()
        {
            return dblPressureDropMax;
        }


        public string get_strModel()
        {
            return strModel;
        }
    }
}