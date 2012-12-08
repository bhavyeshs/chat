using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;

/// <summary>
/// Summary description for clsDBCalls
/// </summary>
/// 
namespace chatApp
{

    public class clsDBCalls
    {
        SqlConnection connObj = new SqlConnection();
        public clsDBCalls()
        {
            connObj.ConnectionString = "Data Source = localhost; Initial Catalog = ChatApp; Integrated Security = SSPI";
        }

        public int CheckSession(string sessionId)
        {
            SqlCommand cmdCheckSession = new SqlCommand("SELECT count(*) FROM LoginDetails WHERE lastSessionId = '" + sessionId + "'", connObj);
            connObj.Open();
            int count = Convert.ToInt32(cmdCheckSession.ExecuteScalar());
            connObj.Close();
            if (count == 1)
            {
                return 1;
            }
            else
                return 0;
        }

        public int CheckLogin(string userName, string password, string sessionId)
        {

            connObj.Open();
            SqlCommand comcheckUserId = new SqlCommand("usp_checkLogin", connObj);
            comcheckUserId.CommandType = CommandType.StoredProcedure;
            comcheckUserId.Parameters.Add("@userName", SqlDbType.VarChar, 50).Value = userName;
            comcheckUserId.Parameters.Add("@password", SqlDbType.VarChar, 50).Value = password;
            comcheckUserId.Parameters.Add("@sessionId", SqlDbType.VarChar, 100).Value = sessionId;
            int Count = Convert.ToInt32(comcheckUserId.ExecuteScalar());
            connObj.Close();
            return Count;

        }

        public DataTable fetchFriends(string sessionId)
        {
            //connObj.Open();
            SqlCommand comgetFriendList = new SqlCommand("SELECT * FROM ufn_FetchFriends(@SessionId)", connObj);
            comgetFriendList.Parameters.Add("@SessionId", SqlDbType.VarChar, 50).Value = sessionId;
            connObj.Open();
            SqlDataAdapter adap = new SqlDataAdapter(comgetFriendList);
            DataTable dtFriendList = new DataTable();
            adap.Fill(dtFriendList);
            connObj.Close();
            return dtFriendList;
        }

        public string getUserName(string sessionId)
        {
            SqlCommand cmdGetUserId = new SqlCommand("SELECT UserName FROM LoginDetails WHERE lastSessionId = '"+sessionId+"'",connObj);
            connObj.Open();
            string userName = Convert.ToString(cmdGetUserId.ExecuteScalar());
            connObj.Close();
            return userName;
        }

        public DataTable checkAlert(string sessionId)
        {
            SqlCommand cmdCheckAlert = new SqlCommand("SELECT * FROM ufn_CheckAlert(@SessionId)", connObj);
            cmdCheckAlert.Parameters.Add("@SessionId", SqlDbType.VarChar, 50).Value = sessionId;
            connObj.Open();
            SqlDataAdapter adap = new SqlDataAdapter(cmdCheckAlert);
            DataTable dtAlertList = new DataTable();
            adap.Fill(dtAlertList);
            connObj.Close();
            return dtAlertList;
        }

        public void setAlert(string sessionId, string toId)
        {
            string FromId = getUserName(sessionId);
            SqlCommand cmdsetChatAlert = new SqlCommand("usp_setAlert", connObj);
            cmdsetChatAlert.CommandType = CommandType.StoredProcedure;
            cmdsetChatAlert.Parameters.Add("@FromId", SqlDbType.VarChar, 50).Value = FromId;
            cmdsetChatAlert.Parameters.Add("@toId", SqlDbType.VarChar, 50).Value = toId;
            connObj.Open();
            cmdsetChatAlert.ExecuteNonQuery();
            connObj.Close();
        }

        public void resetAlert(string sessionId, string toId)
        {
            SqlCommand cmdresetChatAlert = new SqlCommand("usp_ResetAlert", connObj);
            cmdresetChatAlert.CommandType = CommandType.StoredProcedure;
            cmdresetChatAlert.Parameters.Add("@FromId", SqlDbType.VarChar, 50).Value = toId;
            cmdresetChatAlert.Parameters.Add("@SessionId", SqlDbType.VarChar, 50).Value = sessionId;
            connObj.Open();
            cmdresetChatAlert.ExecuteNonQuery();
            connObj.Close();
        }

        public DataTable getMessages(string sessionId, string toId)
        {
            string FromId = getUserName(sessionId);
            SqlCommand comGetMessage = new SqlCommand("SELECT * FROM ufn_GetMessages(@FromId, @toId)", connObj);
            comGetMessage.Parameters.Add("@FromId", SqlDbType.VarChar, 50).Value = FromId;
            comGetMessage.Parameters.Add("@toId", SqlDbType.VarChar, 50).Value = toId;
            DataTable dtChat = new DataTable();
            connObj.Open();
            using (SqlDataAdapter adChat = new SqlDataAdapter(comGetMessage))
            {
                adChat.Fill(dtChat);
            }
            connObj.Close();
            return dtChat;
        }

        public int InsertMessage(string sessionId, string toId, string message)
        {
            string FromId = getUserName(sessionId);
            SqlCommand cmdInsertMessage = new SqlCommand("usp_InsertMessage", connObj);
            cmdInsertMessage.Parameters.Add("@FromId", SqlDbType.VarChar, 50).Value = FromId;
            cmdInsertMessage.Parameters.Add("@toId", SqlDbType.VarChar, 50).Value = toId;
            cmdInsertMessage.Parameters.Add("@message", SqlDbType.VarChar, 200).Value = message;
            SqlParameter prmRet = cmdInsertMessage.Parameters.Add("@retVal",SqlDbType.Int);
            prmRet.Direction = ParameterDirection.ReturnValue;
            cmdInsertMessage.CommandType = CommandType.StoredProcedure;
            connObj.Open();
            cmdInsertMessage.ExecuteNonQuery();
            int retValue =  (int)cmdInsertMessage.Parameters["@retVal"].Value;
            connObj.Close();
            return retValue;
        }

        public int AddFriend(string sessionId, string friendId)
        {
            SqlCommand cmdAddFriend = new SqlCommand("usp_AddFriend", connObj);
            cmdAddFriend.Parameters.Add("@SessionId", SqlDbType.VarChar, 50).Value = sessionId;
            cmdAddFriend.Parameters.Add("@FriendId", SqlDbType.VarChar, 50).Value = friendId;
            SqlParameter prmRet = cmdAddFriend.Parameters.Add("@retVal", SqlDbType.Int);
            prmRet.Direction = ParameterDirection.ReturnValue;
            cmdAddFriend.CommandType = CommandType.StoredProcedure;
            connObj.Open();
            cmdAddFriend.ExecuteNonQuery();
            int retValue = (int)cmdAddFriend.Parameters["@retVal"].Value;
            connObj.Close();
            return retValue;
        }

        public int RegisterUser(string mailId, string password)
        {
            SqlCommand cmdRegisterUser = new SqlCommand("usp_RegisterUser", connObj);
            cmdRegisterUser.Parameters.Add("@mailId", SqlDbType.VarChar, 50).Value = mailId;
            cmdRegisterUser.Parameters.Add("@password", SqlDbType.VarChar, 50).Value = password;
            SqlParameter prmRet = cmdRegisterUser.Parameters.Add("@retVal", SqlDbType.Int);
            prmRet.Direction = ParameterDirection.ReturnValue;
            cmdRegisterUser.CommandType = CommandType.StoredProcedure;
            connObj.Open();
            cmdRegisterUser.ExecuteNonQuery();
            int retValue = (int)cmdRegisterUser.Parameters["@retVal"].Value;
            connObj.Close();
            return retValue;
        }


    }
}