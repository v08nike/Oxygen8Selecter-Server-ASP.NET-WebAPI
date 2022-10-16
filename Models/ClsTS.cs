using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Oxygen8SelectorServer.Models
{
    public class ClsTS
    {
        public static string get_strData(DataTable _dt, string _strKeyColumn, string _strKeyRow, string _strMatchColumn)
        {
            string strData = "-999999";

            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                if (_dt.Rows[i][_strKeyColumn].ToString() == _strKeyRow)
                {
                    strData = _dt.Rows[i][_strMatchColumn].ToString();
                    break;
                }
            }

            return strData;
        }

        public static string get_strData(DataTable _dt, string _strKeyColumn, int _intKeyRow, string _strMatchColumn)
        {
            string strData = "";

            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                if (_dt.Rows[i][_strKeyColumn].ToString() == _intKeyRow.ToString())
                {
                    strData = _dt.Rows[i][_strMatchColumn].ToString();
                    break;
                }
            }

            return strData;
        }

        public static DataTable get_dtData(DataTable _dt, string _strKeyColumn, string _strKeyRow)
        {
            DataTable dtData = new DataTable();
            dtData = _dt.Clone();

            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                if (_dt.Rows[i][_strKeyColumn].ToString() == _strKeyRow)
                {
                    dtData.ImportRow(_dt.Rows[i]);
                }
            }

            return dtData;
        }

        public static DataTable get_dtData(DataTable _dt, string _strKeyColumn, int _intKeyRow)
        {
            DataTable dtData = new DataTable();
            dtData = _dt.Clone();

            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                if (_dt.Rows[i][_strKeyColumn].ToString() == _intKeyRow.ToString())
                {
                    dtData.ImportRow(_dt.Rows[i]);
                }
            }

            return dtData;
        }

        public static string get_strItem(DataTable _dt, int _intID)
        {
            // All selection tables have column id for identity and items column for list of items.
            // items column from the tables are used to populate the comboboxes.

            string strItem = "";

            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                if (_dt.Rows[i]["id"].ToString() == _intID.ToString())
                {
                    strItem = _dt.Rows[i]["items"].ToString();
                    break;
                }
            }

            return strItem;
        }

        public static string get_strSelection(DataTable _dt, int _intID, string _strPrefix, string _strSuffix, bool _bolValidateEmptyString, bool _bolValidateNoOrNA)
        {
            string strItem = "";
            string strDisplay = "";

            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                if (_dt.Rows[i]["id"].ToString() == _intID.ToString())
                {
                    if (_dt.Columns.Contains("display"))
                    {
                        strItem = _dt.Rows[i]["display"].ToString();
                    }
                    else
                    {
                        strItem = _dt.Rows[i]["items"].ToString();
                    }
                    break;
                }
            }

            if (_bolValidateEmptyString && _bolValidateNoOrNA)
            {
                if ((strItem != "") && (strItem != "NA"))
                {
                    strDisplay = _strPrefix + strItem + _strSuffix;
                }
            }
            else if (_bolValidateEmptyString)
            {
                if (strItem != "")
                {
                    strDisplay = _strPrefix + strItem + _strSuffix;
                }

            }
            else if (_bolValidateNoOrNA)
            {
                if (strItem != "NA")
                {
                    strDisplay = _strPrefix + strItem + _strSuffix;
                }
                if (strItem != "No")
                {
                    strDisplay = _strPrefix + strItem + _strSuffix;
                }
            }
            else
            {
                strDisplay = _strPrefix + strItem + _strSuffix;
            }

            return strDisplay;
        }


        public static string get_strSelection(DataTable _dt, int _intID, string _strPrefix, string _strSuffix)
        {
            string strItem = "";
            string strDisplay = "";

            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                if (_dt.Rows[i]["id"].ToString() == _intID.ToString())
                {
                    strItem = _dt.Rows[i]["items"].ToString();

                    if (strItem == "Yes")
                    {
                        strDisplay = _strPrefix + _strSuffix;
                    }
                    else
                    {
                        strDisplay = _strPrefix + strItem + _strSuffix;
                    }
                }
            }

            if ((strItem == "") || (strItem == "No") || (strItem == "NA") || (strItem == "Not Applicable"))
            {
                strDisplay = "";
            }

            return strDisplay;
        }

        public static string get_strNoSelection(DataTable _dt, int _intID, string _strPrefix, string _strSuffix)
        {
            string strItem = "";
            string strDisplay = "";

            strDisplay = _strPrefix + _strSuffix;

            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                if (_dt.Rows[i]["id"].ToString() == _intID.ToString())
                {
                    strItem = _dt.Rows[i]["items"].ToString();
                    break;
                }
            }

            if ((strItem != "") && (strItem != "No") && (strItem != "NA") && (strItem != "Not Applicable"))
            {
                strDisplay = "";
            }

            return strDisplay;
        }


        //------------------------------------------------------------------------------
        public static string get_strItemOnChecked(int _intChecked, string _strStringIfChecked, string _strStringIfNotChecked, string _strPrefix, string _strSuffix)
        {
            string str = "";

            if (_intChecked == 1)
            {
                str = _strPrefix + _strStringIfChecked + _strSuffix;
            }
            else
            {
                str = _strStringIfNotChecked;
            }

            return str;
        }

        public static string get_strItemOnQty(int _intQty, string _strString, string _strPrefix, string _strSuffix)
        {
            string str = "";

            if (_intQty > 0)
            {
                str = _strPrefix + _strString + _strSuffix;
            }

            return str;
        }


        public static string get_strItemOnNoQty(int _intQty, string _strString, string _strPrefix, string _strSuffix)
        {
            string str = "";

            if (_intQty == 0)
            {
                str = _strPrefix + _strString + _strSuffix;
            }

            return str;
        }

        public static string get_strFormated(string _strMain, string _strPrefix, string _strSuffix)
        {
            return _strPrefix + _strMain.ToString() + _strSuffix;
        }

        public static string get_strItemOnString(string _strString, string _strPrefix, string _strSuffix)
        {
            string str = "";

            if ((_strString != "") && (_strString != "Not Applicable"))
            {
                str = _strPrefix + _strString + _strSuffix;
            }

            return str;
        }

        public static string get_strItemOnEmpty(string _strString, string _strPrefix, string _strSuffix)
        {
            string str = "";

            if (_strString != "")
            {
                str = _strPrefix + _strString + _strSuffix;
            }

            return str;
        }

        public static string get_strItemOnNotApplicable(string _strString, string _strPrefix, string _strSuffix)
        {
            string str = "";

            if (_strString != "Not Applicable")
            {
                str = _strPrefix + _strString + _strSuffix;
            }

            return str;
        }

        public static int get_intItemID(DataTable _dt, string _strItem)
        {
            // All selection tables have column id for identity and items column for list of items.
            // items column from the tables are used to populate the comboboxes.

            int intID = -999999;

            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                if (_dt.Rows[i]["items"].ToString() == _strItem.ToString())
                {
                    intID = Convert.ToInt32(_dt.Rows[i]["id"]);
                    break;
                }
            }

            return intID;
        }

        public static string get_strNomenclature(DataTable _dt, int _intID)
        {
            string strNomenclature = "";

            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                if (_dt.Rows[i]["id"].ToString() == _intID.ToString())
                {
                    strNomenclature = _dt.Rows[i]["nomenclature"].ToString();
                    break;
                }
            }

            return strNomenclature;
        }

        //public static string get_strSupplierNomenclature(DataTable _dt, int _intID)
        //{
        //    string strSupplierNomenclature = "";

        //    for (int i = 0; i < _dt.Rows.Count; i++)
        //    {
        //        if (_dt.Rows[i]["id"].ToString() == _intID.ToString())
        //        {
        //            strSupplierNomenclature = _dt.Rows[i]["supplier_nomenclature"].ToString();
        //            break;
        //        }
        //    }

        //    return strSupplierNomenclature;
        //}

        public static string get_strItem(DataTable _dt, string _strColumnMultipleID, int _intMatchID)
        {
            string strItem = "";

            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                string[] strArrItem = _dt.Rows[i][_strColumnMultipleID].ToString().Split(new string[1] { "," }, StringSplitOptions.None);

                foreach (string strID in strArrItem)
                {
                    if (Convert.ToInt32(strID) == _intMatchID)
                    {
                        strItem = _dt.Rows[i]["items"].ToString();
                        break;
                    }
                }
            }

            return strItem;
        }

        public static int get_intID(DataTable _dt, string _strColumnMultipleID, int _intMatchID)
        {
            int intID = 0;

            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                string[] strArrID = _dt.Rows[i][_strColumnMultipleID].ToString().Split(new string[1] { "," }, StringSplitOptions.None);

                foreach (string strID in strArrID)
                {
                    if (Convert.ToInt32(strID) == _intMatchID)
                    {
                        intID = Convert.ToInt32(_dt.Rows[i]["id"]);
                        break;
                    }
                }
            }

            return intID;
        }

        public static DataTable get_dtDataFromImportRows(DataTable _dt, string _strColumnMultipleID, int _intMatchID)
        {
            DataTable dtData = new DataTable();
            dtData = _dt.Clone();

            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                string[] strArrID = _dt.Rows[i][_strColumnMultipleID].ToString().Split(new string[1] { "," }, StringSplitOptions.None);

                foreach (string strID in strArrID)
                {
                    if (strID != "")
                    {
                        if (Convert.ToInt32(strID) == _intMatchID)
                        {
                            dtData.ImportRow(_dt.Rows[i]);
                        }
                    }
                }
            }

            return dtData;
        }

        public static DataTable get_dtDataFromImportRows(DataTable _dt, string _strColumnMultipleItem, string _strMatchItem)
        {
            DataTable dtData = new DataTable();
            dtData = _dt.Clone();

            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                string[] strArrItem = _dt.Rows[i][_strColumnMultipleItem].ToString().Split(new string[1] { "," }, StringSplitOptions.None);

                foreach (string strItem in strArrItem)
                {
                    if (strItem != "")
                    {
                        if (strItem == _strMatchItem)
                        {
                            dtData.ImportRow(_dt.Rows[i]);
                        }
                    }
                }
            }

            return dtData;
        }


        public static DataTable get_dtFromLink(DataTable _dt, string _strLinkColumn, DataTable _dtLink, string _strSortColumn)
        {
            DataTable dt = ClsTS.get_dtSortedASC(_dt, "id");
            DataTable dtLink = ClsTS.get_dtSortedASC(_dtLink, _strLinkColumn);
            int intID = 0;
            int intLinkID = 0;

            DataTable dtSelected = new DataTable();
            dtSelected.Columns.Add("id", typeof(int));
            dtSelected.Columns.Add("items", typeof(string));

            DataColumnCollection columns = _dt.Columns;
            if (columns.Contains("bypass_exist"))
            {
                dtSelected.Columns.Add("bypass_exist", typeof(int));
                dtSelected.Columns.Add("bypass_exist_horizontal_unit", typeof(int));
                dtSelected.Columns.Add("model_bypass", typeof(string));
            }


            if (_strSortColumn != "")
            {
                dtSelected.Columns.Add(_strSortColumn, typeof(int));
            }


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                intID = Convert.ToInt32(dt.Rows[i]["id"]);
                for (int j = 0; j < dtLink.Rows.Count; j++)
                {
                    intLinkID = Convert.ToInt32(dtLink.Rows[j][_strLinkColumn]);

                    if (intID == intLinkID)
                    {
                        DataRow dr = dtSelected.NewRow();
                        dr["id"] = Convert.ToInt32(dt.Rows[i]["id"]);
                        dr["items"] = dt.Rows[i]["items"].ToString();

                        if (_strSortColumn != "")
                        {
                            dr[_strSortColumn] = Convert.ToInt32(dt.Rows[i][_strSortColumn]);
                        }

                        if (columns.Contains("bypass_exist"))
                        {
                            dr["bypass_exist"] = dt.Rows[i]["bypass_exist"].ToString();
                            dr["bypass_exist_horizontal_unit"] = dt.Rows[i]["bypass_exist_horizontal_unit"].ToString();
                            dr["model_bypass"] = dt.Rows[i]["model_bypass"].ToString();
                        }

                        dtSelected.Rows.Add(dr);
                        break;
                    }

                    if (intLinkID > intID)
                    {
                        break;
                    }
                }
            }

            return dtSelected;
        }



        public static DataTable get_dtSortedASC(DataTable _dt, string _strColumn)
        {
            DataView dv = new DataView(_dt);
            dv.Sort = _strColumn + " ASC";
            DataTable dt = dv.ToTable();

            return dt;
        }

        public static DataTable get_dtSortedDESC(DataTable _dt, string _strColumn)
        {
            DataView dv = new DataView(_dt);
            dv.Sort = _strColumn + " DESC";
            DataTable dt = dv.ToTable();

            return dt;
        }
    }
}