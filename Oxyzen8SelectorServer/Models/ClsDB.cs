using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.IO;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;

namespace Oxyzen8SelectorServer.Models
{
    public class ClsDB  //DB: Database
    {
        private static MySqlConnection MySqlConn;
        private static string server;
        private static string port;
        private static string database;
        private static string uid;
        private static string password;

        #region MySQL
        private static string get_strConnection()
        {
            //server = "173.248.135.23";
            //database = "db_oxygen8_test";
            //uid = "unitdes_user_remote";
            //password = "heatAir_03";
            //string strConnString = "Server=" + server + ";" + "Database=" + database + ";" + "Uid=" + uid + ";" + "Pwd=" + password;


            server = "localhost";
            database = "db_oxygen8_test";
            uid = "root";
            password = "";
            string strConnString = "Server=" + server + ";" + "Database=" + database + ";" + "Uid=" + uid + ";" + "Pwd=" + password;

            return strConnString;
        }


        //private static void Initialize()
        //{
        //    ////server = "localhost";
        //    //server = "my01.everleap.com";
        //    //database = "MySQL_2817_unitdesdb";
        //    //uid = "udwuser01";
        //    //password = "heatAir_03";


        //    //server = "173.248.150.198";
        //    //database = "db_udw_fresh_air";
        //    //uid = "udw_user01";
        //    //password = "heatAir_03";

        //    //string strConnString = @"Server=" + server + ";" + "Database=" + database + ";" + "Uid=" + uid + ";" + "Pwd=" + password + "; Initial Catalog = database; Integrated Security = true";
        //    ////new MySqlConnection(@"Data Source = 000.000.00.000;username=*******;password=******; Initial Catalog = database; Integrated Security = true")


        //    //server = "localhost";
        //    //database = "db_udw_fresh_air";
        //    //uid = "udw_user01";
        //    //password = "heatAir_03";


        //    //server = "173.248.150.198";
        //    //database = "db_oxygen8_selector";
        //    //uid = "test_o8";
        //    //password = "Test_Oxy8!";
        //    //string strConnString = "Server=" + server + ";" + "Database=" + database + ";" + "Uid=" + uid + ";" + "Pwd=" + password;


        //    server = "localhost";
        //    database = "db_oxygen8_selector";
        //    uid = "oxygen8_user01";
        //    password = "heatAir_03";
        //    string strConnString = "Server=" + server + ";" + "Database=" + database + ";" + "Uid=" + uid + ";" + "Pwd=" + password;


        //    MySqlConn = new MySqlConnection(strConnString);
        //}


        //open connection to database

        private static void OpenConnection()
        {
            //Initialize();
            MySqlConn = new MySqlConnection(get_strConnection());
            MySqlConn.Open();
        }


        //Close connection
        private static void CloseConnection()
        {
            MySqlConn.Close();
        }


        //Select statement
        public static DataTable get_dtSQL(string _strQuery)
        {
            string strQuery = _strQuery;

            DataTable dt = new DataTable();

            OpenConnection();
            MySqlCommand cmd = new MySqlCommand(strQuery, MySqlConn);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            dt.Load(dataReader);

            dataReader.Close();


            CloseConnection();

            return dt;
        }

        public static void ExecuteSQL(string _strSQL)
        {
            OpenConnection();
            MySqlCommand cmd = new MySqlCommand(_strSQL, MySqlConn);
            cmd.ExecuteReader();


            CloseConnection();
        }

        #endregion MySQL


        public static DataTable get_dt(string _strTableName)
        {
            return get_dtSQL("SELECT * FROM " + _strTableName);
        }

        public static DataTable get_dt(string _strTableName, string _strWHEREClause)
        {
            return get_dtSQL("SELECT * FROM " + _strTableName + _strWHEREClause);
        }

        public static DataTable get_dtByQuery(string _strSQL)
        {
            return get_dtSQL(_strSQL);
        }

        public static DataTable get_dtLive(string _strTableName)
        {
            return get_dtSQL("SELECT * FROM " + _strTableName);
        }

        public static DataTable get_dtLive(string _strTableName, string _strWHEREClause)
        {
            return get_dtSQL("SELECT * FROM " + _strTableName + _strWHEREClause);
        }

        public static DataTable get_dtLive(string _strTableName, int _intID)
        {
            return get_dtSQL("SELECT * FROM " + _strTableName + " WHERE id = " + _intID.ToString());
        }


        public static DataTable get_dtLive(string _strTableName, string _strSpecialColumn, int _intSpecialColumnID)
        {
            return get_dtSQL("SELECT * FROM " + _strTableName + " WHERE " + _strSpecialColumn + " = " + _intSpecialColumnID.ToString());
        }


        //public static DataTable get_dtLive(string _strTableName, string _strSpecialColumn, string _intSpecialColumnValue)
        //{
        //    return get_dtSQL("SELECT * FROM " + _strTableName + " WHERE " + _strSpecialColumn + " = '" + _intSpecialColumnValue + "'");
        //}


        //public static DataTable get_dtLiveColumnID(string _strTableName, string _strColumnID, int _intID)
        //{
        //    DataSet dsLocal = new DataSet();

        //    set_sqlConnection();
        //    sqlCon.Open();

        //    SqlDataAdapter daLocal = new System.Data.SqlClient.SqlDataAdapter("SELECT * FROM " + _strTableName + " WHERE " + _strColumnID + " = " + _intID.ToString(), sqlCon);
        //    daLocal.Fill(dsLocal, _strTableName);

        //    sqlCon.Close();
        //    sqlCon.Dispose();

        //    return dsLocal.Tables[0];
        //}

        //public static DataTable get_dtLiveAll(string _strTableName, int _intID)
        //{
        //    DataSet dsLocal = new DataSet();

        //    set_sqlConnection();
        //    sqlCon.Open();

        //    SqlDataAdapter daLocal = new System.Data.SqlClient.SqlDataAdapter("SELECT * FROM " + _strTableName + " WHERE enabled = 0 OR enabled = 1 OR id = " + _intID.ToString(), sqlCon);
        //    daLocal.Fill(dsLocal, _strTableName);

        //    sqlCon.Close();
        //    sqlCon.Dispose();

        //    return dsLocal.Tables[0];
        //}


        //public static DataTable get_dtLiveEnabled(string _strTableName)
        //{
        //    return get_dtSQL("SELECT * FROM " + _strTableName + " WHERE enabled = 1");
        //}


        //public static DataTable get_dtLiveEnabledInternal(string _strTableName)
        //{
        //    return get_dtSQL("SELECT * FROM " + _strTableName + " WHERE enabled_internal = 1");
        //}


        public static DataTable get_dtByID(string _strTableName, int _intID)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());

            try
            {
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = "SELECT * FROM " + _strTableName + " WHERE id = @ID";
                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@ID", _intID);
                Conn.Open();
                Comm.ExecuteNonQuery();
                adp.Fill(ds, "DataTable");
            }
            catch
            {
                return null;
            }
            finally
            {
                Conn.Close();
            }

            return ds.Tables[0];
        }


        public static DataTable get_dtByID(string _strTableName, string _strColumnName, int _intID)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());

            try
            {
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = "SELECT * FROM " + _strTableName + " WHERE `" + _strColumnName + "` = @ID";
                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@ID", _intID);
                Conn.Open();
                Comm.ExecuteNonQuery();
                adp.Fill(ds, "DataTable");
            }
            catch
            {
                return null;
            }
            finally
            {
                Conn.Close();
            }

            return ds.Tables[0];
        }

        public static DataTable get_dtByValue(string _strTableName, string _strColumn, string _strValue)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());

            string strColumnName = "tbl." + _strColumn;

            try
            {
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = "SELECT * FROM " + _strTableName + " tbl WHERE " + strColumnName + " = @ColumnValue";
                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@ColumnValue", _strValue);
                Conn.Open();

                Comm.ExecuteNonQuery();
                adp.Fill(ds, "DataTable");
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                Conn.Close();
            }

            return ds.Tables[0];
        }

        public static DataTable get_dtLiveEnabled(string _strTableName)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());

            try
            {
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = "SELECT * FROM " + _strTableName + " WHERE enabled = 1";
                Comm.Parameters.Clear();
                //Comm.Parameters.AddWithValue("@ID", _intID);
                Conn.Open();
                Comm.ExecuteNonQuery();
                adp.Fill(ds, "DataTable");
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Conn.Close();
            }

            return ds.Tables[0];
        }


        public static DataTable get_dtLiveEnabledInternal(string _strTableName)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());

            try
            {
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = "SELECT * FROM " + _strTableName + " WHERE enabled_internal = 1";
                Comm.Parameters.Clear();
                //Comm.Parameters.AddWithValue("@ID", _intID);
                Conn.Open();
                Comm.ExecuteNonQuery();
                adp.Fill(ds, "DataTable");
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Conn.Close();
            }

            return ds.Tables[0];
        }


        public static DataTable get_dtLiveEnabled(string _strTableName, int _intID)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());

            try
            {
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = "SELECT * FROM " + _strTableName + " WHERE enabled = 1 OR id = @ID";
                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@ID", _intID);
                Conn.Open();
                Comm.ExecuteNonQuery();
                adp.Fill(ds, "DataTable");
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Conn.Close();
            }

            return ds.Tables[0];
        }


        public static DataTable get_dtLiveEnabled(string _strTableName, int _intID, string _strOrderBy)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());

            try
            {
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = "SELECT * FROM " + _strTableName + " WHERE (enabled = 1 OR id = @ID) ORDER BY " + _strOrderBy;
                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@ID", _intID);
                Conn.Open();
                Comm.ExecuteNonQuery();
                adp.Fill(ds, "DataTable");
            }
            catch
            {
                return null;
            }
            finally
            {
                Conn.Close();
            }

            return ds.Tables[0];
        }

        public static DataTable get_dtLiveEnabled(string _strTableName, string _strColumn, string _strValue)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());

            try
            {
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = "SELECT * FROM " + _strTableName + " WHERE enabled = 1 OR " + _strColumn + "='@Value'";
                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@Value", _strValue);
                Conn.Open();
                Comm.ExecuteNonQuery();
                adp.Fill(ds, "DataTable");
            }
            catch
            {
                return null;
            }
            finally
            {
                Conn.Close();
            }

            return ds.Tables[0];
        }


        public static DataTable get_dtLiveEnabled(string _strTableName, string _strSpecialColumnName, int _intSpecialColumnID, int _intSavedID)
        {
            return get_dtSQL("SELECT * FROM " + _strTableName + " WHERE (enabled = 1 AND " + _strSpecialColumnName + " = " + _intSpecialColumnID.ToString() + ") OR id = " + _intSavedID.ToString());
        }


        public static DataTable get_dtLive(string _strTableName, string _strSpecialColumnName, int _intSpecialColumnID, int _intSavedID)
        {
            return get_dtSQL("SELECT * FROM " + _strTableName + " WHERE " + _strSpecialColumnName + " = " + _intSpecialColumnID.ToString() + " OR id = " + _intSavedID.ToString());
        }



        #region Save Job
        public static DataTable SaveJob(int _intJobID, int _intCreatedUserID, int _intRevisedUserID, string _strJobName, string _strReferenceNo, int _intRevisionNo, string _strCompanyName, string _strContactName, int _intCompanyNameID, int _intContactNameID,
                                        int _intApplicationID, string _strApplicationOther, int _intBasisOfDesignID, int _intUOM_ID, string _strCountry, string _strProvState, int _intCityID, int _intDesignConditionsID, int _intAltitude,
                                        double _dblSummerOutdoorAirDB, double _dblSummerOutdoorAirWB, double _dblSummerOutdoorAirRH, double _dblWinterOutdoorAirDB, double _dblWinterOutdoorAirWB, double _dblWinterOutdoorAirRH,
                                        double _dblSummerReturnAirDB, double _dblSummerReturnAirWB, double _dblSummerReturnAirRH, double _dblWinterReturnAirDB, double _dblWinterReturnAirWB, double _dblWinterReturnAirRH,
                                        string _strCreatedDate, string _strRevisedDate, int _intIsTesNewPrice)
        {
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());
            int intLastID = 0;
            string strQuery = "";

            DataSet ds = new DataSet();
            DataTable dt = new DataTable("tblSaveProjectInfo");
            dt.Columns.Add("id", typeof(Int32));
            dt.Columns.Add("ErrorMsg", typeof(string));
            DataRow dr;


            Comm.Parameters.Clear();

            try
            {
                //Comm.CommandType = CommandType.StoredProcedure;

                if (_intJobID > 0)
                {
                    strQuery = "UPDATE `sav_job` SET `created_user_id`=@CreatedUserID,`revised_user_id`=@RevisedUserID,`job_name`=@JobName, `reference_no`=@ReferenceNo, `revision_no`=@RevisionNo, `company_name`=@CompanyName, `contact_name`=@ContactName,`company_name_id`=@CompanyNameID, `contact_name_id`=@ContactNameID, " +
                                        "`application_id`=@ApplicationID, `application_other`=@ApplicationOther, `basis_of_design_id`=@BasisOfDesignID, `uom_id`=@UOM_ID, `country`=@Country, `prov_state`=@ProvState, `city_id`=@CityID, `design_conditions_id`=@DesignConditionsID, `altitude`=@Altitude, " +
                                        "`summer_outdoor_air_db`=@SummerOutdoorAirDB, `summer_outdoor_air_wb`=@SummerOutdoorAirWB, `summer_outdoor_air_rh`=@SummerOutdoorAirRH, " +
                                        "`winter_outdoor_air_db`=@WinterOutdoorAirDB, `winter_outdoor_air_wb`=@WinterOutdoorAirWB, `winter_outdoor_air_rh`=@WinterOutdoorAirRH, " +
                                        "`summer_return_air_db`=@SummerReturnAirDB, `summer_return_air_wb`=@SummerReturnAirWB, `summer_return_air_rh`=@SummerReturnAirRH, " +
                                        "`winter_return_air_db`=@WinterReturnAirDB, `winter_return_air_wb`=@WinterReturnAirWB, `winter_return_air_rh`=@WinterReturnAirRH, " +
                                        "`created_date`=@CreatedDate,`revised_date`=@RevisedDate,`is_test_new_price`=@IsTestNewPrice " +
                                        "WHERE `id`=@JobID";

                    Comm.Parameters.AddWithValue("@JobID", _intJobID);
                }
                else
                {
                    strQuery = "INSERT INTO `sav_job` (`created_user_id`, `revised_user_id`, `job_name`, `reference_no`, `revision_no`, `company_name`, `contact_name`, `company_name_id`, `contact_name_id`, `application_id`, `application_other`, " +
                                        "`basis_of_design_id`, `uom_id`, `country`, `prov_state`, `city_id`, `design_conditions_id`, `altitude`, " +
                                        "`summer_outdoor_air_db`, `summer_outdoor_air_wb`, `summer_outdoor_air_rh`, `winter_outdoor_air_db`, `winter_outdoor_air_wb`, `winter_outdoor_air_rh`, " +
                                        "`summer_return_air_db`, `summer_return_air_wb`, `summer_return_air_rh`, `winter_return_air_db`, `winter_return_air_wb`, `winter_return_air_rh`, " +
                                        "`created_date`, `revised_date`,`is_test_new_price`) " +
                                        "VALUES (@CreatedUserID, @RevisedUserID, @JobName, @ReferenceNo, @RevisionNo, @CompanyName, @ContactName, @CompanyNameID, @ContactNameID, @ApplicationID, @ApplicationOther, " +
                                        "@BasisOfDesignID, @UOM_ID, @Country, @ProvState, @CityID, @DesignConditionsID, @Altitude, " +
                                        "@SummerOutdoorAirDB, @SummerOutdoorAirWB, @SummerOutdoorAirRH, @WinterOutdoorAirDB, @WinterOutdoorAirWB, @WinterOutdoorAirRH, " +
                                        "@SummerReturnAirDB, @SummerReturnAirWB, @SummerReturnAirRH, @WinterReturnAirDB, @WinterReturnAirWB, @WinterReturnAirRH, " +
                                        "@CreatedDate, @RevisedDate, @IsTestNewPrice)";
                }


                Comm.CommandType = CommandType.Text;
                Comm.CommandText = strQuery;
                Comm.Parameters.AddWithValue("@CreatedUserID", _intCreatedUserID);
                Comm.Parameters.AddWithValue("@RevisedUserID", _intRevisedUserID);
                Comm.Parameters.AddWithValue("@JobName", _strJobName);
                //Comm.Parameters.AddWithValue("@RepID", _intRepID);
                Comm.Parameters.AddWithValue("@ReferenceNo", _strReferenceNo);
                Comm.Parameters.AddWithValue("@RevisionNo", _intRevisionNo);
                Comm.Parameters.AddWithValue("@CompanyName", _strCompanyName);
                Comm.Parameters.AddWithValue("@ContactName", _strContactName);
                Comm.Parameters.AddWithValue("@CompanyNameID", _intCompanyNameID);
                Comm.Parameters.AddWithValue("@ContactNameID", _intContactNameID);
                Comm.Parameters.AddWithValue("@ApplicationID", _intApplicationID);
                Comm.Parameters.AddWithValue("@ApplicationOther", _strApplicationOther);
                Comm.Parameters.AddWithValue("@BasisOfDesignID", _intBasisOfDesignID);
                Comm.Parameters.AddWithValue("@UOM_ID", _intUOM_ID);
                Comm.Parameters.AddWithValue("@Country", _strCountry);
                Comm.Parameters.AddWithValue("@ProvState", _strProvState);
                Comm.Parameters.AddWithValue("@CityID", _intCityID);
                Comm.Parameters.AddWithValue("@DesignConditionsID", _intDesignConditionsID);
                Comm.Parameters.AddWithValue("@Altitude", _intAltitude);
                Comm.Parameters.AddWithValue("@SummerOutdoorAirDB", _dblSummerOutdoorAirDB);
                Comm.Parameters.AddWithValue("@SummerOutdoorAirWB", _dblSummerOutdoorAirWB);
                Comm.Parameters.AddWithValue("@SummerOutdoorAirRH", _dblSummerOutdoorAirRH);
                Comm.Parameters.AddWithValue("@WinterOutdoorAirDB", _dblWinterOutdoorAirDB);
                Comm.Parameters.AddWithValue("@WinterOutdoorAirWB", _dblWinterOutdoorAirWB);
                Comm.Parameters.AddWithValue("@WinterOutdoorAirRH", _dblWinterOutdoorAirRH);
                Comm.Parameters.AddWithValue("@SummerReturnAirDB", _dblSummerReturnAirDB);
                Comm.Parameters.AddWithValue("@SummerReturnAirWB", _dblSummerReturnAirWB);
                Comm.Parameters.AddWithValue("@SummerReturnAirRH", _dblSummerReturnAirRH);
                Comm.Parameters.AddWithValue("@WinterReturnAirDB", _dblWinterReturnAirDB);
                Comm.Parameters.AddWithValue("@WinterReturnAirWB", _dblWinterReturnAirWB);
                Comm.Parameters.AddWithValue("@WinterReturnAirRH", _dblWinterReturnAirRH);
                Comm.Parameters.AddWithValue("@CreatedDate", _strCreatedDate);
                Comm.Parameters.AddWithValue("@RevisedDate", _strRevisedDate);
                Comm.Parameters.AddWithValue("@IsTestNewPrice", _intIsTesNewPrice);
                //Comm.Parameters.AddWithValue("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                Conn.Open();
                Comm.ExecuteNonQuery();


                if (_intJobID == 0)
                {

                }


                if (_intJobID > 0)
                {
                    intLastID = _intJobID;
                }
                else
                {
                    strQuery = "SELECT MAX(id) AS ID FROM `sav_job` WHERE `created_user_id`=@CreatedUserID";
                    Comm.CommandType = CommandType.Text;
                    Comm.CommandText = strQuery;
                    Comm.ExecuteNonQuery();

                    adp.Fill(ds, "DataTable");
                    //intLastID = Convert.ToInt32(Comm.Parameters["@ID"].Value);
                    intLastID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                }

                //Conn.Close();

                dr = dt.NewRow();
                dr["id"] = intLastID;
                dr["ErrorMsg"] = "";
                dt.Rows.Add(dr);

                return dt;

                //return intLastID.ToString();
            }
            catch (Exception ex)
            {
                dr = dt.NewRow();
                dr["id"] = -1;
                dr["ErrorMsg"] = ex.Message.ToString();
                dt.Rows.Add(dr);

                return dt;
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion


        #region Save Project Info
        public static DataTable SaveProjectInfo(int _intJobID, int _intCreatedUserID, int _intRevisedUserID, string _strJobName, string _strReferenceNo, int _intRevisionNo,
                                                string _strCompanyName, string _strContactName, int _intCompanyNameID, int _intContactNameID,
                                                int _intApplicationID, string _strApplicationOther, int _intBasisOfDesignID, string _strCreatedDate, string _strRevisedDate)
        {
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());
            int intLastID = 0;
            string strQuery = "";

            DataSet ds = new DataSet();
            DataTable dt = new DataTable("tblSaveProjectInfo");
            dt.Columns.Add("id", typeof(Int32));
            dt.Columns.Add("ErrorMsg", typeof(string));
            DataRow dr;


            Comm.Parameters.Clear();

            try
            {
                //Comm.CommandType = CommandType.StoredProcedure;

                if (_intJobID > 0)
                {
                    strQuery = "UPDATE `sav_job` SET `created_user_id`=@CreatedUserID,`revised_user_id`=@RevisedUserID,`job_name`=@JobName, `reference_no`=@ReferenceNo, `revision_no`=@RevisionNo, " +
                                                    "`company_name`=@CompanyName, `contact_name`=@ContactName, `company_name_id`=@CompanyNameID, `contact_name_id`=@ContactNameID, `application_id`=@ApplicationID, " +
                                                    " `application_other`=@ApplicationOther, `basis_of_design_id`=@BasisOfDesignID," +
                                                    "`created_date`=@CreatedDate,`revised_date`=@RevisedDate " +
                                                    "WHERE `id`=@JobID";

                    Comm.Parameters.AddWithValue("@JobID", _intJobID);
                }


                Comm.CommandType = CommandType.Text;
                Comm.CommandText = strQuery;
                Comm.Parameters.AddWithValue("@CreatedUserID", _intCreatedUserID);
                Comm.Parameters.AddWithValue("@RevisedUserID", _intRevisedUserID);
                Comm.Parameters.AddWithValue("@JobName", _strJobName);
                //Comm.Parameters.AddWithValue("@RepID", _intRepID);
                Comm.Parameters.AddWithValue("@ReferenceNo", _strReferenceNo);
                Comm.Parameters.AddWithValue("@RevisionNo", _intRevisionNo);
                Comm.Parameters.AddWithValue("@CompanyName", _strCompanyName);
                Comm.Parameters.AddWithValue("@ContactName", _strContactName);
                Comm.Parameters.AddWithValue("@CompanyNameID", _intCompanyNameID);
                Comm.Parameters.AddWithValue("@ContactNameID", _intContactNameID);
                Comm.Parameters.AddWithValue("@ApplicationID", _intApplicationID);
                Comm.Parameters.AddWithValue("@ApplicationOther", _strApplicationOther);
                Comm.Parameters.AddWithValue("@BasisOfDesignID", _intBasisOfDesignID);
                Comm.Parameters.AddWithValue("@CreatedDate", _strCreatedDate);
                Comm.Parameters.AddWithValue("@RevisedDate", _strRevisedDate);
                //Comm.Parameters.AddWithValue("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                Conn.Open();
                Comm.ExecuteNonQuery();


                dr = dt.NewRow();
                dr["id"] = _intJobID;
                dr["ErrorMsg"] = "";
                dt.Rows.Add(dr);

                return dt;
            }
            catch (Exception ex)
            {
                dr = dt.NewRow();
                dr["id"] = -1;
                dr["ErrorMsg"] = ex.Message.ToString();
                dt.Rows.Add(dr);

                return dt;
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion


        #region Save General
        public static DataTable SaveGeneral(int _intJobID, int _intUnitNo, string _strTag, int _intQty, int _intProductTypeID, int _intUnitTypeID, int _intIsBypass, int _intUnitModelID, int _intSelectionTypeID, int _intLocationID, int _intIsDownshot, int _intOrientationID,
                                            int _intControlsPreferenceID, double _dblUnitHeight, double _dblUnitWidth, double _dblUnitLength, double _dblUnitWeight, int _intVoltageID, int _intIsVoltageSPP, int _intUnitModelSelected, double _dblUnitPrice)
        {
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());
            int intLastUnitNo = 0;

            DataSet ds = new DataSet();
            DataTable dt = new DataTable("tblSaveGeneral");
            dt.Columns.Add("UnitNo", typeof(Int32));
            dt.Columns.Add("ErrorMsg", typeof(string));
            DataRow dr;


            if (_intUnitNo == 0)
            {
                string strQueryLastUnitNo = "SELECT MAX(unit_no) AS UNIT_NO FROM `" + ClsDBT.strSavGeneral + "` sav_gen WHERE sav_gen.job_id = @JobID HAVING MAX(unit_no) is not null";

                try
                {
                    //Comm = new MySqlCommand(strQuery, MySqlConn);
                    Comm.CommandType = CommandType.Text;
                    Comm.CommandText = strQueryLastUnitNo;
                    Comm.Parameters.Clear();
                    Comm.Parameters.AddWithValue("@JobID", _intJobID);
                    Conn.Open();

                    ds = new DataSet();
                    //MySqlDataAdapter adp = new MySqlDataAdapter();
                    adp.Fill(ds, "tblJobs");

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        intLastUnitNo = Convert.ToInt32(ds.Tables[0].Rows[0]["UNIT_NO"]);
                    }

                    intLastUnitNo = intLastUnitNo + 1;

                }
                catch (Exception ex)
                {
                    dr = dt.NewRow();
                    dr["UnitNo"] = -1;
                    dr["ErrorMsg"] = ex.Message.ToString();
                    dt.Rows.Add(dr);

                    return dt;
                }
                finally
                {
                    Conn.Close();
                }
            }
            else
            {
                intLastUnitNo = _intUnitNo;
            }


            try
            {
                //Comm.CommandType = CommandType.StoredProcedure;
                Comm.CommandType = CommandType.Text;

                if (_intJobID > 0 && _intUnitNo > 0)
                {
                    Comm.CommandText = "UPDATE `" + ClsDBT.strSavGeneral + "` SET `tag`=@Tag, `qty`=@Qty, `product_type_id`=@ProductTypeID, `is_bypass`=@IsBypass, `unit_type_id`=@UnitTypeID, `unit_model_id`=@UnitModelID, `selection_type_id`=@SelectionTypeID, `location_id`=@LocationID, `is_downshot`=@IsDownshot, `orientation_id`=@OrientationID, " +
                                        "`controls_preference_id`=@ControlsPreferenceID, `unit_height`=@UnitHeight, `unit_width`=@UnitWidth, `unit_length`=@UnitLength, `unit_weight`=@UnitWeight, `voltage_id`=@VoltageID, `is_voltage_spp`=@IsVoltageSPP, `unit_model_selected`=@UnitModelSelected, `unit_price`=@UnitPrice " +
                                        "WHERE `job_id`=@JobID AND `unit_no`=@UnitNo";

                    //Comm.Parameters.AddWithValue("@JobID", _intJobID);
                }
                else
                {
                    Comm.CommandText = "INSERT INTO `" + ClsDBT.strSavGeneral + "` (`job_id`, `unit_no`, `tag`, `qty`, `product_type_id`, `unit_type_id`, `is_bypass`, `unit_model_id`, `selection_type_id`, `location_id`, `is_downshot`, `orientation_id`, " +
                                        "`controls_preference_id`, `unit_height`, `unit_width`, `unit_length`, `unit_weight`, `voltage_id`, `is_voltage_spp`, `unit_model_selected`, `unit_price`) " +
                                        "VALUES (@JobID, @UnitNo, @Tag, @Qty, @ProductTypeID, @UnitTypeID, @IsBypass, @UnitModelID, @SelectionTypeID, @LocationID, @IsDownshot, @OrientationID," +
                                        "@ControlsPreferenceID, @UnitHeight, @UnitWidth, @UnitLength, @UnitWeight, @VoltageID, @IsVoltageSPP, @UnitModelSelected, @UnitPrice)";
                }


                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                Comm.Parameters.AddWithValue("@UnitNo", intLastUnitNo);
                Comm.Parameters.AddWithValue("@Tag", _strTag);
                Comm.Parameters.AddWithValue("@Qty", _intQty);
                Comm.Parameters.AddWithValue("@ProductTypeID", _intProductTypeID);
                Comm.Parameters.AddWithValue("@UnitTypeID", _intUnitTypeID);
                Comm.Parameters.AddWithValue("@IsBypass", _intIsBypass);
                Comm.Parameters.AddWithValue("@UnitModelID", _intUnitModelID);
                Comm.Parameters.AddWithValue("@SelectionTypeID", _intSelectionTypeID);
                Comm.Parameters.AddWithValue("@LocationID", _intLocationID);
                Comm.Parameters.AddWithValue("@IsDownshot", _intIsDownshot);
                Comm.Parameters.AddWithValue("@OrientationID", _intOrientationID);
                //Comm.Parameters.AddWithValue("@ConfigurationID", _intConfigurationID);
                Comm.Parameters.AddWithValue("@ControlsPreferenceID", _intControlsPreferenceID);
                //Comm.Parameters.AddWithValue("@UnitPaintExteriorID", _intUnitPaintExteriorID);
                Comm.Parameters.AddWithValue("@UnitHeight", _dblUnitHeight);
                Comm.Parameters.AddWithValue("@UnitWidth", _dblUnitWidth);
                Comm.Parameters.AddWithValue("@UnitLength", _dblUnitLength);
                Comm.Parameters.AddWithValue("@UnitWeight", _dblUnitWeight);
                Comm.Parameters.AddWithValue("@VoltageID", _intVoltageID);
                Comm.Parameters.AddWithValue("@IsVoltageSPP", _intIsVoltageSPP);
                Comm.Parameters.AddWithValue("@UnitModelSelected", _intUnitModelSelected);
                Comm.Parameters.AddWithValue("@UnitPrice", _dblUnitPrice);

                //Comm.Parameters.AddWithValue("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                Conn.Open();
                Comm.ExecuteNonQuery();


                dr = dt.NewRow();
                dr["UnitNo"] = intLastUnitNo;
                dr["ErrorMsg"] = "";
                dt.Rows.Add(dr);

                return dt;

                //return intLastID.ToString();
            }
            catch (Exception ex)
            {
                dr = dt.NewRow();
                dr["UnitNo"] = -1;
                dr["ErrorMsg"] = ex.Message.ToString();
                dt.Rows.Add(dr);

                return dt;
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion


        #region Save Air Flow
        public static string SaveAirFlow(int _intJobID, int _intUnitNo, int _intAltitude, int _intSummerSupplyAirCFM, int _intSummerReturnAirCFM, int _intWinterSupplyAirCFM, int _intWinterReturnAirCFM,
                                            double _dblSummerOutdoorAirDB, double _dblSummerOutdoorAirWB, double _dblSummerOutdoorAirRH, double _dblWinterOutdoorAirDB, double _dblWinterOutdoorAirWB, double _dblWinterOutdoorAirRH,
                                            double _dblSummerReturnAirDB, double _dblSummerReturnAirWB, double _dblSummerReturnAirRH, double _dblWinterReturnAirDB, double _dblWinterReturnAirWB, double _dblWinterReturnAirRH,
                                            double _dblWinterPreheatSetpointDB, double _dblWinterHeatingSetpointDB, double _dblSummerCoolingSetpointDB, double _dblSummerCoolingSetpointWB, double _dblSummerReheatSetpointDB,
                                            double _dblSupplyAirESP, double _dblExhaustAirESP)
        {

            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());
            int intLastID = 0;
            string strSaveUpdateMsg = "";
            string strQuery = "";

            string strQueryLastUnitNo = "SELECT * FROM `" + ClsDBT.strSavAirFlowData + "` WHERE `job_id` = @JobID AND `unit_no` = @UnitNo";

            try
            {
                //Comm = new MySqlCommand(strQuery, MySqlConn);
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = strQueryLastUnitNo;
                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                Comm.Parameters.AddWithValue("@UnitNo", _intUnitNo);
                Conn.Open();

                ds = new DataSet();
                //MySqlDataAdapter adp = new MySqlDataAdapter();
                adp.Fill(ds, "tblJobs");
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
            finally
            {
                Conn.Close();
            }


            try
            {
                //Comm.CommandType = CommandType.StoredProcedure;
                Comm.CommandType = CommandType.Text;

                if (_intJobID > 0 && _intUnitNo > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    Comm.CommandText = "UPDATE `" + ClsDBT.strSavAirFlowData + "` SET `altitude`=@Altitude, `summer_supply_air_cfm`=@SummerSupplyAirCFM, `summer_return_air_cfm`=@SummerReturnAirCFM, `winter_supply_air_cfm`=@WinterSupplyAirCFM, `winter_return_air_cfm`=@WinterReturnAirCFM, " +
                                        "`summer_outdoor_air_db`=@SummerOutdoorAirDB, `summer_outdoor_air_wb`=@SummerOutdoorAirWB, `summer_outdoor_air_rh`=@SummerOutdoorAirRH, `winter_outdoor_air_db`=@WinterOutdoorAirDB, `winter_outdoor_air_wb`=@WinterOutdoorAirWB, `winter_outdoor_air_rh`=@WinterOutdoorAirRH, " +
                                        "`summer_return_air_db`=@SummerReturnAirDB, `summer_return_air_wb`=@SummerReturnAirWB, `summer_return_air_rh`=@SummerReturnAirRH, `winter_return_air_db`=@WinterReturnAirDB, `winter_return_air_wb`=@WinterReturnAirWB, `winter_return_air_rh`=@WinterReturnAirRH, " +
                                        "`winter_preheat_setpoint_db`=@WinterPreheatSetpointDB, `winter_heating_setpoint_db`=@WinterHeatingSetpointDB, `summer_cooling_setpoint_db`=@SummerCoolingSetpointDB, `summer_cooling_setpoint_wb`=@SummerCoolingSetpointWB, `summer_reheat_setpoint_db`=@SummerReheatSetpointDB, " +
                                        "`supply_air_esp`=@SupplyAirESP, `exhaust_air_esp`=@ExhaustAirESP " +
                                        "WHERE `job_id`=@JobID AND `unit_no`=@UnitNo";

                    //Comm.Parameters.AddWithValue("@JobID", _intJobID);
                    strSaveUpdateMsg = "Updated";
                }
                else
                {
                    Comm.CommandText = "INSERT INTO `" + ClsDBT.strSavAirFlowData + "` (`job_id`, `unit_no`, `altitude`, `summer_supply_air_cfm`, `summer_return_air_cfm`, `winter_supply_air_cfm`, `winter_return_air_cfm`, " +
                                        "`summer_outdoor_air_db`, `summer_outdoor_air_wb`, `summer_outdoor_air_rh`, `winter_outdoor_air_db`, `winter_outdoor_air_wb`, `winter_outdoor_air_rh`, " +
                                        "`summer_return_air_db`, `summer_return_air_wb`, `summer_return_air_rh`, `winter_return_air_db`, `winter_return_air_wb`, `winter_return_air_rh`, " +
                                        "`winter_preheat_setpoint_db`, `winter_heating_setpoint_db`, `summer_cooling_setpoint_db`, `summer_cooling_setpoint_wb`,`summer_reheat_setpoint_db`, " +
                                        "`supply_air_esp`, `exhaust_air_esp`) " +
                                       "VALUES (@JobID, @UnitNo, @Altitude, @SummerSupplyAirCFM, @SummerReturnAirCFM, @WinterSupplyAirCFM, @WinterReturnAirCFM, " +
                                        "@SummerOutdoorAirDB, @SummerOutdoorAirWB, @SummerOutdoorAirRH, @WinterOutdoorAirDB, @WinterOutdoorAirWB, @WinterOutdoorAirRH, " +
                                        "@SummerReturnAirDB, @SummerReturnAirWB, @SummerReturnAirRH, @WinterReturnAirDB, @WinterReturnAirWB, @WinterReturnAirRH, " +
                                        "@WinterPreheatSetpointDB, @WinterHeatingSetpointDB, @SummerCoolingSetpointDB, @SummerCoolingSetpointWB, @SummerReheatSetpointDB, " +
                                        "@SupplyAirESP, @ExhaustAirESP)";

                    strSaveUpdateMsg = "Inserted";
                }


                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                Comm.Parameters.AddWithValue("@UnitNo", _intUnitNo);
                Comm.Parameters.AddWithValue("@Altitude", _intAltitude);
                Comm.Parameters.AddWithValue("@SummerSupplyAirCFM", _intSummerSupplyAirCFM);
                Comm.Parameters.AddWithValue("@SummerReturnAirCFM", _intSummerReturnAirCFM);
                Comm.Parameters.AddWithValue("@WinterSupplyAirCFM", _intWinterSupplyAirCFM);
                Comm.Parameters.AddWithValue("@WinterReturnAirCFM", _intWinterReturnAirCFM);
                Comm.Parameters.AddWithValue("@SummerOutdoorAirDB", _dblSummerOutdoorAirDB);
                Comm.Parameters.AddWithValue("@SummerOutdoorAirWB", _dblSummerOutdoorAirWB);
                Comm.Parameters.AddWithValue("@SummerOutdoorAirRH", _dblSummerOutdoorAirRH);
                Comm.Parameters.AddWithValue("@WinterOutdoorAirDB", _dblWinterOutdoorAirDB);
                Comm.Parameters.AddWithValue("@WinterOutdoorAirWB", _dblWinterOutdoorAirWB);
                Comm.Parameters.AddWithValue("@WinterOutdoorAirRH", _dblWinterOutdoorAirRH);
                Comm.Parameters.AddWithValue("@SummerReturnAirDB", _dblSummerReturnAirDB);
                Comm.Parameters.AddWithValue("@SummerReturnAirWB", _dblSummerReturnAirWB);
                Comm.Parameters.AddWithValue("@SummerReturnAirRH", _dblSummerReturnAirRH);
                Comm.Parameters.AddWithValue("@WinterReturnAirDB", _dblWinterReturnAirDB);
                Comm.Parameters.AddWithValue("@WinterReturnAirWB", _dblWinterReturnAirWB);
                Comm.Parameters.AddWithValue("@WinterReturnAirRH", _dblWinterReturnAirRH);
                Comm.Parameters.AddWithValue("@WinterPreheatSetpointDB", _dblWinterPreheatSetpointDB);
                Comm.Parameters.AddWithValue("@WinterHeatingSetpointDB", _dblWinterHeatingSetpointDB);
                Comm.Parameters.AddWithValue("@SummerCoolingSetpointDB", _dblSummerCoolingSetpointDB);
                Comm.Parameters.AddWithValue("@SummerCoolingSetpointWB", _dblSummerCoolingSetpointWB);
                Comm.Parameters.AddWithValue("@SummerReheatSetpointDB", _dblSummerReheatSetpointDB);
                Comm.Parameters.AddWithValue("@SupplyAirESP", _dblSupplyAirESP);
                Comm.Parameters.AddWithValue("@ExhaustAirESP", _dblExhaustAirESP);

                //Comm.Parameters.AddWithValue("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                Conn.Open();
                Comm.ExecuteNonQuery();

                //if (_intJobID > 0)
                //{
                //    intLastID = _intJobID;
                //}
                //else
                //{
                //    //intLastID = Convert.ToInt32(Comm.Parameters["@ID"].Value);
                //}

                //Conn.Close();

                //DataTable dt = new DataTable("tblLastID");
                //dt.Columns.Add("id", typeof(string));

                //DataRow dr = dt.NewRow();
                //dr["id"] = intLastID;
                //dt.Rows.Add(dr);
                ////ds.Tables.Add(dt); // Table 1


                ////ds.GetXml();

                return strSaveUpdateMsg;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
            finally
            {
                Conn.Close();
            }
        }

        #endregion


        #region Save Component Options
        public static string SaveCompOpt(ClsCompOpt _objCompOptData)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());
            int intLastID = 0;

            string strQueryLastUnitNo = "SELECT * FROM `" + ClsDBT.strSavCompOption + "` WHERE `job_id` = @JobID AND `unit_no` = @UnitNo";

            try
            {
                //Comm = new MySqlCommand(strQuery, MySqlConn);
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = strQueryLastUnitNo;
                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _objCompOptData.intJobID);
                Comm.Parameters.AddWithValue("@UnitNo", _objCompOptData.intUnitNo);
                Conn.Open();

                ds = new DataSet();
                //MySqlDataAdapter adp = new MySqlDataAdapter();
                adp.Fill(ds, "tblJobs");
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
            finally
            {
                Conn.Close();
            }



            try
            {
                //Comm.CommandType = CommandType.StoredProcedure;
                Comm.CommandType = CommandType.Text;

                if (_objCompOptData.intJobID > 0 && _objCompOptData.intUnitNo > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    Comm.CommandText = "UPDATE `" + ClsDBT.strSavCompOption + "` SET `unit_type_id`= @UnitTypeID, `oa_filter_model_id`=@OA_FilterModelID, `final_filter_model_id`=@FinalFilterModelID, `ra_filter_model_id`=@RA_FilterModelID, " +
                                        "`heat_exch_comp_id`=@HeatExchCompID, `preheat_comp_id`=@PreheatCompID, `cooling_comp_id`=@CoolingCompID, `heating_comp_id`=@HeatingCompID, `reheat_comp_id`=@ReheatCompID, " +
                                        "`is_heatpump`=@IsHeatPump, `is_dehumidification`=@IsDehumidification, " +
                                        "`elec_heater_voltage_id`=@ElecHeaterVoltageID, `preheat_elec_heater_installation_id`=@PreheatElecHeaterInstallationID, `heat_elec_heater_installation_id`=@HeatElecHeaterInstallationID, " +
                                        "`preheat_elec_heater_std_coil_no`= @PreheatElecHeaterStdCoilNo, `cooling_dx_vrv_kit_tonnage`= @CoolingDX_VRV_KitTonnage, `heating_elec_heater_std_coil_no`= @HeatingElecHeaterStdCoilNo, `reheat_elec_heater_std_coil_no`= @ReheatElecHeaterStdCoilNo, " +
                                        "`damper_and_actuator_id`=@DamperAndActuatorID, `is_valve_and_actuator_included`=@IsValveAndActuatorIncluded, " +
                                        "`preheat_hwc_valve_and_actuator_id`=@PreheatHWC_ValveAndActuatorID, `cooling_cwc_valve_and_actuator_id`=@CoolingCWC_ValveAndActuatorID, `heating_hwc_valve_and_actuator_id`=@HeatingHWC_ValveAndActuatorID, `reheat_hwc_valve_and_actuator_id`=@ReheatHWC_ValveAndActuatorID," +
                                        "`valve_type_id`=@ValveTypeID,`is_drain_pan`=@IsDrainPan, `oa_filter_pd`=@OA_FilterPD, `ra_filter_pd`=@RA_FilterPD, " +
                                        "`preheat_setpoint_db`=@PreheatSetpointDB, `cooling_setpoint_db`=@CoolingSetpointDB, `cooling_setpoint_wb`=@CoolingSetpointWB,`heating_setpoint_db`=@HeatingSetpointDB, `reheat_setpoint_db`=@ReheatSetpointDB, " +
                                        "`cooling_fluid_type_id`=@CoolingFluidTypeID, `cooling_fluid_concent_id`=@CoolingFluidConcentID, `cooling_fluid_ent_temp`=@CoolingFluidEntTemp, `cooling_fluid_lvg_temp`=@CoolingFluidLvgTemp, " +
                                        "`heating_fluid_type_id`=@HeatingFluidTypeID, `heating_fluid_concent_id`=@HeatingFluidConcentID, `heating_fluid_ent_temp`=@HeatingFluidEntTemp, `heating_fluid_lvg_temp`=@HeatingFluidLvgTemp, " +
                                        "`refrig_suction_temp`=@RefrigSuctionTemp, `refrig_liquid_temp`=@RefrigLiquidTemp, `refrig_superheat_temp`=@RefrigSuperheatTemp, " +
                                        "`refrig_condensing_temp`=@RefrigCondensingTemp, `refrig_vapor_temp`=@RefrigVaporTemp, `refrig_subcooling_temp`=@RefrigSubcoolingTemp, `is_heat_exch_ea_warning`=@HeatExchEA_Warning " +
                                        "WHERE `job_id`=@JobID AND `unit_no`=@UnitNo";

                    //Comm.Parameters.AddWithValue("@JobID", _intJobID);
                }
                else
                {
                    Comm.CommandText = "INSERT INTO `" + ClsDBT.strSavCompOption + "` (`job_id`, `unit_no`, `unit_type_id`, `oa_filter_model_id`, `final_filter_model_id`, `ra_filter_model_id`, " +
                                        "`heat_exch_comp_id`, `preheat_comp_id`, `cooling_comp_id`, `heating_comp_id`, `reheat_comp_id`, " +
                                        "`is_heatpump`, `is_dehumidification`, `elec_heater_voltage_id`, `preheat_elec_heater_installation_id`, `heat_elec_heater_installation_id`, " +
                                        "`preheat_elec_heater_std_coil_no`, `cooling_dx_vrv_kit_tonnage`, `heating_elec_heater_std_coil_no`, `reheat_elec_heater_std_coil_no`, " +
                                        "`damper_and_actuator_id`, `is_valve_and_actuator_included`, " +
                                        "`preheat_hwc_valve_and_actuator_id`, `cooling_cwc_valve_and_actuator_id`, `heating_hwc_valve_and_actuator_id`, `reheat_hwc_valve_and_actuator_id`," +
                                        "`valve_type_id`,`is_drain_pan`, `oa_filter_pd`, `ra_filter_pd`, " +
                                        "`preheat_setpoint_db`, `cooling_setpoint_db`, `cooling_setpoint_wb`, `heating_setpoint_db`, `reheat_setpoint_db`, " +
                                        "`cooling_fluid_type_id`, `cooling_fluid_concent_id`, `cooling_fluid_ent_temp`, `cooling_fluid_lvg_temp`, " +
                                        "`heating_fluid_type_id`, `heating_fluid_concent_id`, `heating_fluid_ent_temp`, `heating_fluid_lvg_temp`, " +
                                        "`refrig_suction_temp`, `refrig_liquid_temp`, `refrig_superheat_temp`, " +
                                        "`refrig_condensing_temp`, `refrig_vapor_temp`, `refrig_subcooling_temp`, `is_heat_exch_ea_warning`) " +
                                        "VALUES (@JobID, @UnitNo,  @UnitTypeID, @OA_FilterModelID, @FinalFilterModelID, @RA_FilterModelID, " +
                                        "@HeatExchCompID, @PreheatCompID, @CoolingCompID, @HeatingCompID, @ReheatCompID, " +
                                        "@IsHeatPump, @IsDehumidification, @ElecHeaterVoltageID, @PreheatElecHeaterInstallationID, @HeatElecHeaterInstallationID, " +
                                        "@PreheatElecHeaterStdCoilNo, @CoolingDX_VRV_KitTonnage, @HeatingElecHeaterStdCoilNo, @ReheatElecHeaterStdCoilNo, " +
                                        "@DamperAndActuatorID, @IsValveAndActuatorIncluded, " + "" +
                                        "@PreheatHWC_ValveAndActuatorID, @CoolingCWC_ValveAndActuatorID, @HeatingHWC_ValveAndActuatorID, @ReheatHWC_ValveAndActuatorID," +
                                        "@ValveTypeID, @IsDrainPan, @OA_FilterPD, @RA_FilterPD, " +
                                        "@PreheatSetpointDB, @CoolingSetpointDB, @CoolingSetpointWB,@HeatingSetpointDB,@ReheatSetpointDB, " +
                                        "@CoolingFluidTypeID, @CoolingFluidConcentID, @CoolingFluidEntTemp, @CoolingFluidLvgTemp, " +
                                        "@HeatingFluidTypeID, @HeatingFluidConcentID, @HeatingFluidEntTemp, @HeatingFluidLvgTemp, " +
                                        "@RefrigSuctionTemp, @RefrigLiquidTemp, @RefrigSuperheatTemp, " +
                                        "@RefrigCondensingTemp, @RefrigVaporTemp, @RefrigSubcoolingTemp, @HeatExchEA_Warning)";
                }

                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _objCompOptData.intJobID);
                Comm.Parameters.AddWithValue("@UnitNo", _objCompOptData.intUnitNo);
                Comm.Parameters.AddWithValue("@UnitTypeID", _objCompOptData.intUnitTypeID);
                Comm.Parameters.AddWithValue("@OA_FilterModelID", _objCompOptData.intOA_FilterModelID);
                Comm.Parameters.AddWithValue("@FinalFilterModelID", _objCompOptData.intSA_FinalFilterModelID);
                Comm.Parameters.AddWithValue("@RA_FilterModelID", _objCompOptData.intRA_FilterModelID);
                Comm.Parameters.AddWithValue("@HeatExchCompID", _objCompOptData.intHeatExchCompID);
                Comm.Parameters.AddWithValue("@PreheatCompID", _objCompOptData.intPreheatCompID);
                Comm.Parameters.AddWithValue("@CoolingCompID", _objCompOptData.intCoolingCompID);
                Comm.Parameters.AddWithValue("@HeatingCompID", _objCompOptData.intHeatingCompID);
                Comm.Parameters.AddWithValue("@ReheatCompID", _objCompOptData.intReheatCompID);
                Comm.Parameters.AddWithValue("@IsHeatPump", _objCompOptData.intIsHeatPump);
                Comm.Parameters.AddWithValue("@IsDehumidification", _objCompOptData.intIsDehumidification);
                Comm.Parameters.AddWithValue("@ElecHeaterVoltageID", _objCompOptData.intElecHeaterVoltageID);
                Comm.Parameters.AddWithValue("@PreheatElecHeaterInstallationID", _objCompOptData.intPreheatElecHeaterInstallationID);
                Comm.Parameters.AddWithValue("@HeatElecHeaterInstallationID", _objCompOptData.intHeatElecHeaterInstallationID);
                Comm.Parameters.AddWithValue("@PreheatElecHeaterStdCoilNo", _objCompOptData.intPreheatElecHeaterStdCoilNo);
                Comm.Parameters.AddWithValue("@CoolingDX_VRV_KitTonnage", _objCompOptData.dblCoolingDX_VRV_KitTonnage);
                Comm.Parameters.AddWithValue("@HeatingElecHeaterStdCoilNo", _objCompOptData.intHeatingElecHeaterStdCoilNo);
                Comm.Parameters.AddWithValue("@ReheatElecHeaterStdCoilNo", _objCompOptData.intReheatElecHeaterStdCoilNo);
                Comm.Parameters.AddWithValue("@DamperAndActuatorID", _objCompOptData.intDamperAndActuatorID);
                Comm.Parameters.AddWithValue("@IsValveAndActuatorIncluded", _objCompOptData.intIsValveAndActuatorIncluded);
                Comm.Parameters.AddWithValue("@PreheatHWC_ValveAndActuatorID", _objCompOptData.intPreheatValveAndActuatorID);
                Comm.Parameters.AddWithValue("@CoolingCWC_ValveAndActuatorID", _objCompOptData.intCoolingValveAndActuatorID);
                Comm.Parameters.AddWithValue("@HeatingHWC_ValveAndActuatorID", _objCompOptData.intHeatingValveAndActuatorID);
                Comm.Parameters.AddWithValue("@ReheatHWC_ValveAndActuatorID", _objCompOptData.intReheatValveAndActuatorID);
                Comm.Parameters.AddWithValue("@IsDrainPan", _objCompOptData.intIsDrainPan);
                Comm.Parameters.AddWithValue("@ValveTypeID", _objCompOptData.intValveTypeID);
                Comm.Parameters.AddWithValue("@OA_FilterPD", _objCompOptData.dblOA_FilterPD);
                Comm.Parameters.AddWithValue("@RA_FilterPD", _objCompOptData.dblRA_FilterPD);
                Comm.Parameters.AddWithValue("@PreheatSetpointDB", _objCompOptData.dblPreheatSetpointDB);
                Comm.Parameters.AddWithValue("@CoolingSetpointDB", _objCompOptData.dblCoolingSetpointDB);
                Comm.Parameters.AddWithValue("@CoolingSetpointWB", _objCompOptData.dblCoolingSetpointWB);
                Comm.Parameters.AddWithValue("@CoolingFluidTypeID", _objCompOptData.intCoolingFluidTypeID);
                Comm.Parameters.AddWithValue("@CoolingFluidConcentID", _objCompOptData.intCoolingFluidConcentID);
                Comm.Parameters.AddWithValue("@CoolingFluidEntTemp", _objCompOptData.dblCoolingFluidEntTemp);
                Comm.Parameters.AddWithValue("@CoolingFluidLvgTemp", _objCompOptData.dblCoolingFluidLvgTemp);
                Comm.Parameters.AddWithValue("@HeatingSetpointDB", _objCompOptData.dblHeatingSetpointDB);
                Comm.Parameters.AddWithValue("@ReheatSetpointDB", _objCompOptData.dblReheatSetpointDB);
                Comm.Parameters.AddWithValue("@HeatingFluidTypeID", _objCompOptData.intHeatingFluidTypeID);
                Comm.Parameters.AddWithValue("@HeatingFluidConcentID", _objCompOptData.intHeatingFluidConcentID);
                Comm.Parameters.AddWithValue("@HeatingFluidEntTemp", _objCompOptData.dblHeatingFluidEntTemp);
                Comm.Parameters.AddWithValue("@HeatingFluidLvgTemp", _objCompOptData.dblHeatingFluidLvgTemp);
                Comm.Parameters.AddWithValue("@RefrigSuctionTemp", _objCompOptData.dblRefrigSuctionTemp);
                Comm.Parameters.AddWithValue("@RefrigLiquidTemp", _objCompOptData.dblRefrigLiquidTemp);
                Comm.Parameters.AddWithValue("@RefrigSuperheatTemp", _objCompOptData.dblRefrigSuperheatTemp);
                Comm.Parameters.AddWithValue("@RefrigCondensingTemp", _objCompOptData.dblRefrigCondensingTemp);
                Comm.Parameters.AddWithValue("@RefrigVaporTemp", _objCompOptData.dblRefrigVaporTemp);
                Comm.Parameters.AddWithValue("@RefrigSubcoolingTemp", _objCompOptData.dblRefrigSubcoolingTemp);
                Comm.Parameters.AddWithValue("@HeatExchEA_Warning", _objCompOptData.intIsHeatExchEA_Warning);

                //Comm.Parameters.AddWithValue("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                Conn.Open();
                Comm.ExecuteNonQuery();

                //if (_intJobID > 0)
                //{
                //    intLastID = _intJobID;
                //}
                //else
                //{
                //    //intLastID = Convert.ToInt32(Comm.Parameters["@ID"].Value);
                //}

                //Conn.Close();

                //DataTable dt = new DataTable("tblLastID");
                //dt.Columns.Add("id", typeof(string));

                //DataRow dr = dt.NewRow();
                //dr["id"] = intLastID;
                //dt.Rows.Add(dr);
                ////ds.Tables.Add(dt); // Table 1

                ////ds.GetXml();

                return "";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion


        #region Save Component Options Custom
        public static string SaveCompOptCustom(ClsCompOptCustom _objCompOptCustom)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());
            int intLastID = 0;

            string strQueryLastUnitNo = "SELECT * FROM `" + ClsDBT.strSavCompOptionCustom + "` WHERE `job_id` = @JobID AND `unit_no` = @UnitNo";

            try
            {
                //Comm = new MySqlCommand(strQuery, MySqlConn);
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = strQueryLastUnitNo;
                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _objCompOptCustom.intJobID);
                Comm.Parameters.AddWithValue("@UnitNo", _objCompOptCustom.intUnitNo);
                Conn.Open();

                ds = new DataSet();
                //MySqlDataAdapter adp = new MySqlDataAdapter();
                adp.Fill(ds, "tblJobs");
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
            finally
            {
                Conn.Close();
            }



            try
            {
                //Comm.CommandType = CommandType.StoredProcedure;
                Comm.CommandType = CommandType.Text;

                if (_objCompOptCustom.intJobID > 0 && _objCompOptCustom.intUnitNo > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    Comm.CommandText = "UPDATE `" + ClsDBT.strSavCompOptionCustom + "` SET `is_preheat_hwc_use_cap`= @isPreheatHWC_UseCap, `preheat_hwc_cap`=@PreheatHWC_Cap, `is_preheat_hwc_use_flow_rate`=@isPreheatHWC_UseFlowRate, `preheat_hwc_flow_rate`=@PreheatHWC_FlowRate, " +
                                        "`is_cooling_cwc_use_cap`= @isCoolingCWC_UseCap, `cooling_cwc_cap`=@CoolingCWC_Cap, `is_cooling_cwc_use_flow_rate`=@isCoolingCWC_UseFlowRate, `cooling_cwc_flow_rate`=@CoolingCWC_FlowRate, " +
                                        "`is_heating_hwc_use_cap`= @isHeatingHWC_UseCap, `heating_hwc_cap`=@HeatingHWC_Cap, `is_heating_hwc_use_flow_rate`=@isHeatingHWC_UseFlowRate, `heating_hwc_flow_rate`=@HeatingHWC_FlowRate, " +
                                        "`is_reheat_hwc_use_cap`= @isReheatHWC_UseCap, `reheat_hwc_cap`=@ReheatHWC_Cap, `is_reheat_hwc_use_flow_rate`=@isReheatHWC_UseFlowRate, `reheat_hwc_flow_rate`=@ReheatHWC_FlowRate " +
                                        "WHERE `job_id`=@JobID AND `unit_no`=@UnitNo";

                    //Comm.Parameters.AddWithValue("@JobID", _intJobID);
                }
                else
                {
                    Comm.CommandText = "INSERT INTO `" + ClsDBT.strSavCompOptionCustom + "` (`job_id`, `unit_no`, " +
                                        "`is_preheat_hwc_use_cap`, `preheat_hwc_cap`, `is_preheat_hwc_use_flow_rate`, `preheat_hwc_flow_rate`, " +
                                        "`is_cooling_cwc_use_cap`, `cooling_cwc_cap`, `is_cooling_cwc_use_flow_rate`, `cooling_cwc_flow_rate`, " +
                                        "`is_heating_hwc_use_cap`, `heating_hwc_cap`, `is_heating_hwc_use_flow_rate`, `heating_hwc_flow_rate`, " +
                                        "`is_reheat_hwc_use_cap`, `reheat_hwc_cap`, `is_reheat_hwc_use_flow_rate`, `reheat_hwc_flow_rate`) " +
                                        "VALUES (@JobID, @UnitNo, @isPreheatHWC_UseCap, @PreheatHWC_Cap, @isPreheatHWC_UseFlowRate, @PreheatHWC_FlowRate, " +
                                        "@isCoolingCWC_UseCap, @CoolingCWC_Cap, @isCoolingCWC_UseFlowRate, @CoolingCWC_FlowRate, " +
                                        "@isHeatingHWC_UseCap, @HeatingHWC_Cap, @isHeatingHWC_UseFlowRate, @HeatingHWC_FlowRate, " +
                                        "@isReheatHWC_UseCap, @ReheatHWC_Cap, @isReheatHWC_UseFlowRate, @ReheatHWC_FlowRate)";
                }


                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _objCompOptCustom.intJobID);
                Comm.Parameters.AddWithValue("@UnitNo", _objCompOptCustom.intUnitNo);
                Comm.Parameters.AddWithValue("@isPreheatHWC_UseCap", _objCompOptCustom.intIsPreheatHWC_UseCap);
                Comm.Parameters.AddWithValue("@PreheatHWC_Cap", _objCompOptCustom.dblPreheatHWC_Cap);
                Comm.Parameters.AddWithValue("@isPreheatHWC_UseFlowRate", _objCompOptCustom.intIsPreheatHWC_UseFlowRate);
                Comm.Parameters.AddWithValue("@PreheatHWC_FlowRate", _objCompOptCustom.dblPreheatHWC_FlowRate);
                Comm.Parameters.AddWithValue("@isCoolingCWC_UseCap", _objCompOptCustom.intIsCoolingCWC_UseCap);
                Comm.Parameters.AddWithValue("@CoolingCWC_Cap", _objCompOptCustom.dblCoolingCWC_Cap);
                Comm.Parameters.AddWithValue("@isCoolingCWC_UseFlowRate", _objCompOptCustom.intIsCoolingCWC_UseFlowRate);
                Comm.Parameters.AddWithValue("@CoolingCWC_FlowRate", _objCompOptCustom.dblCoolingCWC_FlowRate);
                Comm.Parameters.AddWithValue("@isHeatingHWC_UseCap", _objCompOptCustom.intIsHeatingHWC_UseCap);
                Comm.Parameters.AddWithValue("@HeatingHWC_Cap", _objCompOptCustom.dblHeatingHWC_Cap);
                Comm.Parameters.AddWithValue("@isHeatingHWC_UseFlowRate", _objCompOptCustom.intIsHeatingHWC_UseFlowRate);
                Comm.Parameters.AddWithValue("@HeatingHWC_FlowRate", _objCompOptCustom.dblHeatingHWC_FlowRate);
                Comm.Parameters.AddWithValue("@isReheatHWC_UseCap", _objCompOptCustom.intIsReheatHWC_UseCap);
                Comm.Parameters.AddWithValue("@ReheatHWC_Cap", _objCompOptCustom.dblReheatHWC_Cap);
                Comm.Parameters.AddWithValue("@isReheatHWC_UseFlowRate", _objCompOptCustom.intIsReheatHWC_UseFlowRate);
                Comm.Parameters.AddWithValue("@ReheatHWC_FlowRate", _objCompOptCustom.dblReheatHWC_FlowRate);

                //Comm.Parameters.AddWithValue("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                Conn.Open();
                Comm.ExecuteNonQuery();


                return "";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion


        #region SaveLayout
        public static string SaveLayout(ClsLayoutOpt _objLayoutOpt)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());
            //int intLastID = 0;

            string strQueryLastUnitNo = "SELECT * FROM `" + ClsDBT.strSavLayout + "` WHERE `job_id` = @JobID AND `unit_no` = @UnitNo";

            try
            {
                //Comm = new MySqlCommand(strQuery, MySqlConn);
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = strQueryLastUnitNo;
                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _objLayoutOpt.intJobID);
                Comm.Parameters.AddWithValue("@UnitNo", _objLayoutOpt.intUnitNo);
                Conn.Open();

                ds = new DataSet();
                //MySqlDataAdapter adp = new MySqlDataAdapter();
                adp.Fill(ds, "tblJobs");
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
            finally
            {
                Conn.Close();
            }


            try
            {
                //Comm.CommandType = CommandType.StoredProcedure;
                Comm.CommandType = CommandType.Text;

                if (_objLayoutOpt.intJobID > 0 && _objLayoutOpt.intUnitNo > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    Comm.CommandText = "UPDATE `" + ClsDBT.strSavLayout + "` SET `product_type_id`= @ProductTypeID, `unit_type_id`= @UnitTypeID, " +
                                        "`handing_id`= @HandingID, `preheat_coil_handing_id`= @PreheatCoilHandingID, `cooling_coil_handing_id`= @CoolingCoilHandingID, `heating_coil_handing_id`= @HeatingCoilHandingID," +
                                        "`sa_opening_id`=@SupplyAirOpeningID, `sa_opening`=@SupplyAirOpening, `ea_opening_id`=@ExhaustAirOpeningID, `ea_opening`=@ExhaustAirOpening," +
                                        "`oa_opening_id`=@OutdoorAirOpeningID, `oa_opening`=@OutdoorAirOpening, `ra_opening_id`= @ReturnAirOpeningID, `ra_opening`= @ReturnAirOpening " +
                                        "WHERE `job_id`=@JobID AND `unit_no`=@UnitNo";

                    //Comm.Parameters.AddWithValue("@JobID", _intJobID);
                }
                else
                {
                    Comm.CommandText = "INSERT INTO `" + ClsDBT.strSavLayout + "` (`job_id`, `unit_no`, " +
                                        "`product_type_id`,`unit_type_id`, `handing_id`, `preheat_coil_handing_id`,`cooling_coil_handing_id`,`heating_coil_handing_id`,`sa_opening_id`, `sa_opening`, `ea_opening_id`, `ea_opening`, " +
                                        "`oa_opening_id`, `oa_opening`, `ra_opening_id`,  `ra_opening`) " +
                                        "VALUES (@JobID, @UnitNo, @ProductTypeID, @UnitTypeID, @HandingID, @PreheatCoilHandingID, @CoolingCoilHandingID, @HeatingCoilHandingID, @SupplyAirOpeningID, @SupplyAirOpening, @ExhaustAirOpeningID, @ExhaustAirOpening, " +
                                        "@OutdoorAirOpeningID, @OutdoorAirOpening, @ReturnAirOpeningID, @ReturnAirOpening)";
                }


                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _objLayoutOpt.intJobID);
                Comm.Parameters.AddWithValue("@UnitNo", _objLayoutOpt.intUnitNo);
                Comm.Parameters.AddWithValue("@ProductTypeID", _objLayoutOpt.intUnitTypeID);
                Comm.Parameters.AddWithValue("@UnitTypeID", _objLayoutOpt.intUnitTypeID);
                Comm.Parameters.AddWithValue("@HandingID", _objLayoutOpt.intHandingID);
                Comm.Parameters.AddWithValue("@PreheatCoilHandingID", _objLayoutOpt.intPreheatCoilHandingID);
                Comm.Parameters.AddWithValue("@CoolingCoilHandingID", _objLayoutOpt.intCoolingCoilHandingID);
                Comm.Parameters.AddWithValue("@HeatingCoilHandingID", _objLayoutOpt.intHeatingCoilHandingID);
                Comm.Parameters.AddWithValue("@SupplyAirOpeningID", _objLayoutOpt.intSupplyAirOpeningID);
                Comm.Parameters.AddWithValue("@SupplyAirOpening", _objLayoutOpt.strSupplyAirOpening);

                Comm.Parameters.AddWithValue("@ExhaustAirOpeningID", _objLayoutOpt.intExhaustAirOpeningID);
                Comm.Parameters.AddWithValue("@ExhaustAirOpening", _objLayoutOpt.strExhaustAirOpening);
                Comm.Parameters.AddWithValue("@OutdoorAirOpeningID", _objLayoutOpt.intOutdoorAirOpeningID);
                Comm.Parameters.AddWithValue("@OutdoorAirOpening", _objLayoutOpt.strOutdoorAirOpening);
                Comm.Parameters.AddWithValue("@ReturnAirOpeningID", _objLayoutOpt.intReturnAirOpeningID);
                Comm.Parameters.AddWithValue("@ReturnAirOpening", _objLayoutOpt.strReturnAirOpening);

                //Comm.Parameters.AddWithValue("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                Conn.Open();
                Comm.ExecuteNonQuery();


                return "";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion


        #region SavePricing
        public static DataTable SavePricing(int _intQuoteID, int _intJobID, int _intRevisionNo, string _strCustomerPO, int _intQuoteStageID, int _intFOB_PointID, int _intCountryID, double _dblCurrencyRate, double _dblShippingFactor, int _intShippingTypeID,
                                                double _dblDiscountFactor, int _intDiscountTypeID, double _dblPriceAllUnits, double _dblPriceMisc, double _dblPriceShipping, double _dblPriceSubTotal, double _dblPriceDiscount, double _dblPriceFinalTotal, string _strCreatedDate, string _strRevisedDate, string _strValidDate)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());
            int intLastID = 0;
            DataTable dt = new DataTable("tblLastID");
            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("ErrMsg", typeof(string));

            try
            {
                Comm.CommandType = CommandType.Text;

                Conn.Open();
                Comm.CommandText = "DELETE FROM `" + ClsDBT.strSavQuote + "` WHERE `job_id`=0";
                Comm.ExecuteNonQuery();

                Comm.CommandText = "DELETE FROM `" + ClsDBT.strSavQuote + "` WHERE `quote_id`=0";
                Comm.ExecuteNonQuery();


                if (_intQuoteID > 0)
                {
                    Comm.CommandText = "UPDATE `" + ClsDBT.strSavQuote + "` SET `revision_no`=@RevisionNo, `quote_stage_id`=@QuoteStageID, `fob_point_id`=@FOB_PointID, `country_id`=@CountryID,`currency_rate`=@CurrencyRate,`shipping_factor`=@ShippingFactor,`shipping_type_id`=@ShippingTypeID, `discount_factor`=@DiscountFactor, `discount_type_id`=@DiscountTypeID, " +
                                        "`price_all_units`=@PriceAllUnits, `price_misc`=@PriceMisc, `price_shipping`=@PriceShipping,`price_subtotal`=@PriceSubtotal, `price_discount`=@PriceDiscount, `price_final_total`=@PriceFinalTotal, `created_date`=@CreatedDate, `revised_date`=@RevisedDate, `valid_date`=@ValidDate " +
                                        "WHERE `quote_id`=@QuoteID";

                    Comm.Parameters.AddWithValue("@QuoteID", _intQuoteID);
                }
                else
                {
                    Comm.CommandText = "INSERT INTO `" + ClsDBT.strSavQuote + "` (`job_id`, `quote_stage_id`, `revision_no`, `fob_point_id`, `country_id`, `currency_rate`,`shipping_factor`,`shipping_type_id`, `discount_factor`,`discount_type_id`, `price_all_units`, `price_misc`, `price_shipping`, `price_subtotal`, `price_discount`, `price_final_total`, `created_date`, `revised_date`, `valid_date`) " +
                       "VALUES (@JobID, @QuoteStageID, @RevisionNo, @FOB_PointID, @CountryID,@CurrencyRate,@ShippingFactor, @ShippingTypeID, @DiscountFactor, @DiscountTypeID, @PriceAllUnits, @PriceMisc, @PriceShipping, @PriceSubtotal, @PriceDiscount, @PriceFinalTotal, @CreatedDate, @RevisedDate, @ValidDate)";
                }



                //Comm.Parameters.AddWithValue("@CustomerPO", _strCustomerPO);
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                Comm.Parameters.AddWithValue("@QuoteStageID", _intQuoteStageID);
                Comm.Parameters.AddWithValue("@RevisionNo", _intRevisionNo);
                Comm.Parameters.AddWithValue("@FOB_PointID", _intFOB_PointID);
                Comm.Parameters.AddWithValue("@CountryID", _intCountryID);
                Comm.Parameters.AddWithValue("@CurrencyRate", _dblCurrencyRate);
                Comm.Parameters.AddWithValue("@ShippingFactor", _dblShippingFactor);
                Comm.Parameters.AddWithValue("@ShippingTypeID", _intShippingTypeID);
                Comm.Parameters.AddWithValue("@DiscountFactor", _dblDiscountFactor);
                Comm.Parameters.AddWithValue("@DiscountTypeID", _intDiscountTypeID);
                Comm.Parameters.AddWithValue("@PriceAllUnits", _dblPriceAllUnits);
                Comm.Parameters.AddWithValue("@PriceMisc", _dblPriceMisc);
                Comm.Parameters.AddWithValue("@PriceShipping", _dblPriceShipping);
                Comm.Parameters.AddWithValue("@PriceSubtotal", _dblPriceSubTotal);
                Comm.Parameters.AddWithValue("@PriceDiscount", _dblPriceDiscount);
                Comm.Parameters.AddWithValue("@PriceFinalTotal", _dblPriceFinalTotal);
                Comm.Parameters.AddWithValue("@CreatedDate", _strCreatedDate);
                Comm.Parameters.AddWithValue("@RevisedDate", _strRevisedDate);
                Comm.Parameters.AddWithValue("@ValidDate", _strValidDate);
                //Conn.Open();
                Comm.ExecuteNonQuery();

                if (_intQuoteID > 0)
                {
                    intLastID = _intQuoteID;
                }
                else
                {
                    intLastID = Convert.ToInt32(Comm.LastInsertedId);
                    //intLastID = Convert.ToInt32(Comm.Parameters["@ID"].Value);
                }



                DataRow dr = dt.NewRow();
                dr["id"] = intLastID;
                dt.Rows.Add(dr);
                //ds.Tables.Add(dt); // Table 1

                return dt;
                //return true;
            }
            catch (Exception ex)
            {
                DataRow dr = dt.NewRow();
                dr["ErrMsg"] = ex.ToString();
                dt.Rows.Add(dr);

                return dt;
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion


        #region SavePricingNotes
        public static bool SavePricingNotes(int _intJobID, int _intNotesNo, string _strNotes)
        {
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());
            int intLastNotesNo = 0;

            DataSet ds = new DataSet();
            DataTable dt = new DataTable("tblSavePricingNotes");
            dt.Columns.Add("NotesNo", typeof(Int32));
            dt.Columns.Add("ErrorMsg", typeof(string));
            DataRow dr;


            if (_intNotesNo == 0)
            {
                string strQueryLastUnitNo = "SELECT MAX(notes_no) AS NOTES_NO FROM `" + ClsDBT.strSavQuoteNotes + "` tbl_price WHERE tbl_price.job_id = @JobID HAVING MAX(notes_no) is not null";

                try
                {
                    //Comm = new MySqlCommand(strQuery, MySqlConn);
                    Comm.CommandType = CommandType.Text;
                    Comm.CommandText = strQueryLastUnitNo;
                    Comm.Parameters.Clear();
                    Comm.Parameters.AddWithValue("@JobID", _intJobID);
                    Conn.Open();

                    ds = new DataSet();
                    //MySqlDataAdapter adp = new MySqlDataAdapter();
                    adp.Fill(ds, "tblPriceNotes");

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        intLastNotesNo = Convert.ToInt32(ds.Tables[0].Rows[0]["NOTES_NO"]);
                    }

                    intLastNotesNo = intLastNotesNo + 1;

                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    Conn.Close();
                }
            }
            else
            {
                intLastNotesNo = _intNotesNo;
            }


            try
            {
                //Comm.CommandType = CommandType.StoredProcedure;
                Comm.CommandType = CommandType.Text;

                if (_intJobID > 0 && _intNotesNo > 0)
                {
                    Comm.CommandText = "UPDATE `" + ClsDBT.strSavQuoteNotes + "` SET `notes`=@Notes " +
                                        "WHERE `job_id`=@JobID AND `notes_no`=@NotesNo";

                    //Comm.Parameters.AddWithValue("@JobID", _intJobID);
                }
                else
                {
                    Comm.CommandText = "INSERT INTO `" + ClsDBT.strSavQuoteNotes + "` (`job_id`, `notes_no`, `notes`) " +
                                        "VALUES (@JobID, @NotesNo, @Notes)";
                }


                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                Comm.Parameters.AddWithValue("@NotesNo", intLastNotesNo);
                Comm.Parameters.AddWithValue("@Notes", _strNotes);

                //Comm.Parameters.AddWithValue("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                Conn.Open();
                Comm.ExecuteNonQuery();


                //dr = dt.NewRow();
                //dr["NotesNo"] = intLastNotesNo;
                //dr["ErrorMsg"] = "";
                //dt.Rows.Add(dr);

                return true;

                //return intLastID.ToString();
            }
            catch (Exception ex)
            {
                //dr = dt.NewRow();
                //dr["NotesNo"] = -1;
                //dr["ErrorMsg"] = ex.Message.ToString();
                //dt.Rows.Add(dr);

                return false;
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion


        #region SavePricingMisc
        public static bool SavePricingMisc(int _intJobID, int _intMiscNo, string _strMisc, int _intQty, double _dblPrice)
        {
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());
            int intLastNo = 0;

            DataSet ds = new DataSet();
            DataTable dt = new DataTable("tblSavePricingMisc");
            dt.Columns.Add("No", typeof(Int32));
            dt.Columns.Add("ErrorMsg", typeof(string));
            DataRow dr;


            if (_intMiscNo == 0)
            {
                string strQueryLastUnitNo = "SELECT MAX(misc_no) AS MISC_NO FROM `" + ClsDBT.strSavQuoteMisc + "` tbl_price_misc WHERE tbl_price_misc.job_id = @JobID HAVING MAX(misc_no) is not null";

                try
                {
                    //Comm = new MySqlCommand(strQuery, MySqlConn);
                    Comm.CommandType = CommandType.Text;
                    Comm.CommandText = strQueryLastUnitNo;
                    Comm.Parameters.Clear();
                    Comm.Parameters.AddWithValue("@JobID", _intJobID);
                    Conn.Open();

                    ds = new DataSet();
                    //MySqlDataAdapter adp = new MySqlDataAdapter();
                    adp.Fill(ds, "tblPriceMisc");

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        intLastNo = Convert.ToInt32(ds.Tables[0].Rows[0]["MISC_NO"]);
                    }

                    intLastNo = intLastNo + 1;

                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    Conn.Close();
                }
            }
            else
            {
                intLastNo = _intMiscNo;
            }


            try
            {
                //Comm.CommandType = CommandType.StoredProcedure;
                Comm.CommandType = CommandType.Text;

                if (_intJobID > 0 && _intMiscNo > 0)
                {
                    Comm.CommandText = "UPDATE `" + ClsDBT.strSavQuoteMisc + "` SET `misc`=@Misc, `qty`=@Qty, `price`=@Price " +
                                        "WHERE `job_id`=@JobID AND `misc_no`=@MiscNo";

                    //Comm.Parameters.AddWithValue("@JobID", _intJobID);
                }
                else
                {
                    Comm.CommandText = "INSERT INTO `" + ClsDBT.strSavQuoteMisc + "` (`job_id`, `misc_no`, `misc`, `qty`, `price`) " +
                                        "VALUES (@JobID, @MiscNo, @Misc, @Qty, @Price)";
                }


                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                Comm.Parameters.AddWithValue("@MiscNo", intLastNo);
                Comm.Parameters.AddWithValue("@Misc", _strMisc);
                Comm.Parameters.AddWithValue("@Qty", _intQty);
                Comm.Parameters.AddWithValue("@Price", _dblPrice);

                //Comm.Parameters.AddWithValue("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                Conn.Open();
                Comm.ExecuteNonQuery();


                //dr = dt.NewRow();
                //dr["NotesNo"] = intLastNotesNo;
                //dr["ErrorMsg"] = "";
                //dt.Rows.Add(dr);

                return true;

                //return intLastID.ToString();
            }
            catch (Exception ex)
            {
                //dr = dt.NewRow();
                //dr["NotesNo"] = -1;
                //dr["ErrorMsg"] = ex.Message.ToString();
                //dt.Rows.Add(dr);

                return false;
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion


        #region SaveSubmitals
        public static string SaveSubmittals(int _intJobID, string _strLeadTime, int _intRevisionNo, string _strPO_Number, string _strShippingName, string _strShippingStreetAddress, string _strShippingCity, string _strShippingProvince, int _intShippingCountrID, string _strShippingPostalCode, int _intDockTypeID,
                                            int _intIsVoltageTable, int _intIsBACNetPoints, int _intIsOJ_HMI_Spec, int _intIsTerminalWiringDiagram, int _intIsFireAlarm,
                                            int _intIsBackdraftDampers, int _intIsBypassDefrost, int _intIsConstantVolume, int _intIsHydronicPreheat, int _intIsHumidification, int _intIsTempControl)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());
            int intLastID = 0;

            string strQueryLastUnitNo = "SELECT * FROM `" + ClsDBT.strSavSubmittal + "` WHERE `job_id` = @JobID";

            try
            {
                //Comm = new MySqlCommand(strQuery, MySqlConn);
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = strQueryLastUnitNo;
                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                //Comm.Parameters.AddWithValue("@UnitNo", _objCompOptData.intUnitNo);
                Conn.Open();

                ds = new DataSet();
                //MySqlDataAdapter adp = new MySqlDataAdapter();
                adp.Fill(ds, "tblJobs");
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
            finally
            {
                Conn.Close();
            }



            try
            {
                //Comm.CommandType = CommandType.StoredProcedure;
                Comm.CommandType = CommandType.Text;

                Conn.Open();
                Comm.CommandText = "DELETE FROM `" + ClsDBT.strSavSubmittal + "` WHERE `job_id`=0";
                Comm.ExecuteNonQuery();


                if (_intJobID > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    Comm.CommandText = "UPDATE `" + ClsDBT.strSavSubmittal + "` SET `lead_time`=@LeadTime,`revision_no`=@RevisionNo, `po_number`=@PO_Number,`shipping_name`=@ShippingName, `shipping_street_address`=@ShippingStreetAddress, `shipping_city`=@ShippingCity, `shipping_province`=@ShippingProvince, `shipping_country_id`=@ShippingCountryID," +
                                        "`shipping_postal_code`=@ShippingPostalCode, `dock_type_id`=@DockTypeID, " +
                                        "`is_pdf_voltage_table`=@IsPDF_VoltageTable, `is_pdf_bacnet_points`=@IsPDF_BACNetPoints, `is_pdf_oj_hmi_spec`=@IsPDF_OJ_HMI_Spec, " +
                                        "`is_pdf_terminal_wiring_diagram`=@IsPDF_TerminalWiringDiagram, `is_pdf_fire_alarm`=@IsPDF_FireAlarm, `is_backdraft_dampers`=@IsBackdraftDampers, `is_bypass_defrost`=@IsBypassDefrost, `is_constant_volume`=@IsConstantVolume, " +
                                        "`is_hydronic_preheat`=@IsHydronicPreheat, `is_humidification`=@IsHumidification, `is_temp_control`=@IsTempControl " +
                                        "WHERE `job_id`=@JobID";

                    //Comm.Parameters.AddWithValue("@JobID", _intJobID);
                }
                else
                {
                    Comm.CommandText = "INSERT INTO `" + ClsDBT.strSavSubmittal + "` (`job_id`, `lead_time`, `revision_no`, `po_number`, `shipping_name`, `shipping_street_address`, `shipping_city`, `shipping_province`, `shipping_country_id`, `shipping_postal_code`, `dock_type_id`, " +
                                        "`is_pdf_voltage_table`, `is_pdf_bacnet_points`, `is_pdf_oj_hmi_spec`, " +
                                        "`is_pdf_terminal_wiring_diagram`, `is_pdf_fire_alarm`, `is_backdraft_dampers`, `is_bypass_defrost`, `is_constant_volume`, `is_hydronic_preheat`, " +
                                        "`is_humidification`, `is_temp_control`) " +
                                        "VALUES (@JobID, @LeadTime, @RevisionNo, @PO_Number, @ShippingName, @ShippingStreetAddress, @ShippingCity, @ShippingProvince, @ShippingCountryID, @ShippingPostalCode, @DockTypeID, " +
                                        "@IsPDF_VoltageTable, @IsPDF_BACNetPoints, @IsPDF_OJ_HMI_Spec, @IsPDF_TerminalWiringDiagram, @IsPDF_FireAlarm, @IsBackdraftDampers, @IsBypassDefrost, " +
                                        "@IsConstantVolume, @IsHydronicPreheat, @IsHumidification, @IsTempControl)";
                }


                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                Comm.Parameters.AddWithValue("@LeadTime", _strLeadTime);
                Comm.Parameters.AddWithValue("@RevisionNo", _intRevisionNo);
                Comm.Parameters.AddWithValue("@PO_Number", _strPO_Number);
                Comm.Parameters.AddWithValue("@ShippingName", _strShippingName);
                Comm.Parameters.AddWithValue("@ShippingStreetAddress", _strShippingStreetAddress);
                Comm.Parameters.AddWithValue("@ShippingCity", _strShippingCity);
                Comm.Parameters.AddWithValue("@ShippingProvince", _strShippingProvince);
                Comm.Parameters.AddWithValue("@ShippingCountryID", _intShippingCountrID);
                Comm.Parameters.AddWithValue("@ShippingPostalCode", _strShippingPostalCode);
                Comm.Parameters.AddWithValue("@DockTypeID", _intDockTypeID);
                Comm.Parameters.AddWithValue("@IsPDF_VoltageTable", _intIsVoltageTable);
                Comm.Parameters.AddWithValue("@IsPDF_BACNetPoints", _intIsBACNetPoints);
                Comm.Parameters.AddWithValue("@IsPDF_OJ_HMI_Spec", _intIsOJ_HMI_Spec);
                Comm.Parameters.AddWithValue("@IsPDF_TerminalWiringDiagram", _intIsTerminalWiringDiagram);
                Comm.Parameters.AddWithValue("@IsPDF_FireAlarm", _intIsFireAlarm);
                Comm.Parameters.AddWithValue("@IsBackdraftDampers", _intIsBackdraftDampers);
                Comm.Parameters.AddWithValue("@IsBypassDefrost", _intIsBypassDefrost);
                Comm.Parameters.AddWithValue("@IsConstantVolume", _intIsConstantVolume);
                Comm.Parameters.AddWithValue("@IsHydronicPreheat", _intIsHydronicPreheat);
                Comm.Parameters.AddWithValue("@IsHumidification", _intIsHumidification);
                Comm.Parameters.AddWithValue("@IsTempControl", _intIsTempControl);
                //Conn.Open();
                Comm.ExecuteNonQuery();



                return "";
            }
            catch (Exception ex)
            {

                return ex.ToString(); ;
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion


        #region SaveSubmittalsNotes
        public static bool SaveSubmittalsNotes(int _intJobID, int _intNotesNo, string _strNotes)
        {
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());
            int intLastNotesNo = 0;

            DataSet ds = new DataSet();
            DataTable dt = new DataTable("tblSaveSubmittalsNotes");
            dt.Columns.Add("NotesNo", typeof(Int32));
            dt.Columns.Add("ErrorMsg", typeof(string));
            DataRow dr;


            if (_intNotesNo == 0)
            {
                string strQueryLastUnitNo = "SELECT MAX(notes_no) AS NOTES_NO FROM `" + ClsDBT.strSavSubmittalNotes + "` tbl_price WHERE tbl_price.job_id = @JobID HAVING MAX(notes_no) is not null";

                try
                {
                    //Comm = new MySqlCommand(strQuery, MySqlConn);
                    Comm.CommandType = CommandType.Text;
                    Comm.CommandText = strQueryLastUnitNo;
                    Comm.Parameters.Clear();
                    Comm.Parameters.AddWithValue("@JobID", _intJobID);
                    Conn.Open();

                    ds = new DataSet();
                    //MySqlDataAdapter adp = new MySqlDataAdapter();
                    adp.Fill(ds, "tblPriceNotes");

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        intLastNotesNo = Convert.ToInt32(ds.Tables[0].Rows[0]["NOTES_NO"]);
                    }

                    intLastNotesNo = intLastNotesNo + 1;

                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    Conn.Close();
                }
            }
            else
            {
                intLastNotesNo = _intNotesNo;
            }


            try
            {
                //Comm.CommandType = CommandType.StoredProcedure;
                Comm.CommandType = CommandType.Text;

                if (_intJobID > 0 && _intNotesNo > 0)
                {
                    Comm.CommandText = "UPDATE `" + ClsDBT.strSavSubmittalNotes + "` SET `notes`=@Notes " +
                                        "WHERE `job_id`=@JobID AND `notes_no`=@NotesNo";

                    //Comm.Parameters.AddWithValue("@JobID", _intJobID);
                }
                else
                {
                    Comm.CommandText = "INSERT INTO `" + ClsDBT.strSavSubmittalNotes + "` (`job_id`, `notes_no`, `notes`) " +
                                        "VALUES (@JobID, @NotesNo, @Notes)";
                }


                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                Comm.Parameters.AddWithValue("@NotesNo", intLastNotesNo);
                Comm.Parameters.AddWithValue("@Notes", _strNotes);

                //Comm.Parameters.AddWithValue("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                Conn.Open();
                Comm.ExecuteNonQuery();


                //dr = dt.NewRow();
                //dr["NotesNo"] = intLastNotesNo;
                //dr["ErrorMsg"] = "";
                //dt.Rows.Add(dr);

                return true;

                //return intLastID.ToString();
            }
            catch (Exception ex)
            {
                //dr = dt.NewRow();
                //dr["NotesNo"] = -1;
                //dr["ErrorMsg"] = ex.Message.ToString();
                //dt.Rows.Add(dr);

                return false;
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion


        #region SaveSubmittalsShippingNotes
        public static bool SaveSubmittalsShippingNotes(int _intJobID, int _intShippingNotesNo, string _strShippingNotes)
        {
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());
            int intLastNotesNo = 0;

            DataSet ds = new DataSet();
            DataTable dt = new DataTable("tblSaveSubmittalsShippingNotes");
            dt.Columns.Add("ShippingNotesNo", typeof(Int32));
            dt.Columns.Add("ErrorMsg", typeof(string));
            DataRow dr;


            if (_intShippingNotesNo == 0)
            {
                string strQueryLastUnitNo = "SELECT MAX(shipping_notes_no) AS SHIPPING_NOTES_NO FROM `" + ClsDBT.strSavSubmittalShippingNotes + "` tbl_shipping_notes WHERE tbl_shipping_notes.job_id = @JobID HAVING MAX(shipping_notes_no) is not null";

                try
                {
                    //Comm = new MySqlCommand(strQuery, MySqlConn);
                    Comm.CommandType = CommandType.Text;
                    Comm.CommandText = strQueryLastUnitNo;
                    Comm.Parameters.Clear();
                    Comm.Parameters.AddWithValue("@JobID", _intJobID);
                    Conn.Open();

                    ds = new DataSet();
                    //MySqlDataAdapter adp = new MySqlDataAdapter();
                    adp.Fill(ds, "tblPriceNotes");

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        intLastNotesNo = Convert.ToInt32(ds.Tables[0].Rows[0]["SHIPPING_NOTES_NO"]);
                    }

                    intLastNotesNo = intLastNotesNo + 1;

                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    Conn.Close();
                }
            }
            else
            {
                intLastNotesNo = _intShippingNotesNo;
            }


            try
            {
                //Comm.CommandType = CommandType.StoredProcedure;
                Comm.CommandType = CommandType.Text;

                if (_intJobID > 0 && _intShippingNotesNo > 0)
                {
                    Comm.CommandText = "UPDATE `" + ClsDBT.strSavSubmittalShippingNotes + "` SET `shipping_notes`=@ShippingNotes " +
                                        "WHERE `job_id`=@JobID AND `shipping_notes_no`=@ShippingNotesNo";

                    //Comm.Parameters.AddWithValue("@JobID", _intJobID);
                }
                else
                {
                    Comm.CommandText = "INSERT INTO `" + ClsDBT.strSavSubmittalShippingNotes + "` (`job_id`, `shipping_notes_no`, `shipping_notes`) " +
                                        "VALUES (@JobID, @ShippingNotesNo, @ShippingNotes)";
                }


                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                Comm.Parameters.AddWithValue("@ShippingNotesNo", intLastNotesNo);
                Comm.Parameters.AddWithValue("@ShippingNotes", _strShippingNotes);

                //Comm.Parameters.AddWithValue("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                Conn.Open();
                Comm.ExecuteNonQuery();


                //dr = dt.NewRow();
                //dr["NotesNo"] = intLastNotesNo;
                //dr["ErrorMsg"] = "";
                //dt.Rows.Add(dr);

                return true;

                //return intLastID.ToString();
            }
            catch (Exception ex)
            {
                //dr = dt.NewRow();
                //dr["NotesNo"] = -1;
                //dr["ErrorMsg"] = ex.Message.ToString();
                //dt.Rows.Add(dr);

                return false;
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion



        //#region Save Electric Heater THERMOLEC
        //public static string SaveElectricHeaterTHERMOLEC(int _intJobID, int _intUnitNo, int _intComponentNo, int _intTypeID, int _intModelID, int _intDeltaT)
        //{
        //    DataSet ds = new DataSet();
        //    MySqlDataAdapter adp = new MySqlDataAdapter();
        //    var Comm = adp.SelectCommand = new MySqlCommand();
        //    var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());
        //    int intLastID = 0;
        //    int intLatComponentNo = 0;

        //    if (_intComponentNo == 0)
        //    {
        //        string strQueryLastUnitNo = "SELECT MAX(component_no) AS COMPONENT_NO FROM `" + ClsDBT.strSavElectricHeaterTHERMOLEC + "` sav_tbl WHERE sav_tbl.job_id = @JobID AND sav_tbl.unit_no = @UnitNo HAVING MAX(component_no) is not null";

        //        try
        //        {
        //            //Comm = new MySqlCommand(strQuery, MySqlConn);
        //            Comm.CommandType = CommandType.Text;
        //            Comm.CommandText = strQueryLastUnitNo;
        //            Comm.Parameters.Clear();
        //            Comm.Parameters.AddWithValue("@JobID", _intJobID);
        //            Comm.Parameters.AddWithValue("@UnitNo", _intUnitNo);
        //            Conn.Open();

        //            ds = new DataSet();
        //            //MySqlDataAdapter adp = new MySqlDataAdapter();
        //            adp.Fill(ds, "tblJobs");

        //            if (ds.Tables[0].Rows.Count > 0)
        //            {
        //                intLatComponentNo = Convert.ToInt32(ds.Tables[0].Rows[0]["COMPONENT_NO"]);
        //            }

        //            intLatComponentNo = intLatComponentNo + 1;
        //        }
        //        catch (Exception ex)
        //        {
        //            return ex.Message.ToString();
        //        }
        //        finally
        //        {
        //            Conn.Close();
        //        }
        //    }
        //    else
        //    {
        //        intLatComponentNo = _intComponentNo;
        //    }



        //    try
        //    {
        //        //Comm.CommandType = CommandType.StoredProcedure;
        //        Comm.CommandType = CommandType.Text;


        //        if (_intJobID > 0 && _intUnitNo > 0 && _intComponentNo > 0)
        //        {
        //            Comm.CommandText = "UPDATE `" + ClsDBT.strSavElectricHeaterTHERMOLEC + "` SET `type_id`=@TypeID, `model_id`=@ModelID, `delta_t`=@DeltaT " +
        //                                "WHERE `job_id`=@JobID AND `unit_no`=@UnitNo AND `component_no`=@ComponentNo";

        //            //Comm.Parameters.AddWithValue("@JobID", _intJobID);
        //        }
        //        else
        //        {
        //            Comm.CommandText = "INSERT INTO `" + ClsDBT.strSavElectricHeaterTHERMOLEC + "` (`job_id`, `unit_no`, `component_no`, " +
        //                                "`component_id`, `supplier_id`, `type_id`, `model_id`, `delta_t`) " +
        //                               "VALUES (@JobID, @UnitNo,  @ComponentNo, @ComponentID, @SupplierID, @TypeID, @ModelID, @DeltaT)";
        //        }


        //        Comm.Parameters.Clear();
        //        Comm.Parameters.AddWithValue("@JobID", _intJobID);
        //        Comm.Parameters.AddWithValue("@UnitNo", _intUnitNo);
        //        Comm.Parameters.AddWithValue("@ComponentNo", intLatComponentNo);
        //        Comm.Parameters.AddWithValue("@ComponentID", ClsID.intCompElectricHeaterID);
        //        Comm.Parameters.AddWithValue("@SupplierID", ClsID.intSupplierTHERMOLEC_ID);
        //        Comm.Parameters.AddWithValue("@TypeID", _intTypeID);
        //        Comm.Parameters.AddWithValue("@ModelID", 0);
        //        Comm.Parameters.AddWithValue("@DeltaT", 0);
        //        //Comm.Parameters.AddWithValue("@ModelID", _intModelID);
        //        //Comm.Parameters.AddWithValue("@DeltaT", _intDeltaT);
        //        ////Comm.Parameters.AddWithValue("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
        //        Conn.Open();
        //        Comm.ExecuteNonQuery();

        //        //if (_intJobID > 0)
        //        //{
        //        //    intLastID = _intJobID;
        //        //}
        //        //else
        //        //{
        //        //    //intLastID = Convert.ToInt32(Comm.Parameters["@ID"].Value);
        //        //}

        //        //Conn.Close();

        //        //DataTable dt = new DataTable("tblLastID");
        //        //dt.Columns.Add("id", typeof(string));

        //        //DataRow dr = dt.NewRow();
        //        //dr["id"] = intLastID;
        //        //dt.Rows.Add(dr);
        //        ////ds.Tables.Add(dt); // Table 1

        //        ////ds.GetXml();

        //        return "";
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message.ToString();
        //    }
        //    finally
        //    {
        //        Conn.Close();
        //    }
        //}
        //#endregion



        #region Save DuplicateNew
        public static string DuplicateNew(int _intJobID, int _intUnitNo)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());
            int intNewUnitNo = 0;

            string strQueryLastUnitNo = "SELECT MAX(unit_no) AS UNIT_NO FROM `" + ClsDBT.strSavGeneral + "` sav_gen WHERE sav_gen.job_id = @JobID HAVING MAX(unit_no) is not null";

            try
            {
                //Comm = new MySqlCommand(strQuery, MySqlConn);
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = strQueryLastUnitNo;
                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                Conn.Open();

                ds = new DataSet();
                //MySqlDataAdapter adp = new MySqlDataAdapter();
                adp.Fill(ds, "tblJobs");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    intNewUnitNo = Convert.ToInt32(ds.Tables[0].Rows[0]["UNIT_NO"]);
                }

                intNewUnitNo = intNewUnitNo + 1;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
            finally
            {
                Conn.Close();
            }



            try
            {
                //Comm.CommandType = CommandType.StoredProcedure;
                Conn.Open();

                Comm.CommandType = CommandType.Text;
                Comm.CommandText = "CREATE TEMPORARY TABLE tmptable_1 SELECT * FROM `" + ClsDBT.strSavGeneral + "` WHERE `Job_id`=@JobID AND `unit_no`=@UnitNo; " +
                                    "UPDATE tmptable_1 SET `unit_no`=@NewUnitNo; " +
                                    "INSERT INTO `" + ClsDBT.strSavGeneral + "` SELECT * FROM tmptable_1; " +
                                    "DROP TEMPORARY TABLE IF EXISTS tmptable_1";

                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                Comm.Parameters.AddWithValue("@UnitNo", _intUnitNo);
                Comm.Parameters.AddWithValue("@NewUnitNo", intNewUnitNo);
                Comm.ExecuteNonQuery();


                Comm.CommandText = "CREATE TEMPORARY TABLE tmptable_1 SELECT * FROM `" + ClsDBT.strSavAirFlowData + "` WHERE `Job_id`=@JobID AND `unit_no`=@UnitNo; " +
                                    "UPDATE tmptable_1 SET `unit_no`=@NewUnitNo; " +
                                    "INSERT INTO `" + ClsDBT.strSavAirFlowData + "` SELECT * FROM tmptable_1; " +
                                    "DROP TEMPORARY TABLE IF EXISTS tmptable_1";

                Comm.ExecuteNonQuery();

                Comm.CommandText = "CREATE TEMPORARY TABLE tmptable_1 SELECT * FROM `" + ClsDBT.strSavCompOption + "` WHERE `Job_id`=@JobID AND `unit_no`=@UnitNo; " +
                                    "UPDATE tmptable_1 SET `unit_no`=@NewUnitNo; " +
                                    "INSERT INTO `" + ClsDBT.strSavCompOption + "` SELECT * FROM tmptable_1; " +
                                    "DROP TEMPORARY TABLE IF EXISTS tmptable_1";

                Comm.ExecuteNonQuery();


                Comm.CommandText = "CREATE TEMPORARY TABLE tmptable_1 SELECT * FROM `" + ClsDBT.strSavCompOptionCustom + "` WHERE `Job_id`=@JobID AND `unit_no`=@UnitNo; " +
                                    "UPDATE tmptable_1 SET `unit_no`=@NewUnitNo; " +
                                    "INSERT INTO `" + ClsDBT.strSavCompOptionCustom + "` SELECT * FROM tmptable_1; " +
                                    "DROP TEMPORARY TABLE IF EXISTS tmptable_1";

                Comm.ExecuteNonQuery();


                Comm.CommandText = "CREATE TEMPORARY TABLE tmptable_1 SELECT * FROM `" + ClsDBT.strSavLayout + "` WHERE `Job_id`=@JobID AND `unit_no`=@UnitNo; " +
                                    "UPDATE tmptable_1 SET `unit_no`=@NewUnitNo; " +
                                    "INSERT INTO `" + ClsDBT.strSavLayout + "` SELECT * FROM tmptable_1; " +
                                    "DROP TEMPORARY TABLE IF EXISTS tmptable_1";

                Comm.ExecuteNonQuery();



                return "";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion


        #region Save Customer
        public static DataTable SaveCustomer(int _intCustomerID, string _strCustomerName, int _intCustomerTypeID, int _intCountryID, string _strAddress, string _strContactName, int _intFOB_PointID, double _dblShippingFactorPercent, string _strCreatedDate)
        {
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());
            int intLastID = 0;
            string strQuery = "";

            DataSet ds = new DataSet();
            DataTable dt = new DataTable("tblSaveCustomer");
            dt.Columns.Add("id", typeof(Int32));
            dt.Columns.Add("ErrorMsg", typeof(string));
            DataRow dr;


            Comm.Parameters.Clear();

            try
            {
                //Comm.CommandType = CommandType.StoredProcedure;

                if (_intCustomerID > 0)
                {
                    strQuery = "UPDATE `" + ClsDBT.strSavCustomer + "` SET `name`=@CustomerName, `customer_type_id`=@CustomerTypeID, `country_id`=@CountryID, `address`=@Address, `contact_name`=@ContactName, `fob_point_id`=@FOB_PointID, `shipping_factor_percent`=@ShippingFactorPercent, `created_date`=@CreatedDate " +
                                        "WHERE `id`=@RepID";

                    Comm.Parameters.AddWithValue("@RepID", _intCustomerID);
                }
                else
                {
                    strQuery = "INSERT INTO `" + ClsDBT.strSavCustomer + "` (`name`, `customer_type_id`, `country_id`, `address`, `contact_name`, `fob_point_id`, `shipping_factor_percent`, `created_date`) " +
                                        "VALUES (@CustomerName, @CustomerTypeID, @CountryID, @Address, @ContactName, @FOB_PointID, @ShippingFactorPercent, @CreatedDate)";
                }

                Comm.CommandType = CommandType.Text;
                Comm.CommandText = strQuery;
                Comm.Parameters.AddWithValue("@CustomerName", _strCustomerName);
                //Comm.Parameters.AddWithValue("@RepID", _intRepID);
                Comm.Parameters.AddWithValue("@CustomerTypeID", _intCustomerTypeID);
                Comm.Parameters.AddWithValue("@CountryID", _intCountryID);
                Comm.Parameters.AddWithValue("@Address", _strAddress);
                Comm.Parameters.AddWithValue("@ContactName", _strContactName);
                Comm.Parameters.AddWithValue("@FOB_PointID", _intFOB_PointID);
                Comm.Parameters.AddWithValue("@ShippingFactorPercent", _dblShippingFactorPercent);
                Comm.Parameters.AddWithValue("@CreatedDate", _strCreatedDate);
                //Comm.Parameters.AddWithValue("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                Conn.Open();
                Comm.ExecuteNonQuery();


                if (_intCustomerID == 0)
                {

                }

                if (_intCustomerID > 0)
                {
                    intLastID = _intCustomerID;
                }
                else
                {
                    strQuery = "SELECT MAX(id) AS ID FROM `" + ClsDBT.strSavCustomer + "`";
                    Comm.CommandType = CommandType.Text;
                    Comm.CommandText = strQuery;
                    Comm.ExecuteNonQuery();

                    adp.Fill(ds, "DataTable");
                    //intLastID = Convert.ToInt32(Comm.Parameters["@ID"].Value);
                    intLastID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                }

                //Conn.Close();

                dr = dt.NewRow();
                dr["id"] = intLastID;
                dr["ErrorMsg"] = "";
                dt.Rows.Add(dr);

                return dt;

                //return intLastID.ToString();
            }
            catch (Exception ex)
            {
                dr = dt.NewRow();
                dr["id"] = -1;
                dr["ErrorMsg"] = ex.Message.ToString();
                dt.Rows.Add(dr);

                return dt;
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion


        #region Save User
        public static DataTable SaveUser(int _intUserID, string _strUserName, string _strPassword, string _strFirstName, string _strLastName, string _strEmail, int _intCustomerID,
                                        int _intAccess, int _intAccessLevel, int _intAccessPricing, string _strCreatedDate)
        {
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());
            int intLastID = 0;
            string strQuery = "";

            DataSet ds = new DataSet();
            DataTable dt = new DataTable("tblSaveUser");
            dt.Columns.Add("id", typeof(Int32));
            dt.Columns.Add("ErrorMsg", typeof(string));
            DataRow dr;


            Comm.Parameters.Clear();

            try
            {
                //Comm.CommandType = CommandType.StoredProcedure;

                if (_intUserID > 0)
                {
                    strQuery = "UPDATE `" + ClsDBT.strSavUsers + "` SET `username`=@Username, `first_name`=@FirstName, `last_name`=@LastName, `email`=@Email, `customer_id`=@CustomerID, `access`=@Access, " +
                                       "`access_level`=@AccessLevel, `access_pricing`=@AccessPricing, `created_date`=@CreatedDate " +
                                        "WHERE `id`=@UserID";

                    Comm.Parameters.AddWithValue("@UserID", _intUserID);
                }
                else
                {
                    strQuery = "INSERT INTO `" + ClsDBT.strSavUsers + "` (`username`, `password`, `first_name`, `last_name`, `email`, `customer_id`, `access`, `access_level`, `access_pricing`, `created_date`) " +
                                        "VALUES (@Username, @Password, @FirstName, @LastName, @Email, @CustomerID, @Access, @AccessLevel, @AccessPricing, @CreatedDate)";
                }

                Comm.CommandType = CommandType.Text;
                Comm.CommandText = strQuery;
                Comm.Parameters.AddWithValue("@UserName", _strUserName);
                //Comm.Parameters.AddWithValue("@RepID", _intRepID);
                Comm.Parameters.AddWithValue("@Password", _strPassword);
                Comm.Parameters.AddWithValue("@FirstName", _strFirstName);
                Comm.Parameters.AddWithValue("@LastName", _strLastName);
                Comm.Parameters.AddWithValue("@Email", _strEmail);
                Comm.Parameters.AddWithValue("@CustomerID", _intCustomerID);
                Comm.Parameters.AddWithValue("@Access", _intAccess);
                Comm.Parameters.AddWithValue("@AccessLevel", _intAccessLevel);
                Comm.Parameters.AddWithValue("@AccessPricing", _intAccessPricing);
                Comm.Parameters.AddWithValue("@CreatedDate", _strCreatedDate);

                //Comm.Parameters.AddWithValue("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                Conn.Open();
                Comm.ExecuteNonQuery();


                if (_intUserID == 0)
                {

                }


                if (_intUserID > 0)
                {
                    intLastID = _intUserID;
                }
                else
                {
                    strQuery = "SELECT MAX(id) AS ID FROM `" + ClsDBT.strSavUsers + "`";
                    Comm.CommandType = CommandType.Text;
                    Comm.CommandText = strQuery;
                    Comm.ExecuteNonQuery();

                    adp.Fill(ds, "DataTable");
                    //intLastID = Convert.ToInt32(Comm.Parameters["@ID"].Value);
                    intLastID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                }

                //Conn.Close();

                dr = dt.NewRow();
                dr["id"] = intLastID;
                dr["ErrorMsg"] = "";
                dt.Rows.Add(dr);

                return dt;

                //return intLastID.ToString();
            }
            catch (Exception ex)
            {
                dr = dt.NewRow();
                dr["id"] = -1;
                dr["ErrorMsg"] = ex.Message.ToString();
                dt.Rows.Add(dr);

                return dt;
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion


        #region Update User Password
        public static DataTable UpdateUserPassword(int _intUserID, string _strPassword)
        {
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());
            string strQuery = "";

            DataSet ds = new DataSet();
            DataTable dt = new DataTable("tblSaveUser");
            dt.Columns.Add("id", typeof(Int32));
            dt.Columns.Add("ErrorMsg", typeof(string));
            DataRow dr;

            Comm.Parameters.Clear();

            try
            {
                strQuery = "UPDATE `" + ClsDBT.strSavUsers + "` SET `password`=@Password WHERE `id`=@UserID";

                Comm.CommandType = CommandType.Text;
                Comm.CommandText = strQuery;
                Comm.Parameters.AddWithValue("@Password", _strPassword);
                Comm.Parameters.AddWithValue("@UserID", _intUserID);

                Conn.Open();
                Comm.ExecuteNonQuery();

                dr = dt.NewRow();
                dr["id"] = _intUserID;
                dr["ErrorMsg"] = "";
                dt.Rows.Add(dr);

                return dt;
            }
            catch (Exception ex)
            {
                dr = dt.NewRow();
                dr["id"] = -1;
                dr["ErrorMsg"] = ex.Message.ToString();
                dt.Rows.Add(dr);

                return dt;
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion


        #region Update Product
        public static string UpdateUnit(string _strTableName, int _intJobID, int _intUnitNo, int _intSelectionCompleted)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());

            try
            {
                Conn.Open();

                Comm.CommandType = CommandType.Text;
                Comm.CommandText = "UPDATE `" + _strTableName + "` SET `selection_completed`=@SelectionCompleted WHERE `job_id`=@JobID AND `unit_no`=@UnitNo";

                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                Comm.Parameters.AddWithValue("@UnitNo", _intUnitNo);
                Comm.Parameters.AddWithValue("@SelectionCompleted", _intSelectionCompleted);

                Comm.ExecuteNonQuery();

                //DataTable dt = new DataTable("tblProductPrice");
                //dt.Columns.Add("product_code_price", typeof(string));

                //DataRow dr = dt.NewRow();
                //dr["product_code_price"] = _decProductCodePrice;
                //dt.Rows.Add(dr);
                //ds.Tables.Add(dt); // Table 1

                return "";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
            finally
            {
                Conn.Close();

            }
        }
        #endregion


        #region Update Unit Price
        public static string UpdateUnitPrice(int _intJobID, int _intUnitNo, double _dblUnitPrice)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());

            try
            {
                Conn.Open();

                Comm.CommandType = CommandType.Text;
                Comm.CommandText = "UPDATE `" + ClsDBT.strSavGeneral + "` SET `unit_price`=@UnitPrice WHERE `job_id`=@JobID AND `unit_no`=@UnitNo";

                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                Comm.Parameters.AddWithValue("@UnitNo", _intUnitNo);
                Comm.Parameters.AddWithValue("@UnitPrice", _dblUnitPrice);

                Comm.ExecuteNonQuery();

                //DataTable dt = new DataTable("tblProductPrice");
                //dt.Columns.Add("product_code_price", typeof(string));

                //DataRow dr = dt.NewRow();
                //dr["product_code_price"] = _decProductCodePrice;
                //dt.Rows.Add(dr);
                //ds.Tables.Add(dt); // Table 1

                return "";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion


        #region Update Heat Exchanger Exhaust Air Cond Warning
        public static string UpdateHeatExchangerEA_CondWarning(int _intJobID, int _intUnitNo, int _intHeatExchEA_CondWarning)
        {
            //_strColumnName = preheat_hwc_valve_and_actuator_id, cooling_cwc_valve_and_actuator_id, heating_hwc_valve_and_actuator_id, reheat_hwc_valve_and_actuator_id 
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());

            try
            {
                Conn.Open();

                Comm.CommandType = CommandType.Text;
                Comm.CommandText = "UPDATE `" + ClsDBT.strSavCompOption + "` SET `is_heat_exch_ea_warning`= @HeatExchEA_CondWarning WHERE `job_id`=@JobID AND `unit_no`=@UnitNo";

                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                Comm.Parameters.AddWithValue("@UnitNo", _intUnitNo);
                Comm.Parameters.AddWithValue("@HeatExchEA_CondWarning", _intHeatExchEA_CondWarning);

                Comm.ExecuteNonQuery();

                //DataTable dt = new DataTable("tblProductPrice");
                //dt.Columns.Add("product_code_price", typeof(string));

                //DataRow dr = dt.NewRow();
                //dr["product_code_price"] = _decProductCodePrice;
                //dt.Rows.Add(dr);
                //ds.Tables.Add(dt); // Table 1

                return "";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion



        #region Update Electric Heater Std Coil No
        public static string UpdateElectricHeaterStdCoilNo(int _intJobID, int _intUnitNo, string _strColumnName, int _intStandardCoilNo)
        {
            //_strColumnName = preheat_hwc_valve_and_actuator_id, cooling_cwc_valve_and_actuator_id, heating_hwc_valve_and_actuator_id, reheat_hwc_valve_and_actuator_id 
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());

            try
            {
                Conn.Open();

                Comm.CommandType = CommandType.Text;
                Comm.CommandText = "UPDATE `" + ClsDBT.strSavCompOption + "` SET `" + _strColumnName + "`= @StandardCoilNo WHERE `job_id`=@JobID AND `unit_no`=@UnitNo";

                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                Comm.Parameters.AddWithValue("@UnitNo", _intUnitNo);
                Comm.Parameters.AddWithValue("@StandardCoilNo", _intStandardCoilNo);

                Comm.ExecuteNonQuery();

                //DataTable dt = new DataTable("tblProductPrice");
                //dt.Columns.Add("product_code_price", typeof(string));

                //DataRow dr = dt.NewRow();
                //dr["product_code_price"] = _decProductCodePrice;
                //dt.Rows.Add(dr);
                //ds.Tables.Add(dt); // Table 1

                return "";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion



        #region Update DX VRV Kit Tonnage
        public static string UpdateDX_VRV_KitTonnage(int _intJobID, int _intUnitNo, double _dblVRV_KitTonnage)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());

            try
            {
                Conn.Open();

                Comm.CommandType = CommandType.Text;
                Comm.CommandText = "UPDATE `" + ClsDBT.strSavCompOption + "` SET `cooling_dx_vrv_kit_tonnage`= @VRV_KitTonnage WHERE `job_id`=@JobID AND `unit_no`=@UnitNo";

                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                Comm.Parameters.AddWithValue("@UnitNo", _intUnitNo);
                Comm.Parameters.AddWithValue("@VRV_KitTonnage", _dblVRV_KitTonnage);

                Comm.ExecuteNonQuery();

                //DataTable dt = new DataTable("tblProductPrice");
                //dt.Columns.Add("product_code_price", typeof(string));

                //DataRow dr = dt.NewRow();
                //dr["product_code_price"] = _decProductCodePrice;
                //dt.Rows.Add(dr);
                //ds.Tables.Add(dt); // Table 1

                return "";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion



        #region Update Valve And Actuators
        public static string UpdateValveAndActuatorID(int _intJobID, int _intUnitNo, string _strColumnName, double _dblValveAndActuatorID)
        {
            //_strColumnName = preheat_hwc_valve_and_actuator_id, cooling_cwc_valve_and_actuator_id, heating_hwc_valve_and_actuator_id, reheat_hwc_valve_and_actuator_id 
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());

            try
            {
                Conn.Open();

                Comm.CommandType = CommandType.Text;
                Comm.CommandText = "UPDATE `" + ClsDBT.strSavCompOption + "` SET `" + _strColumnName + "`= @ValveAndActuatorID WHERE `job_id`=@JobID AND `unit_no`=@UnitNo";

                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                Comm.Parameters.AddWithValue("@UnitNo", _intUnitNo);
                Comm.Parameters.AddWithValue("@ValveAndActuatorID", _dblValveAndActuatorID);

                Comm.ExecuteNonQuery();

                //DataTable dt = new DataTable("tblProductPrice");
                //dt.Columns.Add("product_code_price", typeof(string));

                //DataRow dr = dt.NewRow();
                //dr["product_code_price"] = _decProductCodePrice;
                //dt.Rows.Add(dr);
                //ds.Tables.Add(dt); // Table 1

                return "";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion



        #region GetUser
        public static DataTable GetUser()
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());


            string strQuery = "SELECT *, tbl_customer.name Customer_Name, tbl_customer.contact_name Customer_Contact_Name, tbl_customer_type.id CustomerTypeID, tbl_customer_type.items CustomerTypeName " +
                                        "FROM `" + ClsDBT.strSavUsers + "` tbl_user " +
                                        "LEFT JOIN `" + ClsDBT.strSavCustomer + "` tbl_customer ON tbl_customer.id = tbl_user.customer_id " +
                                        "LEFT JOIN `" + ClsDBT.strSelCustomerType + "` tbl_customer_type ON tbl_customer_type.id = tbl_customer.customer_type_id " +
                                         "WHERE tbl_user.id != 1 AND tbl_user.id != 2 AND tbl_user.id != 3 AND tbl_user.id != 4 AND tbl_user.id != 5 AND tbl_user.id != 7 "; //7 = Dorothy

            try
            {
                //Comm = new MySqlCommand(strQuery, MySqlConn);
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = strQuery;
                Comm.Parameters.Clear();
                //Comm.Parameters.AddWithValue("@UserID", _intUserID);
                Conn.Open();

                ds = new DataSet();
                //MySqlDataAdapter adp = new MySqlDataAdapter();
                adp.Fill(ds, "tblJobs");

                return ds.Tables[0];

            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Conn.Close();
            }

        }
        #endregion


        #region GetUser
        public static DataTable GetUser(int _intUserID)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());


            string strQuery = "SELECT tbl_user.*, CONCAT(tbl_user.first_name, \" \", tbl_user.last_name) User_Full_Name, " +
                                "tbl_customer.id CustomerID, tbl_customer.name Customer_Name, tbl_customer.contact_name Customer_Contact_Name, tbl_customer.country_id Customer_Country_ID, tbl_customer.shipping_factor_percent CustomerShippingFactorPercent, " +
                                "tbl_customer_type.id CustomerTypeID, tbl_customer_type.items CustomerTypeName, " +
                                "tbl_customer.fob_point_id FOB_Point_ID, tbl_fob_point.items FOB_Point_Name, tbl_fob_point.city FOB_Point_City, tbl_fob_point.state FOB_Point_State, tbl_fob_point.country FOB_Point_Country " +
                                "FROM `" + ClsDBT.strSavUsers + "` tbl_user " +
                                "LEFT JOIN `" + ClsDBT.strSavCustomer + "` tbl_customer ON tbl_customer.id = tbl_user.customer_id " +
                                "LEFT JOIN `" + ClsDBT.strSelCustomerType + "` tbl_customer_type ON tbl_customer_type.id = tbl_customer.customer_type_id " +
                                "LEFT JOIN `" + ClsDBT.strSelCountry + "` tbl_country ON tbl_country.id = tbl_customer.country_id " +
                                "LEFT JOIN `" + ClsDBT.strSelFOB_Point + "` tbl_fob_point ON tbl_fob_point.id = tbl_customer.fob_point_id " +
                                "WHERE tbl_user.id = @UserID";
            try
            {
                //Comm = new MySqlCommand(strQuery, MySqlConn);
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = strQuery;
                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@UserID", _intUserID);
                Conn.Open();

                ds = new DataSet();
                //MySqlDataAdapter adp = new MySqlDataAdapter();
                adp.Fill(ds, "tblJobs");

                return ds.Tables[0];

            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion


        #region GetUser
        public static DataTable GetUser(string _strUsername)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());


            string strQuery = "SELECT tbl_user.*, CONCAT(tbl_user.first_name, \" \", tbl_user.last_name) User_Full_Name, " +
                                "tbl_customer.id CustomerID, tbl_customer.name Customer_Name, tbl_customer.contact_name Customer_Contact_Name, tbl_customer.shipping_factor_percent CustomerShippingFactorPercent, " +
                                "tbl_customer_type.id CustomerTypeID, tbl_customer_type.items CustomerTypeName, tbl_customer.country_id Customer_Country_ID, " +
                                "tbl_customer.fob_point_id FOB_Point_ID, tbl_fob_point.items FOB_Point_Name, tbl_fob_point.city FOB_Point_City, tbl_fob_point.state FOB_Point_State, tbl_fob_point.country FOB_Point_Country " +
                                "FROM `" + ClsDBT.strSavUsers + "` tbl_user " +
                                "LEFT JOIN `" + ClsDBT.strSavCustomer + "` tbl_customer ON tbl_customer.id = tbl_user.customer_id " +
                                "LEFT JOIN `" + ClsDBT.strSelCustomerType + "` tbl_customer_type ON tbl_customer_type.id = tbl_customer.customer_type_id " +
                                "LEFT JOIN `" + ClsDBT.strSelCountry + "` tbl_country ON tbl_country.id = tbl_customer.country_id " +
                                "LEFT JOIN `" + ClsDBT.strSelFOB_Point + "` tbl_fob_point ON tbl_fob_point.id = tbl_customer.fob_point_id " +
                                "WHERE tbl_user.username = @Username";
            try
            {
                //Comm = new MySqlCommand(strQuery, MySqlConn);
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = strQuery;
                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@Username", _strUsername);
                Conn.Open();

                ds = new DataSet();
                //MySqlDataAdapter adp = new MySqlDataAdapter();
                adp.Fill(ds, "tblJobs");

                return ds.Tables[0];

            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion


        #region GetCustomerType
        public static DataTable GetCustomerType(bool _bolExcludeAdmin)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());

            string strQuery = "SELECT * FROM `" + ClsDBT.strSelCustomerType + "` tbl_customer_type ";

            if (_bolExcludeAdmin)
            {
                strQuery += "WHERE tbl_customer_type.id != 2 ";
            }

            strQuery += "ORDER BY items";

            try
            {
                //Comm = new MySqlCommand(strQuery, MySqlConn);
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = strQuery;
                Comm.Parameters.Clear();
                //Comm.Parameters.AddWithValue("@UserID", _intUserID);
                Conn.Open();

                ds = new DataSet();
                //MySqlDataAdapter adp = new MySqlDataAdapter();
                adp.Fill(ds, ClsDBT.strSelCustomerType);

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion


        #region Get User Per Customer
        public static DataTable GetUserPerCustomer(int _intCustomerID)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());


            string strQuery = "SELECT *, CONCAT(tbl_user.first_name, \" \", tbl_user.last_name) User_Full_Name, tbl_customer.name Customer_Name, tbl_customer.contact_name Customer_Contact_Name " +
                                        "FROM `" + ClsDBT.strSavUsers + "` tbl_user " +
                                        "LEFT JOIN `" + ClsDBT.strSavCustomer + "` tbl_customer ON tbl_customer.id = tbl_user.customer_id " +
                                        "WHERE tbl_user.customer_id = @CustomerID ORDER BY Customer_Name, tbl_user.first_name, tbl_user.last_name";
            try
            {
                //Comm = new MySqlCommand(strQuery, MySqlConn);
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = strQuery;
                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@CustomerID", _intCustomerID);
                Conn.Open();

                ds = new DataSet();
                //MySqlDataAdapter adp = new MySqlDataAdapter();
                adp.Fill(ds, "tblJobs");

                return ds.Tables[0];

            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion


        #region GetCustomers
        public static DataTable GetCustomers()
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());

            string strQuery = "SELECT * FROM `" + ClsDBT.strSavCustomer + "` tbl_customer " +
                                "LEFT JOIN `" + ClsDBT.strSelCountry + "` tbl_country ON tbl_country.id = tbl_customer.country_id " +
                                "LEFT JOIN `" + ClsDBT.strSelFOB_Point + "` tbl_fob_point ON tbl_fob_point.id = tbl_customer.fob_point_id " +
                                "WHERE tbl_customer.id != 1 AND tbl_customer.id != 2 AND tbl_customer.id != 4 " +
                                "ORDER BY name";
            try
            {
                //Comm = new MySqlCommand(strQuery, MySqlConn);
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = strQuery;
                Comm.Parameters.Clear();
                //Comm.Parameters.AddWithValue("@UserID", _intUserID);
                Conn.Open();

                ds = new DataSet();
                //MySqlDataAdapter adp = new MySqlDataAdapter();
                adp.Fill(ds, "tblJobs");

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion


        #region GetCustomers
        public static DataTable GetCustomersByType(int _intCustomerTypeID)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());

            string strQuery = "SELECT *, tbl_customer.fob_point_id FOB_Point_ID, tbl_fob_point.items FOB_Point_Name, tbl_fob_point.city FOB_Point_City, tbl_fob_point.state FOB_Point_State, tbl_fob_point.country FOB_Point_Country " +
                                "FROM `" + ClsDBT.strSavCustomer + "` tbl_customer " +
                                "LEFT JOIN `" + ClsDBT.strSelCountry + "` tbl_country ON tbl_country.id = tbl_customer.country_id " +
                                "LEFT JOIN `" + ClsDBT.strSelFOB_Point + "` tbl_fob_point ON tbl_fob_point.id = tbl_customer.fob_point_id ";

            if (_intCustomerTypeID == ClsID.intCustomerTypeAllID)
            {
                //strQuery += "WHERE tbl_customer.id != 1 AND tbl_customer.id != 2 AND tbl_customer.id != 4 ";
                strQuery += "WHERE tbl_customer.id != 1 AND tbl_customer.id != 2 ";
            }
            else
            {
                //strQuery += "WHERE tbl_customer.id != 1 AND tbl_customer.id != 2 AND tbl_customer.id != 4 AND tbl_customer.customer_type_id=@CustomerTypeID ";
                strQuery += "WHERE tbl_customer.id != 1 AND tbl_customer.id != 2 AND tbl_customer.customer_type_id=@CustomerTypeID ";
            }

            strQuery += "ORDER BY name"; //7 = Dorothy


            try
            {
                //Comm = new MySqlCommand(strQuery, MySqlConn);
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = strQuery;
                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@CustomerTypeID", _intCustomerTypeID);
                Conn.Open();

                ds = new DataSet();
                //MySqlDataAdapter adp = new MySqlDataAdapter();
                adp.Fill(ds, "tblJobs");

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion


        #region GetCustomer
        public static DataTable GetCustomerByID(int _intCustomerID)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());

            string strQuery = "SELECT *, tbl_customer.fob_point_id FOB_Point_ID, tbl_fob_point.items FOB_Point_Name, tbl_fob_point.city FOB_Point_City, tbl_fob_point.state FOB_Point_State, tbl_fob_point.country FOB_Point_Country " +
                                "FROM `" + ClsDBT.strSavCustomer + "` tbl_customer " +
                                "LEFT JOIN `" + ClsDBT.strSelCountry + "` tbl_country ON tbl_country.id = tbl_customer.country_id " +
                                "LEFT JOIN `" + ClsDBT.strSelFOB_Point + "` tbl_fob_point ON tbl_fob_point.id = tbl_customer.fob_point_id " +
                                "WHERE tbl_customer.id != 1 AND tbl_customer.id != 2 AND tbl_customer.id != 4 AND tbl_customer.id=@CustomerID " +
                                "ORDER BY name"; //7 = Dorothy
            try
            {
                //Comm = new MySqlCommand(strQuery, MySqlConn);
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = strQuery;
                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@CustomerID", _intCustomerID);
                Conn.Open();

                ds = new DataSet();
                //MySqlDataAdapter adp = new MySqlDataAdapter();
                adp.Fill(ds, "tblJobs");

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion


        #region GetSavedJobsByUser
        public static DataTable GetSavedJobsByUser(int _intUserID, int _intUAL, int _intCustomerID, int _intShowJobBy, string _strSortBy, string _strSortOrder, string _strSearchBy)
        {
            int intAdminUserID = ClsID.intUserAdminID;

            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());

            try
            {
                //Comm.CommandType = CommandType.StoredProcedure;
                //string strSQL = "SELECT job.*, user_1.first_name as created_user_first_name, user_1.last_name as created_user_last_name, " +
                //            "user_2.first_name as revised_user_first_name, user_2.last_name as revised_user_last_name, rep.name as rep_name " +
                //            "FROM sav_job job " +
                //            "LEFT JOIN sav_user user_1 ON job.created_user_id = user_1.id " +
                //            "LEFT JOIN sav_user user_2 ON job.revised_user_id = user_2.id " +
                //            "LEFT JOIN sav_representative rep ON job.customer_id = rep.id ";
                ////"LEFT JOIN sel_job_status job_status ON job.job_status_id = job_status.id ";

                string strSQL = "SELECT *, tbl_customer.name Customer_Name, CONCAT(tbl_created_user.first_name, \" \", tbl_created_user.last_name) Created_User_Full_Name, " +
                            "CONCAT(tbl_revised_user.first_name, \" \", tbl_revised_user.last_name) Revised_User_Full_Name " +
                            "FROM `" + ClsDBT.strSavJob + "` tbl_job " +
                            "LEFT JOIN `" + ClsDBT.strSavUsers + "` tbl_created_user ON tbl_created_user.id = tbl_job.created_user_id " +
                            "LEFT JOIN `" + ClsDBT.strSavUsers + "` tbl_revised_user ON tbl_revised_user.id = tbl_job.revised_user_id " +
                            "LEFT JOIN `" + ClsDBT.strSavCustomer + "` tbl_customer ON tbl_customer.id = tbl_created_user.customer_id ";

                if (_strSearchBy == "")
                {
                    if (_intUAL == ClsID.intUAL_Admin)
                    {
                        if (_intShowJobBy == 1)
                        {
                            strSQL += "WHERE tbl_job.created_user_id = @UserID ";
                        }
                        else if (_intShowJobBy == 2)
                        {
                            strSQL += "WHERE tbl_job.created_user_id != @UserID AND tbl_job.created_user_id != @UserAdminID ";
                        }
                    }
                    else if (_intUAL == ClsID.intUAL_IntAdmin)
                    {
                        if (_intShowJobBy == 1)
                        {
                            strSQL += "WHERE tbl_job.created_user_id = @UserID ";
                        }
                        else if (_intShowJobBy == 2)
                        {
                            strSQL += "WHERE tbl_job.created_user_id != @UserID AND tbl_job.created_user_id != @UserAdminID ";
                        }
                    }
                    else if (_intUAL == ClsID.intUAL_IntLvl_2)
                    {
                        if (_intShowJobBy == 1)
                        {
                            strSQL += "WHERE tbl_job.created_user_id = @UserID ";
                        }
                        else if (_intShowJobBy == 2)
                        {
                            strSQL += "WHERE tbl_job.created_user_id != @UserID AND tbl_job.created_user_id != @UserAdminID ";
                        }
                    }
                    else if (_intUAL == ClsID.intUAL_IntLvl_1)
                    {
                        if (_intShowJobBy == 1)
                        {
                            strSQL += "WHERE tbl_job.created_user_id = @UserID ";
                        }
                        //else if (_intShowJobBy == 2)
                        //{
                        //}
                    }
                    else if (_intUAL == ClsID.intUAL_External)
                    {
                        if (_intShowJobBy == 1)
                        {
                            strSQL += "WHERE tbl_job.created_user_id = @UserID ";
                        }
                        //else if (_intShowJobBy == 2)
                        //{
                        //}
                    }
                    else
                    {
                        strSQL += "WHERE tbl_job.created_user_id = @UserID ";
                    }
                }
                else
                {
                    if (_intUAL == ClsID.intUAL_Admin)
                    {
                        if (_intShowJobBy == 1)
                        {
                            strSQL += "WHERE tbl_job.created_user_id = @UserID AND (tbl_job.id LIKE @SearchBy OR tbl_job.job_name LiKE @SearchBy OR tbl_job.reference_no LIKE @SearchBy OR tbl_job.created_date LIKE @SearchBy OR tbl_created_user.first_name LIKE @SearchBy OR tbl_created_user.last_name LIKE @SearchBy) ";
                        }
                        else if (_intShowJobBy == 2)
                        {
                            strSQL += "WHERE tbl_job.created_user_id != @UserID AND tbl_job.created_user_id != @UserAdminID AND (tbl_job.id LIKE @SearchBy OR tbl_job.job_name LiKE @SearchBy OR tbl_job.reference_no LIKE @SearchBy OR tbl_job.created_date LIKE @SearchBy OR tbl_created_user.first_name LIKE @SearchBy OR tbl_created_user.last_name LIKE @SearchBy OR tbl_customer.name LIKE @SearchBy) ";
                        }
                    }
                    else if (_intUAL == ClsID.intUAL_IntAdmin)
                    {
                        if (_intShowJobBy == 1)
                        {
                            strSQL += "WHERE tbl_job.created_user_id = @UserID AND (tbl_job.id LIKE @SearchBy OR tbl_job.job_name LiKE @SearchBy OR tbl_job.reference_no LIKE @SearchBy OR tbl_job.created_date LIKE @SearchBy OR tbl_created_user.first_name LIKE @SearchBy OR tbl_created_user.last_name LIKE @SearchBy) ";
                        }
                        else if (_intShowJobBy == 2)
                        {
                            strSQL += "WHERE tbl_job.created_user_id != @UserID AND tbl_job.created_user_id != @UserAdminID AND (tbl_job.id LIKE @SearchBy OR tbl_job.job_name LiKE @SearchBy OR tbl_job.reference_no LIKE @SearchBy OR tbl_job.created_date LIKE @SearchBy OR tbl_created_user.first_name LIKE @SearchBy OR tbl_created_user.last_name LIKE @SearchBy OR tbl_customer.name LIKE @SearchBy) ";
                        }
                    }
                    else if (_intUAL == ClsID.intUAL_IntLvl_2)
                    {
                        if (_intShowJobBy == 1)
                        {
                            strSQL += "WHERE tbl_job.created_user_id = @UserID AND (tbl_job.id LIKE @SearchBy OR tbl_job.job_name LiKE @SearchBy OR tbl_job.reference_no LIKE @SearchBy OR tbl_job.created_date LIKE @SearchBy OR tbl_created_user.first_name LIKE @SearchBy OR tbl_created_user.last_name LIKE @SearchBy) ";
                        }
                        else if (_intShowJobBy == 2)
                        {
                            strSQL += "WHERE tbl_job.created_user_id != @UserID AND tbl_job.created_user_id != @UserAdminID AND (tbl_job.id LIKE @SearchBy OR tbl_job.job_name LiKE @SearchBy OR tbl_job.reference_no LIKE @SearchBy OR tbl_job.created_date LIKE @SearchBy OR tbl_created_user.first_name LIKE @SearchBy OR tbl_created_user.last_name LIKE @SearchBy OR tbl_customer.name LIKE @SearchBy) ";
                        }
                    }
                    else if (_intUAL == ClsID.intUAL_IntLvl_1)
                    {
                        if (_intShowJobBy == 1)
                        {
                            strSQL += "WHERE tbl_job.created_user_id = @UserID AND (tbl_job.id LIKE @SearchBy OR tbl_job.job_name LiKE @SearchBy OR tbl_job.reference_no LIKE @SearchBy OR tbl_job.created_date LIKE @SearchBy OR tbl_created_user.first_name LIKE @SearchBy OR tbl_created_user.last_name LIKE @SearchBy) ";
                        }
                        //else if (_intShowJobBy == 2)
                        //{
                        //    strSQL += "WHERE tbl_job.created_user_id != @UserID AND tbl_job.created_user_id != @UserAdminID AND (tbl_job.id LIKE @SearchBy OR tbl_job.job_name LiKE @SearchBy OR tbl_job.reference_no LIKE @SearchBy OR tbl_job.created_date LIKE @SearchBy OR tbl_user.first_name LIKE @SearchBy OR tbl_user.last_name LIKE @SearchBy OR tbl_customer.name LIKE @SearchBy) ";
                        //}
                    }
                    else if (_intUAL == ClsID.intUAL_External)
                    {
                        if (_intShowJobBy == 1)
                        {
                            strSQL += "WHERE tbl_job.created_user_id = @UserID AND (tbl_job.id LIKE @SearchBy OR tbl_job.job_name LiKE @SearchBy OR tbl_job.reference_no LIKE @SearchBy OR tbl_job.created_date LIKE @SearchBy OR tbl_created_user.first_name LIKE @SearchBy OR tbl_created_user.last_name LIKE @SearchBy) ";
                        }
                        //else if (_intShowJobBy == 2)
                        //{
                        //    strSQL += "WHERE job.customer_id = @RepresentativeID AND (job.id LIKE CONCAT(''%', @SearchBy, '%'') OR job.job_name LiKE CONCAT(''%', @SearchBy, '%'') OR job.reference_no LIKE CONCAT(''%', @SearchBy, '%'') OR job.created_date LIKE CONCAT(''%', @SearchBy, '%'')) ";
                        //}
                    }
                    else
                    {
                        strSQL += "WHERE tbl_job.created_user_id = @UserID AND (tbl_job.id LIKE @SearchBy OR tbl_job.job_name LiKE @SearchBy OR tbl_job.reference_no LIKE @SearchBy OR tbl_job.created_date LIKE @SearchBy OR tbl_created_user.first_name LIKE @SearchBy OR tbl_created_user.last_name LIKE @SearchBy) ";
                    }
                }


                if (_strSortBy == "Created_User_Full_Name" || _strSortBy == "Customer_Name")
                {
                    strSQL += "ORDER BY " + _strSortBy + " " + _strSortOrder + " LIMIT 400";
                }
                else
                {
                    strSQL += "ORDER BY tbl_job." + _strSortBy + " " + _strSortOrder + " LIMIT 400";
                }

                Comm.CommandType = CommandType.Text;
                Comm.CommandText = strSQL;
                Conn.Open();
                //Comm.Parameters.AddWithValue("@UserID", _intUserID);
                Comm.Parameters.AddWithValue("@UserID", MySqlDbType.Int32).Value = _intUserID;
                Comm.Parameters.AddWithValue("@UserAdminID", MySqlDbType.Int32).Value = intAdminUserID;
                Comm.Parameters.AddWithValue("@CustomerID", MySqlDbType.Int32).Value = _intCustomerID;
                Comm.Parameters.AddWithValue("@SearchBy", "%" + _strSearchBy + "%");

                adp.Fill(ds, "DataTable");
                return ds.Tables[0];
            }
            catch
            {
                return null;
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion


        #region GetSavedJob
        public static DataTable GetSavedJob(int _intJobID)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());


            //string strQuery = "SELECT *, tbl_customer.name Customer_Name, CONCAT(tbl_user.first_name, \" \", tbl_user.last_name) User_Full_Name " +
            //                    "FROM `" + ClsDBT.strSavJob + "` tbl_job " +
            //                    "LEFT JOIN `" + ClsDBT.strSavUsers + "` tbl_user ON tbl_user.id = tbl_job.created_user_id " +
            //                    "LEFT JOIN `" + ClsDBT.strSavCustomer + "` tbl_customer ON tbl_customer.id = tbl_user.customer_id " +
            //                    "WHERE tbl_job.id = @JobID";


            string strQuery = "SELECT *, CONCAT(tbl_user.first_name, \" \", tbl_user.last_name) User_Full_Name, " +
                                "tbl_customer.id CustomerID, tbl_customer.name Customer_Name, tbl_customer.contact_name Customer_Contact_Name, tbl_customer.country_id Customer_Country_ID, tbl_customer.shipping_factor_percent CustomerShippingFactorPercent " +
                                "FROM `" + ClsDBT.strSavJob + "` tbl_job " +
                                "LEFT JOIN `" + ClsDBT.strSavUsers + "` tbl_user ON tbl_user.id = tbl_job.created_user_id " +
                                "LEFT JOIN `" + ClsDBT.strSavCustomer + "` tbl_customer ON tbl_customer.id = tbl_job.company_name_id " +
                                "WHERE tbl_job.id = @JobID";

            try
            {
                //Comm = new MySqlCommand(strQuery, MySqlConn);
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = strQuery;
                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                Conn.Open();

                ds = new DataSet();
                //MySqlDataAdapter adp = new MySqlDataAdapter();
                adp.Fill(ds, "tblJobs");

                return ds.Tables[0];

            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion


        #region GetSavedUnitsModel
        public static DataTable GetSavedUnitsModel(int _intJobID)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());

            try
            {
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = "SELECT *, tbl_sel_nova_unit_model.items AS NovaUnitModel, tbl_sel_nova_unit_model.model_bypass AS NovaUnitModelBypass " +
                                    "FROM `" + ClsDBT.strSavGeneral + "` tbl_sav_unit " +
                                    "LEFT JOIN `" + ClsDBT.strSelNovaUnitModel + "` tbl_sel_nova_unit_model ON tbl_sel_nova_unit_model.id = tbl_sav_unit.unit_model_id AND tbl_sav_unit.product_type_id='1' " +
                                    "WHERE tbl_sav_unit.job_id=@JobID ";

                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                Conn.Open();
                Comm.ExecuteNonQuery();

                adp.Fill(ds, "DataTable");
                return ds.Tables[0];
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion


        #region GetSavedUnitsNo
        public static DataTable GetSavedUnitsNo(int _intJobID)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());

            try
            {
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = "SELECT `tbl_sav_unit`.unit_no UnitNo " +
                                    "FROM `" + ClsDBT.strSavGeneral + "` tbl_sav_unit " +
                                    "WHERE `tbl_sav_unit`.job_id=@JobID ";
                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                Conn.Open();
                Comm.ExecuteNonQuery();

                adp.Fill(ds, "DataTable");
                return ds.Tables[0];
            }
            catch
            {
                return null;
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion


        #region GetSavedUnits
        public static DataTable GetSavedUnitsAndComps(int _intJobID)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());

            try
            {
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSavGeneral + "` tbl_sav_unit " +
                                    "LEFT JOIN `" + ClsDBT.strSavCompOption + "` tbl_sav_comp_opt ON tbl_sav_comp_opt.job_id = tbl_sav_unit.job_id AND tbl_sav_comp_opt.unit_no = tbl_sav_unit.unit_no " +
                                    "WHERE tbl_sav_unit.job_id=@JobID ";
                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                Conn.Open();
                Comm.ExecuteNonQuery();

                adp.Fill(ds, "DataTable");
                return ds.Tables[0];
            }
            catch
            {
                return null;
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion


        public static DataSet GetSavedUnitItems(int _intJobID, int _intUnitNo)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());

            try
            {
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSavGeneral + "` tbl_sav_unit WHERE `tbl_sav_unit`.job_id=@JobID AND `tbl_sav_unit`.unit_no=@UnitNo";
                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                Comm.Parameters.AddWithValue("@UnitNo", _intUnitNo);
                Conn.Open();
                Comm.ExecuteNonQuery();

                adp.Fill(ds, ClsDBT.strSavGeneral);
                //DataTable dtUnit = ds.Tables[ClsDBT.strSavGeneral];
                DataRow drUnit = ds.Tables[ClsDBT.strSavGeneral].Rows[0];
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSavCompOption + "` tbl_sav_opt WHERE `tbl_sav_opt`.job_id=@JobID AND `tbl_sav_opt`.unit_no=@UnitNo";
                Comm.ExecuteNonQuery();
                adp.Fill(ds, ClsDBT.strSavCompOption);

                //DataTable dtOption = ds.Tables[ClsDBT.strSavCompOption];
                DataRow drOption = ds.Tables[ClsDBT.strSavCompOption].Rows[0];
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSavCompOptionCustom + "` tbl_sav_opt_cust WHERE `tbl_sav_opt_cust`.job_id=@JobID AND `tbl_sav_opt_cust`.unit_no=@UnitNo";
                Comm.ExecuteNonQuery();
                adp.Fill(ds, ClsDBT.strSavCompOptionCustom);


                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSavLayout + "` tbl_sav_layout WHERE `tbl_sav_layout`.job_id=@JobID AND `tbl_sav_layout`.unit_no=@UnitNo";
                Comm.ExecuteNonQuery();

                adp.Fill(ds, ClsDBT.strSavLayout);
                //DataTable dtLayout = ds.Tables[ClsDBT.strSavCompOption];
                DataRow drLayout = ds.Tables[ClsDBT.strSavLayout].Rows[0];


                //if (dtUnit.Rows.Count > 0)
                //{
                Comm.Parameters.Clear();
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSelProductType + "` WHERE id=@ID";
                Comm.Parameters.AddWithValue("@ID", Convert.ToInt32(drUnit["product_type_id"]));
                Comm.ExecuteNonQuery();
                adp.Fill(ds, ClsDBT.strSelProductType);

                Comm.Parameters.Clear();
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSelUnitType + "` WHERE id=@ID";
                Comm.Parameters.AddWithValue("@ID", Convert.ToInt32(drUnit["unit_type_id"]));
                Comm.ExecuteNonQuery();
                adp.Fill(ds, ClsDBT.strSelUnitType);

                Comm.Parameters.Clear();
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSelGeneralLocation + "` WHERE id=@ID";
                Comm.Parameters.AddWithValue("@ID", Convert.ToInt32(drUnit["location_id"]));
                Comm.ExecuteNonQuery();
                adp.Fill(ds, ClsDBT.strSelGeneralLocation);

                Comm.Parameters.Clear();
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSelGeneralOrientation + "` WHERE id=@ID";
                Comm.Parameters.AddWithValue("@ID", Convert.ToInt32(drUnit["orientation_id"]));
                Comm.ExecuteNonQuery();
                adp.Fill(ds, ClsDBT.strSelGeneralOrientation);

                Comm.Parameters.Clear();
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSelControlsPreference + "` WHERE id=@ID";
                Comm.Parameters.AddWithValue("@ID", Convert.ToInt32(drUnit["controls_preference_id"]));
                Comm.ExecuteNonQuery();
                adp.Fill(ds, ClsDBT.strSelControlsPreference);

                Comm.Parameters.Clear();
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSelElectricalVoltage + "` WHERE id=@ID";
                Comm.Parameters.AddWithValue("@ID", Convert.ToInt32(drUnit["voltage_id"]));
                Comm.ExecuteNonQuery();
                adp.Fill(ds, ClsDBT.strSelElectricalVoltage);

                string strUnitModelTable = "";


                switch (Convert.ToInt32(drUnit["product_type_id"]))
                {
                    case ClsID.intProdTypeNovaID:
                        strUnitModelTable = ClsDBT.strSelNovaUnitModel;
                        break;
                    default:
                        break;
                }


                Comm.Parameters.Clear();
                Comm.CommandText = "SELECT * FROM `" + strUnitModelTable + "` WHERE id=@ID";
                Comm.Parameters.AddWithValue("@ID", Convert.ToInt32(drUnit["unit_model_id"]));
                Comm.ExecuteNonQuery();
                adp.Fill(ds, "UnitModel");


                //if (Convert.ToInt32(drUnit["product_type_id"]) == ClsID.intProdTypeNovaID)
                //{
                //    Comm.Parameters.Clear();
                //    Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSelNovaUnitSize + "` WHERE unit_model_id=@ID AND unit_orientation_value=@OrientationValue AND selection_type_id=@SelectionTypeID";
                //    Comm.Parameters.AddWithValue("@ID", Convert.ToInt32(ds.Tables["UnitModel"].Rows[0]["id"]));
                //    Comm.Parameters.AddWithValue("@OrientationValue", ds.Tables[ClsDBT.strSelGeneralOrientation].Rows[0]["value"].ToString());
                //    Comm.Parameters.AddWithValue("@SelectionTypeID", Convert.ToInt32(drUnit["selection_type_id"]));
                //    Comm.ExecuteNonQuery();
                //    adp.Fill(ds, "UnitModelSize");
                //}
                //else if (Convert.ToInt32(drUnit["product_type_id"]) == ClsID.intProdTypeVentumID)
                //{
                //    Comm.Parameters.Clear();
                //    Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSelVentumUnitSize + "` WHERE unit_model_id=@ID";
                //    Comm.Parameters.AddWithValue("@ID", Convert.ToInt32(ds.Tables["UnitModel"].Rows[0]["id"]));
                //    Comm.ExecuteNonQuery();
                //    adp.Fill(ds, "UnitModelSize");
                //}
                //else if (Convert.ToInt32(drUnit["product_type_id"]) == ClsID.intProdTypeVentumLiteID)
                //{
                //    Comm.Parameters.Clear();
                //    Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSelVentumLiteUnitSize + "` WHERE unit_model_id=@ID";
                //    Comm.Parameters.AddWithValue("@ID", Convert.ToInt32(ds.Tables["UnitModel"].Rows[0]["id"]));
                //    Comm.ExecuteNonQuery();
                //    adp.Fill(ds, "UnitModelSize");
                //}


                switch (Convert.ToInt32(drUnit["product_type_id"]))
                {
                    case ClsID.intProdTypeNovaID:
                        Comm.Parameters.Clear();
                        Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSelNovaUnitSize + "` WHERE unit_model_id=@ID AND unit_orientation_value=@OrientationValue AND selection_type_id=@SelectionTypeID";
                        Comm.Parameters.AddWithValue("@ID", Convert.ToInt32(ds.Tables["UnitModel"].Rows[0]["id"]));
                        Comm.Parameters.AddWithValue("@OrientationValue", ds.Tables[ClsDBT.strSelGeneralOrientation].Rows[0]["value"].ToString());
                        Comm.Parameters.AddWithValue("@SelectionTypeID", Convert.ToInt32(drUnit["selection_type_id"]));
                        Comm.ExecuteNonQuery();
                        adp.Fill(ds, "UnitModelSize");
                        break;
                    default:
                        break;
                }


                //Options
                //if (dtOption.Rows.Count > 0)
                //{
                Comm.Parameters.Clear();
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSelFilterModel + "` WHERE id=@ID";
                Comm.Parameters.AddWithValue("@ID", Convert.ToInt32(drOption["oa_filter_model_id"]));
                Comm.ExecuteNonQuery();
                adp.Fill(ds, "OA_FilterModel");

                Comm.Parameters.Clear();
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSelFilterModel + "` WHERE id=@ID";
                Comm.Parameters.AddWithValue("@ID", Convert.ToInt32(drOption["final_filter_model_id"]));
                Comm.ExecuteNonQuery();
                adp.Fill(ds, "FinalFilterModel");

                Comm.Parameters.Clear();
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSelFilterModel + "` WHERE id=@ID";
                Comm.Parameters.AddWithValue("@ID", Convert.ToInt32(drOption["ra_filter_model_id"]));
                Comm.ExecuteNonQuery();
                adp.Fill(ds, "RA_FilterModel");

                Comm.Parameters.Clear();
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSelUnitHeatExchanger + "` WHERE id=@ID";
                Comm.Parameters.AddWithValue("@ID", Convert.ToInt32(drOption["heat_exch_comp_id"]));
                Comm.ExecuteNonQuery();
                adp.Fill(ds, ClsDBT.strSelUnitHeatExchanger);

                Comm.Parameters.Clear();
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSelComponent + "` WHERE id=@ID";
                Comm.Parameters.AddWithValue("@ID", Convert.ToInt32(drOption["preheat_comp_id"]));
                Comm.ExecuteNonQuery();
                adp.Fill(ds, "PreheatComp");

                Comm.Parameters.Clear();
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSelComponent + "` WHERE id=@ID";
                Comm.Parameters.AddWithValue("@ID", Convert.ToInt32(drOption["cooling_comp_id"]));
                Comm.ExecuteNonQuery();
                adp.Fill(ds, "CoolingComp");

                Comm.Parameters.Clear();
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSelComponent + "` WHERE id=@ID";
                Comm.Parameters.AddWithValue("@ID", Convert.ToInt32(drOption["heating_comp_id"]));
                Comm.ExecuteNonQuery();
                adp.Fill(ds, "HeatingComp");

                Comm.Parameters.Clear();
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSelComponent + "` WHERE id=@ID";
                Comm.Parameters.AddWithValue("@ID", Convert.ToInt32(drOption["reheat_comp_id"]));
                Comm.ExecuteNonQuery();
                adp.Fill(ds, "ReheatComp");

                Comm.Parameters.Clear();
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSelElectricalVoltage + "` WHERE id=@ID";
                Comm.Parameters.AddWithValue("@ID", Convert.ToInt32(drOption["elec_heater_voltage_id"]));
                Comm.ExecuteNonQuery();
                adp.Fill(ds, "ElecHeaterVoltage");

                Comm.Parameters.Clear();
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSelElectricHeaterInstallation + "` WHERE id=@ID";
                Comm.Parameters.AddWithValue("@ID", Convert.ToInt32(drOption["preheat_elec_heater_installation_id"]));
                Comm.ExecuteNonQuery();
                adp.Fill(ds, "PreheatElecHeaterInstallation");

                Comm.Parameters.Clear();
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSelElectricHeaterInstallation + "` WHERE id=@ID";
                Comm.Parameters.AddWithValue("@ID", Convert.ToInt32(drOption["heat_elec_heater_installation_id"]));
                Comm.ExecuteNonQuery();
                adp.Fill(ds, "HeatingElecHeaterInstallation");

                Comm.Parameters.Clear();
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSelDamperActuator + "` WHERE id=@ID";
                Comm.Parameters.AddWithValue("@ID", Convert.ToInt32(drOption["damper_and_actuator_id"]));
                Comm.ExecuteNonQuery();
                adp.Fill(ds, ClsDBT.strSelDamperActuator);


                Comm.Parameters.Clear();
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSelValveAndActuator + "` WHERE id=@ID";
                Comm.Parameters.AddWithValue("@ID", Convert.ToInt32(drOption["preheat_hwc_valve_and_actuator_id"]));
                Comm.ExecuteNonQuery();
                adp.Fill(ds, "PreheatHWC_ValveActuator");

                Comm.Parameters.Clear();
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSelValveAndActuator + "` WHERE id=@ID";
                Comm.Parameters.AddWithValue("@ID", Convert.ToInt32(drOption["cooling_cwc_valve_and_actuator_id"]));
                Comm.ExecuteNonQuery();
                adp.Fill(ds, "CoolingCWC_ValveActuator");

                Comm.Parameters.Clear();
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSelValveAndActuator + "` WHERE id=@ID";
                Comm.Parameters.AddWithValue("@ID", Convert.ToInt32(drOption["heating_hwc_valve_and_actuator_id"]));
                Comm.ExecuteNonQuery();
                adp.Fill(ds, "HeatingHWC_ValveActuator");

                Comm.Parameters.Clear();
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSelValveAndActuator + "` WHERE id=@ID";
                Comm.Parameters.AddWithValue("@ID", Convert.ToInt32(drOption["reheat_hwc_valve_and_actuator_id"]));
                Comm.ExecuteNonQuery();
                adp.Fill(ds, "ReheatHWC_ValveActuator");




                Comm.Parameters.Clear();
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSelValveType + "` WHERE id=@ID";
                Comm.Parameters.AddWithValue("@ID", Convert.ToInt32(drOption["valve_type_id"]));
                Comm.ExecuteNonQuery();
                adp.Fill(ds, ClsDBT.strSelValveType);


                Comm.Parameters.Clear();
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSelFluidType + "` WHERE id=@ID";
                Comm.Parameters.AddWithValue("@ID", Convert.ToInt32(drOption["cooling_fluid_type_id"]));
                Comm.ExecuteNonQuery();
                adp.Fill(ds, "CoolingFluidType");


                Comm.Parameters.Clear();
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSelFluidConcentration + "` WHERE id=@ID";
                Comm.Parameters.AddWithValue("@ID", Convert.ToInt32(drOption["cooling_fluid_concent_id"]));
                Comm.ExecuteNonQuery();
                adp.Fill(ds, "CoolingFluidConcentration");


                Comm.Parameters.Clear();
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSelFluidType + "` WHERE id=@ID";
                Comm.Parameters.AddWithValue("@ID", Convert.ToInt32(drOption["heating_fluid_type_id"]));
                Comm.ExecuteNonQuery();
                adp.Fill(ds, "HeatingFluidType");


                Comm.Parameters.Clear();
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSelFluidConcentration + "` WHERE id=@ID";
                Comm.Parameters.AddWithValue("@ID", Convert.ToInt32(drOption["heating_fluid_concent_id"]));
                Comm.ExecuteNonQuery();
                adp.Fill(ds, "HeatingFluidConcentration");


                //string strElectricHeaterModel = Convert.ToInt32(ds.Tables[ClsDBT.strSavGeneral].Rows[0]["product_type_id"]) == ClsID.intProdTypeVentumID ? ClsDBT.strSelVentumElectricHeaterModel : ClsDBT.strSelNovaElectricHeaterModel;
                string strElectricHeaterModel = "";

                switch (Convert.ToInt32(ds.Tables[ClsDBT.strSavGeneral].Rows[0]["product_type_id"]))
                {
                    case ClsID.intProdTypeNovaID:
                        strElectricHeaterModel = ClsDBT.strSelNovaElectricHeaterModel;
                        break;
                    default:
                        break;
                }



                if (Convert.ToInt32(drOption["preheat_elec_heater_std_coil_no"]) > 0)
                {
                    Comm.Parameters.Clear();
                    Comm.CommandText = "SELECT * FROM `" + strElectricHeaterModel + "` WHERE unit_model=@UnitModel AND volt=@Volt AND phase=@Phase AND standard_coil_no=@StandardCoilNo";
                    Comm.Parameters.AddWithValue("@UnitModel", ds.Tables["UnitModel"].Rows[0]["value"].ToString());
                    Comm.Parameters.AddWithValue("@Volt", Convert.ToInt32(ds.Tables["ElecHeaterVoltage"].Rows[0]["volt"]));
                    Comm.Parameters.AddWithValue("@Phase", Convert.ToInt32(ds.Tables["ElecHeaterVoltage"].Rows[0]["phase"]));
                    Comm.Parameters.AddWithValue("@StandardCoilNo", Convert.ToInt32(drOption["preheat_elec_heater_std_coil_no"]));
                    Comm.ExecuteNonQuery();
                    adp.Fill(ds, "PreheatElecHeater");
                }

                if (Convert.ToInt32(drOption["heating_elec_heater_std_coil_no"]) > 0)
                {
                    Comm.Parameters.Clear();
                    Comm.CommandText = "SELECT * FROM `" + strElectricHeaterModel + "` WHERE unit_model=@UnitModel AND volt=@Volt AND phase=@Phase AND standard_coil_no=@StandardCoilNo";
                    Comm.Parameters.AddWithValue("@UnitModel", ds.Tables["UnitModel"].Rows[0]["value"].ToString());
                    Comm.Parameters.AddWithValue("@Volt", Convert.ToInt32(ds.Tables["ElecHeaterVoltage"].Rows[0]["volt"]));
                    Comm.Parameters.AddWithValue("@Phase", Convert.ToInt32(ds.Tables["ElecHeaterVoltage"].Rows[0]["phase"]));
                    Comm.Parameters.AddWithValue("@StandardCoilNo", Convert.ToInt32(drOption["heating_elec_heater_std_coil_no"]));
                    Comm.ExecuteNonQuery();
                    adp.Fill(ds, "HeatingElecHeater");
                }

                if (Convert.ToInt32(drOption[ClsDBTC.reheat_elec_heater_std_coil_no]) > 0)
                {
                    Comm.Parameters.Clear();
                    Comm.CommandText = "SELECT * FROM `" + strElectricHeaterModel + "` WHERE unit_model=@UnitModel AND volt=@Volt AND phase=@Phase AND standard_coil_no=@StandardCoilNo";
                    Comm.Parameters.AddWithValue("@UnitModel", ds.Tables["UnitModel"].Rows[0]["value"].ToString());
                    Comm.Parameters.AddWithValue("@Volt", Convert.ToInt32(ds.Tables["ElecHeaterVoltage"].Rows[0]["volt"]));
                    Comm.Parameters.AddWithValue("@Phase", Convert.ToInt32(ds.Tables["ElecHeaterVoltage"].Rows[0]["phase"]));
                    Comm.Parameters.AddWithValue("@StandardCoilNo", Convert.ToInt32(drOption["reheat_elec_heater_std_coil_no"]));
                    Comm.ExecuteNonQuery();
                    adp.Fill(ds, "ReheatElecHeater");
                }


                Comm.Parameters.Clear();
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSelHanding + "` WHERE id=@ID";
                Comm.Parameters.AddWithValue("@ID", Convert.ToInt32(drLayout["handing_id"]));
                Comm.ExecuteNonQuery();
                adp.Fill(ds, ClsDBT.strSelHanding);

                Comm.Parameters.Clear();
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSelHanding + "` WHERE id=@ID";
                Comm.Parameters.AddWithValue("@ID", Convert.ToInt32(drLayout["preheat_coil_handing_id"]));
                Comm.ExecuteNonQuery();
                adp.Fill(ds, "PreheatCoilHanding");

                Comm.Parameters.Clear();
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSelHanding + "` WHERE id=@ID";
                Comm.Parameters.AddWithValue("@ID", Convert.ToInt32(drLayout["cooling_coil_handing_id"]));
                Comm.ExecuteNonQuery();
                adp.Fill(ds, "CoolingCoilHanding");

                Comm.Parameters.Clear();
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSelHanding + "` WHERE id=@ID";
                Comm.Parameters.AddWithValue("@ID", Convert.ToInt32(drLayout["heating_coil_handing_id"]));
                Comm.ExecuteNonQuery();
                adp.Fill(ds, "HeatingCoilHanding");


                switch (Convert.ToInt32(ds.Tables[ClsDBT.strSavGeneral].Rows[0]["product_type_id"]))
                {
                    case ClsID.intProdTypeNovaID:
                    case ClsID.intProdTypeVentumID:
                    case ClsID.intProdTypeVentumLiteID:
                        Comm.Parameters.Clear();
                        Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSelOpeningsERV_SA + "` WHERE dwg_code=@Opening AND product_type_id=@ProductTypeID";
                        Comm.Parameters.AddWithValue("@Opening", drLayout["sa_opening"].ToString());
                        Comm.Parameters.AddWithValue("@ProductTypeID", Convert.ToInt32(drUnit["product_type_id"]));
                        Comm.ExecuteNonQuery();
                        adp.Fill(ds, ClsDBT.strSelOpeningsERV_SA);

                        Comm.Parameters.Clear();
                        Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSelOpeningsERV_EA + "` WHERE dwg_code=@Opening AND product_type_id=@ProductTypeID";
                        Comm.Parameters.AddWithValue("@Opening", drLayout["ea_opening"].ToString());
                        Comm.Parameters.AddWithValue("@ProductTypeID", Convert.ToInt32(drUnit["product_type_id"]));
                        Comm.ExecuteNonQuery();
                        adp.Fill(ds, ClsDBT.strSelOpeningsERV_EA);

                        Comm.Parameters.Clear();
                        Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSelOpeningsERV_OA + "` WHERE dwg_code=@Opening AND product_type_id=@ProductTypeID";
                        Comm.Parameters.AddWithValue("@Opening", drLayout["oa_opening"].ToString());
                        Comm.Parameters.AddWithValue("@ProductTypeID", Convert.ToInt32(drUnit["product_type_id"]));
                        Comm.ExecuteNonQuery();
                        adp.Fill(ds, ClsDBT.strSelOpeningsERV_OA);

                        Comm.Parameters.Clear();
                        Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSelOpeningsERV_RA + "` WHERE dwg_code=@Opening AND product_type_id=@ProductTypeID";
                        Comm.Parameters.AddWithValue("@Opening", drLayout["ra_opening"].ToString());
                        Comm.Parameters.AddWithValue("@ProductTypeID", Convert.ToInt32(drUnit["product_type_id"]));
                        Comm.ExecuteNonQuery();
                        adp.Fill(ds, ClsDBT.strSelOpeningsERV_RA);
                        break;
                    case ClsID.intProdTypeTerraID:
                        Comm.Parameters.Clear();
                        Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSelOpeningsFC_SA + "` WHERE dwg_code=@Opening AND product_type_id=@ProductTypeID";
                        Comm.Parameters.AddWithValue("@Opening", drLayout["sa_opening"].ToString());
                        Comm.Parameters.AddWithValue("@ProductTypeID", Convert.ToInt32(drUnit["product_type_id"]));
                        Comm.ExecuteNonQuery();
                        adp.Fill(ds, ClsDBT.strSelOpeningsFC_SA);

                        Comm.Parameters.Clear();
                        Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSelOpeningsFC_OA + "` WHERE dwg_code=@Opening AND product_type_id=@ProductTypeID";
                        Comm.Parameters.AddWithValue("@Opening", drLayout["oa_opening"].ToString());
                        Comm.Parameters.AddWithValue("@ProductTypeID", Convert.ToInt32(drUnit["product_type_id"]));
                        Comm.ExecuteNonQuery();
                        adp.Fill(ds, ClsDBT.strSelOpeningsFC_OA);
                        break;
                    default:
                        break;
                }



                //                "LEFT JOIN `" + ClsDBT.strSelOpeningsERV_SA + "` tbl_sel_open_sa ON tbl_sel_open_sa.dwg_code = tbl_sav_layout.sa_opening AND tbl_sel_open_sa.product_type_id = tbl_sav_unit.product_type_id " +
                //"LEFT JOIN `" + ClsDBT.strSelOpeningsERV_EA + "` tbl_sel_open_ea ON tbl_sel_open_ea.dwg_code = tbl_sav_layout.ea_opening AND tbl_sel_open_ea.product_type_id = tbl_sav_unit.product_type_id " +
                //"LEFT JOIN `" + ClsDBT.strSelOpeningsERV_RA + "` tbl_sel_open_ra ON tbl_sel_open_ra.dwg_code = tbl_sav_layout.ra_opening AND tbl_sel_open_ra.product_type_id = tbl_sav_unit.product_type_id " +
                //"LEFT JOIN `" + ClsDBT.strSelOpeningsERV_OA + "` tbl_sel_open_oa ON tbl_sel_open_oa.dwg_code = tbl_sav_layout.oa_opening AND tbl_sel_open_oa.product_type_id = tbl_sav_unit.product_type_id " +




                //    }
                //}


                return ds;

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("==================================================");
                System.Diagnostics.Debug.WriteLine(e);
                return null;
            }
            finally
            {
                Conn.Close();
            }
        }


        public static DataSet GetSavedUnitOptionItems(int _intJobID, int _intUnitNo)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());

            try
            {
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSavCompOption + "` tbl_sav_opt WHERE `tbl_sav_opt`.job_id=@JobID AND `tbl_sav_opt`.unit_no=@UnitNo";

                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                Comm.Parameters.AddWithValue("@UnitNo", _intUnitNo);
                Conn.Open();
                Comm.ExecuteNonQuery();

                adp.Fill(ds, ClsDBT.strSavCompOption);
                DataTable dtOption = ds.Tables[ClsDBT.strSavCompOption];
                DataRow drOption = ds.Tables[ClsDBT.strSavGeneral].Rows[0];

                Comm.Parameters.Clear();
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSavGeneral + "` tbl_sav_unit WHERE `tbl_sav_unit`.job_id = @JobID AND `tbl_sav_unit`.unit_no = @UnitNo";
                Comm.ExecuteNonQuery();
                adp.Fill(ds, ClsDBT.strSavGeneral);




                return ds;

            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                Conn.Close();
            }

        }



        public static DataTable GetSavedUnit(int _intJobID, int _intUnitNo)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());

            try
            {
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = "SELECT * " +
                                    "FROM `" + ClsDBT.strSavGeneral + "` tbl_sav_unit " +
                                    "LEFT JOIN `" + ClsDBT.strSavAirFlowData + "` tbl_sav_air_flow ON tbl_sav_air_flow.job_id = tbl_sav_unit.job_id AND tbl_sav_air_flow.unit_no = tbl_sav_unit.unit_no " +
                                    "LEFT JOIN `" + ClsDBT.strSavCompOption + "` tbl_sav_comp_opt ON tbl_sav_comp_opt.job_id = tbl_sav_unit.job_id AND tbl_sav_comp_opt.unit_no = tbl_sav_unit.unit_no " +
                                    "LEFT JOIN `" + ClsDBT.strSavCompOptionCustom + "` tbl_sav_comp_opt_cust ON tbl_sav_comp_opt_cust.job_id = tbl_sav_unit.job_id AND tbl_sav_comp_opt_cust.unit_no = tbl_sav_unit.unit_no " +
                                    "LEFT JOIN `" + ClsDBT.strSavLayout + "` tbl_sav_layout ON tbl_sav_layout.job_id = tbl_sav_unit.job_id AND tbl_sav_layout.unit_no = tbl_sav_unit.unit_no " +
                                    "WHERE `tbl_sav_unit`.job_id=@JobID AND `tbl_sav_unit`.unit_no=@UnitNo";


                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                Comm.Parameters.AddWithValue("@UnitNo", _intUnitNo);
                Conn.Open();
                Comm.ExecuteNonQuery();

                adp.Fill(ds, "DataTable");
                return ds.Tables[0];
            }
            catch
            {
                return null;
            }
            finally
            {
                Conn.Close();
            }
        }


        public static DataTable GetSavedUnitWithDetails(int _intJobID, int _intUnitNo)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());

            try
            {
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = "SELECT tbl_sav_unit.*, " +
                                    "tbl_sav_unit.qty as Qty, " +
                                    "tbl_sav_unit.tag as Tag, " +
                                    "tbl_sav_unit.selection_type_id as SelectionTypeID, " +
                                    "tbl_sav_unit.is_downshot as IsDownshot, " +
                                    "tbl_sav_unit.is_bypass as IsBypass, " +
                                    "tbl_sav_unit.product_type_id as ProductTypeID, " +
                                    "tbl_sav_comp.*, " +
                                    "tbl_sel_product_type.code as ProductTypeCode, " +
                                    "tbl_sel_unit_type.id as UnitTypeID, " +
                                    "tbl_sel_unit_type.dwg_code as UnitTypeDwgCode, " +
                                    "tbl_sel_nova_unit_model.id as NovaUnitModelID, " +
                                    "tbl_sel_nova_unit_model.value as NovaUnitModelValue, " +
                                    "tbl_sel_nova_unit_model.dwg_code as NovaUnitModelDwgCode, " +
                                    "tbl_sel_nova_unit_model.dis_code as NovaUnitModelDisCode, " +
                                    "tbl_sel_loc.dwg_code as LocationDwgCode, " +
                                    "tbl_sel_loc.id as LocationID, " +
                                    "tbl_sel_ori.id as OrientationID, " +
                                    "tbl_sel_ori.items as Orientation, " +
                                    "tbl_sel_ctrl_pref.items as ControlsPref, " +
                                    "tbl_sel_ctrl_pref.id as ControlsPrefID, " +
                                    "tbl_sel_ctrl_pref.code as ControlsPrefCode, " +
                                    "tbl_sel_ori.dwg_code as OrientationDwgCode, " +
                                    "tbl_sel_elec_heat_volt.items as ElecHeatVoltage, " +
                                    "tbl_sel_elec_heat_volt.volt as ElecHeatVoltageVolt, " +
                                    "tbl_sel_elec_heat_volt.phase as ElecHeatVoltagePhase, " +
                                    "tbl_sel_preheat_elec_heat_install.items as PreheatElecHeatInstallation, " +
                                    "tbl_sel_preheat_elec_heat_install.id as PreheatElecHeatInstallationID, " +
                                    "tbl_sel_heat_elec_heat_install.items as HeatElecHeatInstallation, " +
                                    "tbl_sel_heat_elec_heat_install.id as HeatElecHeatInstallationID, " +
                                    "tbl_sel_handing.items as HandingName, " +
                                    "tbl_sel_handing.dwg_code as HandingDwgCode, " +
                                    "tbl_sel_handing.dis_code as HandingFP_DisCode, " +
                                    "tbl_sel_handing_preheat.items as PreheatCoilHandingName, " +
                                    "tbl_sel_handing_preheat.dwg_code as PreheatCoilHandingDwgCode, " +
                                    "tbl_sel_handing_cooling.items as CoolingCoilHandingName, " +
                                    "tbl_sel_handing_cooling.dwg_code as CoolingCoilHandingDwgCode, " +
                                    "tbl_sel_handing_heating.items as HeatingCoilHandingName, " +
                                    "tbl_sel_handing_heating.dwg_code as HeatingCoilHandingDwgCode, " +
                                    "tbl_sel_open_sa.dwg_code as OpeningSA_DwgCode, " +
                                    "tbl_sel_open_ea.dwg_code as OpeningEA_DwgCode, " +
                                    "tbl_sel_open_ra.dwg_code as OpeningRA_DwgCode, " +
                                    "tbl_sel_open_oa.dwg_code as OpeningOA_DwgCode, " +
                                    "tbl_sel_volt.items as UnitVoltage, " +
                                    "tbl_sel_volt.volt as UnitVoltageVolt, " +
                                    "tbl_sel_volt.phase as UnitVoltagePhase, " +
                                    "tbl_sel_filter_oa.merv as OAFilterMERV, " +
                                    "tbl_sel_filter_ra.merv as RAFilterMERV " +
                                    "FROM `" + ClsDBT.strSavGeneral + "` tbl_sav_unit " +
                                    "LEFT JOIN `" + ClsDBT.strSavCompOption + "` tbl_sav_comp ON tbl_sav_comp.job_id = tbl_sav_unit.job_id AND tbl_sav_comp.unit_no = tbl_sav_unit.unit_no " +
                                    "LEFT JOIN `" + ClsDBT.strSavLayout + "` tbl_sav_layout ON tbl_sav_layout.job_id = tbl_sav_unit.job_id AND tbl_sav_layout.unit_no = tbl_sav_unit.unit_no " +
                                    "LEFT JOIN `" + ClsDBT.strSelProductType + "` tbl_sel_product_type ON tbl_sel_product_type.id = tbl_sav_unit.product_type_id " +
                                    "LEFT JOIN `" + ClsDBT.strSelUnitType + "` tbl_sel_unit_type ON tbl_sel_unit_type.id = tbl_sav_unit.unit_type_id " +
                                    //"LEFT JOIN `" + ClsDBT.strSelNovaUnitModel + "` tbl_sel_unit_model ON tbl_sel_unit_model.id = tbl_sav_unit.unit_model_id " +
                                    "LEFT JOIN `" + ClsDBT.strSelNovaUnitModel + "` tbl_sel_nova_unit_model ON tbl_sel_nova_unit_model.id = tbl_sav_unit.unit_model_id AND tbl_sav_unit.product_type_id='1' " +
                                    "LEFT JOIN `" + ClsDBT.strSelGeneralLocation + "` tbl_sel_loc ON tbl_sel_loc.id = tbl_sav_unit.location_id " +
                                    "LEFT JOIN `" + ClsDBT.strSelGeneralOrientation + "` tbl_sel_ori ON tbl_sel_ori.id = tbl_sav_unit.orientation_id " +
                                    "LEFT JOIN `" + ClsDBT.strSelControlsPreference + "` tbl_sel_ctrl_pref ON tbl_sel_ctrl_pref.id = tbl_sav_unit.controls_preference_id " +
                                    "LEFT JOIN `" + ClsDBT.strSelHanding + "` tbl_sel_handing ON tbl_sel_handing.id = tbl_sav_layout.handing_id " +
                                    "LEFT JOIN `" + ClsDBT.strSelHanding + "` tbl_sel_handing_preheat ON tbl_sel_handing_preheat.id = tbl_sav_layout.preheat_coil_handing_id " +
                                    "LEFT JOIN `" + ClsDBT.strSelHanding + "` tbl_sel_handing_cooling ON tbl_sel_handing_cooling.id = tbl_sav_layout.cooling_coil_handing_id " +
                                    "LEFT JOIN `" + ClsDBT.strSelHanding + "` tbl_sel_handing_heating ON tbl_sel_handing_heating.id = tbl_sav_layout.heating_coil_handing_id " +
                                    "LEFT JOIN `" + ClsDBT.strSelOpeningsERV_SA + "` tbl_sel_open_sa ON tbl_sel_open_sa.dwg_code = tbl_sav_layout.sa_opening AND tbl_sel_open_sa.product_type_id = tbl_sav_unit.product_type_id " +
                                    "LEFT JOIN `" + ClsDBT.strSelOpeningsERV_EA + "` tbl_sel_open_ea ON tbl_sel_open_ea.dwg_code = tbl_sav_layout.ea_opening AND tbl_sel_open_ea.product_type_id = tbl_sav_unit.product_type_id " +
                                    "LEFT JOIN `" + ClsDBT.strSelOpeningsERV_RA + "` tbl_sel_open_ra ON tbl_sel_open_ra.dwg_code = tbl_sav_layout.ra_opening AND tbl_sel_open_ra.product_type_id = tbl_sav_unit.product_type_id " +
                                    "LEFT JOIN `" + ClsDBT.strSelOpeningsERV_OA + "` tbl_sel_open_oa ON tbl_sel_open_oa.dwg_code = tbl_sav_layout.oa_opening AND tbl_sel_open_oa.product_type_id = tbl_sav_unit.product_type_id " +
                                    "LEFT JOIN `" + ClsDBT.strSelElectricalVoltage + "` tbl_sel_volt ON tbl_sel_volt.id = tbl_sav_unit.voltage_id " +
                                    "LEFT JOIN `" + ClsDBT.strSelElectricalVoltage + "` tbl_sel_elec_heat_volt ON tbl_sel_elec_heat_volt.id = tbl_sav_comp.elec_heater_voltage_id " +
                                    "LEFT JOIN `" + ClsDBT.strSelElectricHeaterInstallation + "` tbl_sel_preheat_elec_heat_install ON tbl_sel_preheat_elec_heat_install.id = tbl_sav_comp.preheat_elec_heater_installation_id " +
                                    "LEFT JOIN `" + ClsDBT.strSelElectricHeaterInstallation + "` tbl_sel_heat_elec_heat_install ON tbl_sel_heat_elec_heat_install.id = tbl_sav_comp.heat_elec_heater_installation_id " +
                                    "LEFT JOIN `" + ClsDBT.strSelFilterModel + "` tbl_sel_filter_oa ON tbl_sel_filter_oa.id = tbl_sav_comp.oa_filter_model_id " +
                                    "LEFT JOIN `" + ClsDBT.strSelFilterModel + "` tbl_sel_filter_ra ON tbl_sel_filter_ra.id = tbl_sav_comp.ra_filter_model_id " +
                                    "WHERE `tbl_sav_unit`.job_id=@JobID AND `tbl_sav_unit`.unit_no=@UnitNo";

                //"LEFT JOIN `" + ClsDBT.strSelOpeningsERV_SA + "` tbl_sel_open_sa ON tbl_sel_open_sa.id = tbl_sav_layout.sa_opening_id " +
                //"LEFT JOIN `" + ClsDBT.strSelOpeningsERV_EA + "` tbl_sel_open_ea ON tbl_sel_open_ea.id = tbl_sav_layout.ea_opening_id " +
                //"LEFT JOIN `" + ClsDBT.strSelOpeningsERV_RA + "` tbl_sel_open_ra ON tbl_sel_open_ra.id = tbl_sav_layout.ra_opening_id " +
                //"LEFT JOIN `" + ClsDBT.strSelOpeningsERV_OA + "` tbl_sel_open_oa ON tbl_sel_open_oa.id = tbl_sav_layout.oa_opening_id " +

                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                Comm.Parameters.AddWithValue("@UnitNo", _intUnitNo);
                Conn.Open();
                Comm.ExecuteNonQuery();

                adp.Fill(ds, "DataTable");
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Conn.Close();
            }
        }



        public static DataSet GetSavedJobItems(int _intJobID)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());

            try
            {
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSavJob + "` tbl_sav_job WHERE `tbl_sav_job`.id=@JobID";
                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                Conn.Open();
                Comm.ExecuteNonQuery();
                adp.Fill(ds, ClsDBT.strSavJob);


                Comm.CommandType = CommandType.Text;
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSavGeneral + "` tbl_sav_unit WHERE `tbl_sav_unit`.job_id=@JobID";
                Comm.ExecuteNonQuery();
                adp.Fill(ds, ClsDBT.strSavGeneral);


                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSavCompOption + "` tbl_sav_opt WHERE `tbl_sav_opt`.job_id=@JobID";
                Comm.ExecuteNonQuery();
                adp.Fill(ds, ClsDBT.strSavCompOption);


                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSavCompOptionCustom + "` tbl_sav_opt_cust WHERE `tbl_sav_opt_cust`.job_id=@JobID";
                Comm.ExecuteNonQuery();
                adp.Fill(ds, ClsDBT.strSavCompOptionCustom);


                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSavLayout + "` tbl_sav_layout WHERE `tbl_sav_layout`.job_id=@JobID";
                Comm.ExecuteNonQuery();
                adp.Fill(ds, ClsDBT.strSavLayout);


                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSavLayout + "` tbl_sav_layout WHERE `tbl_sav_layout`.job_id=@JobID";
                Comm.ExecuteNonQuery();
                adp.Fill(ds, ClsDBT.strSavLayout);


                return ds;
            }
            catch (Exception Ex)
            {
                return null;
            }
            finally
            {
                Conn.Close();
            }
        }


        public static DataTable GetSavedUnitsWithDetails(int _intJobID)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());

            try
            {
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = "SELECT tbl_sav_unit.qty as Qty, " +
                                    "tbl_sav_unit.tag as Tag, " +
                                    "tbl_sav_unit.selection_type_id as SelectionTypeID, " +
                                    "tbl_sav_unit.product_type_id as ProductTypeID, " +
                                    "tbl_sav_comp.*, " +
                                    "tbl_sel_unit_type.id as UnitTypeID, " +
                                    "tbl_sel_unit_type.dwg_code as UnitTypeDwgCode, " +
                                    "tbl_sel_nova_unit_model.id as NovaUnitModelID, " +
                                    "tbl_sel_nova_unit_model.value as NovaUnitModelValue, " +
                                    "tbl_sel_ventum_unit_model.id as VentumUnitModelID, " +
                                    "tbl_sel_ventum_unit_model.value as VentumUnitModelValue, " +
                                    "tbl_sel_nova_unit_model.dwg_code as NovaUnitModelDwgCode, " +
                                    "tbl_sel_nova_unit_model.dis_code as NovaUnitModelDisCode, " +
                                    "tbl_sel_ventum_unit_model.dwg_code as VentumUnitModelDwgCode, " +
                                    "tbl_sel_ventum_unit_model.dis_code as VentumUnitModelDisCode, " +
                                    "tbl_sel_loc.dwg_code as LocationDwgCode, " +
                                    "tbl_sel_loc.id as LocationID, " +
                                    "tbl_sel_ori.id as OrientationID, " +
                                    "tbl_sel_ori.items as Orientation, " +
                                    "tbl_sel_ori.dwg_code as OrientationDwgCode, " +
                                    "tbl_sel_handing.items as HandingName, " +
                                    "tbl_sel_handing.dwg_code as HandingDwgCode, " +
                                    "tbl_sel_handing.dis_code as HandingFP_DisCode, " +
                                    "tbl_sel_handing_preheat.items as PreheatCoilHandingName, " +
                                    "tbl_sel_handing_preheat.dwg_code as PreheatCoilHandingDwgCode, " +
                                    "tbl_sel_handing_cooling.items as CoolingCoilHandingName, " +
                                    "tbl_sel_handing_cooling.dwg_code as CoolingCoilHandingDwgCode, " +
                                    "tbl_sel_handing_heating.items as HeatingCoilHandingName, " +
                                    "tbl_sel_handing_heating.dwg_code as HeatingCoilHandingDwgCode, " +
                                    "tbl_sel_open_sa.dwg_code as OpeningSA_DwgCode, " +
                                    "tbl_sel_open_ea.dwg_code as OpeningEA_DwgCode, " +
                                    "tbl_sel_open_ra.dwg_code as OpeningRA_DwgCode, " +
                                    "tbl_sel_open_oa.dwg_code as OpeningOA_DwgCode, " +
                                    "tbl_sel_volt.items as UnitVoltage, " +
                                    "tbl_sel_volt.volt as UnitVoltageVolt, " +
                                    "tbl_sel_volt.phase as UnitVoltagePhase, " +
                                    "tbl_sel_controls.id as ControlsPrefID, " +
                                    "tbl_sel_controls.items as ControlsPref, " +
                                    "tbl_sel_elec_heat_volt.items as ElecHeatVoltage, " +
                                    "tbl_sel_elec_heat_volt.volt as ElecHeatVoltageVolt, " +
                                    "tbl_sel_elec_heat_volt.phase as ElecHeatVoltagePhase, " +
                                    "tbl_sel_preheat_elec_heat_install.items as PreheatElecHeatInstallation, " +
                                    "tbl_sel_preheat_elec_heat_install.id as PreheatElecHeatInstallationID, " +
                                    "tbl_sel_heat_elec_heat_install.items as HeatElecHeatInstallation, " +
                                    "tbl_sel_heat_elec_heat_install.id as HeatElecHeatInstallationID, " +
                                    "tbl_sel_damper_actuator.id as DamperActuatorID, " +
                                    "tbl_sel_damper_actuator.items as DamperActuator, " +
                                    "tbl_sel_preheat_hwc_valve.id as PreheatHWC_ValveID, " +
                                    "tbl_sel_preheat_hwc_valve.valve_type as PreheatHWC_ValveType, " +
                                    "tbl_sel_cooling_cwc_valve.id as CoolingCWC_ValveID, " +
                                    "tbl_sel_cooling_cwc_valve.valve_type as CoolingCWC_ValveType, " +
                                    "tbl_sel_heating_hwc_valve.id as HeatingHWC_ValveID, " +
                                    "tbl_sel_heating_hwc_valve.valve_type as HeatingHWC_ValveType, " +
                                    "tbl_sel_reheat_hwc_valve.id as ReheatHWC_ValveID, " +
                                    "tbl_sel_reheat_hwc_valve.valve_type as ReheatHWC_ValveType, " +
                                    "tbl_sel_valve_type.id as ValveTypeID, " +
                                    "tbl_sel_valve_type.items as ValveType " +
                                    "FROM `" + ClsDBT.strSavGeneral + "` tbl_sav_unit " +
                                    "LEFT JOIN `" + ClsDBT.strSavCompOption + "` tbl_sav_comp ON tbl_sav_comp.job_id = tbl_sav_unit.job_id AND tbl_sav_comp.unit_no = tbl_sav_unit.unit_no " +
                                    "LEFT JOIN `" + ClsDBT.strSavLayout + "` tbl_sav_layout ON tbl_sav_layout.job_id = tbl_sav_unit.job_id AND tbl_sav_layout.unit_no = tbl_sav_unit.unit_no " +
                                    "LEFT JOIN `" + ClsDBT.strSelUnitType + "` tbl_sel_unit_type ON tbl_sel_unit_type.id = tbl_sav_unit.unit_type_id " +
                                    //"LEFT JOIN `" + ClsDBT.strSelNovaUnitModel + "` tbl_sel_unit_model ON tbl_sel_unit_model.id = tbl_sav_unit.unit_model_id " +
                                    "LEFT JOIN `" + ClsDBT.strSelNovaUnitModel + "` tbl_sel_nova_unit_model ON tbl_sel_nova_unit_model.id = tbl_sav_unit.unit_model_id AND tbl_sav_unit.product_type_id='1' " +
                                    "LEFT JOIN `" + ClsDBT.strSelGeneralLocation + "` tbl_sel_loc ON tbl_sel_loc.id = tbl_sav_unit.location_id " +
                                    "LEFT JOIN `" + ClsDBT.strSelGeneralOrientation + "` tbl_sel_ori ON tbl_sel_ori.id = tbl_sav_unit.orientation_id " +
                                    "LEFT JOIN `" + ClsDBT.strSelHanding + "` tbl_sel_handing ON tbl_sel_handing.id = tbl_sav_layout.handing_id " +
                                    "LEFT JOIN `" + ClsDBT.strSelHanding + "` tbl_sel_handing_preheat ON tbl_sel_handing_preheat.id = tbl_sav_layout.preheat_coil_handing_id " +
                                    "LEFT JOIN `" + ClsDBT.strSelHanding + "` tbl_sel_handing_cooling ON tbl_sel_handing_cooling.id = tbl_sav_layout.cooling_coil_handing_id " +
                                    "LEFT JOIN `" + ClsDBT.strSelHanding + "` tbl_sel_handing_heating ON tbl_sel_handing_heating.id = tbl_sav_layout.heating_coil_handing_id " +
                                    "LEFT JOIN `" + ClsDBT.strSelOpeningsERV_SA + "` tbl_sel_open_sa ON tbl_sel_open_sa.dwg_code = tbl_sav_layout.sa_opening AND tbl_sel_open_sa.product_type_id = tbl_sav_unit.product_type_id " +
                                    "LEFT JOIN `" + ClsDBT.strSelOpeningsERV_EA + "` tbl_sel_open_ea ON tbl_sel_open_ea.dwg_code = tbl_sav_layout.ea_opening AND tbl_sel_open_ea.product_type_id = tbl_sav_unit.product_type_id " +
                                    "LEFT JOIN `" + ClsDBT.strSelOpeningsERV_RA + "` tbl_sel_open_ra ON tbl_sel_open_ra.dwg_code = tbl_sav_layout.ra_opening AND tbl_sel_open_ra.product_type_id = tbl_sav_unit.product_type_id " +
                                    "LEFT JOIN `" + ClsDBT.strSelOpeningsERV_OA + "` tbl_sel_open_oa ON tbl_sel_open_oa.dwg_code = tbl_sav_layout.oa_opening AND tbl_sel_open_oa.product_type_id = tbl_sav_unit.product_type_id " +
                                    "LEFT JOIN `" + ClsDBT.strSelElectricalVoltage + "` tbl_sel_volt ON tbl_sel_volt.id = tbl_sav_unit.voltage_id " +
                                    "LEFT JOIN `" + ClsDBT.strSelControlsPreference + "` tbl_sel_controls ON tbl_sel_controls.id = tbl_sav_unit.controls_preference_id " +
                                    "LEFT JOIN `" + ClsDBT.strSelElectricalVoltage + "` tbl_sel_elec_heat_volt ON tbl_sel_elec_heat_volt.id = tbl_sav_comp.elec_heater_voltage_id " +
                                    "LEFT JOIN `" + ClsDBT.strSelElectricHeaterInstallation + "` tbl_sel_preheat_elec_heat_install ON tbl_sel_preheat_elec_heat_install.id = tbl_sav_comp.preheat_elec_heater_installation_id " +
                                    "LEFT JOIN `" + ClsDBT.strSelElectricHeaterInstallation + "` tbl_sel_heat_elec_heat_install ON tbl_sel_heat_elec_heat_install.id = tbl_sav_comp.heat_elec_heater_installation_id " +
                                    "LEFT JOIN `" + ClsDBT.strSelDamperActuator + "` tbl_sel_damper_actuator ON tbl_sel_damper_actuator.id = tbl_sav_comp.damper_and_actuator_id " +
                                    "LEFT JOIN `" + ClsDBT.strSelValveAndActuator + "` tbl_sel_preheat_hwc_valve ON tbl_sel_preheat_hwc_valve.id = tbl_sav_comp.preheat_hwc_valve_and_actuator_id " +
                                    "LEFT JOIN `" + ClsDBT.strSelValveAndActuator + "` tbl_sel_cooling_cwc_valve ON tbl_sel_cooling_cwc_valve.id = tbl_sav_comp.cooling_cwc_valve_and_actuator_id " +
                                    "LEFT JOIN `" + ClsDBT.strSelValveAndActuator + "` tbl_sel_heating_hwc_valve ON tbl_sel_heating_hwc_valve.id = tbl_sav_comp.heating_hwc_valve_and_actuator_id " +
                                    "LEFT JOIN `" + ClsDBT.strSelValveAndActuator + "` tbl_sel_reheat_hwc_valve ON tbl_sel_reheat_hwc_valve.id = tbl_sav_comp.reheat_hwc_valve_and_actuator_id " +
                                    "LEFT JOIN `" + ClsDBT.strSelValveType + "` tbl_sel_valve_type ON tbl_sel_valve_type.id = tbl_sav_comp.valve_type_id " +
                                    "WHERE `tbl_sav_unit`.job_id=@JobID";

                //"LEFT JOIN `" + ClsDBT.strSelOpeningsERV_SA + "` tbl_sel_open_sa ON tbl_sel_open_sa.id = tbl_sav_layout.sa_opening_id " +
                //"LEFT JOIN `" + ClsDBT.strSelOpeningsERV_EA + "` tbl_sel_open_ea ON tbl_sel_open_ea.id = tbl_sav_layout.ea_opening_id " +
                //"LEFT JOIN `" + ClsDBT.strSelOpeningsERV_RA + "` tbl_sel_open_ra ON tbl_sel_open_ra.id = tbl_sav_layout.ra_opening_id " +
                //"LEFT JOIN `" + ClsDBT.strSelOpeningsERV_OA + "` tbl_sel_open_oa ON tbl_sel_open_oa.id = tbl_sav_layout.oa_opening_id " +

                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                Conn.Open();
                Comm.ExecuteNonQuery();

                adp.Fill(ds, "DataTable");
                return ds.Tables[0];
            }
            catch (Exception Ex)
            {
                return null;
            }
            finally
            {
                Conn.Close();
            }
        }



        #region GetSavedCompOptByJob
        public static DataTable GetSavedCompOpt(int _intJobID)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());

            try
            {
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSavCompOption + "` WHERE `job_id`=@JobID";
                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                Conn.Open();
                Comm.ExecuteNonQuery();

                adp.Fill(ds, "DataTable");
                return ds.Tables[0];
            }
            catch
            {
                return null;
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion


        #region GetSavedCompOpt
        public static DataTable GetSavedCompOpt(int _intJobID, int _intUnitNo)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());

            try
            {
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSavCompOption + "` WHERE `job_id`=@JobID AND `unit_no`=@UnitNo";
                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                Comm.Parameters.AddWithValue("@UnitNo", _intUnitNo);
                Conn.Open();
                Comm.ExecuteNonQuery();

                adp.Fill(ds, "DataTable");
                return ds.Tables[0];
            }
            catch
            {
                return null;
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion


        #region GetSavedCompOptCustom
        public static DataTable GetSavedCompOptCustom(int _intJobID, int _intUnitNo)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());

            try
            {
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSavCompOptionCustom + "` WHERE `job_id`=@JobID AND `unit_no`=@UnitNo";
                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                Comm.Parameters.AddWithValue("@UnitNo", _intUnitNo);
                Conn.Open();
                Comm.ExecuteNonQuery();

                adp.Fill(ds, "DataTable");
                return ds.Tables[0];
            }
            catch
            {
                return null;
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion


        #region GetSavedLayoutOpt
        public static DataTable GetSavedLayoutOpt(int _intJobID, int _intUnitNo)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());

            try
            {
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = "SELECT * FROM `" + ClsDBT.strSavLayout + "` WHERE `job_id`=@JobID AND `unit_no`=@UnitNo";
                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                Comm.Parameters.AddWithValue("@UnitNo", _intUnitNo);
                Conn.Open();
                Comm.ExecuteNonQuery();

                adp.Fill(ds, "DataTable");
                return ds.Tables[0];
            }
            catch
            {
                return null;
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion


        #region GetSavedQuote
        public static DataTable GetSavedQuote(int _intJobID)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());


            string strQuery = "SELECT * " +
                                "FROM `" + ClsDBT.strSavQuote + "` tbl_sav_pricing " +
                                "LEFT JOIN `" + ClsDBT.strSelCountry + "` tbl_sel_country ON tbl_sel_country.id = tbl_sav_pricing.country_id " +
                                "WHERE tbl_sav_pricing.job_id = @JobID";

            try
            {
                //Comm = new MySqlCommand(strQuery, MySqlConn);
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = strQuery;
                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                Conn.Open();

                ds = new DataSet();
                //MySqlDataAdapter adp = new MySqlDataAdapter();
                adp.Fill(ds, "tblPricing");

                return ds.Tables[0];

            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion


        #region GetQuoteMisc
        public static DataTable GetSavedQuoteMisc(int _intJobID)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());


            string strQuery = "SELECT * " +
                                "FROM `" + ClsDBT.strSavQuoteMisc + "` tbl_price_misc " +
                                "WHERE tbl_price_misc.job_id = @JobID";

            try
            {
                //Comm = new MySqlCommand(strQuery, MySqlConn);
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = strQuery;
                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                Conn.Open();

                ds = new DataSet();
                //MySqlDataAdapter adp = new MySqlDataAdapter();
                adp.Fill(ds, "tblPriceMisc");


                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion


        #region GetQuoteNotes
        public static DataTable GetSavedQuoteNotes(int _intJobID)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());


            string strQuery = "SELECT * " +
                                "FROM `" + ClsDBT.strSavQuoteNotes + "` tbl_price_notes " +
                                "WHERE tbl_price_notes.job_id = @JobID";

            try
            {
                //Comm = new MySqlCommand(strQuery, MySqlConn);
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = strQuery;
                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                Conn.Open();

                ds = new DataSet();
                //MySqlDataAdapter adp = new MySqlDataAdapter();
                adp.Fill(ds, "tblPriceNotes");


                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion


        #region GetSavedSubmittals
        public static DataTable GetSavedSubmittal(int _intJobID)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());


            string strQuery = "SELECT *, tbl_sel_country.items AS ShippingCountry " +
                                "FROM `" + ClsDBT.strSavSubmittal + "` tbl_sav_submittals " +
                                "LEFT JOIN `" + ClsDBT.strSelCountry + "` tbl_sel_country ON tbl_sel_country.id = tbl_sav_submittals.shipping_country_id " +
                                "WHERE tbl_sav_submittals.job_id = @JobID";

            try
            {
                //Comm = new MySqlCommand(strQuery, MySqlConn);
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = strQuery;
                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                Conn.Open();

                ds = new DataSet();
                //MySqlDataAdapter adp = new MySqlDataAdapter();
                adp.Fill(ds, "tblSubmittals");

                return ds.Tables[0];

            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion


        #region GetSubmittalsNotes
        public static DataTable GetSavedSubmittalsNotes(int _intJobID)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());


            string strQuery = "SELECT * " +
                                "FROM `" + ClsDBT.strSavSubmittalNotes + "` tbl_submittals_notes " +
                                "WHERE tbl_submittals_notes.job_id = @JobID";

            try
            {
                //Comm = new MySqlCommand(strQuery, MySqlConn);
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = strQuery;
                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                Conn.Open();

                ds = new DataSet();
                //MySqlDataAdapter adp = new MySqlDataAdapter();
                adp.Fill(ds, "tblSubmittalsNotes");


                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion


        #region GetSubmittalsShippingNotes
        public static DataTable GetSavedSubmittalsShippingNotes(int _intJobID)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());


            string strQuery = "SELECT * " +
                                "FROM `" + ClsDBT.strSavSubmittalShippingNotes + "` tbl_submittals_shipping_notes " +
                                "WHERE tbl_submittals_shipping_notes.job_id = @JobID";

            try
            {
                //Comm = new MySqlCommand(strQuery, MySqlConn);
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = strQuery;
                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                Conn.Open();

                ds = new DataSet();
                //MySqlDataAdapter adp = new MySqlDataAdapter();
                adp.Fill(ds, "tblSubmittalsShippingNotes");


                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion




        #region Delete Project
        public static bool DeleteProject(int _intJobID)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());


            try
            {
                Comm.CommandType = CommandType.Text;
                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                Conn.Open();


                Comm.CommandText = "DELETE FROM `" + ClsDBT.strSavAirFlowData + "` WHERE `job_id`=@JobID";
                Comm.ExecuteNonQuery();

                Comm.CommandText = "DELETE FROM `" + ClsDBT.strSavCompOption + "` WHERE `job_id`=@JobID";
                Comm.ExecuteNonQuery();

                Comm.CommandText = "DELETE FROM `" + ClsDBT.strSavCompOptionCustom + "` WHERE `job_id`=@JobID";
                Comm.ExecuteNonQuery();

                Comm.CommandText = "DELETE FROM `" + ClsDBT.strSavLayout + "` WHERE `job_id`=@JobID";
                Comm.ExecuteNonQuery();


                Comm.CommandText = "DELETE FROM `" + ClsDBT.strSavGeneral + "` WHERE `job_id`=@JobID";
                Comm.ExecuteNonQuery();

                //Delete Job Table always last to prevent the job id not being deleted on above tables if the execution fails on any tables above.
                Comm.CommandText = "DELETE FROM `" + ClsDBT.strSavJob + "` WHERE `id`=@JobID";
                Comm.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion


        #region Delete Unit
        public static bool DeleteUnit(int _intJobID, int _intUnitNo)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());


            try
            {
                Comm.CommandType = CommandType.Text;
                Comm.Parameters.Clear();
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                Comm.Parameters.AddWithValue("@UnitNo", _intUnitNo);
                Conn.Open();


                Comm.CommandText = "DELETE FROM `" + ClsDBT.strSavAirFlowData + "` WHERE `job_id`=@JobID AND `unit_no`=@UnitNo";
                Comm.ExecuteNonQuery();

                //Comm.CommandText = "DELETE FROM `" + ClsDBT.strSavElectrical + "` WHERE `job_id`=@JobID AND `unit_no`=@UnitNo";
                //Comm.ExecuteNonQuery();

                //Comm.CommandText = "DELETE FROM `" + ClsDBT.strSavControls + "` WHERE `job_id`=@JobID AND `unit_no`=@UnitNo";
                //Comm.ExecuteNonQuery();

                Comm.CommandText = "DELETE FROM `" + ClsDBT.strSavCompOption + "` WHERE `job_id`=@JobID AND `unit_no`=@UnitNo";
                Comm.ExecuteNonQuery();

                Comm.CommandText = "DELETE FROM `" + ClsDBT.strSavCompOptionCustom + "` WHERE `job_id`=@JobID AND `unit_no`=@UnitNo";
                Comm.ExecuteNonQuery();

                Comm.CommandText = "DELETE FROM `" + ClsDBT.strSavLayout + "` WHERE `job_id`=@JobID AND `unit_no`=@UnitNo";
                Comm.ExecuteNonQuery();

                //Comm.CommandText = "DELETE FROM `" + ClsDBT.strSavLouver + "` WHERE `job_id`=@JobID AND `unit_no`=@UnitNo";
                //Comm.ExecuteNonQuery();

                //Comm.CommandText = "DELETE FROM `" + ClsDBT.strSavDamper + "` WHERE `job_id`=@JobID AND `unit_no`=@UnitNo";
                //Comm.ExecuteNonQuery();

                //Comm.CommandText = "DELETE FROM `" + ClsDBT.strSavFilter + "` WHERE `job_id`=@JobID AND `unit_no`=@UnitNo";
                //Comm.ExecuteNonQuery();

                //Comm.CommandText = "DELETE FROM `" + ClsDBT.strSavFixedPlateCORE + "` WHERE `job_id`=@JobID AND `unit_no`=@UnitNo";
                //Comm.ExecuteNonQuery();

                //Comm.CommandText = "DELETE FROM `" + ClsDBT.strSavFixedPlateHEATEX + "` WHERE `job_id`=@JobID AND `unit_no`=@UnitNo";
                //Comm.ExecuteNonQuery();

                //Comm.CommandText = "DELETE FROM `" + ClsDBT.strSavElectricHeaterTHERMOLEC + "` WHERE `job_id`=@JobID AND `unit_no`=@UnitNo";
                //Comm.ExecuteNonQuery();

                //Comm.CommandText = "DELETE FROM `" + ClsDBT.strSavCoilDIRECT_COIL + "` WHERE `job_id`=@JobID AND `unit_no`=@UnitNo";
                //Comm.ExecuteNonQuery();

                //Comm.CommandText = "DELETE FROM `" + ClsDBT.strSavFanZIEHL_ABEGG + "` WHERE `job_id`=@JobID AND `unit_no`=@UnitNo";
                //Comm.ExecuteNonQuery();

                //Delete General Table always last to prevent the unit no not being deleted on above tables if the execution fails on any tables above.
                Comm.CommandText = "DELETE FROM `" + ClsDBT.strSavGeneral + "` WHERE `job_id`=@JobID AND `unit_no`=@UnitNo";
                Comm.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion


        #region DeletePricingMisc
        public static bool DeletePricingMisc(int _intJobID, int _intMiscNo)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());
            int intLastID = 0;
            DataTable dt = new DataTable("tblLastID");
            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("ErrMsg", typeof(string));

            try
            {
                Comm.CommandType = CommandType.Text;

                //if (_intJobID > 0)
                //{
                //    Comm.CommandText = "UPDATE `sav_job_pricing` SET `customer_po`=@CustomerPO,`country_id`=@CountryID,`margin_factor`=@MarginFactor,`currency_rate`=@CurrencyRate,`loyalty_factor`=@LoyaltyFactor,`shipping_factor`=@ShippingFactor,`price_with_margin`=@PriceWithMargin,`price_with_loyalty`=@PriceWithLoyalty,`price_shipping_cost`=@PriceShippingCost, " +
                //                        "`price_profit`=@PriceProfit,`price_total`=@PriceTotal,`price_freight_cost`=@PriceFreightCost,`price_freight_cost_small_order`=@PriceFreightCostSmallOrder,`price_total_before_freight`=@PriceTotalBeforeFreight, `discount`=@Discount WHERE `job_id`=@JobID";
                //    Comm.Parameters.AddWithValue("@JobID", _intJobID);
                //}
                //else
                //{

                Comm.CommandText = "DELETE FROM `" + ClsDBT.strSavQuoteMisc + "` WHERE `job_id`=0 OR `misc_no`=0";
                Conn.Open();
                Comm.ExecuteNonQuery();
                Comm.CommandText = "DELETE FROM `" + ClsDBT.strSavQuoteMisc + "` WHERE `job_id`=@JobID AND `misc_no`=@MiscNo";
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                Comm.Parameters.AddWithValue("@MiscNo", _intMiscNo);
                Comm.ExecuteNonQuery();


                DataRow dr = dt.NewRow();
                dr["id"] = intLastID;
                dt.Rows.Add(dr);
                //ds.Tables.Add(dt); // Table 1

                return true;
                //return true;
            }
            catch (Exception ex)
            {
                DataRow dr = dt.NewRow();
                dr["ErrMsg"] = ex.ToString();
                dt.Rows.Add(dr);

                return false;
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion


        #region DeletePricingNotes
        public static bool DeletePricingNotes(int _intJobID, int _intNotesNo)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());
            int intLastID = 0;
            DataTable dt = new DataTable("tblLastID");
            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("ErrMsg", typeof(string));

            try
            {
                Comm.CommandType = CommandType.Text;

                //if (_intJobID > 0)
                //{
                //    Comm.CommandText = "UPDATE `sav_job_pricing` SET `customer_po`=@CustomerPO,`country_id`=@CountryID,`margin_factor`=@MarginFactor,`currency_rate`=@CurrencyRate,`loyalty_factor`=@LoyaltyFactor,`shipping_factor`=@ShippingFactor,`price_with_margin`=@PriceWithMargin,`price_with_loyalty`=@PriceWithLoyalty,`price_shipping_cost`=@PriceShippingCost, " +
                //                        "`price_profit`=@PriceProfit,`price_total`=@PriceTotal,`price_freight_cost`=@PriceFreightCost,`price_freight_cost_small_order`=@PriceFreightCostSmallOrder,`price_total_before_freight`=@PriceTotalBeforeFreight, `discount`=@Discount WHERE `job_id`=@JobID";
                //    Comm.Parameters.AddWithValue("@JobID", _intJobID);
                //}
                //else
                //{

                Comm.CommandText = "DELETE FROM `" + ClsDBT.strSavQuoteNotes + "` WHERE `job_id`=0 OR `notes_no`=0";
                Conn.Open();
                Comm.ExecuteNonQuery();
                Comm.CommandText = "DELETE FROM `" + ClsDBT.strSavQuoteNotes + "` WHERE `job_id`=@JobID AND `notes_no`=@NotesNo";
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                Comm.Parameters.AddWithValue("@NotesNo", _intNotesNo);
                Comm.ExecuteNonQuery();


                DataRow dr = dt.NewRow();
                dr["id"] = intLastID;
                dt.Rows.Add(dr);
                //ds.Tables.Add(dt); // Table 1

                return true;
                //return true;
            }
            catch (Exception ex)
            {
                DataRow dr = dt.NewRow();
                dr["ErrMsg"] = ex.ToString();
                dt.Rows.Add(dr);

                return false;
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion


        #region DeleteSubmittalsNotes
        public static bool DeleteSubmittalsNotes(int _intJobID, int _intNotesNo)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            var Comm = adp.SelectCommand = new MySqlCommand();
            var Conn = adp.SelectCommand.Connection = new MySqlConnection(get_strConnection());
            int intLastID = 0;
            DataTable dt = new DataTable("tblLastID");
            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("ErrMsg", typeof(string));

            try
            {
                Comm.CommandType = CommandType.Text;

                //if (_intJobID > 0)
                //{
                //    Comm.CommandText = "UPDATE `sav_job_pricing` SET `customer_po`=@CustomerPO,`country_id`=@CountryID,`margin_factor`=@MarginFactor,`currency_rate`=@CurrencyRate,`loyalty_factor`=@LoyaltyFactor,`shipping_factor`=@ShippingFactor,`price_with_margin`=@PriceWithMargin,`price_with_loyalty`=@PriceWithLoyalty,`price_shipping_cost`=@PriceShippingCost, " +
                //                        "`price_profit`=@PriceProfit,`price_total`=@PriceTotal,`price_freight_cost`=@PriceFreightCost,`price_freight_cost_small_order`=@PriceFreightCostSmallOrder,`price_total_before_freight`=@PriceTotalBeforeFreight, `discount`=@Discount WHERE `job_id`=@JobID";
                //    Comm.Parameters.AddWithValue("@JobID", _intJobID);
                //}
                //else
                //{

                Comm.CommandText = "DELETE FROM `" + ClsDBT.strSavSubmittalNotes + "` WHERE `job_id`=0 OR `notes_no`=0";
                Conn.Open();
                Comm.ExecuteNonQuery();
                Comm.CommandText = "DELETE FROM `" + ClsDBT.strSavSubmittalNotes + "` WHERE `job_id`=@JobID AND `notes_no`=@NotesNo";
                Comm.Parameters.AddWithValue("@JobID", _intJobID);
                Comm.Parameters.AddWithValue("@NotesNo", _intNotesNo);
                Comm.ExecuteNonQuery();


                DataRow dr = dt.NewRow();
                dr["id"] = intLastID;
                dt.Rows.Add(dr);
                //ds.Tables.Add(dt); // Table 1

                return true;
                //return true;
            }
            catch (Exception ex)
            {
                DataRow dr = dt.NewRow();
                dr["ErrMsg"] = ex.ToString();
                dt.Rows.Add(dr);

                return false;
            }
            finally
            {
                Conn.Close();
            }
        }
        #endregion




        //public static void ExecuteSQL(string _strSQL)
        //{
        //    set_sqlConnection();
        //    sqlCeConn.Open();

        //    SqlCeCommand sqlCeComm = new SqlCeCommand(_strSQL, sqlCeConn);

        //    sqlCeComm.ExecuteNonQuery();
        //    sqlCeConn.Close();
        //}

        //public static void ExecuteSQL_PDF(int _intJobID, int _intFileNo, int _intPDF_TypeID, FileUpload _fu)
        //{
        //    string filePath = _fu.PostedFile.FileName;
        //    string filename = Path.GetFileName(filePath);
        //    string ext = Path.GetExtension(filename);
        //    string contenttype = String.Empty;

        //    Stream fs = _fu.PostedFile.InputStream;
        //    BinaryReader br = new BinaryReader(fs);
        //    Byte[] bytes = br.ReadBytes((Int32)fs.Length);

        //    contenttype = "application/pdf";

        //    int intNo = 1;

        //    DataTable dt = ClsDB.get_dtLive(ClsDBT.strSavJobPDF, " WHERE job_id = '" + _intJobID + "' ORDER BY file_no DESC");

        //    if(dt.Rows.Count > 0)
        //    {
        //        intNo = Convert.ToInt32(dt.Rows[0]["file_no"]) + 1;
        //    }

        //    //insert the file into database
        //    string strQuery = "insert into " + ClsDBT.strSavJobPDF + " (Job_id, file_no, pdf_type_id, file_name, file_data) values (@JobID, @FileNo, @PDF_TypeID, @FileName, @FileData)";

        //    set_sqlConnection();
        //    sqlCon.Open();

        //    SqlCommand cmd = new SqlCommand(strQuery, sqlCon);
        //    cmd.Parameters.Add("@JobID", SqlDbType.VarChar).Value = _intJobID;
        //    cmd.Parameters.Add("@FileNo", SqlDbType.VarChar).Value = intNo; 
        //    cmd.Parameters.Add("@PDF_TypeID", SqlDbType.VarChar).Value = _intPDF_TypeID;
        //    cmd.Parameters.Add("@FileName", SqlDbType.VarChar).Value = filename;
        //    cmd.Parameters.Add("@FileData", SqlDbType.Binary).Value = bytes;

        //    cmd.ExecuteNonQuery();
        //    sqlCon.Close(); 
        //}




        //public static void UpdatePDF(FileUpload _fu, int _intJobID, int _intFileNo, int _intPDF_TypeID)
        //{
        //    string filePath = _fu.PostedFile.FileName;
        //    string filename = Path.GetFileName(filePath);
        //    string ext = Path.GetExtension(filename);
        //    string contenttype = String.Empty;
        //    string strQuery = "";

        //    Stream fs = _fu.PostedFile.InputStream;
        //    BinaryReader br = new BinaryReader(fs);
        //    Byte[] bytes = br.ReadBytes((Int32)fs.Length);

        //    contenttype = "application/pdf";

        //    //insert the file into database

        //     strQuery = "UPDATE " + ClsDBT.strSavJobPDF +
        //            " SET pdf_type_id = @PDF_TypeID " +
        //            " WHERE job_id = @JobID AND file_no = @FileNo";

        //     if (filename != "")
        //     {
        //         strQuery = "UPDATE " + ClsDBT.strSavJobPDF +
        //                             " SET pdf_type_id = @PDF_TypeID, file_name = @FileName, file_data = @FileData" +
        //                             " WHERE job_id = @JobID AND file_no = @FileNo";
        //     }

        //    set_sqlConnection();
        //    sqlCon.Open();

        //    SqlCommand cmd = new SqlCommand(strQuery, sqlCon);
        //    //cmd.Parameters.Add("@TableName", SqlDbType.VarChar).Value = _strTableName;
        //    cmd.Parameters.Add("@JobID", SqlDbType.VarChar).Value = _intJobID;
        //    cmd.Parameters.Add("@FileNo", SqlDbType.VarChar).Value = _intFileNo;
        //    cmd.Parameters.Add("@PDF_TypeID", SqlDbType.VarChar).Value = _intPDF_TypeID;
        //    cmd.Parameters.Add("@FileName", SqlDbType.VarChar).Value = filename;
        //    cmd.Parameters.Add("@FileData", SqlDbType.Binary).Value = bytes;

        //    cmd.ExecuteNonQuery();
        //    sqlCon.Close();
        //}


        //public static void UpdatePDF(FileUpload _fu, string _strTableName, int _intJobID, int _intUnitNo)
        //{
        //    string filePath = _fu.PostedFile.FileName;
        //    string filename = Path.GetFileName(filePath);
        //    string ext = Path.GetExtension(filename);
        //    string contenttype = String.Empty;

        //    Stream fs = _fu.PostedFile.InputStream;
        //    BinaryReader br = new BinaryReader(fs);
        //    Byte[] bytes = br.ReadBytes((Int32)fs.Length);

        //    contenttype = "application/pdf";

        //    //insert the file into database
        //    string strQuery = "UPDATE " + _strTableName +
        //                        "  SET pdf_file_name = @FileName, pdf_file_data = @FileData" +
        //                        " WHERE job_id = @JobID AND unit_no = @UnitNo";

        //    OpenConnection();


        //    MySqlCommand cmd = new MySqlCommand(strQuery, MySqlConn);
        //    //cmd.Parameters.Add("@TableName", SqlDbType.VarChar).Value = _strTableName;
        //    cmd.Parameters.Add("@JobID", SqlDbType.VarChar).Value = _intJobID;
        //    cmd.Parameters.Add("@UnitNo", SqlDbType.VarChar).Value = _intUnitNo;
        //    cmd.Parameters.Add("@FileName", SqlDbType.VarChar).Value = filename;
        //    cmd.Parameters.Add("@FileData", SqlDbType.Binary).Value = bytes;

        //    MySqlDataReader dataReader = cmd.ExecuteReader();

        //    CloseConnection();
        //}


        public static void UpdatePDF(Byte[] _bytArr, string _strTableName, int _intJobID, int _intUnitNo)
        {
            string contenttype = String.Empty;
            contenttype = "application/pdf";

            //insert the file into database
            string strQuery = "UPDATE " + _strTableName +
                                " SET pdf_performance = @FileData" +
                                " WHERE job_id = @JobID AND unit_no = @UnitNo";

            OpenConnection();


            MySqlCommand cmd = new MySqlCommand(strQuery, MySqlConn);
            //cmd.Parameters.Add("@TableName", SqlDbType.VarChar).Value = _strTableName;
            cmd.Parameters.AddWithValue("@JobID", _intJobID);
            cmd.Parameters.AddWithValue("@UnitNo", _intUnitNo);
            cmd.Parameters.AddWithValue("@FileData", _bytArr);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            CloseConnection();
        }


        //public static void UpdatePDF(FileUpload _fu, string _strTableName, int _intJobID, int _intUnitNo, int _intComponentNo)
        //{
        //    string filePath = _fu.PostedFile.FileName;
        //    string filename = Path.GetFileName(filePath);
        //    string ext = Path.GetExtension(filename);
        //    string contenttype = String.Empty;

        //    Stream fs = _fu.PostedFile.InputStream;
        //    BinaryReader br = new BinaryReader(fs);
        //    Byte[] bytes = br.ReadBytes((Int32)fs.Length);

        //    contenttype = "application/pdf";

        //    //insert the file into database
        //    string strQuery = "UPDATE " + _strTableName +
        //                        "  SET pdf_file_name = @FileName, pdf_file_data = @FileData" +
        //                        " WHERE job_id = @JobID AND Unit_no = @UnitNo AND component_no = @ComponentNO";

        //    set_sqlConnection();
        //    sqlCon.Open();

        //    SqlCommand cmd = new SqlCommand(strQuery, sqlCon);
        //    //cmd.Parameters.Add("@TableName", SqlDbType.VarChar).Value = _strTableName;
        //    cmd.Parameters.Add("@JobID", SqlDbType.VarChar).Value = _intJobID;
        //    cmd.Parameters.Add("@UnitNo", SqlDbType.VarChar).Value = _intUnitNo; 
        //    cmd.Parameters.Add("@ComponentNo", SqlDbType.VarChar).Value = _intComponentNo;
        //    cmd.Parameters.Add("@FileName", SqlDbType.VarChar).Value = filename;
        //    cmd.Parameters.Add("@FileData", SqlDbType.Binary).Value = bytes;

        //    cmd.ExecuteNonQuery();
        //    sqlCon.Close();
        //}

        //public static void UpdatePDF(FileUpload _fu, string _strTableName, int _intJobID, int _intUnitNo, int _intComponentNo, string _strPDF_FileColumnName, string _strPDF_FileColumnData)
        //{
        //    string filePath = _fu.PostedFile.FileName;
        //    string filename = Path.GetFileName(filePath);
        //    string ext = Path.GetExtension(filename);
        //    string contenttype = String.Empty;

        //    Stream fs = _fu.PostedFile.InputStream;
        //    BinaryReader br = new BinaryReader(fs);
        //    Byte[] bytes = br.ReadBytes((Int32)fs.Length);

        //    contenttype = "application/pdf";

        //    //insert the file into database
        //    string strQuery = "UPDATE " + _strTableName +
        //                        "  SET " + _strPDF_FileColumnName + " = @FileName, " + _strPDF_FileColumnData + " = @FileData" +
        //                        " WHERE job_id = @JobID AND Unit_no = @UnitNo AND component_no = @ComponentNO";

        //    set_sqlConnection();
        //    sqlCon.Open();

        //    SqlCommand cmd = new SqlCommand(strQuery, sqlCon);
        //    //cmd.Parameters.Add("@TableName", SqlDbType.VarChar).Value = _strTableName;
        //    cmd.Parameters.Add("@JobID", SqlDbType.VarChar).Value = _intJobID;
        //    cmd.Parameters.Add("@UnitNo", SqlDbType.VarChar).Value = _intUnitNo;
        //    cmd.Parameters.Add("@ComponentNo", SqlDbType.VarChar).Value = _intComponentNo;
        //    cmd.Parameters.Add("@FileName", SqlDbType.VarChar).Value = filename;
        //    cmd.Parameters.Add("@FileData", SqlDbType.Binary).Value = bytes;

        //    cmd.ExecuteNonQuery();
        //    sqlCon.Close();
        //}


        //private static void addUsersTable(string _strUserTableName)
        //{
        //    if (ds == null)
        //    {
        //        ds = new DataSet();
        //    }

        //    set_sqlConnection();
        //    sqlCon.Open();

        //    da = new System.Data.SqlClient.SqlDataAdapter("OPEN MASTER KEY DECRYPTION BY PASSWORD = 'aa_master_key_2803' OPEN SYMMETRIC KEY annexair_table_key_2803 DECRYPTION BY CERTIFICATE encrypt_annexair_certificate " +
        //                                                   "SELECT *, CONVERT(VARCHAR(50),DECRYPTBYKEY(encrypt_password)) AS decrypt_password FROM " + _strUserTableName + " WHERE access = 1", sqlCon);
        //    da.Fill(ds, _strUserTableName);

        //    sqlCon.Close();
        //    sqlCon.Dispose();
        //}
    }
}
