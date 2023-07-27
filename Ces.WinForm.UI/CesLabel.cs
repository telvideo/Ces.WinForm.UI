﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ces.WinForm.UI
{
    public partial class CesLabel : UserControl
    {
        public CesLabel()
        {
            InitializeComponent();
        }


        private CesLabelRotationDegreeEnum cesDegree { get; set; }
            = CesLabelRotationDegreeEnum.Rotate0;
        [System.ComponentModel.Category("CesLabel")]
        [System.ComponentModel.Description("CesLabel can show string value in vertical direction.")]
        public CesLabelRotationDegreeEnum CesDegree
        {
            get { return cesDegree; }
            set
            {
                cesDegree = value;
                Redraw();
            }
        }


        private string cesText { get; set; }
        [System.ComponentModel.Category("CesLabel")]
        [System.ComponentModel.Description("CesLabel can show string value in vertical direction.")]
        public string CesText
        {
            get { return cesText; }
            set
            {
                cesText = value;
                Redraw();
            }
        }


        private System.Drawing.ContentAlignment cesTextAlignment { get; set; }
            = ContentAlignment.MiddleCenter;
        [System.ComponentModel.Category("CesLabel")]
        public System.Drawing.ContentAlignment CesTextAlignment
        {
            get { return cesTextAlignment; }
            set
            {
                cesTextAlignment = value;
                Redraw();
            }
        }



        // Methods


        private void Redraw()
        {
            System.Drawing.Graphics g = this.CreateGraphics();
            using System.Drawing.SolidBrush brush = new SolidBrush(this.ForeColor);
            var textSize = g.MeasureString(cesText, this.Font);
            var rectangle = new RectangleF(0, 0, textSize.Width, textSize.Height);
            float offsetX = 0;
            float offsetY = 0;

            // Set X,Y Offset for TranslateTransform

            if (cesDegree == CesLabelRotationDegreeEnum.Rotate0)
            {
                switch (cesTextAlignment)
                {
                    case ContentAlignment.TopLeft:
                        offsetX = 0;
                        offsetY = 0;
                        break;
                    case ContentAlignment.TopCenter:
                        offsetX = this.Width / 2 - textSize.Width / 2;
                        offsetY = 0;
                        break;
                    case ContentAlignment.TopRight:
                        offsetX = this.Width - textSize.Width;
                        offsetY = 0;
                        break;
                    case ContentAlignment.MiddleLeft:
                        offsetX = 0;
                        offsetY = this.Height / 2 - textSize.Height / 2;
                        break;
                    case ContentAlignment.MiddleCenter:
                        offsetX = this.Width / 2 - textSize.Width / 2;
                        offsetY = this.Height / 2 - textSize.Height / 2;
                        break;
                    case ContentAlignment.MiddleRight:
                        offsetX = this.Width - textSize.Width;
                        offsetY = this.Height / 2 - textSize.Height / 2;
                        break;
                    case ContentAlignment.BottomLeft:
                        offsetX = 0;
                        offsetY = this.Height - textSize.Height;
                        break;
                    case ContentAlignment.BottomCenter:
                        offsetX = this.Width / 2 - textSize.Width / 2;
                        offsetY = this.Height - textSize.Height;
                        break;
                    case ContentAlignment.BottomRight:
                        offsetX = this.Width - textSize.Width;
                        offsetY = this.Height - textSize.Height;
                        break;
                }
            }

            if (cesDegree == CesLabelRotationDegreeEnum.Rotate90)
            {
                switch (cesTextAlignment)
                {
                    case ContentAlignment.TopLeft:
                        offsetX = 0;
                        offsetY = -textSize.Height;
                        break;
                    case ContentAlignment.TopCenter:
                        offsetX = 0;
                        offsetY = -(this.Width / 2 + textSize.Height / 2);
                        break;
                    case ContentAlignment.TopRight:
                        offsetX = 0;
                        offsetY = -this.Width;
                        break;
                    case ContentAlignment.MiddleLeft:
                        offsetX = this.Height / 2 - textSize.Width / 2;
                        offsetY = -textSize.Height;
                        break;
                    case ContentAlignment.MiddleCenter:
                        offsetX = this.Height / 2 - textSize.Width / 2;
                        offsetY = -(this.Width / 2 + textSize.Height / 2);
                        break;
                    case ContentAlignment.MiddleRight:
                        offsetX = this.Height / 2 - textSize.Width / 2;
                        offsetY = -this.Width;
                        break;
                    case ContentAlignment.BottomLeft:
                        offsetX = this.Height - textSize.Width;
                        offsetY = -textSize.Height;
                        break;
                    case ContentAlignment.BottomCenter:
                        offsetX = this.Height - textSize.Width;
                        offsetY = -(this.Width / 2 + textSize.Height / 2);
                        break;
                    case ContentAlignment.BottomRight:
                        offsetX = this.Height - textSize.Width;
                        offsetY = -this.Width;
                        break;
                }
            }

            if (cesDegree == CesLabelRotationDegreeEnum.Rotate180)
            {
                switch (cesTextAlignment)
                {
                    case ContentAlignment.TopLeft:
                        offsetX = -textSize.Width;
                        offsetY = -textSize.Height;
                        break;
                    case ContentAlignment.TopCenter:
                        offsetX = -(this.Width / 2 + textSize.Width / 2);
                        offsetY = -textSize.Height;
                        break;
                    case ContentAlignment.TopRight:
                        offsetX = -this.Width;
                        offsetY = -textSize.Height;
                        break;
                    case ContentAlignment.MiddleLeft:
                        offsetX = -textSize.Width;
                        offsetY = -(this.Height / 2 + textSize.Height / 2);
                        break;
                    case ContentAlignment.MiddleCenter:
                        offsetX = -(this.Width / 2 + textSize.Width / 2);
                        offsetY = -(this.Height / 2 + textSize.Height / 2);
                        break;
                    case ContentAlignment.MiddleRight:
                        offsetX = -this.Width;
                        offsetY = -(this.Height / 2 + textSize.Height / 2);
                        break;
                    case ContentAlignment.BottomLeft:
                        offsetX = -textSize.Width;
                        offsetY = -this.Height;
                        break;
                    case ContentAlignment.BottomCenter:
                        offsetX = -(this.Width / 2 + textSize.Width / 2);
                        offsetY = -this.Height;
                        break;
                    case ContentAlignment.BottomRight:
                        offsetX = -this.Width;
                        offsetY = -this.Height;
                        break;
                }
            }

            if (cesDegree == CesLabelRotationDegreeEnum.Rotate270)
            {
                switch (cesTextAlignment)
                {
                    case ContentAlignment.TopLeft:
                        offsetX = -textSize.Width;
                        offsetY = 0;
                        break;
                    case ContentAlignment.TopCenter:
                        offsetX = -textSize.Width;
                        offsetY = this.Width / 2 - textSize.Height / 2;
                        break;
                    case ContentAlignment.TopRight:
                        offsetX = -textSize.Width;
                        offsetY = this.Width - textSize.Width;
                        break;
                    case ContentAlignment.MiddleLeft:
                        offsetX = -(this.Height / 2 + textSize.Width / 2);
                        offsetY = 0;
                        break;
                    case ContentAlignment.MiddleCenter:
                        offsetX = -(this.Height / 2 + textSize.Width / 2);
                        offsetY = this.Width / 2 - textSize.Height / 2;
                        break;
                    case ContentAlignment.MiddleRight:
                        offsetX = -(this.Height / 2 + textSize.Width / 2);
                        offsetY = this.Width - textSize.Width;
                        break;
                    case ContentAlignment.BottomLeft:
                        offsetX = -this.Height;
                        offsetY = 0;
                        break;
                    case ContentAlignment.BottomCenter:
                        offsetX = -this.Height;
                        offsetY = this.Width / 2 - textSize.Height / 2;
                        break;
                    case ContentAlignment.BottomRight:
                        offsetX = -this.Height;
                        offsetY = this.Width - textSize.Height;
                        break;
                }
            }

            g.Clear(this.BackColor);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.RotateTransform((float)cesDegree);
            g.TranslateTransform(offsetX, offsetY);
            g.DrawString(cesText, this.Font, brush, rectangle);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Redraw();
        }
    }

    public enum CesLabelRotationDegreeEnum
    {
        Rotate0 = 0,
        Rotate90 = 90,
        Rotate180 = 180,
        Rotate270 = 270,
    }
}