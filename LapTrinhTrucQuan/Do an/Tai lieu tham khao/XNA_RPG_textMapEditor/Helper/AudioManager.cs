using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

///
/// XNA_RPG textMapEditor engine duoc viet boi HuyetSat - Xvna.forumb.biz
/// Moi cap nhat hay thac mac ý kien ve engine xin liên he tai: xvna.forumb.biz hoac thanh_vinh648@yahoo.com
/// Engine hoàn toàn free và nó cho phép các ban phát trien RPG mot cách de dàng!
/// Yeu cau ghi ro~ nguon goc engine va tac gia khi ban phat trien game ca nhan bang engine nay!
/// Chân thành cam an ban dã quan tâm su dung engine này!
///
namespace XNA_RPG_textMapEditor.Helper
{
    class AudioManager
    {
        public Song BackSound;
        public SoundEffect Die1;
        
        public SoundEffect Exit;
        public SoundEffect KeyReceived;
        public AudioManager(Game game)
        {
            BackSound = game.Content.Load<Song>(AssetPath.Sound + "Music");
            Die1 = game.Content.Load<SoundEffect>(AssetPath.Sound + "PlayerKilled");
            KeyReceived = game.Content.Load<SoundEffect>(AssetPath.Sound + "GemCollected");
            Exit = game.Content.Load<SoundEffect>(AssetPath.Sound + "ExitReached");
        }
    }
}
