using System;
using System.Collections.Generic;
using System.Text;

namespace Example.CoreShareds
{
    public class GenericResult<T>
    {
        public T Data { get; set; }
        public EnumResultType EnumResultType { get; set; }
        public System.Exception Exception { get; private set; }
        public List<string> MessageList { get; set; }

        public bool IsSucceed
        {
            get
            {
                return this.EnumResultType == EnumResultType.Success;
            }
        }
        private GenericResult()
        {
        }

        private static GenericResult<T> Fill(T data, List<string> messageList = null)
        {
            return new GenericResult<T>
            {
                Data = data,
                MessageList = messageList
            };
        }
     
        public static GenericResult<T> Success(T data, List<string> messageList = null)
        {
            var result = Fill(data, messageList);
            result.EnumResultType = EnumResultType.Success;
            return result;
        }
        public static GenericResult<T> Success(T data, string message)
        {
            var result = Fill(data, string.IsNullOrEmpty(message) ? null : new List<string>() { message });
            result.EnumResultType = EnumResultType.Success;
            return result;
        }
        public static GenericResult<T> Error(Exception e)
        {
            var result = Fill(default(T), null);
            result.EnumResultType = EnumResultType.Error;
            result.Exception = e;
            return result;
        }
        public static GenericResult<T> Error(T data, Exception e)
        {
            var result = Fill(data, null);
            result.EnumResultType = EnumResultType.Error;
            result.Exception = e;
            return result;
        }
        public static GenericResult<T> Error(T data, List<string> messageList = null)
        {
            var result = Fill(data, messageList);
            result.EnumResultType = EnumResultType.Error;
            return result;
        }
        public static GenericResult<T> Error(T data, string message)
        {
            var result = Fill(data, string.IsNullOrEmpty(message) ? null : new List<string>() { message });
            result.EnumResultType = EnumResultType.Error;
            return result;
        }

        public static GenericResult<T> Warning(T data, List<string> messageList = null)
        {
            var result = Fill(data, messageList);
            result.EnumResultType = EnumResultType.Warning;
            return result;
        }
        public static GenericResult<T> Warning(T data, string message)
        {
            var result = Fill(data, string.IsNullOrEmpty(message) ? null : new List<string>() { message });
            result.EnumResultType = EnumResultType.Warning;
            return result;
        }

        public static GenericResult<T> UserSafeError(T data, List<string> messageList = null)
        {
            var result = Fill(data, messageList);
            result.EnumResultType = EnumResultType.UserSafeError;
            return result;
        }
        public static GenericResult<T> UserSafeError(T data, string message)
        {
            var result = Fill(data, string.IsNullOrEmpty(message) ? null : new List<string>() { message });
            result.EnumResultType = EnumResultType.UserSafeError;
            return result;
        }
        public static GenericResult<T> UserSafeError(string message)
        {
            var result = Fill(default(T), string.IsNullOrEmpty(message) ? null : new List<string>() { message });
            result.EnumResultType = EnumResultType.UserSafeError;
            return result;
        }
    }


}
