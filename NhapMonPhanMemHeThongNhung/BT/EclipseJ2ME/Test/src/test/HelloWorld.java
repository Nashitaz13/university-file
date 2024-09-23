package test;

import javax.microedition.lcdui.*;
import javax.microedition.midlet.MIDlet;
import javax.microedition.midlet.MIDletStateChangeException;

public class HelloWorld extends MIDlet {
	Form form ;
	
	public HelloWorld() {
		form = new Form("HelloWorld");
	
	}

	protected void destroyApp(boolean unconditional)
			throws MIDletStateChangeException {
		// TODO Auto-generated method stub

	}

	protected void pauseApp() {
		// TODO Auto-generated method stub

	}

	protected void startApp() throws MIDletStateChangeException {
		// TODO Auto-generated method stub
		Display.getDisplay(this).setCurrent(form);
	}

}
