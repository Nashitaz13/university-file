 //
//  This class handles painting various Memory Hardware
//  components such as the TLB, Pagetable etc.
//
//  Author: Avijit Chakraborty, Joyjeet Bhowmik
//
//  URL: http://earth.usc.edu/~avijitc/final/index.html#Source
//
import java.awt.*;

public class SimulatorDisplayUtils extends VMS {
  //
  //  Data Private to this class
  //

  private int canvasWidth, canvasHeight;
  private int originX, originY;
  private int MMUoX, MMUoY, MMUwidth, MMUheight;
  private final int MMU_BOX_HEIGHT = 350;

  // Here are the colors for the 2 different states
  // (running and sleeping) of a process. Also, declared
  // is the color of the shadow box for each process.
  private Color C_SHADOW        = new Color( 200, 200, 200 );
  private Color C_PROCESS_RUN   = new Color( 100, 210, 250 );
  private Color C_PROCESS_SLEEP = new Color( 215, 235, 250 );

  private final int SHADOW_WIDTH   = 4;
  private final int SHADOW_HEIGHT  = 4;

  // The total number of processes in this simulation
  private final int TOTAL_PROCS    = 4;

  // Details of graphics pertaining to processes
  private final int PROCESS_WIDTH  = 40;
  private final int PROCESS_HEIGHT = 50;
  private int processOriginX, processOriginY;
  private int processSeparation;

  // Details of graphics pertaining to the OS Kernel
  private final Color C_KERNEL_BG = new Color( 200, 255, 196 );
  private int kernelX, kernelY;
  private final int KERNEL_WIDTH = 80;
  private final int KERNEL_HEIGHT= 25;

  // Details of graphics pertaining to TLB (translation lookaside buffer)
  private final int TOTAL_TLB_ENTRIES = 4;
  private final int TLB_WIDTH      = 100;
  private final int TLB_HEIGHT     = 20;
  private int TLBoX, TLBoY;
  private final Color C_TLB_BG = new Color( 240, 240, 180 );

  // Details of graphics pertaining to PT (page table)
  private final int TOTAL_PT_ENTRIES = 32;
  private final int PT_WIDTH         = 15;
  private final int PT_HEIGHT        = 40;
  private int PToX, PToY;
  private final Color C_PT_BG = new Color( 255, 240, 200 );

  // Details of graphics pertaining to MM (main memory)
  private final int TOTAL_MM_CELLS = 16;
  private final int MM_WIDTH       = 25;
  private final int MM_HEIGHT      = 25;
  private int MMoX, MMoY;
  private final Color C_MM_BG = new Color( 255, 195, 180 );

  // Details of graphics pertaining to HD (hard disk)
  private final int HD_WIDTH       = 100;
  private final int HD_HEIGHT      = 60;
  private int HDoX, HDoY;
  private final Color C_HD_BG = new Color( 255, 240, 210 );
  private final Color C_HD_LINES = new Color( 140, 100, 80 );

  // Details of graphics pertaining to connection between
  // various components
  private final Color C_CONN_PASSIVE = new Color( 220, 220, 220 );
  private final Color C_CONN_ACTIVE  = new Color( 255, 0, 0 );

  private Color C_HIT = new Color( 0, 255, 0 );
  private Color C_MISS = new Color( 255, 0, 0 );

  private Graphics theG;

  //
  //  For TEXT Annotation
  //
  private final String procStr[] = {"P1", "P2", "P3", "P4" };
  private final String numStr[] = {"0", "1", "2", "3", "4", "5",
                                          "6", "7", "8", "9", "10", "11",
                                          "12", "13", "14", "15", "16", "17",
                                          "18", "19", "20", "21", "22", "23",
                                          "24", "25", "26", "27", "28", "29",
                                          "30", "31" };


  StatisticPanel s_Statistic;
  //---------------------
  //  The constructor
  //---------------------


  public SimulatorDisplayUtils() {

    //s_Statistic = s;
    canvasWidth  = 573 - 21;
    canvasHeight = 300 - 21;
    originX      = 10;
    originY      = 10;
    //
    //  Process related
    //
    //processOriginX = originX + 40;
    processOriginX = 40;
    processOriginY = 2;
    //processOriginY = originY + 10;
    processSeparation = ((canvasWidth-80) - (TOTAL_PROCS*PROCESS_WIDTH)) /
			( TOTAL_PROCS - 1 ) ;
    //
    //  OS Kernel related
    //
    kernelX = originX + (canvasWidth/2)-(KERNEL_WIDTH/2);
    kernelY = processOriginY + PROCESS_HEIGHT + 25;

    //
    //  The bounding box for MMU
    //
    MMUoX = originX + 15;
    MMUoY = processOriginY + PROCESS_HEIGHT + 80;
    MMUwidth = canvasWidth - 20;
    MMUheight = MMUoY + MMU_BOX_HEIGHT;
    //
    //  TLB related
    //
    TLBoX = MMUoX + 20;
    TLBoY = MMUoY + 100;
    //
    // PT related
    //
    PToX = MMUoX + 20;
    PToY = TLBoY + 180;
    //
    // MM related
    //
    MMoX = MMUoX + TLB_WIDTH + 200;
    MMoY = MMUoY + 20;
    //
    // HD related
    //
    HDoX = MMUoX + TLB_WIDTH + 200;
    HDoY = MMUoY + 160;
  }



  public void changeProcess()
  {
    int temp_pid = theScheduler.getPID();

    //System.out.println ("process id "+temp_pid);
    if ( temp_pid == 0 )
    {
        C_PROCESS_RUN = new Color( 0, 153, 255 );
        C_HIT = new Color( 0, 153, 255 );
    }

    if ( temp_pid == 1 )
    {
        C_PROCESS_RUN = new Color( 255, 255, 153 );
        C_HIT = new Color( 255, 255, 153 );
    }

    if ( temp_pid == 2 )
    {
        C_PROCESS_RUN = new Color( 0, 255, 153 );
        C_HIT = new Color( 0, 255, 153 );
    }

    if ( temp_pid == 3 )
    {
        C_PROCESS_RUN = new Color( 255, 51, 0 );
        C_HIT = new Color( 255, 51,0 );
    }

  }



  private void delay (long Range)
  {
    long ct;
    ct = System.currentTimeMillis();

    while (System.currentTimeMillis() < ct+Range) {}

  }







  //
  // Methods
  // -------------------
  // displayLayout()
  // displayProcess()
  // displayTLB()
  // displayTLB()
  // displayPT()
  // displayVaddr()
  // displayPageFrames()
  // displayDiskAccess()
  //


  //
  //
  //  This is the main Method that needs to be called
  //  when the entire Canvas needs to be updated
  //
  //
  int firstTime = 0;
  public void displayLayout( int drawAll, Graphics g ) {
    int i;
    theG = g;
    //System.out.println ("drawAll: "+drawAll);

    if ( drawAll == 0 )
    {
        //System.out.println ("update_PageTable");
	    displayPT( theScheduler.theMMU[theScheduler.getPID()].getCurPTI(), false );


    }

    if ( drawAll== -1 ) {
      /*if ( firstTime == 0 ){
      	s_Statistic.references();
      	s_Statistic.Page_Fault();
      	s_Statistic.TLB_Misses();
      }*/

      drawShadow( MMUoX, MMUoY, MMUwidth, MMU_BOX_HEIGHT );
      theG.setColor( Color.black );
      theG.drawRect( MMUoX, MMUoY, MMUwidth, MMU_BOX_HEIGHT );
      firstTime++;

      //
      //  the Kernel
      //
      displayKernel();
      theG.setFont( new Font( "TimesRoman", Font.BOLD, 14 ) );
      theG.drawString( "  MMU  ", kernelX+15, kernelY+17 );
      joinKernelToTLB( false );
      //
      //  processes
      //
      for ( i = 0; i < TOTAL_PROCS; i++ ) {
        displayProcess( i, false );
        theG.setFont( new Font( "TimesRoman", Font.BOLD, 14 ) );
	    theG.drawString( procStr[i], processOriginX +
	    i * ( PROCESS_WIDTH+ processSeparation ) + PROCESS_WIDTH/2 - 3,
	    processOriginY+PROCESS_HEIGHT+20 );
      }


      //
      // the TLB
      //
      theG.setFont( new Font( "TimesRoman", Font.BOLD, 14 ) );
      theG.drawString( "TLB", TLBoX+35, TLBoY-10 );
      for ( i=0; i< TOTAL_TLB_ENTRIES; i++ )
      {
	     displayTLB( i, false );
	     //System.out.println ("drawover TLB");
	  }
      //
      // the Page Table
      //
      theG.setFont( new Font( "TimesRoman", Font.BOLD, 14 ) );
      theG.drawString( "Page Table", PToX+200, PToY-10 );
      drawShadow( PToX, PToY, PT_WIDTH*TOTAL_PT_ENTRIES, PT_HEIGHT );
      for ( i=0; i< TOTAL_PT_ENTRIES; i++ )
         displayPT( i, false );

      for ( i=0; i< TOTAL_PT_ENTRIES; i++ )
         displayPTIndex(i);

      //
      // the Physical memory
      //
      theG.setFont( new Font( "TimesRoman", Font.BOLD, 14 ) );
      theG.drawString( "Memory", MMoX+60, MMoY+120 );
      drawShadow( MMoX, MMoY, MM_WIDTH*4, MM_HEIGHT*4 );
      for ( i=0; i< TOTAL_MM_CELLS; i++ ) displayMM( i, false, -1 );

      displayHD();
      theG.setFont( new Font( "TimesRoman", Font.BOLD, 14 ) );
      theG.setColor( Color.black );
      theG.drawString( "Hard Disk", HDoX+20, HDoY+30 );

      //
      //  the Processes
      //
      joinProcessToKernel( true, getRunningProc() );
      for ( i = 0; i < TOTAL_PROCS; i++ )
         if ( i != getRunningProc() ) joinProcessToKernel( false, i );

      joinMMToKernel( false );
      joinTLBToPT( false );
      joinPTToMM( false );
      joinTLBToMM( false );
      joinHDToMM( false );
      joinProcessToKernel( false, 0 );
      joinProcessToKernel( false, 1 );
      joinProcessToKernel( false, 2 );
      joinProcessToKernel( false, 3 );
      //
      //  Erase the text annotations
      //
      theG.setColor( Color.white );
      theG.fillRect( TLBoX+40, TLBoY+90, 100, 40 );
      theG.fillRect( PToX+350, PToY-23, 150, 20 );
      theG.setColor( Color.white );
      theG.fillRect( MMoX+130, MMoY+70, 100, 50 );
    }

/*    if ( (drawAll == 0) )
    {

      System.out.println ("drawAll  "+drawAll);
      changeProcess();
      displayKernel();
      theG.setFont( new Font( "TimesRoman", Font.BOLD, 14 ) );
      theG.drawString( "  MMU  ", kernelX+15, kernelY+17 );
      joinMMToKernel( true );
      displayProcess( getLastRunningProc(), false );
      joinProcessToKernel( false, getLastRunningProc() );
      displayProcess( getRunningProc(), true );
      joinProcessToKernel( true, getRunningProc() );
      //
      // TLB
      //
      joinHDToMM( false );
      joinKernelToTLB( true );
      for ( i=0; i< TOTAL_TLB_ENTRIES; i++ )
      {
	     displayTLB( i, false );
	     //System.out.println ("drawover TLB");
	  }

      //
      // Page Table
      //
      for ( i=0; i< TOTAL_PT_ENTRIES; i++ )
         displayPT( i, false );




    }

*/
    if (drawAll == 1)
    { // Draw Only the Updates
      //
      // Kernel & Process
      //
      if ( getSwitchProcess() )
      {
         //System.out.println ("draw");


         changeProcess();
         for ( i=0; i< TOTAL_TLB_ENTRIES; i++ )
         {
	        displayTLB( i, false );
	        //System.out.println ("drawover TLB");
	     }

         //
         // Page Table
         //
         for ( i=0; i< TOTAL_PT_ENTRIES; i++ )
            displayPT( i, false );

         //setSwitchProcess( false );
      }


      //s_Statistic.references();
      //s_Statistic.action();
      displayKernel();
      theG.setFont( new Font( "TimesRoman", Font.BOLD, 14 ) );
      theG.drawString( "  MMU  ", kernelX+15, kernelY+17 );
      joinMMToKernel( true );
      displayProcess( getLastRunningProc(), false );
      joinProcessToKernel( false, getLastRunningProc() );
      displayProcess( getRunningProc(), true);
      joinProcessToKernel( true,getRunningProc() );



      joinHDToMM( false );
      joinKernelToTLB( true );
      if ( getTlbState() ) {	// TLB hit
	    theG.setColor( Color.white );
	    theG.fillRect( PToX+350, PToY-23, 150, 20 );
        theG.fillRect( MMoX+130, MMoY+70, 100, 50 );

        for (int t = 0; t < 4; t++)
     	    displayTLB( t, false );

	//    displayTLB( getLastTlbHitIndex(), false );
	    displayTLB( getTlbHitIndex(), true );
        //System.out.println("TLB HIT DISPLAY");
        //System.out.print("current: "+getTlbHitIndex() );
        //System.out.println("  last: "+getLastTlbHitIndex() );

        joinTLBToPT( false );
        joinTLBToMM( true );
        joinPTToMM( false );
	    //displayMM( getLastMM(), false, -1 );
	    displayHitMM( getCurMM(), getMMvPageFrame() );


	    theG.setColor( Color.white );
	    theG.fillRect( TLBoX+40, TLBoY+90, 100, 40 );
	    theG.setColor( Color.blue );
        theG.setFont( new Font( "TimesRoman", Font.BOLD, 14 ) );
	    theG.drawString( "TLB hit", TLBoX+45, TLBoY+110 );
        theG.setFont( new Font( "TimesRoman", Font.BOLD, 12 ) );

      }
      else {			// TLB miss
	    //s_Statistic.action();
	    //displayTLB( getLastTlbHitIndex(), false );
        //displayTLB( getTlbHitIndex(), false );
        for (int t = 0; t < 4; t++)
     	    displayTLB( t, false );
        //System.out.println("TLB MISS DISPLAY");
        //System.out.print("current: "+getTlbHitIndex() );
        //System.out.println("  last: "+getLastTlbHitIndex() );
        joinTLBToPT( true );
        joinTLBToMM( false );
	    theG.setColor( Color.white );
	    theG.fillRect( TLBoX+40, TLBoY+90, 100, 40 );
	    theG.setColor( Color.red );
        theG.setFont( new Font( "TimesRoman", Font.BOLD, 14 ) );
	    theG.drawString( "TLB miss", TLBoX+45, TLBoY+110 );
 	    //s_Statistic.TLB_Misses();	//increase statistic_TLB
        //
        // Page Table
            //
        if ( theScheduler.theMMU[theScheduler.getPID()].getPtState() ) {  // PT Hit

            theG.setFont( new Font( "TimesRoman", Font.BOLD, 12 ) );
	        theG.setColor( Color.red );
	        theG.drawString( "         ", MMoX+135, MMoY+80 );
	        theG.drawString( "           ", MMoX+135, MMoY+100 );

            displayPT( theScheduler.theMMU[theScheduler.getPID()].getLastPTI(), false );
	        displayPT( theScheduler.theMMU[theScheduler.getPID()].getCurPTI(), true );
            joinPTToMM( true );
	        //displayMM( getLastMM(), false, -1);
	        displayHitMM( getCurMM(), getMMvPageFrame() );

	        theG.setColor( Color.white );
	        theG.fillRect( PToX+350, PToY-23, 150, 20 );
            theG.setFont( new Font( "TimesRoman", Font.BOLD, 14 ) );
	        theG.setColor( Color.blue );
	        theG.drawString( "Page Table hit", PToX+360, PToY-10 );

	        theG.setColor( Color.white );
	        theG.fillRect( MMoX+130, MMoY+70, 100, 50 );

        }
        else {
            // PageFault
	        //s_Statistic.action();
            joinPTToMM( false );
            joinTLBToPT( false );
            joinKernelToTLB( false );
            joinHDToMM( true );

	        theG.setColor( Color.white );
	        theG.fillRect( PToX+350, PToY-23, 150, 20 );
            theG.setFont( new Font( "TimesRoman", Font.BOLD, 14 ) );
	        theG.setColor( Color.red );
	        theG.drawString( "Page Fault", PToX+360, PToY-10 );
	        //s_Statistic.Page_Fault();

	        // Swapping

	        theG.setColor( Color.white );
	        theG.fillRect( MMoX+130, MMoY+70, 100, 50 );
            theG.setFont( new Font( "TimesRoman", Font.BOLD, 12 ) );
	        theG.setColor( Color.red );
	        theG.drawString( "Paging in", MMoX+135, MMoY+80 );
	        theG.drawString( "Updating PT", MMoX+135, MMoY+100 );
	        displayMM( getCurMM(), true, getMMvPageFrame() );

            displayPT( theScheduler.theMMU[theScheduler.getPID()].getLastPTI(), false );
	        displayPT( theScheduler.theMMU[theScheduler.getPID()].getCurPTI(), false );
        }
      }
    }
  }		//  END of Update //

  //
  //  This Method displays the given process block
  //  in the appropriate state.
  //
  //  Input:  Graphics Object
  //	      process ID
  //	      state --  true (running)
  //	     		false (sleep)
  protected void
  displayProcess( int processID, boolean state ) {
    int  oX, oY;
    oX = processOriginX + processID * (PROCESS_WIDTH+processSeparation);
    oY = processOriginY;
    theG.setFont( new Font( "TimesRoman", Font.BOLD, 14 ) );
    if ( processID == 0 )
    {
        C_PROCESS_SLEEP = new Color( 0, 153, 255 );
    }

    if ( processID == 1 )
    {
        C_PROCESS_SLEEP = new Color( 255, 255, 153 );
    }

    if ( processID == 2 )
    {
        C_PROCESS_SLEEP = new Color( 0, 255, 153 );
    }

    if ( processID == 3 )
    {
        C_PROCESS_SLEEP = new Color( 255, 51, 0 );
    }



    if ( state ) {
      theG.setColor( C_PROCESS_RUN );
      theG.fillRect( oX, oY, PROCESS_WIDTH, PROCESS_HEIGHT );
      drawShadow( oX, oY, PROCESS_WIDTH, PROCESS_HEIGHT );
      theG.setColor( Color.black );
      theG.drawRect( oX, oY, PROCESS_WIDTH, PROCESS_HEIGHT );
      theG.setColor( Color.black );
      theG.drawString( "Exec ", oX+5, oY+15 );
      theG.setFont( new Font( "TimesRoman", Font.BOLD, 14 ) );
      theG.drawString( Integer.toString( gimmePageNum ),
	  oX+PROCESS_WIDTH/3, oY+35 );
    }
    else {
      theG.setColor( C_PROCESS_SLEEP );
      theG.fillRect( oX, oY, PROCESS_WIDTH, PROCESS_HEIGHT );
      drawShadow( oX, oY, PROCESS_WIDTH, PROCESS_HEIGHT );
      theG.setColor( Color.black );
      theG.drawRect( oX, oY, PROCESS_WIDTH, PROCESS_HEIGHT );
      //theG.setColor( Color.black );
      theG.setFont( new Font( "TimesRoman", Font.BOLD, 10 ) );
      theG.drawString( "Sleep", oX+10, oY+30 );
    }

    theG.setFont( new Font( "TimesRoman", Font.BOLD, 14 ) );
    theG.setColor( Color.black );
  }

  //
  //  This method displays the OS Kernel Box with
  //  the virtual page number that is requested by
  //  the running process
  //
  public void displayKernel() {
    theG.setColor( C_KERNEL_BG );
    theG.fillRect( kernelX, kernelY, KERNEL_WIDTH, KERNEL_HEIGHT );
    drawShadow( kernelX, kernelY,  KERNEL_WIDTH, KERNEL_HEIGHT );
    theG.setColor( Color.black );
    theG.drawRect( kernelX, kernelY,  KERNEL_WIDTH, KERNEL_HEIGHT );
  }

  //
  //  This method draws the TLB Block
  //  To update a specific TLB entry, call UpdateTLB()
  //
  //  Input: Graphics Object
  //
  public void displayTLB( int entryNum, boolean hit ) {
     int oX, oY;

     oX = TLBoX;
     oY = TLBoY + entryNum * TLB_HEIGHT;

     if ( hit )
       theG.setColor( C_HIT );
     else
       theG.setColor( C_TLB_BG );
     theG.fillRect( oX, oY, TLB_WIDTH, TLB_HEIGHT );
     if ( entryNum == (TOTAL_TLB_ENTRIES-1))
        drawShadow( oX, oY, TLB_WIDTH, TLB_HEIGHT );
     theG.setColor( C_SHADOW );
     theG.fillRect( oX+TLB_WIDTH+1,oY+SHADOW_HEIGHT,SHADOW_WIDTH, TLB_HEIGHT );

     theG.setColor( Color.black );
     theG.drawRect( oX, oY, TLB_WIDTH, TLB_HEIGHT );
     theG.drawLine( oX+TLB_WIDTH/2, oY, oX+TLB_WIDTH/2, oY+TLB_HEIGHT );
     theG.setColor( Color.black );
     theG.setFont( new Font( "TimesRoman", Font.BOLD, 14 ) );

        if ( theScheduler.theMMU[theScheduler.getPID()].TLB_TAG[entryNum] == -1 ) {
        theG.drawString( "E", oX+20, (oY+15));
        theG.drawString( "E", oX+70, (oY+15));
        }
        else {
            theG.drawString( Integer.toString( theScheduler.theMMU[theScheduler.getPID()].TLB_TAG[entryNum]), oX+20, (oY+15));
            theG.drawString( Integer.toString( theScheduler.theMMU[theScheduler.getPID()].TLB_DATA[entryNum]), oX+70, (oY+15));
        }


  }


  //
  // This method will draw the indeces of the page table
  //
  public void displayPTIndex (int entryNum)
  {
    int oX, oY;

    oX = PToX + entryNum *PT_WIDTH;
    oY = PToY + 18;
    theG.setColor( Color.black );
    theG.setFont( new Font( "TimesRoman", Font.PLAIN, 10 ) );
    theG.drawString (Integer.toString(entryNum), oX+4, oY+35);
  }

  //
  // This method draws the Page Table block in the window.
  // To update a specific page table entry, call UpdatePT()
  //
  // Input: Graphics Object
  //
  public void displayPT( int entryNum, boolean hit ) {
     int oX, oY;
     int run = theScheduler.getPID();

     oX = PToX + entryNum * PT_WIDTH;
     oY = PToY;

     if ( hit )
       theG.setColor( C_HIT );
     else
       theG.setColor( C_PT_BG );
     theG.fillRect( oX, oY, PT_WIDTH, PT_HEIGHT );
     theG.setColor( Color.black );
     theG.drawRect( oX, oY, PT_WIDTH, PT_HEIGHT );
     theG.setColor( Color.black );
     theG.setFont( new Font( "TimesRoman", Font.PLAIN, 10 ) );
     theG.drawString( Integer.toString( theScheduler.theMMU[run].PT_STATE[entryNum] ), oX+4, oY+10 );
     theG.drawLine( oX, oY+15, oX+PT_WIDTH, oY+15 );
     //System.out.println ("PT_NUM: "+run);
     if ( theScheduler.theMMU[run].PT_NUM[entryNum] == -1 )
       theG.drawString( "E", oX+4, oY+35 );
     else
       theG.drawString( Integer.toString( theScheduler.theMMU[run].PT_NUM[entryNum] ), oX+4, oY+35 );

  }

  //
  //
  // Input: Graphics Object
  //
  public void displayHitMM( int entryNum, int vPageFrame )
  {
     int oX, oY;

     oX = MMoX + ( entryNum%4 ) * MM_WIDTH;
     if ( entryNum == 0 ) oY = MMoY;
     else oY = MMoY + ( entryNum/4 ) * MM_HEIGHT;

     theG.setFont( new Font( "TimesRoman", Font.PLAIN, 10 ) );
     for ( int i = 0; i < 4; i++)
     {
        theG.setColor( Color.black );
        theG.drawRect( oX, oY, MM_WIDTH, MM_HEIGHT );
        theG.setColor( C_HIT );
        theG.fillRect( oX, oY, MM_WIDTH, MM_HEIGHT );
        theG.setColor( Color.white );
        theG.fillRect( oX, oY, MM_WIDTH, MM_HEIGHT );
        delay(20);
        theG.setColor( C_HIT );
        theG.fillRect( oX, oY, MM_WIDTH, MM_HEIGHT );


     }

     theG.setColor( Color.black );
     theG.drawRect( oX, oY, MM_WIDTH, MM_HEIGHT );
     theG.drawString( Integer.toString( entryNum ), oX+4, oY+10 );

     theG.setFont( new Font( "TimesRoman", Font.PLAIN, 12 ) );
     if (vPageFrame < 0)
        theG.drawString (" ", oX+8, oY+21);
     else
        theG.drawString( Integer.toString( vPageFrame ), oX+8, oY+21 );

  }



  public void displayMM( int entryNum , boolean highLight, int vPageFrame ) {
     int oX, oY;

     oX = MMoX + ( entryNum%4 ) * MM_WIDTH;
     if ( entryNum == 0 ) oY = MMoY;
     else oY = MMoY + ( entryNum/4 ) * MM_HEIGHT;

     theG.setFont( new Font( "TimesRoman", Font.PLAIN, 10 ) );

     if ( highLight )
       theG.setColor( C_HIT );
     else
       theG.setColor( C_MM_BG );
     theG.fillRect( oX, oY, MM_WIDTH, MM_HEIGHT );
     theG.setColor( Color.black );
     theG.drawRect( oX, oY, MM_WIDTH, MM_HEIGHT );
     theG.drawString( Integer.toString( entryNum ), oX+4, oY+10 );

     theG.setFont( new Font( "TimesRoman", Font.PLAIN, 12 ) );
     if (vPageFrame < 0)
        theG.drawString (" ", oX+8, oY+21);
     else
        theG.drawString( Integer.toString( vPageFrame ), oX+8, oY+21 );
  }

  //
  // This method draws the hard disk in the window.
  //
  // Input: Graphics Object
  //
  public void displayHD( ) {
     int oX, oY;

     oX = HDoX;
     oY = HDoY;

     theG.setColor( C_HD_BG );
     theG.fillRect( oX, oY, HD_WIDTH, HD_HEIGHT );

     theG.setColor( C_HD_LINES );

     drawShadow( oX, oY, HD_WIDTH, HD_HEIGHT );
     theG.setColor( Color.black );
     theG.drawRect( oX, oY, HD_WIDTH, HD_HEIGHT );

     theG.setColor( C_HD_LINES );
     theG.fillRect( oX+1, oY+HD_HEIGHT-(HD_HEIGHT/3),HD_WIDTH-2 , 2 );

     theG.setColor( Color.white );
     theG.fillRect( oX+1, oY+HD_HEIGHT-(HD_HEIGHT/3)+3, HD_WIDTH-2, 2 );

     theG.setColor( Color.green );
     theG.fillRect( oX+(HD_WIDTH-HD_WIDTH*1/5), oY+HD_HEIGHT-(HD_HEIGHT/3),4,4 );

     theG.setColor( Color.red );
     theG.fillRect( oX+(HD_WIDTH-HD_WIDTH*1/5)+5,oY+HD_HEIGHT-(HD_HEIGHT/3),4,4);
  }
  //
  //  The following method is to draw the connection from
  //  one component to another
  //
  //  Note: The y2 corordinate of this method uses an
  //  absolute number.  Need to change that in future.
  //
  public void joinKernelToTLB( boolean blink ) {
    if ( blink )
      theG.setColor( C_CONN_ACTIVE );
    else
      theG.setColor( C_CONN_PASSIVE );

    theG.fillRect( kernelX+KERNEL_WIDTH/3-1, kernelY+KERNEL_HEIGHT+6, 3, 18 );
    theG.fillRect( TLBoX+TLB_WIDTH/4, kernelY+KERNEL_HEIGHT+6+18,
		   (kernelX+KERNEL_WIDTH/3)-(TLBoX+TLB_WIDTH/4)+2, 3 );
    theG.fillRect( TLBoX+TLB_WIDTH/4, kernelY+KERNEL_HEIGHT+6+18,
		   3, TLBoY - (kernelY+KERNEL_HEIGHT+6+18) - 2 );
  }
  //
  //  The following method is to draw the connection from
  //  one components to the other
  //
  //  Note: The y2 corordinate of this method uses an
  //  absolute number.  Need to change that in future.
  //
  public void joinTLBToPT( boolean blink ) {
    if ( blink )
      theG.setColor( C_CONN_ACTIVE );
    else
      theG.setColor( C_CONN_PASSIVE );

    theG.fillRect( TLBoX+TLB_WIDTH/4, TLBoY+TLB_HEIGHT*TOTAL_TLB_ENTRIES,
		   3, PToY - (TLBoY+TLB_HEIGHT*TOTAL_TLB_ENTRIES) - 2 );
  }
  //
  //  The following method is to draw the connection from
  //  one components to the other
  //
  //  Note: The y2 corordinate of this method uses an
  //  absolute number.  Need to change that in future.
  //
  public void joinPTToMM( boolean blink ) {
    if ( blink )
      theG.setColor( C_CONN_ACTIVE );
    else
      theG.setColor( C_CONN_PASSIVE );

    theG.fillRect( 220, 245, 3, PToY-245 - 2 );
    theG.fillRect( 220, 245, 104, 3 );
  }
  //
  //  The following method is to draw the connection from
  //  one components to the other
  //
  //  Note: The y2 corordinate of this method uses an
  //  absolute number.  Need to change that in future.
  //
  public void joinTLBToMM( boolean blink ) {
    if ( blink )
      theG.setColor( C_CONN_ACTIVE );
    else
      theG.setColor( C_CONN_PASSIVE );

    theG.fillRect( TLBoX+TLB_WIDTH+2, 280, 37, 3 );
    theG.fillRect( TLBoX+TLB_WIDTH+2+35, 195, 3, 87 );
    theG.fillRect( TLBoX+TLB_WIDTH+2+35, 195, 142, 3 );
  }
  //
  //  The following method is to draw the connection from
  //  one components to the other
  //
  //  Note: The y2 corordinate of this method uses an
  //  absolute number.  Need to change that in future.
  //
  public void joinMMToKernel( boolean blink ) {
    if ( blink )
      theG.setColor( C_CONN_ACTIVE );
    else
      theG.setColor( C_CONN_PASSIVE );

    theG.fillRect( kernelX+(KERNEL_WIDTH*2/3)+65, kernelY+KERNEL_HEIGHT+18+6,
      3, 24);
    theG.fillRect( kernelX+(KERNEL_WIDTH*2/3), kernelY+KERNEL_HEIGHT+18+6,
      65, 3);
    theG.fillRect( kernelX+(KERNEL_WIDTH*2/3), kernelY+KERNEL_HEIGHT+6,
      3, 18 );

  }
  //
  //  Disk to Main Memory Connection
  //
  public void joinHDToMM( boolean blink ) {
    if ( blink )
      theG.setColor( C_CONN_ACTIVE );
    else
      theG.setColor( C_CONN_PASSIVE );


    theG.fillRect( HDoX + (HD_WIDTH/2), HDoY-2-35, 3, 35 );
  }
  //
  //  Connection between a Process and the Kernel
  //
  public void joinProcessToKernel( boolean blink, int pid ) {
    int oX, oY;
    if ( blink )
      theG.setColor( C_CONN_ACTIVE );
    else
      theG.setColor( C_CONN_PASSIVE );

    if ( pid == 0 ) {
       oX = processOriginX + PROCESS_WIDTH + SHADOW_WIDTH + 1 ;
       oY = processOriginY + PROCESS_HEIGHT/2;
       theG.fillRect( oX, oY, processSeparation/2, 3 );

       theG.fillRect( oX + processSeparation/2, oY,
         3, (kernelY+(KERNEL_HEIGHT/2))-oY );

       theG.fillRect( oX + processSeparation/2, kernelY+(KERNEL_HEIGHT/2),
         kernelX-(oX+processSeparation/2), 3 );
    }
    if ( pid == 1 ) {
       oX = processOriginX +
            2*PROCESS_WIDTH+processSeparation + SHADOW_WIDTH - 1;
       oY = processOriginY + PROCESS_HEIGHT/2;
       theG.fillRect( oX, oY, kernelX+(KERNEL_WIDTH/3) - oX, 3 );
       theG.fillRect( kernelX+(KERNEL_WIDTH/3), oY, 3, kernelY-oY);

    }
    if ( pid == 2 ) {
       oX = processOriginX + pid * (PROCESS_WIDTH+processSeparation) - 1;
       oY = processOriginY + PROCESS_HEIGHT/2;
       theG.fillRect( kernelX+2*(KERNEL_WIDTH/3), oY,
         oX - (kernelX+2*(KERNEL_WIDTH/3)), 3 );
       theG.fillRect( kernelX+2*(KERNEL_WIDTH/3), oY, 3, kernelY-oY);
    }
    if ( pid == 3 ) {
       oX = processOriginX + pid * (PROCESS_WIDTH+processSeparation) - 1;
       oY = processOriginY + PROCESS_HEIGHT/2;
       theG.fillRect( oX-processSeparation/2, oY, processSeparation/2, 3 );
       theG.fillRect( oX-processSeparation/2, oY,
         3, (kernelY+(KERNEL_HEIGHT/2))-oY );
       theG.fillRect( kernelX+KERNEL_WIDTH+SHADOW_WIDTH+1,
         kernelY+(KERNEL_HEIGHT/2),
         oX-(processSeparation/2)-(kernelX+KERNEL_WIDTH+2), 3);
    }
  }

  //
  //  For drawing shadow around a rectangle
  //
  private void drawShadow( int x1,int y1, int w, int h ) {
      theG.setColor( C_SHADOW );
      theG.fillRect( x1+w+1, y1+1+SHADOW_HEIGHT, SHADOW_WIDTH, h );
      theG.fillRect( x1+1+SHADOW_WIDTH, y1+1+h, w, SHADOW_WIDTH );
  }

}

