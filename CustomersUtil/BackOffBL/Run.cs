using System;
using System.Threading;

namespace CustomersUtil
{
    public static class Run
    {
        private const int Second = 1000;

        //public static void TightLoop(int retries, Action routine)
        //{
        //    int retryCount = retries;
        //    int currentCount = 0;

        //    do
        //    {
        //        try
        //        {
        //            routine();
        //            break;
        //        }
        //        catch (Exception ex)
        //        {
        //            if (++currentCount >= retryCount) break;
        //        }
        //    } while (true);
        //}

        //public static void WithDefault(int retries, int interval, Action routine)
        //{
        //    int retryCount = retries;
        //    int backOffInterval = interval;
        //    int currentCount = 0;

        //    do
        //    {
        //        try
        //        {
        //            routine();
        //            break;
        //        }
        //        catch (Exception ex)
        //        {
        //            if (++currentCount >= retryCount) break;
        //            Thread.Sleep(backOffInterval * Second);
        //        }
        //    } while (true);
        //}


        public static void WithProgressBackOff(int retries
                                      , int intervalMin
                                      , int intervalMax
                                      , Action routine)
        {
            int retryCount = retries;
            int minInterval = intervalMin;
            int maxInterval = intervalMax;
            int backOffInterval = intervalMin;
            int exponent = 2;
            int currentCount = 0;
            do
            {
                try
                {
                    routine();
                    return;
                }
                catch (Exception ex)
                {
                    Logger.Error(String.Format(@"Inside WithProgressBackOff for:{0}
                            ,currentCount :{1}
                            ,retryCount:{2}
                            ,backOffInterval * Second:{3}
                            ,Err Msg:{4}
                            ,Stack:{5}"
                             , "void"
                             , currentCount + 1
                             , retryCount
                             , backOffInterval * Second
                             , ex.Message
                             , ex.StackTrace));
                    currentCount++;
                    if (currentCount >= retryCount)
                    {
                        throw ex;
                    }
                    else if (currentCount < retryCount)
                    {
                        Thread.Sleep(backOffInterval * Second);
                        backOffInterval = Math.Min(maxInterval, backOffInterval * exponent);
                    }
                }
            } while (true);
            throw new Exception("Fail to get data for :" + "void");

        }
        public static TRes WithProgressBackOff<TRes>(int retries
                                      , int intervalMin
                                      , int intervalMax
                                      , Func<TRes> routine)
        {
            int retryCount = retries;
            int minInterval = intervalMin;
            int maxInterval = intervalMax;
            int backOffInterval = intervalMin;
            int exponent = 2;
            int currentCount = 0;
            TRes returnObject = default(TRes);
            do
            {
                try
                {
                    returnObject = routine();
                    return returnObject;
                }
                catch (Exception ex)
                {
                    Logger.Error(String.Format(@"Inside WithProgressBackOff for:{0}
                            ,currentCount :{1}
                            ,retryCount:{2}
                            ,backOffInterval * Second:{3}
                            ,Err Msg:{4}
                            ,Stack:{5}"
                            , typeof(TRes).Name
                            , currentCount + 1
                            , retryCount
                            , backOffInterval * Second
                            , ex.Message
                            , ex.StackTrace));
                    currentCount++;
                    if (currentCount >= retryCount)
                    {
                        throw ex;
                    }
                    else if (currentCount < retryCount)
                    {
                        Thread.Sleep(backOffInterval * Second);
                        backOffInterval = Math.Min(maxInterval, backOffInterval * exponent);
                    }
                }
            } while (true);
            throw new Exception("Fail to get data for :" + typeof(TRes).Name);

        }
        public static TRes WithProgressBackOff<T1, TRes>(int retries
                                , int intervalMin
                                , int intervalMax
                                , T1 p1
                                , Func<T1, TRes> routine)
        {
            int retryCount = retries;
            int minInterval = intervalMin;
            int maxInterval = intervalMax;
            int backOffInterval = intervalMin;
            int exponent = 2;
            int currentCount = 0;
            TRes returnObject = default(TRes);
            do
            {
                try
                {
                    returnObject = routine(p1);
                    return returnObject;
                }
                catch (Exception ex)
                {
                    Logger.Error(String.Format(@"Inside WithProgressBackOff for:{0}
                            ,currentCount :{1}
                            ,retryCount:{2}
                            ,backOffInterval * Second:{3}
                            ,Err Msg:{4}
                            ,Stack:{5}"
                            , typeof(TRes).Name
                            , currentCount + 1
                            , retryCount
                            , backOffInterval * Second
                            , ex.Message
                            , ex.StackTrace));
                    currentCount++;
                    if (currentCount >= retryCount)
                    {
                        throw ex;
                    }
                    else if (currentCount < retryCount)
                    {
                        Thread.Sleep(backOffInterval * Second);
                        backOffInterval = Math.Min(maxInterval, backOffInterval * exponent);
                    }
                }
            } while (true);
            throw new Exception("Fail to get data for :" + typeof(TRes).Name);

        }
        public static TRes WithProgressBackOff<T1, T2, TRes>(int retries
                                       , int intervalMin
                                       , int intervalMax
                                       , T1 p1, T2 p2
                                       , Func<T1, T2, TRes> routine)
        {
            int retryCount = retries;
            int minInterval = intervalMin;
            int maxInterval = intervalMax;
            int backOffInterval = intervalMin;
            int exponent = 2;
            int currentCount = 0;
            TRes returnObject = default(TRes);
            do
            {
                try
                {
                    returnObject = routine(p1, p2);
                    return returnObject;
                }
                catch (Exception ex)
                {
                    Logger.Error(String.Format(@"Inside WithProgressBackOff for:{0}
                            ,currentCount :{1}
                            ,retryCount:{2}
                            ,backOffInterval * Second:{3}
                            ,Err Msg:{4}
                            ,Stack:{5}"
                           , typeof(TRes).Name
                           , currentCount + 1
                           , retryCount
                           , backOffInterval * Second
                           , ex.Message
                           , ex.StackTrace));
                    currentCount++;
                    if (currentCount >= retryCount)
                    {
                        throw ex;
                    }
                    else if (currentCount < retryCount)
                    {
                        Thread.Sleep(backOffInterval * Second);
                        backOffInterval = Math.Min(maxInterval, backOffInterval * exponent);
                    }
                }
            } while (true);
            throw new Exception("Fail to get data for :" + typeof(TRes).Name);

        }

        public static TRes WithProgressBackOff<T1, T2, T3, TRes>(int retries
                                   , int intervalMin
                                   , int intervalMax
                                   , T1 p1, T2 p2, T3 p3
                                   , Func<T1, T2, T3, TRes> routine)
        {
            int retryCount = retries;
            int minInterval = intervalMin;
            int maxInterval = intervalMax;
            int backOffInterval = intervalMin;
            int exponent = 2;
            int currentCount = 0;
            TRes returnObject = default(TRes);
            do
            {
                try
                {
                    returnObject = routine(p1, p2, p3);
                    return returnObject;
                }
                catch (Exception ex)
                {
                    Logger.Error(String.Format(@"Inside WithProgressBackOff for:{0}
                            ,currentCount :{1}
                            ,retryCount:{2}
                            ,backOffInterval * Second:{3}
                            ,Err Msg:{4}
                            ,Stack:{5}"
                            , typeof(TRes).Name
                            , currentCount + 1
                            , retryCount
                            , backOffInterval * Second
                            , ex.Message
                            , ex.StackTrace));
                    currentCount++;
                    if (currentCount >= retryCount)
                    {
                        throw ex;
                    }
                    else if (currentCount < retryCount)
                    {
                        Thread.Sleep(backOffInterval * Second);
                        backOffInterval = Math.Min(maxInterval, backOffInterval * exponent);
                    }
                }
            } while (true);
            throw new Exception("Fail to get data for :" + typeof(TRes).Name);

        }

        public static TRes WithProgressBackOff<T1, T2, T3,T4, TRes>(int retries
                                   , int intervalMin
                                   , int intervalMax
                                   , T1 p1, T2 p2, T3 p3,T4 p4
                                   , Func<T1, T2, T3,T4, TRes> routine)
        {
            int retryCount = retries;
            int minInterval = intervalMin;
            int maxInterval = intervalMax;
            int backOffInterval = intervalMin;
            int exponent = 2;
            int currentCount = 0;
            TRes returnObject = default(TRes);
            do
            {
                try
                {
                    returnObject = routine(p1, p2, p3,p4);
                    return returnObject;
                }
                catch (Exception ex)
                {
                    Logger.Error(String.Format(@"Inside WithProgressBackOff for:{0}
                            ,currentCount :{1}
                            ,retryCount:{2}
                            ,backOffInterval * Second:{3}
                            ,Err Msg:{4}
                            ,Stack:{5}"
                            , typeof(TRes).Name
                            , currentCount + 1
                            , retryCount
                            , backOffInterval * Second
                            , ex.Message
                            , ex.StackTrace));
                    currentCount++;
                    if (currentCount >= retryCount)
                    {
                        throw ex;
                    }
                    else if (currentCount < retryCount)
                    {
                        Thread.Sleep(backOffInterval * Second);
                        backOffInterval = Math.Min(maxInterval, backOffInterval * exponent);
                    }
                }
            } while (true);
            throw new Exception("Fail to get data for :" + typeof(TRes).Name);

        }

        public static TRes WithProgressBackOff<T1, T2, T3, T4,T5, TRes>(int retries
                                   , int intervalMin
                                   , int intervalMax
                                   , T1 p1, T2 p2, T3 p3, T4 p4,T5 p5
                                   , Func<T1, T2, T3, T4,T5, TRes> routine)
        {
            int retryCount = retries;
            int minInterval = intervalMin;
            int maxInterval = intervalMax;
            int backOffInterval = intervalMin;
            int exponent = 2;
            int currentCount = 0;
            TRes returnObject = default(TRes);
            do
            {
                try
                {
                    returnObject = routine(p1, p2, p3, p4,p5);
                    return returnObject;
                }
                catch (Exception ex)
                {
                    Logger.Error(String.Format(@"Inside WithProgressBackOff for:{0}
                            ,currentCount :{1}
                            ,retryCount:{2}
                            ,backOffInterval * Second:{3}
                            ,Err Msg:{4}
                            ,Stack:{5}"
                            , typeof(TRes).Name
                            , currentCount + 1
                            , retryCount
                            , backOffInterval * Second
                            , ex.Message
                            , ex.StackTrace));
                    currentCount++;
                    if (currentCount >= retryCount)
                    {
                        throw ex;
                    }
                    else if (currentCount < retryCount)
                    {
                        Thread.Sleep(backOffInterval * Second);
                        backOffInterval = Math.Min(maxInterval, backOffInterval * exponent);
                    }
                }
            } while (true);
            throw new Exception("Fail to get data for :" + typeof(TRes).Name);

        }

        public static TRes WithProgressBackOff<T1, T2, T3, T4, T5,T6, TRes>(int retries
                                   , int intervalMin
                                   , int intervalMax
                                   , T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6
                                   , Func<T1, T2, T3, T4, T5,T6, TRes> routine)
        {
            int retryCount = retries;
            int minInterval = intervalMin;
            int maxInterval = intervalMax;
            int backOffInterval = intervalMin;
            int exponent = 2;
            int currentCount = 0;
            TRes returnObject = default(TRes);
            do
            {
                try
                {
                    returnObject = routine(p1, p2, p3, p4, p5,p6);
                    return returnObject;
                }
                catch (Exception ex)
                {
                    Logger.Error(String.Format(@"Inside WithProgressBackOff for:{0}
                            ,currentCount :{1}
                            ,retryCount:{2}
                            ,backOffInterval * Second:{3}
                            ,Err Msg:{4}
                            ,Stack:{5}"
                            , typeof(TRes).Name
                            , currentCount + 1
                            , retryCount
                            , backOffInterval * Second
                            , ex.Message
                            , ex.StackTrace));
                    currentCount++;
                    if (currentCount >= retryCount)
                    {
                        throw ex;
                    }
                    else if (currentCount < retryCount)
                    {
                        Thread.Sleep(backOffInterval * Second);
                        backOffInterval = Math.Min(maxInterval, backOffInterval * exponent);
                    }
                }
            } while (true);
            throw new Exception("Fail to get data for :" + typeof(TRes).Name);

        }
    }

}
