// Decompiled with JetBrains decompiler
// Type: Coalesced.Form1
// Assembly: Coalesced, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 301B067E-34A2-4596-BB13-30F8D7D3679D
// Assembly location: E:\Userdata\Descargas\Coalesced_UnPacker.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Coalesced
{
  public class Form1 : Form
  {
    private IContainer components;
    private Button open;
    private OpenFileDialog openFileDialog1;
    private StatusStrip statusStrip1;
    private Button makeout;
    private ToolStripStatusLabel toolStripStatusLabel1;
    private Button rebuild;
    private ToolStripProgressBar toolStripProgressBar1;
    private ToolStripStatusLabel about;
    private string dir;
    private string fname;
    private string fullpath;
    private short files;
    private short nmlen;
    private short secCount;
    private short recCount;
    private int valueLength;

    public Form1()
    {
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.open = new Button();
      this.openFileDialog1 = new OpenFileDialog();
      this.statusStrip1 = new StatusStrip();
      this.toolStripStatusLabel1 = new ToolStripStatusLabel();
      this.makeout = new Button();
      this.rebuild = new Button();
      this.toolStripProgressBar1 = new ToolStripProgressBar();
      this.about = new ToolStripStatusLabel();
      this.statusStrip1.SuspendLayout();
      this.SuspendLayout();
      this.open.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.open.Location = new Point(12, 12);
      this.open.Name = "open";
      this.open.Size = new Size(212, 35);
      this.open.TabIndex = 0;
      this.open.Text = "Open Coalesced_.bin";
      this.open.UseVisualStyleBackColor = true;
      this.open.Click += new EventHandler(this.open_Click);
      this.openFileDialog1.DefaultExt = "*.bin";
      this.openFileDialog1.FileName = "Coalesced_INT";
      this.statusStrip1.Items.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.toolStripStatusLabel1,
        (ToolStripItem) this.toolStripProgressBar1,
        (ToolStripItem) this.about
      });
      this.statusStrip1.Location = new Point(0, 113);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new Size(237, 22);
      this.statusStrip1.SizingGrip = false;
      this.statusStrip1.TabIndex = 1;
      this.statusStrip1.Text = "Tool";
      this.toolStripStatusLabel1.AutoSize = false;
      this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
      this.toolStripStatusLabel1.Size = new Size(65, 17);
      this.toolStripStatusLabel1.Text = "Files: 0";
      this.toolStripStatusLabel1.TextAlign = ContentAlignment.MiddleLeft;
      this.makeout.Enabled = false;
      this.makeout.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.makeout.Location = new Point(12, 53);
      this.makeout.Name = "makeout";
      this.makeout.Size = new Size(103, 44);
      this.makeout.TabIndex = 2;
      this.makeout.Text = "Make out";
      this.makeout.UseVisualStyleBackColor = true;
      this.makeout.Click += new EventHandler(this.makeout_Click);
      this.rebuild.Enabled = false;
      this.rebuild.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.rebuild.Location = new Point(121, 53);
      this.rebuild.Name = "rebuild";
      this.rebuild.Size = new Size(103, 44);
      this.rebuild.TabIndex = 3;
      this.rebuild.Text = "Rebuild";
      this.rebuild.UseVisualStyleBackColor = true;
      this.rebuild.Click += new EventHandler(this.rebuild_Click);
      this.toolStripProgressBar1.Margin = new Padding(1, 3, 8, 3);
      this.toolStripProgressBar1.Name = "toolStripProgressBar1";
      this.toolStripProgressBar1.Size = new Size(110, 16);
      this.toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
      this.about.IsLink = true;
      this.about.LinkBehavior = LinkBehavior.HoverUnderline;
      this.about.Name = "about";
      this.about.Size = new Size(48, 17);
      this.about.Text = "(c) 2013";
      this.about.TextAlign = ContentAlignment.MiddleRight;
      this.about.Click += new EventHandler(this.about_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(237, 135);
      this.Controls.Add((Control) this.rebuild);
      this.Controls.Add((Control) this.makeout);
      this.Controls.Add((Control) this.statusStrip1);
      this.Controls.Add((Control) this.open);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.MaximizeBox = false;
      this.Name = "Form1";
      this.ShowIcon = false;
      this.Text = "Coalesced Tool";
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void depack()
    {
      using (BinaryReader binaryReader = new BinaryReader((Stream) File.OpenRead(this.fname), Encoding.ASCII))
      {
        this.files = BitConverter.ToInt16(Enumerable.ToArray<byte>(Enumerable.Reverse<byte>((IEnumerable<byte>) binaryReader.ReadBytes(4))), 0);
        Directory.CreateDirectory(this.dir);
        for (short index1 = (short) 0; (int) index1 < (int) this.files; ++index1)
        {
          this.nmlen = (short) (((int) -BitConverter.ToInt16(Enumerable.ToArray<byte>(Enumerable.Reverse<byte>((IEnumerable<byte>) binaryReader.ReadBytes(4))), 0) - 1) * 2);
          if ((int) this.nmlen < 2)
          {
            int num = (int) MessageBox.Show("File name error. " + binaryReader.BaseStream.Position.ToString());
            Environment.Exit(0);
          }
          this.fullpath = Encoding.Unicode.GetString(binaryReader.ReadBytes((int) this.nmlen));
          binaryReader.BaseStream.Seek(2L, SeekOrigin.Current);
          this.secCount = BitConverter.ToInt16(Enumerable.ToArray<byte>(Enumerable.Reverse<byte>((IEnumerable<byte>) binaryReader.ReadBytes(4))), 0);
          if ((int) this.nmlen > 0)
          {
            Directory.CreateDirectory(this.dir + Path.GetDirectoryName(this.fullpath.Replace("..\\..\\", "")));
            using (BinaryWriter binaryWriter = new BinaryWriter((Stream) File.Create(this.dir + this.fullpath.Replace("..\\..\\", "")), Encoding.Unicode))
            {
              for (short index2 = (short) 0; (int) index2 < (int) this.secCount; ++index2)
              {
                this.nmlen = (short) (((int) -BitConverter.ToInt16(Enumerable.ToArray<byte>(Enumerable.Reverse<byte>((IEnumerable<byte>) binaryReader.ReadBytes(4))), 0) - 1) * 2);
                if ((int) this.nmlen < 2)
                {
                  int num = (int) MessageBox.Show("Section name error. " + binaryReader.BaseStream.Position.ToString());
                  Environment.Exit(0);
                }
                binaryWriter.Write('[');
                binaryWriter.Write(binaryReader.ReadBytes((int) this.nmlen));
                binaryWriter.Write(']');
                binaryWriter.Write(655373);
                binaryReader.BaseStream.Seek(2L, SeekOrigin.Current);
                this.recCount = BitConverter.ToInt16(Enumerable.ToArray<byte>(Enumerable.Reverse<byte>((IEnumerable<byte>) binaryReader.ReadBytes(4))), 0);
                if ((int) this.recCount > 0)
                {
                  for (short index3 = (short) 0; (int) index3 < (int) this.recCount; ++index3)
                  {
                    this.nmlen = (short) (((int) -BitConverter.ToInt16(Enumerable.ToArray<byte>(Enumerable.Reverse<byte>((IEnumerable<byte>) binaryReader.ReadBytes(4))), 0) - 1) * 2);
                    if ((int) this.nmlen < 2)
                    {
                      int num = (int) MessageBox.Show("Value name error. " + binaryReader.BaseStream.Position.ToString());
                      Environment.Exit(0);
                    }
                    binaryWriter.Write(binaryReader.ReadBytes((int) this.nmlen));
                    binaryReader.BaseStream.Seek(2L, SeekOrigin.Current);
                    binaryWriter.Write('=');
                    this.valueLength = (int) -BitConverter.ToInt16(Enumerable.ToArray<byte>(Enumerable.Reverse<byte>((IEnumerable<byte>) binaryReader.ReadBytes(4))), 0) - 1;
                    if (this.valueLength > 0)
                    {
                      for (short index4 = (short) 0; (int) index4 < this.valueLength; ++index4)
                      {
                        short num = binaryReader.ReadInt16();
                        if ((int) num != 10)
                          binaryWriter.Write(num);
                        else
                          binaryWriter.Write('¶');
                      }
                      binaryReader.BaseStream.Seek(2L, SeekOrigin.Current);
                    }
                    if ((int) index3 != (int) this.recCount - 1)
                      binaryWriter.Write(655373);
                  }
                  if ((int) index2 != (int) this.secCount - 1)
                    binaryWriter.Write(655373);
                }
                if ((int) index2 != (int) this.secCount - 1)
                  binaryWriter.Write(655373);
              }
            }
          }
          this.toolStripProgressBar1.PerformStep();
        }
      }
    }

    private void repack()
    {
      using (BinaryReader binaryReader = new BinaryReader((Stream) File.OpenRead(this.fname)))
      {
        using (BinaryWriter binaryWriter = new BinaryWriter((Stream) File.Create(this.dir + Path.GetFileName(this.fname)), Encoding.Unicode))
        {
          byte[] numArray = new byte[4];
          byte[] buffer1 = binaryReader.ReadBytes(4);
          this.files = BitConverter.ToInt16(Enumerable.ToArray<byte>(Enumerable.Reverse<byte>((IEnumerable<byte>) buffer1)), 0);
          binaryWriter.Write(buffer1);
          for (short index1 = (short) 0; (int) index1 < (int) this.files; ++index1)
          {
            byte[] buffer2 = binaryReader.ReadBytes(4);
            this.nmlen = (short) (((int) -BitConverter.ToInt16(Enumerable.ToArray<byte>(Enumerable.Reverse<byte>((IEnumerable<byte>) buffer2)), 0) - 1) * 2);
            binaryWriter.Write(buffer2);
            this.fullpath = Encoding.Unicode.GetString(binaryReader.ReadBytes((int) this.nmlen));
            binaryReader.BaseStream.Seek(2L, SeekOrigin.Current);
            byte[] buffer3 = binaryReader.ReadBytes(4);
            this.secCount = BitConverter.ToInt16(Enumerable.ToArray<byte>(Enumerable.Reverse<byte>((IEnumerable<byte>) buffer3)), 0);
            if ((int) this.nmlen > 0)
            {
              using (StreamReader streamReader = new StreamReader((Stream) File.OpenRead(this.dir + this.fullpath.Replace("..\\..\\", "")), Encoding.Unicode))
              {
                binaryWriter.Write(Encoding.Unicode.GetBytes(this.fullpath));
                binaryWriter.Write((short) 0);
                binaryWriter.Write(buffer3);
                for (short index2 = (short) 0; (int) index2 < (int) this.secCount; ++index2)
                {
                  streamReader.ReadLine();
                  byte[] buffer4 = binaryReader.ReadBytes(4);
                  this.nmlen = (short) (((int) -BitConverter.ToInt16(Enumerable.ToArray<byte>(Enumerable.Reverse<byte>((IEnumerable<byte>) buffer4)), 0) - 1) * 2);
                  binaryWriter.Write(buffer4);
                  binaryWriter.Write(binaryReader.ReadBytes((int) this.nmlen + 2));
                  byte[] buffer5 = binaryReader.ReadBytes(4);
                  binaryWriter.Write(buffer5);
                  this.recCount = BitConverter.ToInt16(Enumerable.ToArray<byte>(Enumerable.Reverse<byte>((IEnumerable<byte>) buffer5)), 0);
                  if ((int) this.recCount > 0)
                  {
                    for (short index3 = (short) 0; (int) index3 < (int) this.recCount; ++index3)
                    {

                      byte[] buffer6 = binaryReader.ReadBytes(4);
                      this.nmlen = (short) (((int) -BitConverter.ToInt16(Enumerable.ToArray<byte>(Enumerable.Reverse<byte>((IEnumerable<byte>) buffer6)), 0) - 1) * 2);
                      binaryWriter.Write(buffer6);
                      binaryWriter.Write(binaryReader.ReadBytes((int) this.nmlen + 2));
                      this.valueLength = ((int) -BitConverter.ToInt16(Enumerable.ToArray<byte>(Enumerable.Reverse<byte>((IEnumerable<byte>) binaryReader.ReadBytes(4))), 0) - 1) * 2;
                      string str = streamReader.ReadLine();
                      if (this.valueLength > 0 && !String.IsNullOrEmpty(str))
                          {
                              char[] chArray = str.Substring(str.IndexOf('=') + 1).ToCharArray();
                              binaryWriter.Write(Enumerable.ToArray<byte>(Enumerable.Reverse<byte>((IEnumerable<byte>)BitConverter.GetBytes(-(chArray.Length + 1)))));
                              foreach (char ch in chArray)
                              {
                                  if ((int)ch != 182)
                                      binaryWriter.Write(ch);
                                  else
                                      binaryWriter.Write((short)10);
                              }
                              binaryWriter.Write((short)0);
                              binaryReader.BaseStream.Seek((long)(this.valueLength + 2), SeekOrigin.Current);
                          }
                          else
                              binaryWriter.Write(0);

                    }
                  }
                  streamReader.ReadLine();
                }
              }
            }
            this.toolStripProgressBar1.PerformStep();
          }
        }
      }
    }

    private string filesum(string file)
    {
      using (BinaryReader binaryReader = new BinaryReader((Stream) File.OpenRead(file)))
      {
        try
        {
          this.files = BitConverter.ToInt16(Enumerable.ToArray<byte>(Enumerable.Reverse<byte>((IEnumerable<byte>) binaryReader.ReadBytes(4))), 0);
          this.nmlen = (short) (((int) -BitConverter.ToInt16(Enumerable.ToArray<byte>(Enumerable.Reverse<byte>((IEnumerable<byte>) binaryReader.ReadBytes(4))), 0) - 1) * 2);
          this.fullpath = Encoding.Unicode.GetString(binaryReader.ReadBytes((int) this.nmlen));
        }
        catch
        {
          this.files = (short) 0;
        }
        if ((int) this.files == 0 || (int) this.files > 1000)
        {
          int num = (int) MessageBox.Show("Probably not a Coalesced file.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          this.makeout.Enabled = false;
          this.rebuild.Enabled = false;
          this.files = (short) 0;
        }
        else
        {
          this.makeout.Enabled = true;
          this.rebuild.Enabled = true;
          this.toolStripProgressBar1.Maximum = (int) this.files;
          this.toolStripProgressBar1.Step = 1;
        }
        return this.files.ToString();
      }
    }

    private void open_Click(object sender, EventArgs e)
    {
      if (this.openFileDialog1.ShowDialog() != DialogResult.OK)
        return;
      this.fname = this.openFileDialog1.FileName;
      this.dir = Path.GetDirectoryName(this.fname) + "\\" + Path.GetFileNameWithoutExtension(this.fname) + "\\";
      this.toolStripStatusLabel1.Text = "Files: " + this.filesum(this.fname);
    }

    private void makeout_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Make it out in the bin source\\" + Path.GetFileNameWithoutExtension(this.fname) + "\\", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.OK)
        return;
      this.toolStripProgressBar1.Value = 0;
      this.depack();
    }

    private void about_Click(object sender, EventArgs e)
    {
      int num = (int) MessageBox.Show("Developed by Gocha (hello XeNTaX)\nSpecial for Trap [nighttrap3d0]\n\nTool developed and tested on Coalesced_xxx.bin files \nfrom Xbox360 games - Borderlands 2, Aliens: CM.\nShould work for all Xbox360, PS3 games as well.\n\n(c) 2013 GamesZone.GE | gochamax@gmail.com");
    }

    private void rebuild_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("New bin will be made in \\" + Path.GetFileNameWithoutExtension(this.fname) + "\\", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.OK)
        return;
      this.toolStripProgressBar1.Value = 0;
      this.repack();
    }
  }
}
