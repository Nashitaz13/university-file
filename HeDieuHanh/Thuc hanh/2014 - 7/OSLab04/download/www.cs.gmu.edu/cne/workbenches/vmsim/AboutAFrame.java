import java.awt.*;

public class AboutAFrame extends Frame
{
    Button close;
    String  str;
    TextArea textA;
    AboutAFrame()
    {
        super("About the Author ");
        str = "\n\n\n\tThis applet was implemented by Ngon Tran under\n"+
              "\tthe supervision of Dr. Daniel A. Menasce' at the\n"+
              "\tCenter for the New Engineer at George Mason University.\n\n"+
              "\tSummer 1996."+
	      "\n\n\tThe initial version of this applet was developed by Avijit Chakraborty" +
	      "\n\tand Joyject Bhowmik, but has been greatly modified by Ngon Tran.";
        textA = new TextArea( str, 10, 50 );
        //textA.setFont ("Helvetica", Font.PLAIN, 12);
        textA.setEditable( false );
        close = new Button ("Close");

        add ("Center", textA);
        add ("South", close);

    }

    public boolean action ( Event e, Object what )
    {
        if (e.target==close)
        {
            this.hide();
            this.dispose();
            return true;
        }
        return false;

    }

}
