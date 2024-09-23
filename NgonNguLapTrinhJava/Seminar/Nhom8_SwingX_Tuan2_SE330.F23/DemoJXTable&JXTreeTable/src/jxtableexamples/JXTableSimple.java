package jxtableexamples;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Component;
import java.awt.Dimension;
import java.util.regex.Pattern;

import javax.swing.JFrame;
import javax.swing.JScrollPane;
import javax.swing.event.DocumentEvent;
import javax.swing.event.DocumentListener;
import javax.swing.table.AbstractTableModel;
import javax.swing.table.TableModel;
import javax.swing.table.TableRowSorter;

import org.jdesktop.swingx.JXLabel;
import org.jdesktop.swingx.JXPanel;
import org.jdesktop.swingx.JXTable;
import org.jdesktop.swingx.JXTextField;
import org.jdesktop.swingx.decorator.ColorHighlighter;
import org.jdesktop.swingx.decorator.ComponentAdapter;
import org.jdesktop.swingx.decorator.HighlightPredicate;
import org.jdesktop.swingx.decorator.HighlighterFactory;
import org.jdesktop.swingx.sort.RowFilters;

public class JXTableSimple extends JFrame {

	public String[] columnsName = { "StudentID", "Name", "PassToeic" };

	private Object[][] dataStudent = {
			{ "12520034", "Nguyễn Văn Cảnh", Boolean.FALSE },
			{ "12520042", "Nguyễn Sỹ Mạnh Cường", Boolean.FALSE },
			{ "12520061", "Hoàng Minh Dương", Boolean.FALSE },
			{ "12520125", "Mai Tuấn Linh", Boolean.FALSE },
			{ "12520234", "Trần Văn Nam", Boolean.FALSE },
			{ "12520364", "Lê Thu Trang", Boolean.FALSE },
			{ "12520726", "Bùi Thị Xuân", Boolean.FALSE }, };

	//
	private AbstractTableModel dataModel;
	private JXTable table = new JXTable();
	private JXTextField textFilter = new JXTextField();
	
	private TableRowSorter<TableModel> sorter;


	// Constructor
	public JXTableSimple() {
		JFrame frame = new JFrame("Simple JXTable");
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

		init();
		
		JScrollPane scrollPane = new JScrollPane(table);
		frame.add(scrollPane,BorderLayout.CENTER);
		
		JXPanel panel = new JXPanel(new BorderLayout());
		
		JXLabel labelFilter = new JXLabel("Filter:");
		
		panel.add(labelFilter,BorderLayout.WEST);
		
		panel.add(textFilter,BorderLayout.CENTER);
		
		frame.add(panel, BorderLayout.NORTH);
		
		scrollPane.setPreferredSize(new Dimension(400, 300));

		frame.pack();
		frame.setLocationRelativeTo(null);
		frame.setVisible(true);

	}

	public void init() {
		
		textFilter.getDocument().addDocumentListener(new DocumentListener() {
			
			@Override
			public void removeUpdate(DocumentEvent e) {
				filter();
			}
			
			@Override
			public void insertUpdate(DocumentEvent e) {
				filter();
			}
			
			@Override
			public void changedUpdate(DocumentEvent e) {
				filter();
			}
		});

		// tao data model
		dataModel = new AbstractTableModel() {

			@Override
			public Object getValueAt(int row, int col) {
				// TODO Auto-generated method stub
				return dataStudent[row][col];
			}

			@Override
			public int getRowCount() {
				// TODO Auto-generated method stub
				return dataStudent.length;
			}

			@Override
			public int getColumnCount() {
				// TODO Auto-generated method stub
				return columnsName.length;
			}

			public String getColumnName(int col) {
				return columnsName[col];
			}

			public Class getColumnClass(int col) {
				return getValueAt(0, col).getClass();
			}

			public void setValueAt(Object oValue, int row, int col) {
				dataStudent[row][col] = oValue;
			}

			public boolean isCellEditable(int row, int col) {
				return (col == 2);
			}
		};

		table.setModel(dataModel);

		// xac dinh highlinght
		HighlightPredicate predicate = new HighlightPredicate() {

			@Override
			public boolean isHighlighted(Component render,
					ComponentAdapter adapter) {

				return ((Boolean) adapter.getValueAt(adapter.row, 2))
						.booleanValue();
			}

		};

		// Render
		ColorHighlighter colorHighLight = new ColorHighlighter(predicate,
				Color.RED, Color.DARK_GRAY);
		
		// HighLighting
		table.addHighlighter(HighlighterFactory
				.createSimpleStriping(HighlighterFactory.BEIGE));
		
		table.addHighlighter(colorHighLight);

		// Rollver
		table.addHighlighter(new ColorHighlighter(
				HighlightPredicate.ROLLOVER_ROW, null, Color.BLUE));

		// an hien cac cot
		table.setColumnControlVisible(true);
		
		//Filter Search
		sorter = new TableRowSorter<TableModel>(table.getModel());
		table.setRowSorter(sorter);
	}
	
	public void filter() {
		String text = textFilter.getText();
		
		if (text.length() == 0) {
			sorter.setRowFilter(null);
		} else {
			sorter.setRowFilter(RowFilters.regexFilter(Pattern.compile(
					"(?i).*" + text + ".*",
					Pattern.CASE_INSENSITIVE | Pattern.DOTALL).toString()));
		}
	}

	public static void main(String[] args) {
		new JXTableSimple();
	}

}
