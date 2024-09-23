//
// This is the scheduler for the 4 processes in this simulation.
// Processes are scheduled in a round-robin way based on the
// currently running process faulting on a page (whence the next
// process (numerically) is scheduled. The page for which any
// process faults is stored in an array (corresponding to the
// location for that process). Then, the process() method is
// called with the particular array location value for the process
// being scheduled. The default value (if no page fault) is -1.
//
//  Author: Avijit Chakraborty, Joyjeet Bhowmik
//
//  URL: http://earth.usc.edu/~avijitc/final/index.html#Source
//
import java.lang.*;
import java.awt.*;

public class Scheduler extends SimulatorDisplayUtils implements Runnable
{
  //private static int PageFaultTbl[] = new int[4];
  private int pid;
  public static Thread schdThread;
  public static int slider_num_one = 1000;
  public static int slider_num_two = 500;

  public MMU theMMU[] = new MMU[4];

  public int getPID()
  {
    return pid;
  }

  public Scheduler()
  {
    int i;

    for (i=0; i < 4; i++ )
    {
        theMMU[i] = new MMU( 32, 16, 4 );
        //PageFaultTbl[i] = -1;
    }
    pid = 0;


  }


  public void start()
  {
    if ( schdThread == null )
    {
      schdThread = new Thread( this );
      schdThread.start();
    }
    //pid = 0;
    schdThread.resume();
    //System.out.println( "schedular.start called" );
  }

  public void run()
  {
      pid = 0;
      setLastRunningProc( pid );
      setRunningProc( pid );
      int howMany = RandomNumGenerate( 2 )* 2 + 4;
      theMMU[pid].setPageState( false );
      int counter;

      while( schdThread != null )
      {
        setNum_Process_Exec( howMany );
	    setSwitchProcess(true);

        for (counter = 0; counter < howMany; counter++)
        {
    	    Process( pid );


	        try { Thread.sleep( slider_num_one ); }
	        catch( InterruptedException e ) {}
	    }
	    setLastRunningProc( pid );
	    pid = (pid+1) % 4;
	    //theCanvas.display();
	    setRunningProc( pid );
	    theMMU[pid].setPageState( false );
	    theMMU[pid].counter = 0;
        TLBresetLRU();
	    howMany = RandomNumGenerate( 2 )* 2 + 4;
      }
      schdThread = null;

  }

  public void stop()
  {
    //System.out.println( "schedular.stop called" );
    if ( schdThread != null )
      schdThread.suspend();
  }


  public void resetSim()
  {
    //System.out.println( "schedular.resetSim called" );
    if ( schdThread != null )
    schdThread.stop();
    schdThread = null;
    //  pid = 0;
    VMS.restartSim();
    for (int i = 0; i <4; i++)
    {
        theMMU[i].reset();
        theMMU[i].counter = 0;
        //System.out.println( "counter "+theMMU[i].counter );
    }
  }


  //
  // This method generates a random page frame number and
  // requests for that page from the memory management unit.
  // If there is a page fault, it returns the page frame
  // number which faulted, else it just continues generating
  // requests for random page frame numbers.
  //
  public void Process( int pid )
  {
    int status;
    boolean PageFault = false;
    boolean updatePT;
    int physicalPageFrame;
    int id_process = pid;
    int temp,temp2=-1;


        // then generate a random page frame number.
        gimmePageNum = Scheduler.RandomNumGenerate( 32 );
	    //System.out.println( "Gimme " + gimmePageNum );
     	//setVAddr( gimmePageNum );

     	incr_Reference();

        // Generate a request for the page from the memory manager
        status = theMMU[pid].virtualToPhysical( gimmePageNum );


        // If the requested page is not in memory
/*        if ( status == 2 )
        {
            PageFault = true;
	        //System.out.println( "Oops ! Page Fault for " + gimmePageNum );
	        theMMU[pid].setPageState( false );
            //theMMU[pid].swapIn( gimmePageNum );
        }
*/
        if (status == 2)
        {

            //before swap check if there are already existence
            //set that certain frame to empty
            temp2 = getCurMM();
            //System.out.println ("currMM: "+temp2);

            temp = getPMinPT( temp2 );
            if ( temp == id_process )
                updatePT = true;
            else updatePT = false;

//              System.out.println ("check "+temp);
            if ( temp != -1 )
            {
                //System.out.println ("what MMU: "+temp);
                theMMU[temp].dumpPT( temp2, updatePT );

	            //setSwitchProcess(true);
                // System.out.println ("PT_NUM1:"+theMMU[temp].PT_NUM[1]);
            }

            // Get the last faulted page from disk
            theMMU[pid].swapIn( gimmePageNum );
            PM_IN_PT[temp2] = pid;
	        theCanvas.display();

	        //System.out.println( "Page "+gimmePageNum + " swapped in from disk" );

        }
  }



  public static int RandomNumGenerate( int Range )
  {
    double tmpNum;
    int    randomNum;

    tmpNum = Math.random();
    randomNum = (int)(tmpNum*1000.0);
    return( randomNum % Range );
  }
}
