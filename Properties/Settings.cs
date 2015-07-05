// Decompiled with JetBrains decompiler
// Type: Coalesced.Properties.Settings
// Assembly: Coalesced, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 301B067E-34A2-4596-BB13-30F8D7D3679D
// Assembly location: E:\Userdata\Descargas\Coalesced_UnPacker.exe

using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace Coalesced.Properties
{
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
  [CompilerGenerated]
  internal sealed class Settings : ApplicationSettingsBase
  {
    private static Settings defaultInstance = (Settings) SettingsBase.Synchronized((SettingsBase) new Settings());

    public static Settings Default
    {
      get
      {
        return Settings.defaultInstance;
      }
    }
  }
}
