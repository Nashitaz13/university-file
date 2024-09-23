import javax.microedition.lcdui.*;
import javax.microedition.midlet.MIDlet;
import javax.microedition.midlet.MIDletStateChangeException;

public class Bai2 extends MIDlet implements CommandListener {

	private Form form;
	private TextField textField;
	private Command exit;
	private StringItem stringItem;

	public Bai2() {
		form = new Form("ItemStateChange Example");
		textField = new TextField("Input :", "", 256, TextField.ANY);
		exit = new Command("Exit", Command.EXIT, 1);
		stringItem = new StringItem("Length ", "" + textField.getString().length());
	}

	protected void destroyApp(boolean arg0) throws MIDletStateChangeException {
		// TODO Auto-generated method stub

	}

	protected void pauseApp() {
		// TODO Auto-generated method stub

	}

	protected void startApp() throws MIDletStateChangeException {
		form.append(textField);
		form.append(stringItem);
		form.addCommand(exit);
		form.setCommandListener(this);
		Display.getDisplay(this).setCurrent(form);
		while (true) {
			stringItem.setText("" + textField.getString().length());
		}
	}

	public void commandAction(Command m, Displayable d) {
		if (m == exit) {
			try {
				destroyApp(false);
				notifyDestroyed();
			} catch (MIDletStateChangeException e) {
				e.printStackTrace();
			}
		}
	}
}
