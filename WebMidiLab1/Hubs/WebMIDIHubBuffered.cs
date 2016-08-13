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


        public void WebMIDISyncThrough(long tick)
        {
            Clients.Caller.WebMIDIInputSync(tick);
        }
    }
}
