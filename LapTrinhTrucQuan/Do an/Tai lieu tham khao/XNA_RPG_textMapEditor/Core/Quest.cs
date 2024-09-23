using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XNA_RPG_textMapEditor.Controller;
///
/// XNA_RPG textMapEditor engine duoc viet boi HuyetSat - Xvna.forumb.biz
/// Moi cap nhat hay thac mac ý kien ve engine xin liên he tai: xvna.forumb.biz hoac thanh_vinh648@yahoo.com
/// Engine hoàn toàn free và nó cho phép các ban phát trien RPG mot cách de dàng!
/// Yeu cau ghi ro~ nguon goc engine va tac gia khi ban phat trien game ca nhan bang engine nay!
/// Chân thành cam an ban dã quan tâm su dung engine này!
///
namespace XNA_RPG_textMapEditor.Core
{
    class Quest
    {
        //da nhan dc phan` thuong hay chua
        bool receiveGoal;
        //DK Level bao nhieu thi` lam dc quest
       // int Level;
        //Nhiem vu co' bat buoc phai lam` hay ko
        public bool Require {get;set;}
        //Dieu kien de player nhan dc quest
        public bool ReceiveQuest {get;set;}
        //DK de player lam xong quest
        public bool FinishQuest {get;set;}
        //Cac cong viec ma player plai lam khi nhan quest
        public Player player { get; set; }
        public List<bool> Tasks {get;set;}
        //Chi so cua nhiem vu hien tai dang phai thuc hien
        public int TaskNow {get;set;}
        public Quest()
        {
            ReceiveQuest = false;
            FinishQuest = false;
            Tasks = new List<bool>();
            TaskNow = 0;
        }
        public void Update()
        {
            TaskNow = 0;
            //xac' dinh quest dang lam` 
            if (ReceiveQuest&&!FinishQuest)
            {
                for (int i = 0; i < Tasks.Count; i++)
                {
                    if (Tasks[i])
                    {
                        TaskNow = i+1;
                        if (i == Tasks.Count-1)
                        {
                            FinishQuest = true;
                        }
                    }
                }
            }
            if ((ReceiveQuest && FinishQuest && !receiveGoal))
            {
                player = ReceiveGoal(player);
            }
        }
        //Phan` thuong cho player sau khi hoan` thanh` quest
        public virtual Player ReceiveGoal(Player player)
        {
            //if (FinishQuest)
            //player.Gold += 500;
            receiveGoal = true;
            return player;
        }
    }
}
