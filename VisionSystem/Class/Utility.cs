/*
 * @file Utility.cs
 *
 * Copyright (c) 2019 KEYENCE CORPORATION.
 * All rights reserved.
 *
 */

using System;
using System.Runtime.InteropServices;
using System.Windows.Media;
using System.Windows.Media.Imaging;

internal class Utility
{

    public WriteableBitmap CreateBitmap(CameraControl camera, string IPAddress)
    {
        string pixelFormat = (string)camera.GetFeatureValue(IPAddress, "PixelFormat");
        int width = (int)(long)camera.GetFeatureValue(IPAddress, "Width");
        int height = (int)(long)camera.GetFeatureValue(IPAddress, "Height");

        WriteableBitmap bmp = null;
        int stride;
        int bytelength;
        byte[] buffer;
        switch (pixelFormat)
        {
            case "Mono8":
                stride = width * 8 / 8;
                bytelength = stride * height;
                buffer = new byte[bytelength];
                bmp = new WriteableBitmap(WriteableBitmap.Create(width, height, 96, 96, PixelFormats.Gray8, BitmapPalettes.Gray256, buffer, stride));
                break;
            case "Mono16":
                stride = width * 16 / 8;
                bytelength = stride * height;
                buffer = new byte[bytelength];
                bmp = new WriteableBitmap(WriteableBitmap.Create(width, height, 96, 96, PixelFormats.Gray16, BitmapPalettes.Gray256, buffer, stride));
                break;
            case "BGR8Packed":
                stride = width * 24 / 8;
                bytelength = stride * height;
                buffer = new byte[bytelength];
                bmp = new WriteableBitmap(WriteableBitmap.Create(width, height, 96, 96, PixelFormats.Bgr24, null, buffer, stride));
                break;
            case "RGB8Packed":
                stride = width * 24 / 8;
                bytelength = stride * height;
                buffer = new byte[bytelength];
                bmp = new WriteableBitmap(WriteableBitmap.Create(width, height, 96, 96, PixelFormats.Rgb24, null, buffer, stride));
                break;
            case "BGRA8Packed":
                stride = width * 32 / 8;
                bytelength = stride * height;
                buffer = new byte[bytelength];
                bmp = new WriteableBitmap(WriteableBitmap.Create(width, height, 96, 96, PixelFormats.Bgr32, null, buffer, stride));
                break;
            case "RGBA8Packed":
                stride = width * 32 / 8;
                bytelength = stride * height;
                buffer = new byte[bytelength];
                bmp = new WriteableBitmap(WriteableBitmap.Create(width, height, 96, 96, PixelFormats.Bgr32, null, buffer, stride));
                break;
            default:
                break;
        }
        return bmp;
    }

    public void ConvertRGBA8toBGRA8(IntPtr buffer, int pixelSize)
    {
        unsafe
        {
            byte dataR;
            byte dataB;

            for (int i = 0; i < pixelSize; i++)
            {
                dataR = *((byte*)(buffer) + (i * 4));
                dataB = *((byte*)(buffer) + (i * 4) + 2);

                *((byte*)(buffer) + (i * 4)) = dataB;
                *((byte*)(buffer) + (i * 4) + 2) = dataR;
            }
        }
    }

    public WriteableBitmap CreateHeatmap(CameraControl Camera, string IPAddress, WriteableBitmap bmp)
    {
        byte[,] aHeightColorTable =
        {
	            // RAINBOW1
                { 255, 0, 0 },
                { 255, 4, 0 },
                { 255, 8, 0 },
                { 255, 12, 0 },
                { 255, 16, 0 },
                { 255, 20, 0 },
                { 255, 24, 0 },
                { 255, 28, 0 },
                { 255, 32, 0 },
                { 255, 36, 0 },
                { 255, 40, 0 },
                { 255, 44, 0 },
                { 255, 48, 0 },
                { 255, 52, 0 },
                { 255, 56, 0 },
                { 255, 59, 0 },
                { 255, 62, 0 },
                { 255, 65, 0 },
                { 255, 68, 0 },
                { 255, 70, 0 },
                { 255, 72, 0 },
                { 255, 74, 0 },
                { 255, 76, 0 },
                { 255, 78, 0 },
                { 255, 80, 0 },
                { 255, 82, 0 },
                { 255, 84, 0 },
                { 255, 86, 0 },
                { 255, 88, 0 },
                { 255, 90, 0 },
                { 255, 92, 0 },
                { 255, 94, 0 },
                { 255, 96, 0 },
                { 255, 98, 0 },
                { 255, 100, 0 },
                { 255, 102, 0 },
                { 255, 104, 0 },
                { 255, 106, 0 },
                { 255, 108, 0 },
                { 255, 110, 0 },
                { 255, 112, 0 },
                { 255, 114, 0 },
                { 255, 116, 0 },
                { 255, 118, 0 },
                { 255, 120, 0 },
                { 255, 122, 0 },
                { 255, 124, 0 },
                { 255, 126, 0 },
                { 255, 128, 0 },
                { 255, 130, 0 },
                { 255, 132, 0 },
                { 255, 136, 0 },
                { 255, 140, 0 },
                { 255, 144, 0 },
                { 255, 148, 0 },
                { 255, 152, 0 },
                { 255, 156, 0 },
                { 255, 160, 0 },
                { 255, 164, 0 },
                { 255, 168, 0 },
                { 255, 172, 0 },
                { 255, 176, 0 },
                { 255, 180, 0 },
                { 255, 184, 0 },
                { 255, 188, 0 },
                { 255, 192, 0 },
                { 255, 196, 0 },
                { 255, 199, 0 },
                { 255, 203, 0 },
                { 255, 206, 0 },
                { 255, 210, 0 },
                { 255, 213, 0 },
                { 255, 217, 0 },
                { 255, 220, 0 },
                { 255, 224, 0 },
                { 255, 227, 0 },
                { 255, 231, 0 },
                { 255, 234, 0 },
                { 255, 238, 0 },
                { 255, 241, 0 },
                { 255, 245, 0 },
                { 255, 248, 0 },
                { 255, 252, 0 },
                { 255, 255, 0 },
                { 250, 255, 0 },
                { 245, 255, 0 },
                { 240, 255, 0 },
                { 235, 255, 0 },
                { 230, 255, 0 },
                { 225, 255, 0 },
                { 220, 255, 0 },
                { 215, 255, 0 },
                { 210, 255, 0 },
                { 205, 255, 0 },
                { 200, 255, 0 },
                { 195, 255, 0 },
                { 190, 255, 0 },
                { 185, 255, 0 },
                { 180, 255, 0 },
                { 175, 255, 0 },
                { 168, 255, 0 },
                { 160, 255, 0 },
                { 150, 255, 0 },
                { 140, 255, 0 },
                { 130, 255, 0 },
                { 120, 255, 0 },
                { 110, 255, 0 },
                { 100, 255, 0 },
                { 90, 255, 0 },
                { 80, 255, 0 },
                { 70, 255, 0 },
                { 60, 255, 0 },
                { 50, 255, 0 },
                { 40, 255, 0 },
                { 30, 255, 0 },
                { 20, 255, 0 },
                { 10, 255, 0 },
                { 0, 255, 0 },
                { 0, 255, 10 },
                { 0, 255, 20 },
                { 0, 255, 30 },
                { 0, 255, 40 },
                { 0, 255, 50 },
                { 0, 255, 60 },
                { 0, 255, 70 },
                { 0, 255, 80 },
                { 0, 255, 90 },
                { 0, 255, 100 },
                { 0, 255, 110 },
                { 0, 255, 120 },
                { 0, 255, 130 },
                { 0, 255, 140 },
                { 0, 255, 150 },
                { 0, 255, 158 },
                { 0, 255, 164 },
                { 0, 255, 169 },
                { 0, 255, 175 },
                { 0, 255, 180 },
                { 0, 255, 186 },
                { 0, 255, 191 },
                { 0, 255, 197 },
                { 0, 255, 202 },
                { 0, 255, 208 },
                { 0, 255, 213 },
                { 0, 255, 219 },
                { 0, 255, 224 },
                { 0, 255, 230 },
                { 0, 255, 235 },
                { 0, 255, 241 },
                { 0, 255, 246 },
                { 0, 255, 252 },
                { 0, 255, 255 },
                { 0, 252, 255 },
                { 0, 249, 255 },
                { 0, 245, 255 },
                { 0, 242, 255 },
                { 0, 238, 255 },
                { 0, 235, 255 },
                { 0, 231, 255 },
                { 0, 228, 255 },
                { 0, 224, 255 },
                { 0, 221, 255 },
                { 0, 217, 255 },
                { 0, 214, 255 },
                { 0, 210, 255 },
                { 0, 207, 255 },
                { 0, 203, 255 },
                { 0, 200, 255 },
                { 0, 196, 255 },
                { 0, 194, 255 },
                { 0, 192, 255 },
                { 0, 190, 255 },
                { 0, 188, 255 },
                { 0, 186, 255 },
                { 0, 184, 255 },
                { 0, 182, 255 },
                { 0, 180, 255 },
                { 0, 178, 255 },
                { 0, 176, 255 },
                { 0, 174, 255 },
                { 0, 172, 255 },
                { 0, 170, 255 },
                { 0, 168, 255 },
                { 0, 166, 255 },
                { 0, 164, 255 },
                { 0, 162, 255 },
                { 0, 160, 255 },
                { 0, 158, 255 },
                { 0, 156, 255 },
                { 0, 154, 255 },
                { 0, 152, 255 },
                { 0, 150, 255 },
                { 0, 148, 255 },
                { 0, 146, 255 },
                { 0, 144, 255 },
                { 0, 142, 255 },
                { 0, 140, 255 },
                { 0, 138, 255 },
                { 0, 136, 255 },
                { 0, 134, 255 },
                { 0, 132, 255 },
                { 0, 130, 255 },
                { 0, 128, 255 },
                { 0, 126, 255 },
                { 0, 124, 255 },
                { 0, 122, 255 },
                { 0, 120, 255 },
                { 0, 118, 255 },
                { 0, 116, 255 },
                { 0, 114, 255 },
                { 0, 112, 255 },
                { 0, 110, 255 },
                { 0, 108, 255 },
                { 0, 106, 255 },
                { 0, 104, 255 },
                { 0, 102, 255 },
                { 0, 100, 255 },
                { 0, 98, 255 },
                { 0, 96, 255 },
                { 0, 94, 255 },
                { 0, 92, 255 },
                { 0, 90, 255 },
                { 0, 88, 255 },
                { 0, 86, 255 },
                { 0, 84, 255 },
                { 0, 82, 255 },
                { 0, 80, 255 },
                { 0, 78, 255 },
                { 0, 76, 255 },
                { 0, 74, 255 },
                { 0, 72, 255 },
                { 0, 70, 255 },
                { 0, 68, 255 },
                { 0, 66, 255 },
                { 0, 64, 255 },
                { 0, 62, 255 },
                { 0, 60, 255 },
                { 0, 58, 255 },
                { 0, 56, 255 },
                { 0, 54, 255 },
                { 0, 52, 255 },
                { 0, 50, 255 },
                { 0, 48, 255 },
                { 0, 46, 255 },
                { 0, 44, 255 },
                { 0, 42, 255 },
                { 0, 40, 255 },
                { 0, 38, 255 },
                { 0, 36, 255 },
                { 0, 34, 255 },
                { 0, 32, 255 },
                { 0, 26, 255 },
                { 0, 20, 255 },
                { 0, 14, 255 },
                { 0, 8, 255 },
                { 0, 0, 255 },
            };

        int width = bmp.PixelWidth;
        int height = bmp.PixelHeight;
        int pointNum = width * height;

        ushort[] depth = new ushort[pointNum];
        byte[] bytedepth = new byte[pointNum * sizeof(ushort)];
        Marshal.Copy(bmp.BackBuffer, bytedepth, 0, bytedepth.Length * sizeof(byte));
        Buffer.BlockCopy(bytedepth, 0, depth, 0, bytedepth.Length * sizeof(byte));

        int stride = width * 24 / 8;
        int bytelength = stride * height;
        byte[] buffer = new byte[bytelength];

        ushort range_min = 0x0001;
        ushort range_mid = Convert.ToUInt16(Camera.GetFeatureValue(IPAddress, "IntermediateDataValue"));
        ushort range_max = Convert.ToUInt16(range_mid * 2 - 1);
        ushort InvalidDataValue = Convert.ToUInt16(Camera.GetFeatureValue(IPAddress, "InvalidDataValue"));

        for (int i = 0; i < pointNum; i++)
        {
            if (depth[i] != InvalidDataValue)
            {
                int index = (depth[i] - range_min) * 256 / (range_max - range_min);
                index = (index > 0 ? index : 0);
                index = (index < 255 ? index : 255);
                buffer[(i * 3) + 2] = aHeightColorTable[index, 0];
                buffer[(i * 3) + 1] = aHeightColorTable[index, 1];
                buffer[(i * 3) + 0] = aHeightColorTable[index, 2];
            }
            else
            {
                buffer[(i * 3) + 2] = 0x00;
                buffer[(i * 3) + 1] = 0x00;
                buffer[(i * 3) + 0] = 0x00;
            }
        }

        return new WriteableBitmap(WriteableBitmap.Create(width, height, 96, 96, PixelFormats.Rgb24, null, buffer, stride));
    }
}
