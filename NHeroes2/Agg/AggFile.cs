using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using NHeroes2.Agg.Icns;
using NHeroes2.Serialize;

namespace NHeroes2.Agg
{
    class MutPoint
    {
        public int x, y;
    }

    public class AggFile
    {
        const int FATSIZENAME = 15;

        string filename;
        Dictionary<string, AggFat> fat = new Dictionary<string, AggFat>();
        int count_items = 0;
        private int size;
        private ByteVectorReader stream;
        byte[] fileContent;
        string key;
        byte[] body;

        public bool Open(string fname)
        {
            filename = fname;
            if (!File.Exists(fname))
                return false;

            fileContent = File.ReadAllBytes(filename);
            size = fileContent.Length;
            stream = new ByteVectorReader(fileContent);

            count_items = stream.getLE16();

            stream.seek(size - FATSIZENAME * count_items);
            var vectorNames = new List<string>(count_items);

            for (var ii = 0; ii < count_items; ++ii)
            {
                vectorNames.Add(stream.toString(FATSIZENAME));
            }

            stream.seek(2);
            for (var ii = 0; ii < count_items; ++ii)
            {
                var itemName = vectorNames[ii];
                AggFat f = new AggFat();
                var crc = stream.getLE32();
                f.crc = crc;
                var offset = stream.getLE32();
                f.offset = offset;
                var sizeChunk = stream.getLE32();
                f.size = sizeChunk;
                fat[itemName] = f;
            }

            return true;
        }


        byte[] ReadICNChunk(int icn)
        {
            // hard fix artifact "ultimate stuff" sprite for loyalty version
            return Read(Icn.GetString(icn));
        }


        static byte[] kb_pal =
        {
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3f, 0x3f,
            0x3f, 0x3c, 0x3c, 0x3c, 0x3a, 0x3a, 0x3a, 0x37, 0x37, 0x37, 0x35, 0x35, 0x35, 0x32, 0x32, 0x32,
            0x30, 0x30, 0x30, 0x2d, 0x2d, 0x2d, 0x2b, 0x2b, 0x2b, 0x29, 0x29, 0x29, 0x26, 0x26, 0x26, 0x24,
            0x24, 0x24, 0x21, 0x21, 0x21, 0x1f, 0x1f, 0x1f, 0x1c, 0x1c, 0x1c, 0x1a, 0x1a, 0x1a, 0x17, 0x17,
            0x17, 0x15, 0x15, 0x15, 0x12, 0x12, 0x12, 0x10, 0x10, 0x10, 0x0e, 0x0e, 0x0e, 0x0b, 0x0b, 0x0b,
            0x09, 0x09, 0x09, 0x06, 0x06, 0x06, 0x04, 0x04, 0x04, 0x01, 0x01, 0x01, 0x00, 0x00, 0x00, 0x3f,
            0x3b, 0x37, 0x3c, 0x37, 0x32, 0x3a, 0x34, 0x2e, 0x38, 0x31, 0x2a, 0x36, 0x2e, 0x26, 0x34, 0x2a,
            0x22, 0x32, 0x28, 0x1e, 0x30, 0x25, 0x1b, 0x2e, 0x22, 0x18, 0x2b, 0x1f, 0x15, 0x29, 0x1c, 0x12,
            0x27, 0x1a, 0x0f, 0x25, 0x18, 0x0d, 0x23, 0x15, 0x0b, 0x21, 0x13, 0x08, 0x1f, 0x11, 0x07, 0x1d,
            0x0f, 0x05, 0x1a, 0x0d, 0x04, 0x18, 0x0c, 0x03, 0x16, 0x0a, 0x02, 0x14, 0x09, 0x01, 0x12, 0x07,
            0x01, 0x0f, 0x06, 0x00, 0x0d, 0x05, 0x00, 0x0b, 0x04, 0x00, 0x09, 0x03, 0x00, 0x30, 0x33, 0x3f,
            0x2b, 0x2e, 0x3c, 0x26, 0x2a, 0x3a, 0x22, 0x26, 0x38, 0x1e, 0x22, 0x36, 0x1a, 0x1e, 0x34, 0x16,
            0x1a, 0x31, 0x13, 0x16, 0x2f, 0x10, 0x13, 0x2d, 0x0d, 0x10, 0x2b, 0x0a, 0x0d, 0x29, 0x08, 0x0c,
            0x26, 0x07, 0x0a, 0x24, 0x05, 0x09, 0x22, 0x04, 0x08, 0x20, 0x03, 0x07, 0x1e, 0x02, 0x06, 0x1c,
            0x01, 0x05, 0x19, 0x01, 0x05, 0x17, 0x00, 0x04, 0x15, 0x00, 0x03, 0x13, 0x00, 0x03, 0x11, 0x2b,
            0x38, 0x27, 0x27, 0x35, 0x23, 0x24, 0x33, 0x20, 0x20, 0x30, 0x1c, 0x1d, 0x2e, 0x19, 0x1a, 0x2c,
            0x17, 0x17, 0x29, 0x14, 0x14, 0x27, 0x11, 0x12, 0x24, 0x0f, 0x0f, 0x22, 0x0c, 0x0d, 0x1f, 0x0a,
            0x0b, 0x1d, 0x09, 0x09, 0x1b, 0x07, 0x08, 0x19, 0x06, 0x06, 0x17, 0x05, 0x05, 0x15, 0x03, 0x03,
            0x13, 0x02, 0x02, 0x10, 0x01, 0x01, 0x0e, 0x01, 0x01, 0x0c, 0x00, 0x00, 0x0a, 0x00, 0x00, 0x08,
            0x00, 0x00, 0x06, 0x00, 0x3f, 0x3d, 0x34, 0x3e, 0x3a, 0x2b, 0x3d, 0x38, 0x23, 0x3c, 0x37, 0x1b,
            0x3b, 0x35, 0x14, 0x3a, 0x33, 0x0d, 0x39, 0x32, 0x05, 0x38, 0x31, 0x00, 0x36, 0x2f, 0x08, 0x34,
            0x2c, 0x07, 0x32, 0x28, 0x06, 0x2f, 0x26, 0x06, 0x2d, 0x23, 0x06, 0x2a, 0x1f, 0x05, 0x27, 0x1c,
            0x04, 0x25, 0x19, 0x03, 0x22, 0x16, 0x03, 0x1f, 0x13, 0x02, 0x1d, 0x11, 0x02, 0x1a, 0x0f, 0x00,
            0x18, 0x0c, 0x00, 0x15, 0x0a, 0x00, 0x13, 0x08, 0x00, 0x39, 0x33, 0x3e, 0x36, 0x2f, 0x3b, 0x32,
            0x2a, 0x39, 0x30, 0x27, 0x36, 0x2d, 0x23, 0x34, 0x2a, 0x1f, 0x31, 0x27, 0x1c, 0x2f, 0x24, 0x19,
            0x2d, 0x21, 0x16, 0x2a, 0x1e, 0x13, 0x28, 0x1c, 0x11, 0x25, 0x19, 0x0e, 0x23, 0x17, 0x0c, 0x20,
            0x14, 0x0a, 0x1e, 0x12, 0x08, 0x1b, 0x10, 0x06, 0x19, 0x0e, 0x05, 0x17, 0x0b, 0x02, 0x14, 0x08,
            0x01, 0x11, 0x06, 0x00, 0x0e, 0x04, 0x00, 0x0b, 0x2d, 0x3d, 0x3f, 0x2a, 0x3a, 0x3c, 0x28, 0x38,
            0x3a, 0x25, 0x36, 0x38, 0x22, 0x33, 0x35, 0x20, 0x31, 0x33, 0x1e, 0x2e, 0x31, 0x1c, 0x2c, 0x2f,
            0x19, 0x2a, 0x2c, 0x17, 0x27, 0x2a, 0x16, 0x25, 0x28, 0x14, 0x23, 0x25, 0x12, 0x20, 0x23, 0x10,
            0x1d, 0x20, 0x0e, 0x1a, 0x1d, 0x0c, 0x18, 0x1b, 0x0a, 0x15, 0x18, 0x08, 0x13, 0x16, 0x07, 0x10,
            0x13, 0x05, 0x0e, 0x10, 0x04, 0x0b, 0x0e, 0x03, 0x09, 0x0b, 0x02, 0x07, 0x09, 0x3f, 0x39, 0x39,
            0x3d, 0x34, 0x34, 0x3c, 0x2f, 0x2f, 0x3a, 0x2b, 0x2b, 0x39, 0x27, 0x27, 0x37, 0x23, 0x23, 0x36,
            0x1f, 0x1f, 0x34, 0x1b, 0x1b, 0x33, 0x17, 0x17, 0x31, 0x14, 0x14, 0x30, 0x11, 0x11, 0x2f, 0x0e,
            0x0e, 0x2e, 0x0b, 0x0b, 0x2d, 0x09, 0x09, 0x2a, 0x08, 0x08, 0x27, 0x06, 0x06, 0x24, 0x04, 0x04,
            0x21, 0x03, 0x03, 0x1e, 0x02, 0x02, 0x1b, 0x01, 0x01, 0x18, 0x00, 0x00, 0x15, 0x00, 0x00, 0x12,
            0x00, 0x00, 0x3f, 0x39, 0x27, 0x3e, 0x36, 0x23, 0x3d, 0x34, 0x1f, 0x3c, 0x31, 0x1c, 0x3b, 0x2e,
            0x18, 0x3a, 0x2b, 0x14, 0x39, 0x28, 0x11, 0x38, 0x24, 0x0e, 0x38, 0x21, 0x0b, 0x33, 0x1d, 0x08,
            0x2e, 0x19, 0x06, 0x29, 0x16, 0x04, 0x25, 0x12, 0x02, 0x20, 0x0f, 0x01, 0x1b, 0x0c, 0x00, 0x17,
            0x0a, 0x00, 0x3f, 0x16, 0x03, 0x37, 0x0d, 0x01, 0x30, 0x05, 0x00, 0x29, 0x00, 0x00, 0x3f, 0x3f,
            0x00, 0x3f, 0x33, 0x00, 0x30, 0x23, 0x00, 0x23, 0x12, 0x00, 0x29, 0x34, 0x00, 0x25, 0x2f, 0x00,
            0x21, 0x2b, 0x00, 0x1e, 0x27, 0x01, 0x1a, 0x23, 0x01, 0x17, 0x1e, 0x01, 0x13, 0x1a, 0x01, 0x10,
            0x16, 0x01, 0x0d, 0x12, 0x01, 0x0a, 0x1e, 0x34, 0x06, 0x1a, 0x31, 0x01, 0x12, 0x2d, 0x00, 0x0e,
            0x2b, 0x03, 0x15, 0x2f, 0x00, 0x0e, 0x2b, 0x00, 0x10, 0x2d, 0x21, 0x38, 0x3f, 0x00, 0x26, 0x3f,
            0x00, 0x14, 0x39, 0x00, 0x00, 0x29, 0x23, 0x23, 0x2f, 0x1c, 0x1c, 0x27, 0x15, 0x15, 0x1f, 0x0f,
            0x0f, 0x17, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
        };

        void DrawPointFast(Bitmap srf, int x, int y, byte palette)
        {
            var r = kb_pal[palette * 3]*4;
            var g = kb_pal[palette * 3 + 1]*4;
            var b = kb_pal[palette * 3 + 2]*4;
            var palColor = Color.FromArgb(r, g, b);
            srf.SetPixel(x, y, palColor);
        }

        public IcnSprite RenderICNSprite(int icn, int index)
        {
            var res = new IcnSprite();

            var body = ReadICNChunk(icn);
            if (body.Length == 0)
            {
                return res;
            }

            ByteVectorReader st = new ByteVectorReader(body);

            var count = st.getLE16();
            if (index >= count)
            {
                return res;
            }

            var blockSize = st.getLE32();

            if (index != 0) st.skip(index * 13);

            var header1 = st.ReadData<IcnHeader>();

            UInt32 sizeData = 0;
            if (index + 1 != count)
            {
                var header2 = st.ReadData<IcnHeader>();
                sizeData = header2.offsetData - header1.offsetData;
            }
            else
                sizeData = (UInt32) blockSize - header1.offsetData;


            Render(res, header1, body, sizeData);

            return res;
        }

        private void Render(IcnSprite res, IcnHeader header1, byte[] body, uint sizeData)
        {
            // start render
            var sz = new Size(header1.width, header1.height);

            var buf = body;
            var bufPos = 6 + header1.offsetData;
            var max = bufPos + sizeData;

            res.offset = new Point(header1.offsetX, header1.offsetY);
            res.SetSize(true, sz.Width, sz.Height, false);

            var shadowCol = Color.FromArgb(0, 0, 0, 0x40);

            var pt = new MutPoint();

            while (true)
            {
                var cur = buf[bufPos];
                // 0x00 - end line
                if (0 == cur)
                {
                    ++pt.y;
                    pt.x = 0;
                    bufPos++;
                }
                else
                    // 0x7F - count data
                {
                    UInt32 c;
                    if (0x80 > buf[bufPos])
                    {
                        c = buf[bufPos];
                        ++bufPos;
                        while (c-- != 0 && bufPos < max)
                        {
                            DrawPointFast(res.first, pt.x, pt.y, buf[bufPos]);
                            ++pt.x;
                            ++bufPos;
                        }
                    }
                    else
                        // 0x80 - end data
                    if (0x80 == buf[bufPos])
                    {
                        break;
                    }
                    else
                        // 0xBF - skip data
                    if (0xC0 > buf[bufPos])
                    {
                        pt.x += buf[bufPos] - 0x80;
                        ++bufPos;
                    }
                    else
                        // 0xC0 - shadow
                    if (0xC0 == buf[bufPos])
                    {
                        ++bufPos;
                        if (buf[bufPos] % 4 != 0)
                            c = (uint) (buf[bufPos] % 4);
                        else
                        {
                            ++bufPos;
                            c = buf[bufPos];
                        }

                        if (res.first.PixelFormat == PixelFormat.Format8bppIndexed) // skip alpha
                        {
                            pt.x += (int) c;
                            c = 0;
                        }
                        else
                        {
                            if (res.second == null)
                            {
                                res.SetSize(false, sz.Width, sz.Height, true);
                            }

                            while (c-- != 0)
                            {
                                res.second.SetPixel(pt.x, pt.y, shadowCol);
                                ++pt.x;
                            }
                        }

                        ++bufPos;
                    }
                    else
                        // 0xC1
                    if (0xC1 == buf[bufPos])
                    {
                        ++bufPos;
                        c = buf[bufPos];
                        ++bufPos;
                        while (c-- != 0)
                        {
                            DrawPointFast(res.first, pt.x, pt.y, buf[bufPos]);
                            ++pt.x;
                        }

                        ++bufPos;
                    }
                    else
                    {
                        c = (uint) (buf[bufPos] - 0xC0);
                        ++bufPos;
                        while (c-- != 0)
                        {
                            DrawPointFast(res.first, pt.x, pt.y, buf[bufPos]);
                            ++pt.x;
                        }

                        ++bufPos;
                    }
                }

                if (bufPos >= max)
                {
                    break;
                }
            }
        }

        public byte[] Read(string fileName)
        {
            if (!fat.TryGetValue(fileName, out var f))
            {
                return Array.Empty<byte>();
            }

            if (f.size == 0)
            {
                return Array.Empty<byte>();
            }

            stream.seek(f.offset);
            var body = stream.getRaw(f.size);
            return body;
        }
    }
}