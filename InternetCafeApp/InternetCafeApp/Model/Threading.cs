using InternetCafeApp;
using System;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.System.Threading;
using Windows.UI.Core;

namespace InternetCafeApp.Model
{
    class Threading
    {
    }
 
}

namespace ThreadPool
{
    public enum Status
    {
        Unregistered = 0,
        Started = 1,
        Canceled = 2,
        Completed = 3
    }

    class ThreadPoolSample
    {
  /*      public static ThreadPoolTimer DelayTimer;
        public static DelayTimer DelayTimerScenario;
        public static int DelayTimerMilliseconds = 0;
        public static string DelayTimerInfo = "";
        public static Status DelayTimerStatus = Status.Unregistered;
        public static int DelayTimerSelectedIndex = 0;
        */
        public static ThreadPoolTimer PeriodicTimer;
        public static MainPage PeriodicTimerScenario;
        public static long PeriodicTimerCount = 0;
        public static int PeriodicTimerMilliseconds = 0;
        public static string PeriodicTimerInfo = "";
        public static Status PeriodicTimerStatus = Status.Unregistered;
        public static int PeriodicTimerSelectedIndex = 0;

/*        public static IAsyncAction ThreadPoolWorkItem;
        public static WorkItem WorkItemScenaioro;
        public static WorkItemPriority WorkItemPriority = WorkItemPriority.Normal;
        public static Status WorkItemStatus;
        public static int WorkItemSelectedIndex = 1;
  */
    }
}