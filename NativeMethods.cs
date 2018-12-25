/*
 *http://www.pinvoke.net/
 * 
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Mouse_Simulation
{
    public class NativeMethods
    {
        private const uint OCR_NORMAL = 32512;
        private const int IDC_ARROW = 32512;
        private const int VK_NUMPAD1 = 0x61;
        private const int VK_BACK = 0x08;    //BACKSPACE key
        private const int VK_TAB = 0x09;     //TAB key
        private const int VK_CLEAR = 0x0C;   //CLEAR key
        private const int VK_RETURN = 0x0D;  //ENTER key
        private const int VK_SHIFT = 0x10;   //SHIFT key
        private const int VK_CONTROL = 0x11; //CTRL key
        private const int VK_LCONTROL = 0xA2; //CTRL key
        private const int VK_MENU = 0x12;    //ALT key
        private const int VK_RMENU = 0xA5;    //Right ALT key
        private const int VK_LMENU = 0xA4;    //LEft ALT key
        private const int VK_PAUSE = 0x13;   //PAUSE key
        private const int VK_ESCAPE = 0x1B;  //ESC key
        private const int VK_END = 0x23;     //END key
        private const int VK_LEFT = 0x25;    //LEFT ARROW key
        private const int VK_UP = 0x26;      //UP ARROW key
        private const int VK_RIGHT = 0x27;   //Right ARROW key
        private const int VK_DOWN = 0x28;    //DOWN ARROW key
        private const int VK_DELETE = 0x2E;  //DEL key
        private const int VK_KEYDOWN = 0x100;
        private const int KEY_E = 0x45;
        private const int KEYEVENTF_EXTENDEDKEY = 0x0001;  //Hold the key
        private const byte VK_NUMLOCK = 0x90;
        private const byte VK_CAPSLOCK = 0x14; // Capslock



        //Mouse event listener code
        private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const uint MOUSEEVENTF_LEFTUP = 0x0004;
        private const uint MOUSEEVENTF_RIGHTDOWN = 0X08;
        private const uint MOUSEEVENTF_RIGHTUP = 0x10;
        private const uint MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        private const uint MOUSEEVENTF_MIDDLEUP = 0x0040;
        private const uint MOUSEEVENTF_ABSOLUTE = 0x8000;
        private const uint MOUSEEVENTF_MOVE = 0x0001;

        //Key board event listener
        private const int KEYEVENTF_KEYUP = 0x0002;

        void copy()
        {
            keybd_event(VK_CONTROL, 0, 0, 0);// press ctrl
            keybd_event(0x41, 0, 0, 0); // press a
            keybd_event(0x41, 0, 2, 0); //release a
            keybd_event(0x11, 0, 2, 0); //release ctrl

            keybd_event(VK_CONTROL, 0, 0, 0);// press ctrl
            keybd_event(0x43, 0, 0, 0); // press c
            keybd_event(0x43, 0, 2, 0); //release c
            keybd_event(VK_CONTROL, 0, 2, 0); //release ctrl            
        }

        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(int vKey);
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);
        [DllImport("user32.dll")]
        private static extern int GetKeyboardState(byte[] lpKeyState);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        private static extern short GetKeyState(int keyCode);
        [DllImport("user32.dll")]
        private static extern uint keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        public static void ShowCursor()
        {
            IntPtr hcursor = LoadCursor(IntPtr.Zero, IDC_ARROW);
            bool ret_val = SetSystemCursor(hcursor, OCR_NORMAL);

        }
        public static string getActiveWindow()
        {
            const int nChars = 256;
            IntPtr handle;
            StringBuilder Buff = new StringBuilder(nChars);
            handle = GetForegroundWindow();
            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return "";
        }

        [DllImport("user32.dll")]
        private static extern bool BlockInput(bool block);
        public static void FreezeInputDevices()
        {
            BlockInput(true);
        }
        public static void ThawInputDevices()
        {
            BlockInput(false);
        }

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        [DllImport("user32.dll")]
        static extern IntPtr GetActiveWindow();

        [DllImport("user32.dll")]
        internal static extern IntPtr LoadCursor(IntPtr a, int b);

        [DllImport("user32.dll")]
        public static extern IntPtr LoadCursorFromFile(string lpFileName);

        [DllImport("user32.dll")]
        public static extern bool SetSystemCursor(IntPtr hcur, uint id);

        [DllImport("user32.dll")]
        internal static extern int ShowCursor(bool bShow);

        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, int dwExtraInfo);

        public static void SimulateMouseLeftDown()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
        }
        public static void SimulateMouseLeftUp()
        {
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }
        public static void SimulateMouseRightDown()
        {
            mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
        }
        public static void SimulateMouseRightUp()
        {
            mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
        }
        public static void SimulateMouseMiddleDown()
        {
            mouse_event(MOUSEEVENTF_MIDDLEDOWN, 0, 0, 0, 0);
        }
        public static void SimulateMouseMiddleUp()
        {
            mouse_event(MOUSEEVENTF_MIDDLEUP, 0, 0, 0, 0);
        }

        public static void SimulateKeyDown(Keys key)
        {
            keybd_event((byte)key, 0, VK_KEYDOWN, 0);
            //keybd_event((byte)key, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
          //  keybd_event(VK_MENU, 0, KEYEVENTF_KEYDOWN, 0);

        }

        public static void SimulateKeyUp(Keys key)
        {
            keybd_event((byte)key, 0, KEYEVENTF_KEYUP, 0);
        }
    }
}
