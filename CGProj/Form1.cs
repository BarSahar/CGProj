﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpenGL;
using System.Runtime.InteropServices;

namespace CGProj
{
    public partial class Form1 : Form
    {
        cOGL cGL;

        public Form1()
        {

            InitializeComponent();
            cGL = new cOGL(panel1);
            //apply the bars values as cGL.ScrollValue[..] properties 
            //!!!
            hScrollBarScroll(hScrollBar1, null);
            hScrollBarScroll(hScrollBar2, null);
            hScrollBarScroll(hScrollBar3, null);
            hScrollBarScroll(hScrollBar4, null);
            hScrollBarScroll(hScrollBar5, null);
            hScrollBarScroll(hScrollBar6, null);
            hScrollBarScroll(hScrollBar7, null);
            hScrollBarScroll(hScrollBar8, null);
            hScrollBarScroll(hScrollBar9, null);
            hScrollBarScroll(hScrollBar11, null);
            hScrollBarScroll(hScrollBar12, null);
            hScrollBarScroll(hScrollBar13, null);
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            cGL.Draw();
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            cGL.OnResize();
        }

        public float[] oldPos = new float[7];

        private void numericUpDownValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nUD = (NumericUpDown)sender;
            int i = int.Parse(nUD.Name.Substring(nUD.Name.Length - 1));
            int pos = (int)nUD.Value;
            switch (i)
            {
                case 1:
                    if (pos > oldPos[i - 1])
                    {
                        cGL.xShift += 0.25f;
                        cGL.intOptionC = 4;
                    }
                    else
                    {
                        cGL.xShift -= 0.25f;
                        cGL.intOptionC = -4;
                    }
                    break;
                case 2:
                    if (pos > oldPos[i - 1])
                    {
                        cGL.yShift += 0.25f;
                        cGL.intOptionC = 5;
                    }
                    else
                    {
                        cGL.yShift -= 0.25f;
                        cGL.intOptionC = -5;
                    }
                    break;
                case 3:
                    if (pos > oldPos[i - 1])
                    {
                        cGL.zShift += 0.25f;
                        cGL.intOptionC = 6;
                    }
                    else
                    {
                        cGL.zShift -= 0.25f;
                        cGL.intOptionC = -6;
                    }
                    break;
                case 4:
                    if (pos > oldPos[i - 1])
                    {
                        cGL.xAngle += 5;
                        cGL.intOptionC = 1;
                    }
                    else
                    {
                        cGL.xAngle -= 5;
                        cGL.intOptionC = -1;
                    }
                    break;
                case 5:
                    if (pos > oldPos[i - 1])
                    {
                        cGL.yAngle += 5;
                        cGL.intOptionC = 2;
                    }
                    else
                    {
                        cGL.yAngle -= 5;
                        cGL.intOptionC = -2;
                    }
                    break;
                case 6:
                    if (pos > oldPos[i - 1])
                    {
                        cGL.zAngle += 5;
                        cGL.intOptionC = 3;
                    }
                    else
                    {
                        cGL.zAngle -= 5;
                        cGL.intOptionC = -3;
                    }
                    break;
                case 7: //lid angle!!
                    if (pos > oldPos[i - 1])
                    {
                        if (cGL.mirrorAngle < 100)
                            cGL.mirrorAngle += 5;
                    }
                    else if (cGL.mirrorAngle > 10)
                    {
                        cGL.mirrorAngle -= 5;
                    }
                    cGL.updateShadowPlanes();
                    break;
            }
            cGL.Draw();
            oldPos[i - 1] = pos;

        }

        private void hScrollBarScroll(object sender, ScrollEventArgs e)
        {
            cGL.intOptionC = 0;
            HScrollBar hb = (HScrollBar)sender;
            int n = int.Parse(hb.Name.Substring(10));
            if (n > 10) {
                //lighting
                if (n == 13) //Z axis
                    cGL.ScrollValue[n - 1] = (hb.Value - 50) / 10.0f +5f;
                else
                    cGL.ScrollValue[n - 1] = (hb.Value - 100) / 10.0f;
            }
            else
                cGL.ScrollValue[n - 1] = (hb.Value - 100) / 10.0f;

            if (e != null)
                cGL.Draw();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cGL.intOptionC = 0;
            cGL.intOptionB += 2;    //dancer rotation
            cGL.sin_index++;
            cGL.Draw();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
        }
        bool swap = true;
        private void button1_Click(object sender, EventArgs e)
        {
            if (swap)
            {                
                Random rnd = new Random();
                cGL.textureOffset = rnd.Next(1, 15);   
            }
            else
                cGL.textureOffset = 0;

            swap = !swap;
            cGL.Draw();
        }
    }
}