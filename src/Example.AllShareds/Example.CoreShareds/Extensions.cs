using System;
using System.Collections.Generic;
using System.Text;

namespace Example.CoreShareds
{
    public static class Extensions
    {
        public static string ToInnerExMessage(this Exception e, string ifNullMsg = "An error occurred")
        {
            while (e.InnerException != null)
                e = e.InnerException;
            return e.Message;
        }
        public static string GetAllExMessage(this Exception e, string ifNullMsg = "An error occurred")
        {
            StringBuilder sb = new StringBuilder();
            do
            {
                sb.AppendLine(e.Message);
                e = e.InnerException;
            } while (e != null);
            return sb.ToString();
        }
        public static GenericResult<T> GetUserSafeResult<T>(this GenericResult<T> result, string msg = "An Error occured")
        {
            if (result.IsSucceed)
                return result;

            if (result.EnumResultType != EnumResultType.UserSafeError)
                return GenericResult<T>.UserSafeError(result.Data, "An Error occured");

            return result;
        }

        public static string GetAllMessage<T>(this GenericResult<T> result, bool userSafeMsg = true, string defaultMsg = "An Error occured", string separator = " ")
        {
            if (userSafeMsg)
            {
                if (result.EnumResultType == EnumResultType.UserSafeError)
                    return result.MessageList == null ? defaultMsg : string.Join(separator, result.MessageList);
                else
                    return defaultMsg;
            }
            else
            {
                string msg = result.Exception?.GetAllExMessage() + separator + (result.MessageList == null ? "" : string.Join(separator, result.MessageList));
                if (string.IsNullOrEmpty(msg))
                    return defaultMsg;
                return msg;
            }
        }
    }
}
