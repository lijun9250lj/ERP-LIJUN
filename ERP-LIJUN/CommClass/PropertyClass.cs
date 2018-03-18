using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP_LIJUN.CommClass
{
    class PropertyClass
    {
        //操作员id
        public static string m_OperatorCode;

        public static string OperatorCode
        {
            get
            {
                return m_OperatorCode;
            }
            set
            {
                m_OperatorCode = value;
            }
        }

        //操作员Name
        public static string m_OperatorName;

        public static string OperatorName
        {
            get
            {
                return m_OperatorName;
            }
            set
            {
                m_OperatorName = value;
            }
        }

        private static string m_PassWord;
        /// <summary>
        /// 操作员密码
        /// </summary>
        public static string PassWord
        {
            get
            {
                return m_PassWord;
            }
            set
            {
                m_PassWord = value;
            }
        }

        private static string m_IsAdmin;
        /// <summary>
        /// 是否系统管理员标记
        /// </summary>
        public static string IsAdmin
        {
            get
            {
                return m_IsAdmin;
            }
            set
            {
                m_IsAdmin = value;
            }
        }
    }
}
