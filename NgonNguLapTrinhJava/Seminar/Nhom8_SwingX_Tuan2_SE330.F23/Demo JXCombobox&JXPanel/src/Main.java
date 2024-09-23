import java.awt.Dimension;

import javax.swing.SwingUtilities;

import org.jdesktop.swingx.JXFrame;

public class Main {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		 	SwingUtilities.invokeLater(new Runnable() {
				
				@Override
				public void run() {
					// TODO Auto-generated method stub
					new MyJXComboBox().setVisible(true);
				}
			});
	}

}
