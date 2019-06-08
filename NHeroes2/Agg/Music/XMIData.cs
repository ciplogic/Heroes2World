using System.Linq;
using NHeroes2.Serialize;
using static NHeroes2.Agg.Music.Xml2Mid;

namespace NHeroes2.Agg.Music
{
    internal class XMIData
    {
        public XMITracks tracks = new XMITracks();

        public XMIData(byte[] buf)
        {
            var sb = new ByteVectorReader(buf);

            // FORM XDIR
            var group = sb.ReadData<GroupChunkHeader>();
            if (group.ID != TAG_FORM || group.type != TAG_XDIR)
            {
                H2Log.H2ERROR("parse H2ERROR: " + "form xdir");
                return;
            }

            // INFO
            var iff = sb.ReadData<IFFChunkHeader>();
            if (iff.ID != TAG_INFO || iff.length != 2)
            {
                H2Log.H2ERROR("parse H2ERROR: " + "info");
                return;
            }

            var numTracks = sb.getLE16();

            // CAT XMID
            group = sb.ReadData<GroupChunkHeader>();
            if (group.ID != TAG_CAT0 || group.type != TAG_XMID)
            {
                H2Log.H2ERROR("parse H2ERROR: " + "cat xmid");
                return;
            }

            for (var track = 0; track < numTracks; ++track)
            {
                var xmiTrack = new XMITrack();
                tracks.Add(xmiTrack);
                group = sb.ReadData<GroupChunkHeader>();
                // FORM XMID
                if (group.ID != TAG_FORM || group.type != TAG_XMID)
                {
                    H2Log.H2ERROR("unknown tag: " + group.ID + " (expected FORM), " + group.type + " (expected XMID)");
                    continue;
                }

                iff = sb.ReadData<IFFChunkHeader>();
                // [TIMB]
                if (iff.ID == TAG_TIMB)
                {
                    xmiTrack.timb = sb.getRaw(iff.length);
                    if (tracks.Last().timb.Length != iff.length)
                    {
                        H2Log.H2ERROR("parse H2ERROR: " + "out of range");
                        break;
                    }

                    iff = sb.ReadData<IFFChunkHeader>();
                }

                // [RBRN]
                if (iff.ID == TAG_RBRN)
                {
                    sb.skip(iff.length);
                    iff = sb.ReadData<IFFChunkHeader>();
                }

                // EVNT
                if (iff.ID != TAG_EVNT)
                {
                    H2Log.H2ERROR("parse H2ERROR: " + "evnt");
                    break;
                }

                xmiTrack.evnt = sb.getRaw(iff.length);

                if (xmiTrack.evnt.Length != iff.length)
                {
                    H2Log.H2ERROR("parse H2ERROR: " + "out of range");
                    break;
                }
            }
        }

        public bool isvalid()
        {
            return tracks.Count != 0;
        }
    }
}