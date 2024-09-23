import java.awt.*;


class StatisticPanel extends Panel
{
     /*static int width;
     static int height;
     static int num_references;
     static int num_Page_Fault;
     static int num_TLB_Misses;
     String pageFault;
     String TBL;
     String ratio_PageFault;
     String ratio_TLBMisses;
     */
     StatisticCanvas SCanvas;
     Button about;
     Frame window;

     StatisticPanel()
     {
	    setLayout( new BorderLayout());
        //width = 20;
	    //height = 480;
	    //num_Page_Fault = 0;
	    //num_TLB_Misses = 0;
    	//num_references = 0;
        setBackground (Color.pink);
        window = new AboutAFrame();
        window.resize (500, 350);


	    SCanvas = new StatisticCanvas ();
	    about = new Button("  ABout  ");
	    add ("North", new Label ("      STATISTICS       "));
	    add ("Center", SCanvas );
	    add ("South", about );
     }

     public void references()
     {
	    SCanvas.num_references++;
	    SCanvas.action();
	    //System.out.println ("num_references ++ "+SCanvas.num_references);
     }

     public void TLB_Misses()
     {

	    SCanvas.num_TLB_Misses++;
	    SCanvas.action();
	    //System.out.println ("num_TLB_Misses ++ "+SCanvas.num_TLB_Misses);
     }

     public void Page_Fault()
     {
	    SCanvas.num_Page_Fault++;
	    SCanvas.action();
	    //System.out.println ("num_Page_Fault ++ "+SCanvas.num_Page_Fault);
     }


     public boolean action ( Event e, Object arg )
     {
        if ( ("  ABout  ".equals( arg )) )
        {
            aboutAuthor();
            return true;
        }
        return false;
     }


     public void Reset() {
	    SCanvas.num_Page_Fault = 0;
	    SCanvas.num_references = 0;
	    SCanvas.num_TLB_Misses = 0;
	    SCanvas.action();
     }

     public void paint (Graphics g)
     {
	    //SCanvas.action();
     }

     public void aboutAuthor ()
     {

        window.show();
        //System.out.println ("aboutAuthor method had been called" );
     }
}

class StatisticCanvas extends Panel
{
     //static int width;
     //static int height;
     public static int num_references;
     public static int num_Page_Fault;
     public static int num_TLB_Misses;
     static String pageFault;
     String s_TBL;
     String total_Refer;
     String ratio_PageFault;
     String ratio_TLBMisses;
     float ratio_Page;
     float ratio_TLB;


     StatisticCanvas()
     {
        //width = 20;
	//height = 480;
	num_Page_Fault = 0;
	num_TLB_Misses = 0;
    	num_references = 0;

	total_Refer = ("No. of References:  "+num_references);
	pageFault = ("Page Faults: "+num_Page_Fault);
        s_TBL =     ("TLB Misses: "+num_TLB_Misses);
	ratio_Page=0;
	ratio_TLB=0;

	//ratio
	//ratio_PageFault = ("Page Fault Ratio: " + ratio_Page);
	//ratio_TLBMisses = ("TLB Miss Ratio: " + ratio_TLB);
	action();

     }

     public void action ()
     {
        int temp1,temp2;
	total_Refer = ("Total References:  "+num_references);
	pageFault = ("Page Faults: "+num_Page_Fault);
        s_TBL =     ("TLB Misses: "+num_TLB_Misses);
        if ( num_references != 0) {		// avoiding divide by 0
	    temp1 = (int)(((float)num_Page_Fault/num_references)*100);
	    ratio_Page = (float)temp1/100;

	    temp2  = (int)(((float)num_TLB_Misses/num_references)*100);
	    ratio_TLB = (float)temp2/100;
	}
	else
	{
	   ratio_Page = 0;
	   ratio_TLB = 0;
	}
	ratio_PageFault = ("Page Fault Ratio: " + ratio_Page);
	ratio_TLBMisses = ("TLB Miss Ratio: " + ratio_TLB);
	repaint();
     }



     public void paint (Graphics g)
     {
	Font f = new Font("TimesRoman", Font.PLAIN, 12);
	g.setFont(f);
        setBackground (Color.pink);
	try {
	g.drawString (total_Refer, 3, 40);
	g.drawString (pageFault,20,60);
	g.drawString (s_TBL,20,80);

	g.drawString (ratio_PageFault,3,150);
	g.drawString (ratio_TLBMisses,3,170);
	}
	catch ( NullPointerException e) {System.out.println("paint()"); }
     }
}


