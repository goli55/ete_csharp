using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace CustomersUtil
{
    public class Logger
    {
        static int _sec_interval = 0;
        static bool? _enable_interval =null;
        readonly static int default_check_interval = 5;
        readonly static int max_log_line_size = 3000;
        readonly static object _lock = new object();
        readonly static object _lock1 = new object();

        private static readonly ILog _logger =
           LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static Logger()
        {
            XmlConfigurator.Configure();
        }




        public static int SecInterval{
            get
            {
                lock (_lock)
                {
                    if (_sec_interval == 0)
                    {
                        try
                        {
                            string str_interval = ConfigurationManager.AppSettings["IntervalSecCheck"];
                            if (int.TryParse(str_interval, out _sec_interval) == false)
                            {
                                _sec_interval = default_check_interval;
                            }
                        }
                        catch
                        {
                            _sec_interval = default_check_interval;
                        }
                        finally
                        {
                            if (_sec_interval <= 0)
                            {
                                _sec_interval = default_check_interval;
                            }
                        }
                    }
                }

                return _sec_interval;
            }
        }
        public static bool EnableIntervalCheck
        {
            get
            {
                lock (_lock1)
                {
                    if (_enable_interval.HasValue == false)
                    {
                        try
                        {
                            string enable_interval = ConfigurationManager.AppSettings["EnableIntervalSecCheck"];
                            bool enable;
                            if (bool.TryParse(enable_interval, out enable) == false)
                            {
                                _enable_interval = false;
                            }
                            else
                            {
                                _enable_interval = enable;
                            }
                        }
                        catch
                        {
                            _enable_interval = false;
                        }
                        finally
                        {
                            if (_enable_interval.HasValue==false)
                            {
                                _enable_interval = false;
                            }
                        }
                    }
                }

                return _enable_interval.GetValueOrDefault();
            }
        }

        private static void wrtieIntervalLog(string log,Guid internalGuid,Action<Guid,string> write,bool writeAll=false){
            try
            {
                if (writeAll == false)
                    write(internalGuid, log);
                else
                {
                    var iter = ChunksUpto(log, max_log_line_size);
                    Parallel.ForEach(iter, (s_p) => write(internalGuid, s_p));
                }
                //foreach (var s_p in iter)    write(internalGuid, s_p);
            }
            catch (AggregateException ae)
            {
                _logger.Error("fail to write to logger with parallel");
            }

        }
        private static void wrtieIntervalLog(string log, Guid internalGuid, Exception e, Action<Guid, string, Exception> write, bool writeAll=false)
        {
            try
            {
                if (writeAll == false)
                    write(internalGuid, log, e);
                else
                {
                    var iter = ChunksUpto(log, max_log_line_size);
                    Parallel.ForEach(iter, (s_p) => write(internalGuid, s_p, e));
                }
                //foreach (var s_p in iter)  write(internalGuid, s_p, e);
            }
            catch (AggregateException ae)
            {
                _logger.Error("fail to write to logger with parallel");

            }

        }

        public static void IntervalCheck(Guid internalGuid, double sec, string s, int secInterval = 0, bool writeAll=false)
        {
            if (secInterval == 0) secInterval = SecInterval;

            if (sec > secInterval)
            {
                string log = string.Format("worked:{0} sec. - more then: {1} sec.Log:\n{2}."
                    , sec
                    , SecInterval
                    , s);
                wrtieIntervalLog(log
                    , internalGuid
                    , (g_part, s_part) => _logger.Error(string.Format("tracking guid:{0}. {1}", g_part, s_part))
                    , writeAll);


            }
            else if (EnableIntervalCheck)
            {
                string log = string.Format("worked:{0} sec.Log:\n{1}."
                    , sec
                    , s);

                wrtieIntervalLog(log
                    , internalGuid
                    , (g_part, s_part) => _logger.Info(string.Format("tracking guid:{0}. {1}", g_part, s_part))
                    , writeAll);

            }

        }
        public static void Debug(string s, Guid? tracking = null, bool writeAll=false)
        {
            if (tracking.HasValue == false)
                tracking = Guid.NewGuid();

            wrtieIntervalLog(s
                , tracking.GetValueOrDefault()
                , (g_part, s_part) => _logger.Debug(string.Format("tracking guid:{0}. {1}", g_part, s_part))
                , writeAll);

        }

        public static void Error(string s, Guid? tracking = null, bool writeAll = false)
        {
            if (tracking.HasValue == false)
                tracking = Guid.NewGuid();

            wrtieIntervalLog(s
                , tracking.GetValueOrDefault()
                , (g_part, s_part) => _logger.Error(string.Format("tracking guid:{0}. {1}", g_part, s_part))
                , writeAll);
            
        }

        public static void Error(string s, Exception e, Guid? tracking = null, bool writeAll = false)
        {
            //logger.Error(s, e);
            if(tracking.HasValue==false)
                tracking = Guid.NewGuid();

            wrtieIntervalLog(s
                    , tracking.GetValueOrDefault(),e, (g_part, s_part, e_part) => {
                            _logger.Error(string.Format("tracking guid:{0}. {1}", g_part, s_part), e_part);
                        }
                        , writeAll);

        }


        public static void Info(string s, Guid? tracking = null, bool writeAll = false)
        {
            if (tracking.HasValue == false)
                tracking = Guid.NewGuid();

            wrtieIntervalLog(s
                        , tracking.GetValueOrDefault()
                        , (g_part, s_part) => _logger.Info(string.Format("tracking guid:{0}. {1}", g_part, s_part))
                        , writeAll);

        }

        static IEnumerable<string> ChunksUpto(string str, int maxChunkSize)
        {
            for (int i = 0; i < str.Length; i += maxChunkSize)
                yield return str.Substring(i, Math.Min(maxChunkSize, str.Length - i));
        }
    }
}


