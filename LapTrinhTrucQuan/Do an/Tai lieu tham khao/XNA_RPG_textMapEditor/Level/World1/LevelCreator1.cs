using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

using XNA_RPG_textMapEditor.Core;
using XNA_RPG_textMapEditor.Enemy;
using XNA_RPG_textMapEditor.Helper;
using XNA_RPG_textMapEditor.Controller;
///
/// XNA_RPG textMapEditor engine duoc viet boi HuyetSat - Xvna.forumb.biz
/// Moi cap nhat hay thac mac ý kien ve engine xin liên he tai: xvna.forumb.biz hoac thanh_vinh648@yahoo.com
/// Engine hoàn toàn free và nó cho phép các ban phát trien RPG mot cách de dàng!
/// Yeu cau ghi ro~ nguon goc engine va tac gia khi ban phat trien game ca nhan bang engine nay!
/// Chân thành cam an ban dã quan tâm su dung engine này!
///
namespace XNA_RPG_textMapEditor.Level.World1
{
    class LevelCreator1
    {
        List<Tiles> tiles,goals,keys,gates;
        List<MeleeEnemy> enemys;
        Player player;
        //for debugging
        List<Texture2D> playerTextures = new List<Texture2D>();

        #region LevelProperty
        public List<Tiles> Goals
        {
            get { return goals; }
        }
        public List<Tiles> Keys
        {
            get { return keys; }
        }
        public List<Tiles> Gates
        {
            get { return gates; }
        }
        public List<Tiles> Tiles
        {
            get { return tiles; }
        }
        public Player Player
        {
            get
            {
                return player;
            }
        }
        public List<MeleeEnemy> Enemys
        {
            get { return enemys; }
        }
        #endregion 

        public void CreateLevel(Game game,string MapPath)
        {
            playerTextures.Add(game.Content.Load<Texture2D>(AssetPath.PlayerTexture+"Idle"));
            playerTextures.Add(game.Content.Load<Texture2D>(AssetPath.PlayerTexture + "Run"));
            playerTextures.Add(game.Content.Load<Texture2D>(AssetPath.PlayerTexture + "Jump"));
            playerTextures.Add(game.Content.Load<Texture2D>(AssetPath.PlayerTexture + "Celebrate"));
            playerTextures.Add(game.Content.Load<Texture2D>(AssetPath.PlayerTexture + "Die"));
            //Thiet lap cho enemys va` player
            player = new Player(game, playerTextures[0], playerTextures[1], playerTextures[2], playerTextures[3], playerTextures[4]);

            tiles = new List<Tiles>();
            enemys = new List<MeleeEnemy>();
            goals = new List<Tiles>();
            keys = new List<Tiles>();
            gates = new List<Tiles>();
            //Load textMap
            int Width;
            List<string> lines = new List<string>();
            using (StreamReader reader = new StreamReader(MapPath))
            {
                string line = reader.ReadLine();
                Width = line.Length;
                while (line != null)
                {
                    lines.Add(line);
                    if (line.Length != Width)
                        throw new Exception(String.Format("Chieu dai` khac chieu rong"));
                    line = reader.ReadLine();
                }
            }
            int Height = lines.Count;
            for (int y = 0; y < Height ; ++y)
            {
                for (int x = 0; x < Width; ++x)
                {
                    // to load each tile.
                    char Type = lines[y][x];
                    LoadCompoment(Type, x, y, game);
                }
            }
        }
        private void LoadCompoment(char type, int x, int y,Game game)
        {
            switch (type)
            {
                case '-':
                    {
                        //Ko load gi` ca
                        break;
                    }
                case 'P':
                    {                        
                        player.Position = new Vector2(x * 50, y * 50);
                        break;
                    }
                case 'E':
                    {
                        List<Texture2D> EnemyText = new List<Texture2D>();
                        int i = RDHelper.GetRandomInt(4);
                        EnemyText.Add(game.Content.Load<Texture2D>(AssetPath.EnemyTexture + i.ToString()+"/idle"));
                        EnemyText.Add(game.Content.Load<Texture2D>(AssetPath.EnemyTexture + i.ToString() + "/run"));
                        EnemyText.Add(game.Content.Load<Texture2D>(AssetPath.EnemyTexture + i.ToString() + "/die"));
                        MeleeEnemy enemy = new MeleeEnemy(game, EnemyText[0], EnemyText[1], EnemyText[2], EnemyText[2], EnemyText[2]);
                        enemy.User = player;
                        enemy.Position = new Vector2(x * 50, y * 50);
                        enemys.Add(enemy);
                        break;
                    }
                case 'T':
                    {
                        List<Texture2D> tileText = new List<Texture2D>();
                        for (int i = 0; i < 7; i++)
                        {
                            tileText.Add(game.Content.Load<Texture2D>(AssetPath.TileTexture + "BlockA" + i.ToString()));
                        }
                        Tiles tile = new Tiles(game, tileText);
                        tile.Position = new Vector2(x * 50, y * 50);
                        tile.Initialize();
                        tiles.Add(tile);
                        break;
                    }
                case 'G':
                    {
                        List<Texture2D> tileText = new List<Texture2D>();
                        tileText.Add(game.Content.Load<Texture2D>(AssetPath.TileTexture+"Exit"));
                        Tiles goal = new Tiles(game, tileText);
                        goal.Position = new Vector2(x * 50, y * 50);
                        goal.Initialize();
                        goals.Add(goal);
                        break;
                    }
                case 'K':
                    {
                        List<Texture2D> tileText = new List<Texture2D>();
                        tileText.Add(game.Content.Load<Texture2D>(AssetPath.TileTexture + "Key"));
                        Tiles goal = new Tiles(game, tileText);
                        goal.Position = new Vector2(x * 50, y * 50);
                        goal.Initialize();
                        keys.Add(goal);
                        break;
                    }
                case 'B':
                    {
                        List<Texture2D> tileText = new List<Texture2D>();
                        tileText.Add(game.Content.Load<Texture2D>(AssetPath.TileTexture + "Gate"));
                        Tiles goal = new Tiles(game, tileText);
                        goal.Position = new Vector2(x * 50, y * 50);
                        goal.Initialize();
                        tiles.Add(goal);
                        gates.Add(goal);
                        break;
                    }
                default:
                    throw new Exception(String.Format("Sai ky tu o TextMap"));
            }
        }
    }
}
