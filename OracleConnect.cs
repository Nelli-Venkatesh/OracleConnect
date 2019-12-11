using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleConnect
{
    public class db
    {
        public static OracleConnection con;


        // Insert/Update/Delete Data Using Parameterized
        public static int executeParametersInsertion(OracleCommand extCmd, string connection_string)
        {
            try
            {
                using (con = new OracleConnection(connection_string))
                {
                    using (OracleCommand cmd = extCmd)
                    {

                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        cmd.Connection = con;
                        int i = cmd.ExecuteNonQuery();
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                            con.Dispose();
                        }
                        return i;
                    }
                }
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                    con.Dispose();
                }
                throw ex;
            }
        }


        // Retrive Data Using Procedure
        public static DataTable executeProcedure(OracleCommand extCmd, string connection_string)
        {
            try
            {
                using (con = new OracleConnection(connection_string))
                {
                    using (OracleCommand cmd = extCmd)
                    {

                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        cmd.Connection = con;
                        OracleDataAdapter adp = new OracleDataAdapter(cmd);
                        cmd.CommandTimeout = 0;
                        DataTable dt = new DataTable();
                        adp.Fill(dt);

                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                            con.Dispose();
                        }

                        if (dt != null && dt.Rows.Count > 0)
                        {
                            return dt;
                        }

                        return new DataTable();
                    }
                }
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                    con.Dispose();
                }
                throw ex;
            }
        }


        // Retrive Data Using Query
        public static DataTable executeQuery(string query, string connection_string)
        {
            try
            {
                using (con = new OracleConnection(connection_string))
                {
                    using (OracleCommand cmd = new OracleCommand(query, con))
                    {

                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        cmd.Connection = con;
                        OracleDataAdapter dap = new OracleDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        dap.Fill(dt);
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                            con.Dispose();
                        }
                        if (dt.Rows.Count > 0)
                        {
                            return dt;
                        }

                        return new DataTable();
                    }
                }
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                    con.Dispose();
                }
                throw ex;
            }
        }


        // Insert/Update/Delete Data Using Query
        public static int executenonQuery(string query, string connection_string)
        {
            int i = 0;
            try
            {
                using (con = new OracleConnection(connection_string))
                {
                    using (OracleCommand cmd = new OracleCommand(query, con))
                    {

                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        cmd.Connection = con;
                        i = cmd.ExecuteNonQuery();
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                            con.Dispose();
                        }
                        return i;
                    }
                }
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                    con.Dispose();
                }
                throw ex;
            }
        }


    }
}
