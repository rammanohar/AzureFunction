

using log4net;
using log4net.Config;
using log4net.Core;
using System;
using System.IO;
using System.Reflection;

namespace Logandcosmodb.Concrete
{
    public class Azure4NetLogger : ILog, ILoggerWrapper
    {
        private ILog _logger;

        public Azure4NetLogger(string path)
        {
            this._logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            XmlConfigurator.Configure(LogManager.GetRepository(Assembly.GetEntryAssembly()), new FileInfo(Path.Combine(path, "log4net.config")));
        }

        public bool IsDebugEnabled => this._logger.IsDebugEnabled;

        public bool IsInfoEnabled => this._logger.IsInfoEnabled;

        public bool IsWarnEnabled => this._logger.IsWarnEnabled;

        public bool IsErrorEnabled => this._logger.IsErrorEnabled;

        public bool IsFatalEnabled => this._logger.IsFatalEnabled;

        public ILogger Logger => this._logger.Logger;

        public void Debug(object message) => this._logger.Debug(message);

        public void Debug(object message, Exception exception) => this._logger.Debug(message, exception);

        public void DebugFormat(string format, params object[] args) => this._logger.DebugFormat(format, args);

        public void DebugFormat(string format, object arg0) => this._logger.DebugFormat(format, arg0);

        public void DebugFormat(string format, object arg0, object arg1) => this._logger.DebugFormat(format, arg0, arg1);

        public void DebugFormat(string format, object arg0, object arg1, object arg2) => this._logger.DebugFormat(format, arg0, arg1, arg2);

        public void DebugFormat(IFormatProvider provider, string format, params object[] args) => this._logger.DebugFormat(provider, format, args);

        public void Error(object message) => this._logger.Error(message);

        public void Error(object message, Exception exception) => this._logger.Error(message, exception);

        public void ErrorFormat(string format, params object[] args) => this._logger.ErrorFormat(format, args);

        public void ErrorFormat(string format, object arg0) => this._logger.ErrorFormat(format, arg0);

        public void ErrorFormat(string format, object arg0, object arg1) => this._logger.ErrorFormat(format, arg0, arg1);

        public void ErrorFormat(string format, object arg0, object arg1, object arg2) => this._logger.ErrorFormat(format, arg0, arg1, arg2);

        public void ErrorFormat(IFormatProvider provider, string format, params object[] args) => this._logger.ErrorFormat(provider, format, args);

        public void Fatal(object message) => this._logger.Fatal(message);

        public void Fatal(object message, Exception exception) => this._logger.Fatal(message, exception);

        public void FatalFormat(string format, params object[] args) => this._logger.FatalFormat(format, args);

        public void FatalFormat(string format, object arg0) => this._logger.FatalFormat(format, arg0);

        public void FatalFormat(string format, object arg0, object arg1) => this._logger.FatalFormat(format, arg0, arg1);

        public void FatalFormat(string format, object arg0, object arg1, object arg2) => this._logger.FatalFormat(format, arg0, arg1, arg2);

        public void FatalFormat(IFormatProvider provider, string format, params object[] args) => this._logger.FatalFormat(provider, format, args);

        public void Info(object message) => this._logger.Info(message);

        public void Info(object message, Exception exception) => this._logger.Info(message, exception);

        public void InfoFormat(string format, params object[] args) => this._logger.InfoFormat(format, args);

        public void InfoFormat(string format, object arg0) => this._logger.InfoFormat(format, arg0);

        public void InfoFormat(string format, object arg0, object arg1) => this._logger.InfoFormat(format, arg0, arg1);

        public void InfoFormat(string format, object arg0, object arg1, object arg2) => this._logger.InfoFormat(format, arg0, arg1, arg2);

        public void InfoFormat(IFormatProvider provider, string format, params object[] args) => this._logger.InfoFormat(provider, format, args);

        public void Warn(object message) => this._logger.Warn(message);

        public void Warn(object message, Exception exception) => this._logger.Warn(message, exception);

        public void WarnFormat(string format, params object[] args) => this._logger.WarnFormat(format, args);

        public void WarnFormat(string format, object arg0) => this._logger.WarnFormat(format, arg0);

        public void WarnFormat(string format, object arg0, object arg1) => this._logger.WarnFormat(format, arg0, arg1);

        public void WarnFormat(string format, object arg0, object arg1, object arg2) => this._logger.WarnFormat(format, arg0, arg1, arg2);

        public void WarnFormat(IFormatProvider provider, string format, params object[] args) => this._logger.WarnFormat(provider, format, args);
    }
}