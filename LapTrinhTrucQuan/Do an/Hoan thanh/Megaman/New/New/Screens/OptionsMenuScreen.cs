using Microsoft.Xna.Framework;

namespace New
{
    class OptionsMenuScreen : MenuScreen
    {
        MenuEntry ungulateMenuEntry;
        MenuEntry controlMenuEntry;
        MenuEntry frobnicateMenuEntry;
        MenuEntry elfMenuEntry;

        enum Ungulate
        {
            GameActions,
            LanguageXNA,
        }

        static Ungulate currentUngulate = Ungulate.GameActions;

        static string[] controls = { "Moves = Navigation keys", "Jump=X, Shoot=C, Dash=Z, Pause=Space, Exit=Q", };
        static int currentLanguage = 0;

        static bool frobnicate = true;

        static int elf = 23;

        public OptionsMenuScreen()
            : base("Options")
        {
            
            ungulateMenuEntry = new MenuEntry(string.Empty);
            controlMenuEntry = new MenuEntry(string.Empty);
            frobnicateMenuEntry = new MenuEntry(string.Empty);
            elfMenuEntry = new MenuEntry(string.Empty);

            SetMenuEntryText();

            MenuEntry back = new MenuEntry("Back");

            
            ungulateMenuEntry.Selected += UngulateMenuEntrySelected;
            controlMenuEntry.Selected += LanguageMenuEntrySelected;
            frobnicateMenuEntry.Selected += FrobnicateMenuEntrySelected;
            elfMenuEntry.Selected += ElfMenuEntrySelected;
            back.Selected += OnCancel;
            
            MenuEntries.Add(ungulateMenuEntry);
            MenuEntries.Add(controlMenuEntry);
            MenuEntries.Add(frobnicateMenuEntry);
            MenuEntries.Add(back);
        }
    
        void SetMenuEntryText()
        {
            ungulateMenuEntry.Text = "Introduction: " + currentUngulate;
            controlMenuEntry.Text = "Controls: " + controls[currentLanguage];
            frobnicateMenuEntry.Text = "Version: 1.0.0";
        }

        void UngulateMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            currentUngulate++;

            if (currentUngulate > Ungulate.LanguageXNA)
                currentUngulate = 0;

            SetMenuEntryText();
        }

        void LanguageMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            currentLanguage = (currentLanguage + 1) % controls.Length;

            SetMenuEntryText();
        }


        void FrobnicateMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            frobnicate = !frobnicate;

            SetMenuEntryText();
        }
        void ElfMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            elf++;

            SetMenuEntryText();
        }

    }
}
