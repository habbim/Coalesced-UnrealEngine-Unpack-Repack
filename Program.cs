// Decompiled with JetBrains decompiler
// Type: Coalesced.Program
// Assembly: Coalesced, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 301B067E-34A2-4596-BB13-30F8D7D3679D
// Assembly location: E:\Userdata\Descargas\Coalesced_UnPacker.exe

using System;
using System.Windows.Forms;

namespace Coalesced
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new Form1());
    }
  }
}
