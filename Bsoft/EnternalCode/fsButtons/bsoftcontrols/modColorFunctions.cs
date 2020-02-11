namespace bsoftcontrols
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Diagnostics;
    using System.Drawing;

    [StandardModule]
    internal sealed class modColorFunctions
    {
        public static Color cHSB(float hue, float saturation, float brightness)
        {
            float num5;
            if (hue < 0f)
            {
                hue = 0f;
            }
            if (hue > 359f)
            {
                hue -= 360f;
            }
            if (saturation < 0f)
            {
                saturation = 0f;
            }
            if (saturation > 1f)
            {
                saturation = 1f;
            }
            if (brightness < 0f)
            {
                brightness = 0f;
            }
            if (brightness > 1f)
            {
                brightness = 1f;
            }
            Debug.Write("\r\n" + Conversions.ToString(hue) + ", " + Conversions.ToString(saturation) + ", " + Conversions.ToString(brightness));
            if (saturation == 0f)
            {
                return cRGB((int) Math.Round((double) (brightness * 255f)), (int) Math.Round((double) (brightness * 255f)), (int) Math.Round((double) (brightness * 255f)));
            }
            if (brightness < 0.5)
            {
                num5 = brightness * (1f + saturation);
            }
            else
            {
                num5 = (brightness + saturation) - (brightness * saturation);
            }
            float num4 = (2f * brightness) - num5;
            float vH = hue / 360f;
            Debug.Write("\r\n" + Conversions.ToString(num4) + ", " + Conversions.ToString(num5));
            Debug.Write("\r\n" + Conversions.ToString(Hue2RGB(num4, num5, hue + ((float) 0.33333333333333331))) + ", " + Conversions.ToString(Hue2RGB(num4, num5, hue)) + ", " + Conversions.ToString(Hue2RGB(num4, num5, hue - ((float) 0.33333333333333331))));
            int r = (int) Math.Round((double) (255f * Hue2RGB(num4, num5, vH + ((float) 0.33333333333333331))));
            int g = (int) Math.Round((double) (255f * Hue2RGB(num4, num5, vH)));
            int b = (int) Math.Round((double) (255f * Hue2RGB(num4, num5, vH - ((float) 0.33333333333333331))));
            return cRGB(r, g, b);
        }

        public static Color cRGB(int r, int g, int b)
        {
            if (r > 0xff)
            {
                r = 0xff;
            }
            if (r < 0)
            {
                r = 0;
            }
            if (g > 0xff)
            {
                g = 0xff;
            }
            if (g < 0)
            {
                g = 0;
            }
            if (b > 0xff)
            {
                b = 0xff;
            }
            if (b < 0)
            {
                b = 0;
            }
            return ColorTranslator.FromWin32(Information.RGB(r, g, b));
        }

        private static float Hue2RGB(float v1, float v2, float vH)
        {
            if (vH < 0f)
            {
                vH++;
            }
            if (vH > 1f)
            {
                vH--;
            }
            if ((6f * vH) < 1f)
            {
                return (v1 + (((v2 - v1) * 6f) * vH));
            }
            if ((2f * vH) < 1f)
            {
                return v2;
            }
            if ((3f * vH) < 2f)
            {
                return (v1 + ((float) (((v2 - v1) * (0.66666666666666663 - vH)) * 6.0)));
            }
            return v1;
        }

        public static Color InvertColor(Color c)
        {
            int r = c.R;
            int g = c.G;
            int b = c.B;
            int num6 = 0xff - r;
            int num4 = 0xff - g;
            int num2 = 0xff - b;
            return cRGB(num6, num4, num2);
        }

        public static Color MultiplyMix(Color BaseColor, Color BlendColor, int Opacity)
        {
            int r = BaseColor.R;
            int g = BaseColor.G;
            int b = BaseColor.B;
            int num8 = BlendColor.R;
            int num5 = BlendColor.G;
            int num2 = BlendColor.B;
            int num9 = (int) Math.Round((double) (((double) (r * num8)) / 255.0));
            int num6 = (int) Math.Round((double) (((double) (g * num5)) / 255.0));
            int num3 = (int) Math.Round((double) (((double) (b * num2)) / 255.0));
            return OpacityMix(cRGB(num9, num6, num3), BaseColor, Opacity);
        }

        public static Color OpacityMix(Color BlendColor, Color BaseColor, int Opacity)
        {
            int r = BlendColor.R;
            int g = BlendColor.G;
            int b = BlendColor.B;
            int num8 = BaseColor.R;
            int num5 = BaseColor.G;
            int num2 = BaseColor.B;
            int num9 = (int) Math.Round((double) ((r * (((double) Opacity) / 100.0)) + (num8 * (1.0 - (((double) Opacity) / 100.0)))));
            int num6 = (int) Math.Round((double) ((g * (((double) Opacity) / 100.0)) + (num5 * (1.0 - (((double) Opacity) / 100.0)))));
            int num3 = (int) Math.Round((double) ((b * (((double) Opacity) / 100.0)) + (num2 * (1.0 - (((double) Opacity) / 100.0)))));
            return cRGB(num9, num6, num3);
        }

        public static int OverlayMath(int @base, int blend)
        {
            double num = ((double) @base) / 255.0;
            double num2 = ((double) blend) / 255.0;
            if (num < 0.5)
            {
                return (int) Math.Round((double) (((2.0 * num) * num2) * 255.0));
            }
            return (int) Math.Round((double) ((1.0 - ((2.0 * (1.0 - num)) * (1.0 - num2))) * 255.0));
        }

        public static Color OverlayMix(Color BaseColor, Color BlendColor, int opacity)
        {
            int r = BaseColor.R;
            int g = BaseColor.G;
            int b = BaseColor.B;
            int num8 = BlendColor.R;
            int num5 = BlendColor.G;
            int num2 = BlendColor.B;
            int num9 = OverlayMath(BaseColor.R, BlendColor.R);
            int num6 = OverlayMath(BaseColor.G, BlendColor.G);
            int num3 = OverlayMath(BaseColor.B, BlendColor.B);
            return OpacityMix(cRGB(num9, num6, num3), BaseColor, opacity);
        }

        private static Color ScreenMix(Color BaseColor, Color BlendColor, int Opacity)
        {
            int r = BaseColor.R;
            int g = BaseColor.G;
            int b = BaseColor.B;
            int num8 = BlendColor.R;
            int num5 = BlendColor.G;
            int num2 = BlendColor.B;
            int num9 = (int) Math.Round((double) ((1.0 - ((1.0 - (((double) r) / 255.0)) * (1.0 - (((double) num8) / 255.0)))) * 255.0));
            int num6 = (int) Math.Round((double) ((1.0 - ((1.0 - (((double) g) / 255.0)) * (1.0 - (((double) num5) / 255.0)))) * 255.0));
            int num3 = (int) Math.Round((double) ((1.0 - ((1.0 - (((double) b) / 255.0)) * (1.0 - (((double) num2) / 255.0)))) * 255.0));
            return OpacityMix(cRGB(num9, num6, num3), BaseColor, Opacity);
        }

        private static int SoftLightMath(int @base, int blend)
        {
            float num = (float) (((double) @base) / 255.0);
            float num2 = (float) (((double) blend) / 255.0);
            if (num2 < 0.5)
            {
                return (int) Math.Round((double) ((((2f * num) * num2) + (Math.Pow((double) num, 2.0) * (1f - (2f * num2)))) * 255.0));
            }
            return (int) Math.Round((double) (((Math.Sqrt((double) num) * ((2f * num2) - 1f)) + ((2f * num) * (1f - num2))) * 255.0));
        }

        public static Color SoftLightMix(Color BaseColor, Color BlendColor, int Opacity)
        {
            int r = BaseColor.R;
            int g = BaseColor.G;
            int b = BaseColor.B;
            int blend = BlendColor.R;
            int num5 = BlendColor.G;
            int num2 = BlendColor.B;
            int num9 = SoftLightMath(r, blend);
            int num6 = SoftLightMath(g, num5);
            int num3 = SoftLightMath(b, num2);
            return OpacityMix(cRGB(num9, num6, num3), BaseColor, Opacity);
        }
    }
}

