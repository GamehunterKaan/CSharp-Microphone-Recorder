using System;
using System.Threading;
using System.Runtime.InteropServices;


namespace Microphone_Module
{
    public class Program
    {
        [DllImport("winmm.dll")]

       public static extern long mciSendString(

       string strCommand,

       string strReturn,

       int iReturnLength,

       IntPtr oCallback,

       int lpszDeviceID
       );
        static void Main(string[] args)
        {
            int sleep = (int.Parse(args[0])*1000);
            mciSendString("open new Type waveaudio Alias recsound", "", 0, IntPtr.Zero, 1);
            mciSendString("record recsound", null, 0, IntPtr.Zero, 1);
            Thread.Sleep(sleep);
            mciSendString("save recsound " + args[1], "", 0, IntPtr.Zero ,1);
            mciSendString("close recsound ", null, 0, IntPtr.Zero, 1);
        }
    }
}