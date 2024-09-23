//
//  Memory Management Unit for the Virtual Memory Simulation
//
//  Author: Avijit Chakraborty, Joyjeet Bhowmik
//
//  URL: http://earth.usc.edu/~avijitc/final/index.html#Source
//
public class MMU extends VMS{
  //
  // Data used by this class
  //


  public int PT_STATE[];
  public int PT_NUM[];
  public static int counter = 0;


  int gimmePageNum;


  private int	vmPages = 0;		// Total Virtual memory pages
  private int	pmPages = 0;		// Total Physical memory pages
  private int	tlbEntries = 0;		// Total TLB entries


  //----------------------------0000
  //    Here are the data accesses by the Shedular
  private int vAddr;
  private int pAddr;
  private int pmHitIndex, pmSwapIndex;
  private boolean pageState;  //true = hit, false = miss
  private boolean pageTableState;       //true = hit, false = miss
  private int curPTI, lastPTI;


  public int getVAddr()
  {
    return vAddr;
  }

  public int getPAddr()
  {
    return pAddr;
  }


  public void setPageState (boolean what)
  {
    pageState = what;
  }

  public boolean getPageState()
  {
    return pageState;
  }

  public boolean getPtState()
  {
    return pageTableState;
  }

  public int getCurPTI()
  {
    return (curPTI);
  }

  public int getLastPTI()
  {
    return (lastPTI);
  }




  //--------------------
  //  The constructor
  //--------------------
  public MMU( int vmPages, int pmPages, int tlbEntries )
  {
    int i;

    gimmePageNum = -1;

    this.vmPages = vmPages;
    this.pmPages = pmPages;
    this.tlbEntries = tlbEntries;

    TLB_TAG 	= new int[tlbEntries];
    TLB_DATA	= new int[tlbEntries];
    TLB         = new int[tlbEntries];

    VMS.TLB_LRU	= 0;
    for (i=0; i < tlbEntries; i++ )
    {
      TLB_TAG[i]  = -1;
      TLB_DATA[i] = -1;
      TLB[i] = 0;
    }


    PT_STATE	= new int[vmPages];
    PT_NUM	= new int[vmPages];
    for (i=0; i<vmPages; i++ )
    {
      PT_STATE[i] = 0;
      PT_NUM[i]   = -1;
    }

    PM_LRU	= 0;
    PM_IN_TLB	= new int[pmPages];
    PM_IN_PT	= new int[pmPages];
    PM          = new int[pmPages];
    for (i=0; i<pmPages; i++ )
    {
      PM_IN_TLB[i] = -1;
      PM_IN_PT[i] = -1;
      PM[i] = 0;
    }

  }


  //--------------------------------
  // Methods available to the world
  //--------------------------------


  public void reset()
  {

    int i;
    TLB_LRU = 0;
    PM_LRU= 0;
    counter = 0;

    for (i = 0; i<TLB_TAG.length; i++)
    {
        TLB_TAG[i] = -1;
        TLB_DATA[i] = -1;
        TLB[i] = 0;
    }
    for (i = 0; i<PT_STATE.length; i++)
    {
        PT_STATE[i] = 0;
        PT_NUM[i] = -1;
    }
    for (i = 0; i<PM_IN_PT.length; i++)
    {
        PM_IN_TLB[i] = -1;
        PM_IN_PT[i] = -1;
        PM[i] = 0;
    }
  }




  //
  //  This method converts virtual page number
  //  to physical page number. Returns false in case
  //  of page fault
  //
  //  input: virtual page number
  //  output: physical page number (in case of hit)
  //  returns: true if hit or false if Page fault
  //
  //  will return 0 if TLB hit
  //  will return 1 if PT hit
  //  will return 2 if PT miss


  public int virtualToPhysical( int vPageNum )
  {
    int pPageNum = PMgetLRU();
    boolean found;
    int tlbIndex = -1;
    int oldTLBIndex;
    int i,tmp;

    found = false;

    if (getTlbState() )
    {
      setLastTlbHitIndex (getTlbHitIndex() );
      //setLastMM( getCurMM() );
    }

    if ( getPtState() )
    {
        lastPTI = getCurPTI() ;
        //setLastMM( getCurMM() );
    }

    // Search for if already in TLB
    for (i = 0; i < tlbEntries; i++ )
    {
      pPageNum = TLBgetEntry( i, vPageNum );
      if ( pPageNum != -1 )
      {
	    found = true;
	    tlbIndex = i;
	    break;
      }
    }
    setSwitchProcess( false );

    if ( (counter % getNum_Process_Exec() ) == 0)
    {

       setSwitchProcess ( true );
       //cccctheCanvas.display();
    }
    counter++;

    if ( found )
    { // TLB Hit
      //System.out.println( "TLB hit for " + vPageNum );
      setTlbState(true);
      setTlbHitIndex( tlbIndex );
      //cccsetLastTlbHitIndex( tlbIndex );

      setCurMM( pPageNum );
      setMMvPageFrame(vPageNum);
      theCanvas.display();
      TLBincrLRU( tlbIndex );
      PMincrLRU( pPageNum );
/*    System.out.println ("After PMincrLRU ...");
    for (int c=0; c<16; c++)
       System.out.println (PM[c]);
       */
      //System.out.println ("PMINDEX: "+pPageNum);
      return 0;
    }
    else {				// TLB Miss
      // Check the Page table
      //System.out.println( "TLB miss, searching PT " );
      setTlbState( false );
      theCanvas.display();
      incr_TLB_Miss();
      pPageNum = PTgetEntry (vPageNum, pPageNum);
      if ( pPageNum != -1 ) {
	    //
	    // Page Table Hit
	    //
            //System.out.println( "PT Hit: pPgNum " + pPageNum );
	    pageTableState = true;
	    pAddr = pPageNum;
	    vAddr = vPageNum;
	    curPTI = vPageNum;
	    setCurMM( pPageNum );
	    setMMvPageFrame( vPageNum );
        PMincrLRU( pPageNum );

/*    System.out.println ("After PMincrLRU ...");
    for (int c=0; c<16; c++)
       System.out.println (PM[c]);
*/

        //System.out.println ("PMINDEX: "+pPageNum);

        theCanvas.display();

	    // Now update the TLB entry
        tlbIndex = TLBsetEntry(vPageNum, pPageNum );
        //setLastTlbHitIndex( tlbIndex );
        TLBincrLRU( tlbIndex );
        //tlbState = false;
        theCanvas.display();
        return 1;
      }
      else {						// Page Fault
	    pageTableState = false;
        setTlbState( false );

	    setCurMM( PMgetLRU() );
	    curPTI = vPageNum;
	    incr_PT_Miss();
	    return(2);
      }
    }

  }

  //
  //  The following method swaps a page from disk
  //  to the Physical memory.  In this implementtion`
  //  we don't acutally move pages, but just fake it
  //  by updating proper fields
  //
  //  1) Get the index of the LRU page from memory and
  //     replace the content with the page number of the
  //     new page
  //  2) Update the Page Table
  //  3) Update TLB
  //
  public void swapIn ( int vPageNum )
  {
    int i, oldPageIndex, oldTLBIndex;
    int tlbIndex, oldest;
    int tmp;

     // Refresh the Graphics
    theCanvas.display();

    //oldPageIndex = PMgetLRU();

    //
    // Now we  need to update Page table
    // and TLB
    //
    oldPageIndex = PMgetLRU();
    oldTLBIndex = TLBgetLRU();
    //System.out.println ("PM_LRU: "+oldPageIndex);


    tlbIndex = TLBsetEntry(vPageNum, oldPageIndex);
    //cccsetLastTlbHitIndex( oldTLBIndex );
    setTlbHitIndex( oldTLBIndex );

    TLBincrLRU( oldTLBIndex );

    //PMresetLRU( oldPageIndex );

    // Update the Page Table
    //
    theCanvas.display();
    //System.out.println (" PM_index "+oldPageIndex);
    pageTableState = false;
    curPTI = vPageNum;

    PTsetEntry( vPageNum, oldPageIndex );
    //PM_IN_PT[oldPageIndex] = theScheduler.getPID();
    PMincrLRU( oldPageIndex );
  /*  System.out.println ("After PMincrLRU ...");
    for (i=0; i<16; i++)
       System.out.println (PM[i]);
*/
    //System.out.println (" PM_Oldest_Index :"+getPM_LRU()):

    setCurMM( oldPageIndex );
    setMMvPageFrame( vPageNum );

    theCanvas.display();
    //return( oldPageIndex );
  }

  //


  //
  //  These are Page Table related
  //
  private void PTsetEntry( int index, int pmPageNum )
  {
    PT_STATE[index]	= 1;
    PT_NUM[index]	= pmPageNum;
  }


  private int PTgetEntry( int vPageNum, int pmPageNum )
  {
    pmPageNum = PT_NUM[vPageNum];
    if ( PT_STATE[vPageNum] == 1 )
      return pmPageNum;
    else
      return -1;
  }

  public void dumpPT( int pmPageNum, boolean what )
  {
    int i;
    int hit;

    for ( i=0; i < vmPages; i++)
    {
        if ( (PT_NUM[i] == pmPageNum) && (PT_STATE[i]==1) )
        {
           PT_NUM[i] = -1;
           PT_STATE[i] = 0;
           //hit = i
           //System.out.println( "PT_NUM["+i+"] "+PT_STATE[i]+" "+PT_NUM[i] );
           break;
        }
    }
    if (what)
    {
         pageTableState = false;
         curPTI = i ;
         //System.out.println ("update: "+i);
         setUpdatePT(true);
	     VMS.theCanvas.updatePTonly();
	     //System.out.println ("after: ....");
	}



  }

/*
  private void dumpPT()
  {
    int i;

    for(i=0; i<this.PT_NUM.length; i++)
      System.out.println( "PT["+i+"] "+PT_STATE[i]+" "+PT_NUM[i] );
  }
*/

  //
  //  Thsese are Physical memory related
  //
}

