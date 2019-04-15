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
        public static GenericResult<T> GetUserSafeResult<T>(this GenericResult<T> result, string baseMsg = "")
        {
            if (result.IsSucceed || result.EnumResultType == EnumResultType.UserSafeError)
                return GenericResult<T>.UserSafeError(result.Data, baseMsg + " " + result.GetAllMessage());

            return GenericResult<T>.UserSafeError(result.Data, baseMsg);
        }
        public static GenericResult<TResult> GetUserSafeResult<TResult, TEntry>(this GenericResult<TEntry> entry, TResult result = default(TResult), string baseMsg = "")
        {
            if (entry.IsSucceed || entry.EnumResultType == EnumResultType.UserSafeError)
                return GenericResult<TResult>.UserSafeError(result, baseMsg + " " + entry.GetAllMessage());

            return GenericResult<TResult>.UserSafeError(result, baseMsg);
        }
        public static GenericResult<TResult> ConvertTo<TResult, TEntry>(this GenericResult<TEntry> entry, TResult result, string baseMsg = "")
        {
            var msg = baseMsg + " " + entry.GetAllMessage();
            switch (entry.EnumResultType)
            {
                case EnumResultType.Success:
                    return GenericResult<TResult>.Success(result, msg);
                case EnumResultType.Error:
                    return GenericResult<TResult>.Error(result, msg);
                case EnumResultType.Warning:
                    return GenericResult<TResult>.Warning(result, msg);
                case EnumResultType.UserSafeError:
                    return GenericResult<TResult>.UserSafeError(result, msg);
                default:
                    return GenericResult<TResult>.Error(result, msg);
            }
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
