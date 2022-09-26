using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Security.Cryptography;
using System.IO;
using System.Collections;
using System.Text;

namespace Oxyzen8SelectorServer.Models
{
    public class ClsGo
    {
        public static int getSelectionType(int _intUnitModelID, int _intOrientationID, int _intAirFlowCFM)
        {
            //int intCFM_Max = 0;
            //int intCFM_Min = 0;
            int intVelocity = 0;
            int intFaceAreaHeight = 0;
            int intFaceAreaWidth = 0;
            string strSelectionType = "";
            int intSelectionTypeID = 0;

            //if (intUnitModelID > 0)
            //{
            //    ClsWFC.get_ddlSavedID(ddlUnitModel, intUnitModelID);
            //}


            //DataTable dtUnitModel = ClsDB.get_dtLive(ClsDBT.strSelUnitModel, ClsWFC.get_ddl_intSelectedItemID(ddlUnitModel));
            //intCFM_Min = Convert.ToInt32(dtUnitModel.Rows[0]["cfm_min"]);
            //intCFM_Max = Convert.ToInt32(dtUnitModel.Rows[0]["cfm_max"]);


            //if (Convert.ToInt32(txbSummerSupplyAirCFM.Text) > intCFM_Max)
            //{
            //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", ClsAlert.get_sbMessage("CFM range for this model [" + intCFM_Min.ToString() + "  -  " + intCFM_Max.ToString() + "]").ToString());
            //    txbSummerSupplyAirCFM.Text = intCFM_Max.ToString();
            //}
            //else if (Convert.ToInt32(txbSummerSupplyAirCFM.Text) < intCFM_Min)
            //{
            //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", ClsAlert.get_sbMessage("CFM range for this model [" + intCFM_Min.ToString() + "  -  " + intCFM_Max.ToString() + "]").ToString());
            //    txbSummerSupplyAirCFM.Text = intCFM_Min.ToString();
            //}
            //else
            //{
            DataTable dtUnitSizeDeratedFlow = new DataTable();
            dtUnitSizeDeratedFlow = ClsDB.get_dtLive(ClsDBT.strSelNovaUnitSize, "unit_model_id", _intUnitModelID);
            dtUnitSizeDeratedFlow = ClsTS.get_dtDataFromImportRows(dtUnitSizeDeratedFlow, "unit_orientation_id", _intOrientationID);

            DataTable dtUnitSizeDecoupled = dtUnitSizeDeratedFlow.Copy();

            dtUnitSizeDeratedFlow = ClsTS.get_dtDataFromImportRows(dtUnitSizeDeratedFlow, "selection_type_id", 1);      //Derated Flowrate
            dtUnitSizeDecoupled = ClsTS.get_dtDataFromImportRows(dtUnitSizeDecoupled, "selection_type_id", 2);          //Decoupled


            intFaceAreaHeight = Convert.ToInt32(dtUnitSizeDeratedFlow.Rows[0]["cabinet_face_area_height"]);
            intFaceAreaWidth = Convert.ToInt32(dtUnitSizeDeratedFlow.Rows[0]["cabinet_face_area_width"]);
            strSelectionType = dtUnitSizeDeratedFlow.Rows[0]["selection_type"].ToString();
            intSelectionTypeID = Convert.ToInt32(dtUnitSizeDeratedFlow.Rows[0]["selection_type_id"]);
            intVelocity = Convert.ToInt32(_intAirFlowCFM / ((intFaceAreaHeight * intFaceAreaWidth) / 144d));

            if (intVelocity > 500)
            {
                intFaceAreaHeight = Convert.ToInt32(dtUnitSizeDecoupled.Rows[0]["cabinet_face_area_height"]);
                intFaceAreaWidth = Convert.ToInt32(dtUnitSizeDecoupled.Rows[0]["cabinet_face_area_width"]);
                strSelectionType = dtUnitSizeDecoupled.Rows[0]["selection_type"].ToString();
                intSelectionTypeID = Convert.ToInt32(dtUnitSizeDecoupled.Rows[0]["selection_type_id"]);
                intVelocity = Convert.ToInt32(_intAirFlowCFM / ((intFaceAreaHeight * intFaceAreaWidth) / 144d));
            }

            //lblVelocity.Text = intVelocity.ToString();
            //lblSelectionType.Text = strSelectionType;
            //lblSelectionType.Attributes["SelectionTypeID"] = intSelectionTypeID.ToString();
            return intSelectionTypeID;
            //}

            //txbSummerReturnAirCFM.Text = txbSummerSupplyAirCFM.Text;
            //txbWinterSupplyAirCFM.Text = txbSummerSupplyAirCFM.Text;
            //txbWinterReturnAirCFM.Text = txbSummerSupplyAirCFM.Text;
        }



        public static string get_strUnitModelColumnName(int _intProductTypeID, int _intUnitTypeID, int _intIsBypass)
        {
            string strUnitModelColumnName = "items";

            switch (_intProductTypeID)
            {
                case ClsID.intProdTypeNovaID:
                    strUnitModelColumnName = _intIsBypass == 1 ? "model_bypass" : "items";
                    break;
                case ClsID.intProdTypeVentumID:
                case ClsID.intProdTypeVentumLiteID:
                    if (_intUnitTypeID == ClsID.intUnitTypeERV_ID)
                    {
                        strUnitModelColumnName = "model_erv";
                    }
                    else if (_intUnitTypeID == ClsID.intUnitTypeHRV_ID)
                    {
                        strUnitModelColumnName = "model_hrv";
                    }
                    break;
                default:
                    break;
            }

            //if (_intProductTypeID == ClsID.intProdTypeNovaID)
            //{
            //    if (_intIsBypass == 1)
            //    {
            //        strUnitModelColumnName = "model_bypass";
            //    }
            //    else
            //    {
            //        strUnitModelColumnName = "items";
            //    }
            //}
            //else if (_intProductTypeID == ClsID.intProdTypeVentumID)
            //{
            //    if (_intUnitTypeID == ClsID.intUnitTypeERV_ID)
            //    {
            //        strUnitModelColumnName = "model_erv";
            //    }
            //    else if (_intUnitTypeID == ClsID.intUnitTypeHRV_ID)
            //    {
            //        strUnitModelColumnName = "model_hrv";
            //    }
            //}

            return strUnitModelColumnName;
        }


        public static DataTable RemoveDuplicateRows(DataTable dTable, string colName)
        {
            Hashtable hTable = new Hashtable();
            ArrayList duplicateList = new ArrayList();

            //Add list of all the unique item value to hashtable, which stores combination of key, value pair.
            //And add duplicate item value in arraylist.
            foreach (DataRow drow in dTable.Rows)
            {
                if (hTable.Contains(drow[colName]))
                    duplicateList.Add(drow);
                else
                    hTable.Add(drow[colName], string.Empty);
            }

            //Removing a list of duplicate items from datatable.
            foreach (DataRow dRow in duplicateList)
                dTable.Rows.Remove(dRow);

            //Datatable which contains unique records will be return as output.
            return dTable;
        }



        public static string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }


        public static string get_strRandomPasswordString(int length)
        {
            const string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "OXY8@O8#OXY8@O8#";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }



        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "OXY8@O8#OXY8@O8#";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
}