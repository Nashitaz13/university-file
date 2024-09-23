//	/*********************************************************
//		The Applet for the Virtual memory simulation
//			Modified by Ngon Tran
//	*********************************************************/



//
//  The Applet for the Virtual memory simulation
//
//  Author: Avijit Chakraborty, Joyjeet Bhowmik
//
//  URL: http://earth.usc.edu/~avijitc/final/index.html#Source
//
import java.lang.*;
import java.awt.*;
import java.applet.*;

public class VMS extends Applet {

  public static MyCanvas theCanvas;
  public Thread schdThread = null;
  public static Scheduler theScheduler;
  SimulatorDisplayUtils vmsDispUtils;
  private static StatisticPanel statisticResult;


  //-----------------------------------------------
  //  Here are the data accesses by the Schedular,
  //  MMU
  //  and SimulatorDisplayUtils
  //
  private static int runningProcess;
  private static int lastRunningProcess;
  private static int vPageFrame;
  private static int tlbHitIndex;
  private static int lastTlbHitIndex;
  private static boolean tlbState;
  private static int curMM, lastMM;
  private static int num_Process_Exec;
  private static boolean switchProcess;
  private static boolean updatePT;

  protected static void setUpdatePT( boolean what )
  {
    updatePT = what;
  }

  protected static boolean updatePageTable ()
  {
    return updatePT;
  }

  protected static void setSwitchProcess( boolean what )
  {
    switchProcess = what;
  }

  protected static boolean getSwitchProcess()
  {
    return (switchProcess);
  }


  protected static void setCurMM( int num )
  {
    curMM = num;
  }

  protected static int getCurMM()
  {
    return (curMM);
  }

  protected static void setLastMM( int num )
  {
    lastMM = num;
  }

  protected static int getLastMM()
  {
    return (lastMM);
  }

  protected static void setNum_Process_Exec( int number )
  {
    num_Process_Exec = number;
  }

  protected static int getNum_Process_Exec()
  {
    return num_Process_Exec;
  }

  protected static void setTlbState( boolean what)
  {
    tlbState = what;
  }

  protected static boolean getTlbState()
  {
    return (tlbState);
  }

  protected static void setTlbHitIndex( int index)
  {
    tlbHitIndex = index;
  }
  protected static void setLastTlbHitIndex( int index)
  {
    lastTlbHitIndex = index;
  }

  protected int getTlbHitIndex()
  {
    return tlbHitIndex;
  }

  protected static int getLastTlbHitIndex()
  {
    return lastTlbHitIndex;
  }



  protected static void setRunningProc( int pid ) {
    runningProcess = pid;
  }

  protected static void setLastRunningProc( int pid ) {
    lastRunningProcess = pid;
  }
  protected static int getRunningProc() {
    return( runningProcess );
  }
  protected static int getLastRunningProc() {
    return( lastRunningProcess );
  }

  protected static void setMMvPageFrame( int number)
  {
    vPageFrame = number;
  }

  protected static int getMMvPageFrame()
  {
    return (vPageFrame);
  }

  static public int TLB_TAG[];                         // the TLB
  static public int TLB_DATA[];
  static public int TLB[];
  static public int TLB_LRU;

  static public int PM_LRU;
  static public int PM[];

  public int PM_IN_TLB[];
  static public int PM_IN_PT[];


  protected static int getPMinPT (int index)
  {
    return PM_IN_PT[index];
  }

  protected static int TLBgetLRU()
  {
    int oldest, i;
    oldest = TLB[0];
    //System.out.println ("TLB[]:");
    for ( i=1; i < 4; i++ )
    {
        //System.out.println (i);
        if( oldest > TLB[i] )
            oldest = TLB[i];
    }
    i = 0;
    while ( oldest != TLB[i] ) i++;
    //System.out.println ("index: " + i + "oldest: " + oldest);

    return i;
  }

  protected static int PMgetLRU()
  {
    int oldest, i;
    oldest = PM[0];
    for ( i=1; i < 16; i++ )
    {
        if( oldest > PM[i] )
            oldest = PM[i];
    }
    i = 0;
    while ( oldest != PM[i] ) i++;
    //System.out.println ("index: " + i + "oldest: " + oldest);

    return i;
  }

  //
  //  These are TLB related methods
  //
  protected int TLBgetData( int index )
  {
    return( TLB_DATA[index] );
  }


  protected int TLBgetEntry( int index, int vmPageNum )
  {
    if ( TLB_TAG[index] == vmPageNum )
    {
       return( TLB_DATA[index] );
    }
    else
       return ( -1 );
  }


  protected int TLBsetEntry(int vmPageNum, int pmPageNum)
  {
    int oldestIndex;
    oldestIndex = TLBgetLRU();
    //System.out.println (" TLB_index "+TLB_LRU);

    TLB_TAG[oldestIndex]	= vmPageNum;
    TLB_DATA[oldestIndex ]	= pmPageNum;
    
    //System.out.println ("TLB_vm["+oldestIndex+"] :"+TLB_TAG[oldestIndex]+"\t\tTLB_pm:"+TLB_DATA[oldestIndex] );

    return oldestIndex;
  }


  protected static void TLBincrLRU( int index)
  {
    //index = index % 4;
    TLB_LRU++;
    TLB[index] = TLB_LRU;

    //System.out.println ("TLB_LRU :"+TLB_LRU);
  }

  protected static void PMincrLRU( int index )
  {
    PM_LRU++;
    PM[index] = PM_LRU;
    //System.out.println ("PM_LRU :"+PM_LRU);
  }


  protected static void PMresetLRU(int index)
  {
    PM[index] = 0;
  }


  protected static void incr_Reference()
  {
    statisticResult.references();
  }


  protected static void incr_TLB_Miss()
  {
    statisticResult.TLB_Misses();
  }

  protected static void incr_PT_Miss()
  {
    statisticResult.Page_Fault();
  }

  static int gimmePageNum;


  //------------------------------------------------
  //

  public static void TLBresetLRU()
  {
    TLB_LRU = 0;
    for (int count = 0; count < 4; count++)
    {
        TLB_TAG[count] = -1;
        TLB_DATA[count]= -1;
        TLB[count] = 0;
    }
    System.out.println("_____________________________");
  }


  public void init() {
    Controls theControls;
    CNEControls secondCtrl;
    //StatisticCanvas statisticC;
    int theScrWidth = 300;
    int theScrHeight = 200;

    setLayout(new BorderLayout());

    statisticResult = new StatisticPanel();
    //statisticC = new StatisticCanvas();
    theCanvas = new MyCanvas( theScrWidth, theScrHeight);
    vmsDispUtils = theCanvas.createDispUtils();

    theScheduler = new Scheduler();
    secondCtrl = new CNEControls( theCanvas, theScheduler );
    theControls = new Controls( theCanvas, theScheduler, secondCtrl, statisticResult );
    add("Center", theCanvas );
    add("South", theControls );
    add("East", statisticResult );


    //
    // Initialization of the display related state variables
    //
    runningProcess = 0;
    //vAddr = 0;
    //pAddr = 0;
    //tlbState = false;
    //pageState = false;
    //pageTableState = false;

    gimmePageNum = -1;

  }
  public static void restartSim() {
    int i;

    //
    // Initialization of the display related state variables
    //
    runningProcess = 0;
    //vAddr = 0;
    //pAddr = 0;
    //tlbState = false;
    //pageState = false;
    //pageTableState = false;
    gimmePageNum = -1;

    //
    // Now refresh the window
    //
    theCanvas.drawAll = -1;
    theCanvas.repaint();

  }


  public static void switchProcess()
  {
    theCanvas.drawAll = 0;
    theCanvas.repaint();

  }

  public SimulatorDisplayUtils returnDispUtils() {
    return( vmsDispUtils );
  }
  public void paint() {
    //theCanvas.repaint();
  }
/*
  public static void main(String args[]) {
	Frame f = new Frame("Virtual Memory ");
	VMS testApplet = new VMS();

	testApplet.init();
	f.add("Center",testApplet);
	f.resize(610,560);
	f.show();
  }
*/

}












//
//  This class takes care of the Canvas part of the application
//  i.e., where the actual drawing is done
//
//

class MyCanvas extends Panel {
  static int width;
  static int height;
  public static SimulatorDisplayUtils theDispUtils;
  Graphics offScreenGraphics = null;
  Image offScreenImage = null;
  public int drawAll;
  //StatisticPanel s_Statistic;

  public MyCanvas( int w, int h ) {
    width  = w;
    height = h;
    drawAll = -1;
    //s_Statistic = s;
  }
  public SimulatorDisplayUtils createDispUtils() {
    theDispUtils = new SimulatorDisplayUtils();
    return( theDispUtils );
  }

  public void switchProcess()
  {
    drawAll = 0;
    repaint();
    //Graphics g;

    //System.out.println ("switchProcess method called  "+drawAll);
    //paint(g);

  }

  public void display() {
    drawAll = 1;
    repaint();

  }

  public void updatePTonly()
  {
    Graphics g = getGraphics();
    drawAll = 0;
    paint(g);
  }

  public void update( Graphics g ) {
    paint( g );
  }
  //
  //  This update function is called everytime the
  //  applet gets a Graphics Exposure
  //
  public void paint( Graphics theG ) {
    setBackground( Color.white );

    theDispUtils.displayLayout( drawAll, theG );
  }

}
//
// This class takes care of the control part i.e.,
// the menu buttons etc.
//
//

class Controls extends Panel {
  MyCanvas target;
  CNEControls secondCtrl;
  Scheduler theScheduler;
  StatisticPanel statisticResult;
  Button stopButton;
  Button startButton;
  Button resetButton;
  Button stepButton;
  Label l;

  public Controls( MyCanvas target, Scheduler theSchd, CNEControls second, StatisticPanel s ) {
    this.target = target;
    this.statisticResult = s;
    this.theScheduler = theSchd;
    this.secondCtrl = second;
    setLayout(new FlowLayout());
    setBackground( Color.lightGray );
    target.setForeground( Color.black );

    l = new Label ("                                  ");
    startButton= new Button( "   Start  " );
    stopButton = new Button( "   Stop   " );
    resetButton= new Button( "   Reset  " );

    Font f= new Font("TimesRoman", Font.BOLD,20);
    stepButton= new Button( "   Step   " );


    add( startButton  );
    add( stopButton );
    add( resetButton );
    //add(l);
    add( stepButton );
    add( this.secondCtrl );
  }

  public void paint( Graphics theG ) {
    Rectangle r = bounds();
    theG.setColor(Color.lightGray);
    theG.drawRect(0, 0, r.width, r.height );
  }

  public boolean action( Event e, Object arg ) {
    if ( ("   Start  ".equals( arg )) || (" Play ".equals( arg )) ) {
      //System.out.println( "Start pressed" );
      theScheduler.start();
      return true;

    }
    if ( "   Stop   ".equals( arg ) ) {
      //System.out.println( "Stop pressed" );
      theScheduler.stop();
      startButton.setLabel( " Play " );
      return true;
    }
    if ( "   Reset  ".equals( arg ) ) {
      //System.out.println( "Reset pressed" );
      startButton.setLabel( "   Start  " );
      theScheduler.resetSim();
      secondCtrl.reset_Scrollbar();
      theScheduler.slider_num_one = 1000;	//reset the initial speed
      theScheduler.slider_num_two = 500;
      statisticResult.Reset();
      return true;
    }
    if ( "   Step   ".equals( arg) ) {
       //System.out.println( "Step pressed ");
      //startButton.setLabel( " Play " );
      theScheduler.start();
      theScheduler.slider_num_one = 1000;	//reset the initial speed
      theScheduler.slider_num_two = 500;
      try { Thread.sleep( theScheduler.slider_num_two ); }
        catch( InterruptedException ie ) {
      }
      theScheduler.stop();
      return true;
    }
    return false;
  }
}





//
// This class takes care of the control part i.e.,
// the slider-speed etc.
//
//

class CNEControls extends Panel {
  MyCanvas target;
  Scheduler theScheduler;
  Label l;
  int resetValue;
  Scrollbar speed;

  public CNEControls( MyCanvas target, Scheduler theSchd ) {
    this.target = target;
    this.theScheduler = theSchd;
    setLayout(new FlowLayout());
    setBackground( Color.lightGray );
    target.setForeground( Color.black );

    l = new Label("Normal ");
    speed = new Scrollbar(0,5,1,1,10);
    add( new Label("     SPEED BAR"));
    add(speed);
    add( l );
  }

  public void reset_Scrollbar(){
    speed.setValue(5);
  }

  public void paint( Graphics theG ) {
    Rectangle r = bounds();
    theG.setColor(Color.lightGray);
    theG.drawRect(0, 0, r.width, r.height );
  }

  public boolean handleEvent (Event evt) {
	if (evt.target instanceof Scrollbar) {
	   switch(((Scrollbar)evt.target).getValue()){
		case 1:  theScheduler.slider_num_one = 200;
			 theScheduler.slider_num_two = 100;
			 l.setText("Fastest");
			 break;
		case 2:  theScheduler.slider_num_one = 400;
			 theScheduler.slider_num_two = 200;
			 l.setText("Fast   ");
			 break;
		case 3:  theScheduler.slider_num_one = 600;
			 theScheduler.slider_num_two = 300;
			 l.setText("Fast   ");
			 break;
		case 4:  theScheduler.slider_num_one = 800;
			 theScheduler.slider_num_two = 400;
			 l.setText("Fast   ");
			 break;
		case 5:  theScheduler.slider_num_one = 1000;
			 theScheduler.slider_num_two = 500;
			 l.setText("Normal ");
			 break;
		case 6:  theScheduler.slider_num_one = 1200;
			 theScheduler.slider_num_two = 500;
			 l.setText("Slow   ");
			 break;
		case 7:  theScheduler.slider_num_one = 1400;
			 theScheduler.slider_num_two = 500;
			 l.setText("Slow   ");
			 break;
		case 8:  theScheduler.slider_num_one = 1600;
			 theScheduler.slider_num_two = 600;
			 l.setText("Slow   ");
			 break;
		case 9:  theScheduler.slider_num_one = 1800;
			 theScheduler.slider_num_two = 800;
			 l.setText("Slow   ");
			 break;

		case 10:  theScheduler.slider_num_one = 2000;
			  theScheduler.slider_num_two = 1000;
			 l.setText("Slowest");
			  break;
	   }
	return true;
	}
	else return false;
  }


}
