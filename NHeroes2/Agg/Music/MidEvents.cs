using System;
using System.Collections.Generic;
using NHeroes2.Utilities;
using static NHeroes2.Agg.H2Log;

namespace NHeroes2.Agg.Music
{
    class MidEvents
    {
        public List<MidEvent> _items = new List<MidEvent>();

        public MidEvents(XMITrack t)

        {
            var ptr = t.evnt;
            var ptrPos = 0;
            var endSize = t.evnt.Length;

            UInt32 delta = 0;
            List<meta_t> notesoff = new List<meta_t>();

            while (ptr[ptrPos] != 0 && ptrPos < endSize)
            {
                // insert event: note off
                if (delta != 0)
                {
                    // sort duration
                    //notesoff.sort();

                    var it1 = 0;
                    var it2 = notesoff.Count;
                    UInt32 delta2 = 0;

                    // apply delta
                    for (; it1 != it2; ++it1)
                    {
                        if (notesoff[it1].duration <= delta)
                        {
                            var item = notesoff[it1];
                            // note off
                            _items.Add(new MidEvent(item.duration - delta2, item.command, item.quantity, 0x7F));
                                
                            delta2 += item.duration - delta2;
                        }
                    }

                    // remove end notes
                    while (!notesoff.empty() && notesoff.front().duration <= delta)
                        notesoff.RemoveAt(0);

                    // fixed delta
                    if (delta2!=0) delta -= delta2;

                    // decrease duration
                    foreach (var it in notesoff)
                        it.decrease_duration(delta);
                }

                // interval
                if (ptr[ptrPos] < 128)
                {
                    delta += ptr[ptrPos];
                    ++ptrPos;
                }
                else
                    // command
                {
                    // end
                    if (0xFF == ptr[ptrPos] && 0x2F == ptr[ptrPos + 1])
                    {
                        _items.Add(new MidEvent(delta, ptr[ptrPos], ptr[ptrPos + 1], ptr[ptrPos + 2]));
                        break;
                    }

                    switch (ptr[ptrPos] >> 4)
                    {
                        // meta
                        case 0x0F:
                        {
                            pack_t pack = unpackValue(ptr, ptrPos + 2);
                            ptrPos += (int)(pack.first + pack.second + 1);
                            delta = 0;
                        }
                            break;

                        // key pressure
                        case 0x0A:
                        // control change
                        case 0x0B:
                        // pitch bend
                        case 0x0E:
                        {
                            _items.Add(new MidEvent( delta, ptr[ptrPos], ptr[ptrPos +1], ptr[ptrPos +2]));
                            ptrPos += 3;
                            delta = 0;
                        }
                            break;

                        // note off
                        case 0x08:
                        // note on
                        case 0x09:
                        {
                            _items.Add(new MidEvent (delta, ptr[ptrPos], ptr[ptrPos + 1], ptr[ptrPos + 2]));
                            pack_t pack = unpackValue(ptr,ptrPos + 3);
                            notesoff.Add(new meta_t((byte) (ptr[ptrPos] - 0x10), ptr[ptrPos + 1], pack.first)); 
                            ptrPos += 3 + (int)pack.second;
                            delta = 0;
                        }
                            break;

                        // program change
                        case 0x0C:
                        // chanel pressure
                        case 0x0D:
                        {
                            _items.Add(new MidEvent (delta, ptr[ptrPos], ptr[ptrPos + 1]));
                            ptrPos += 2;
                            delta = 0;
                        }
                            break;

                        // unused command
                        default:
                            _items.Add(new MidEvent (0, 0xFF, 0x2F, 0));
                            H2ERROR("unknown st: 0x");
                            break;
                    }
                }
            }
        }

        private pack_t unpackValue(byte[] ptr, int ptrPos)
        {
            var p = ptrPos;
            pack_t res = new pack_t();

            while ((ptr[p] & 0x80) != 0)
            {
                if (4 <= p - ptrPos)
                {
                    H2ERROR("unpack delta mistake");
                    break;
                }

                res.first |= (UInt32)(0x0000007F & ptr[p]);
                res.first <<= 7;
                ++p;
            }

            res.first += ptr[ptrPos];
            res.second = (uint) (p - ptrPos + 1);

            return res;
        }
    }
}