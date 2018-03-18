using ERP_LIJUN.CommClass;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERP_LIJUN.DataClass
{
    class DataBase
    {
        private SqlConnection m_Conn = null;
        private SqlCommand m_Cmd = null;

        public DataBase()
        {
            string strServer = OperatorFile.GetIniFileString
                ("DataBase","Server","",Application.StartupPath.ToString()+"//ERP-LIJUN.ini");
            string strConn = "Server = " + strServer + ";Database=db_ERP;integrated security = SSPI";
            try
            {
                m_Conn = new SqlConnection(strConn);
                m_Cmd = new SqlCommand();
                m_Cmd.Connection = m_Conn;
            }catch(Exception e)
            {
                throw e;
            }
        }

        public SqlConnection Conn
        {
            get { return m_Conn; }
        }
        public SqlCommand Cmd
        {
            get { return m_Cmd; }
        }


        public SqlDataReader GetDataReader(string sqlStr)
        {
            SqlDataReader sdr;
            m_Cmd.CommandType = System.Data.CommandType.Text;
            m_Cmd.CommandText = sqlStr;

            try
            {
                if(m_Conn.State==System.Data.ConnectionState.Closed)
                {
                    m_Conn.Open();
                }
                //执行Transact-SQL语句（若SqlDataReader对象关闭，则对应数据连接也关闭）
                sdr = m_Cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
            catch (Exception e )
            {
                throw e;
            }
            return sdr;
        }
    }
}
