using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Oxygen8SelectorServer.Models
{
    public class ClsWFC
    {
        public static dynamic get_ddlItemsAdded(DataTable _dt, string _strTextField, string _strValueField)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(_strValueField, typeof(int));
            dt.Columns.Add(_strTextField, typeof(string));

            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[_strValueField] = Convert.ToInt32(_dt.Rows[i][_strValueField]);
                dr[_strTextField] = _dt.Rows[i][_strTextField].ToString();

                dt.Rows.Add(dr);
            }

            return dt;
        }

        public static dynamic get_ddlItemsAddedOnID(DataTable _dt, string _strColumnMultipleID, int _intMatchID, string _strTextField, string _strValueField)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(_strValueField, typeof(int));
            dt.Columns.Add(_strTextField, typeof(string));

            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                string[] strArrID = _dt.Rows[i][_strColumnMultipleID].ToString().Split(new string[1] { "," }, StringSplitOptions.None);

                foreach (string strID in strArrID)
                {
                    if (Convert.ToInt32(strID) == _intMatchID)
                    {
                        DataRow dr = dt.NewRow();
                        dr[_strValueField] = Convert.ToInt32(_dt.Rows[i][_strValueField]);
                        dr[_strTextField] = _dt.Rows[i][_strTextField].ToString();

                        dt.Rows.Add(dr);
                        break;
                    }
                }
            }

            return dt;
        }

        public static dynamic get_ddlItemsAddedOnID(DataTable _dt, string _strColumnMultipleID, int _intMatchID)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("items", typeof(string));

            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                string[] strArrID = _dt.Rows[i][_strColumnMultipleID].ToString().Split(new string[1] { "," }, StringSplitOptions.None);

                foreach (string strID in strArrID)
                {
                    if (Convert.ToInt32(strID) == _intMatchID)
                    {
                        DataRow dr = dt.NewRow();
                        dr["id"] = Convert.ToInt32(_dt.Rows[i]["id"]);
                        dr["items"] = _dt.Rows[i]["items"].ToString();

                        dt.Rows.Add(dr);
                        break;
                    }
                }
            }

            return dt;
        }



        public static dynamic get_ddlItemsAddedOnID(DataTable _dt, string _strLinkColumn, DataTable _dtLink)
        {
            DataTable dt = ClsTS.get_dtSortedASC(_dt, "id");
            DataTable dtLink = ClsTS.get_dtSortedASC(_dtLink, _strLinkColumn);
            int intID = 0;
            int intLinkID = 0;

            DataTable dtSelected = new DataTable();
            dtSelected.Columns.Add("id", typeof(int));
            dtSelected.Columns.Add("items", typeof(string));


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

        public static dynamic get_ddlItemsAddedOnValue(DataTable _dt, string _strLinkColumn, DataTable _dtLink)
        {
            DataTable dt = ClsTS.get_dtSortedASC(_dt, "id");
            DataTable dtLink = ClsTS.get_dtSortedASC(_dtLink, _strLinkColumn);
            string intID = "";
            string intLinkID = "";
            int intDummyID = 0;

            DataTable dtSelected = new DataTable();
            dtSelected.Columns.Add("id", typeof(int));
            dtSelected.Columns.Add("items", typeof(string));


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                intID = dt.Rows[i]["items"].ToString();
                for (int j = 0; j < dtLink.Rows.Count; j++)
                {
                    intLinkID = dtLink.Rows[j][_strLinkColumn].ToString();

                    if (intID == intLinkID)
                    {
                        DataRow dr = dtSelected.NewRow();
                        dr["id"] = ++intDummyID;
                        dr["items"] = dt.Rows[i]["items"].ToString();

                        dtSelected.Rows.Add(dr);
                        break;
                    }
                }
            }

            return dtSelected;
        }
    }
}