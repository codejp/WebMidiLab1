using Microsoft.AspNet.SignalR;
using System;

namespace WebMidiLab1.Hubs
{
    public class WebMIDIHubBuffered : Hub
    {
        public void WebMIDIOutput(byte status, byte msg1, byte msg2)
        {
            Clients.All.WebMIDIInput(status, msg1, msg2, DateTime.Now.Ticks);
        }

        private static DateTime d1970 = new DateTime(1970, 1, 1, 0, 0, 0);
        private static long tick1970 = d1970.Ticks;
        private static TimeSpan timespan1970 = TimeSpan.FromTicks(d1970.Ticks);

        public void WebMIDISync(long tick)
        {
            var client = TimeSpan.FromMilliseconds(tick).Add(timespan1970);
            var server = TimeSpan.FromTicks(DateTimeOffset.Now.UtcTicks);
            Clients.Caller.WebMIDIInputSync(server.Ticks - client.Ticks);
        }
        public void WebMIDISyncThrough(long tick)
        {
            Clients.Caller.WebMIDIInputSync(tick);
        }
    }
}
