import java.io.IOException;
import java.io.PrintWriter;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletConfig;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

public class MuaHang extends HttpServlet {
	private GioHang gh=null;
	
	public MuaHang() {
		super();
		gh=new GioHang();
	}

	public void init(ServletConfig config) throws ServletException {
	}
	
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		doPost(request, response);	
	}

	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		response.setContentType("text/html;charset=UTF-8");
		PrintWriter out = response.getWriter();
		
		try {
			HttpSession session = request.getSession(true);
			out.println("<html>");
			out.println("<head>");
			out.println("<title>Smartphone Shop</title>");
			out.println("</head>");
			out.println("<body>");
			out.println("<form action=\"login.jsp\" method=\"post\">");
			out.println("Xin chào !<BR>");
			out.println("<input type=\"submit\" value=\"Đăng xuất\">");
			out.println("</form>");
			out.println("<h1 align=\"center\">CỬA HÀNG ĐIỆN THOẠI DI ĐỘNG</h1>");
			out.println("<form action=\"XuLy\" method=\"post\">");
			out.println("<p>Chọn hãng:<select name=\"cbohang\">");
			out.println("<option><Hãng></option>" +
			"<option>Apple</option>" +
			"<option>Samsung</option>" +
			"<option>Sony</option>" +
			"<option>Nokia</option>" +
			"<option>Asus</option>");
			out.println("</select>");
			out.println("</p>");
			out.println("<input type=\"submit\" value=\"Xem giỏ hàng\">");
			out.println("<h2 align=\"center\">THÔNG TIN MẶT HÀNG</h2>");
			out.println("<table width=\"80%\" border=\"1\"><tr>"+
			"<td align=\"center\">STT</td><td align=\"center\">Tên Sản phẩm</td>"+ 
			"<td align=\"center\">Giá</td><td align=\"center\">Ghi chú</td></tr>"); 
			String hang = request.getParameter("cbohang");
			if (hang.startsWith("Apple")) {
				out.println("<tr><td align=\"center\">"+1+"</td><td>"+"Iphone 5"+"</td><td>"+12000000+"</td>"+"<td>"+""+"</td>"+"</tr>");
				out.println("<tr><td align=\"center\">"+2+"</td><td>"+"Iphone 5S"+"</td><td>"+12500000+"</td>"+"<td>"+""+"</td>"+"</tr>");
				out.println("<tr><td align=\"center\">"+3+"</td><td>"+"Iphone 6"+"</td><td>"+14000000+"</td>"+"<td>"+""+"</td>"+"</tr>");
				out.println("<tr><td align=\"center\">"+4+"</td><td>"+"Iphone 6S"+"</td><td>"+15000000+"</td>"+"<td>"+""+"</td>"+"</tr>");
				out.println("<tr><td align=\"center\">"+5+"</td><td>"+"Iphone 6S Plus"+"</td><td>"+16000000+"</td>"+"<td>"+""+"</td>"+"</tr>");
			}
			if (hang.startsWith("Samsung")) {
				out.println("<tr><td align=\"center\">"+1+"</td><td>"+"Galaxy S6"+"</td><td>"+13000000+"</td>"+"<td>"+""+"</td>"+"</tr>");
				out.println("<tr><td align=\"center\">"+2+"</td><td>"+"Galaxy S6 Edge"+"</td><td>"+14000000+"</td>"+"<td>"+""+"</td>"+"</tr>");
				out.println("<tr><td align=\"center\">"+3+"</td><td>"+"Galaxy S7"+"</td><td>"+15000000+"</td>"+"<td>"+""+"</td>"+"</tr>");
				out.println("<tr><td align=\"center\">"+4+"</td><td>"+"Galaxy S7 Edge"+"</td><td>"+16000000+"</td>"+"<td>"+""+"</td>"+"</tr>");
			}
			if (hang.startsWith("Sony")) {
				out.println("<tr><td align=\"center\">"+1+"</td><td>"+"Xperia Z1"+"</td><td>"+10000000+"</td>"+"<td>"+""+"</td>"+"</tr>");
				out.println("<tr><td align=\"center\">"+2+"</td><td>"+"Xperia Z2"+"</td><td>"+11000000+"</td>"+"<td>"+""+"</td>"+"</tr>");
				out.println("<tr><td align=\"center\">"+3+"</td><td>"+"Xperia Z3"+"</td><td>"+12000000+"</td>"+"<td>"+""+"</td>"+"</tr>");
				out.println("<tr><td align=\"center\">"+4+"</td><td>"+"Xperia Z4"+"</td><td>"+13000000+"</td>"+"<td>"+""+"</td>"+"</tr>");
			}
			if (hang.startsWith("Nokia")) {
				out.println("<tr><td align=\"center\">"+1+"</td><td>"+"Lumia 520"+"</td><td>"+8000000+"</td>"+"<td>"+""+"</td>"+"</tr>");
				out.println("<tr><td align=\"center\">"+2+"</td><td>"+"Lumia 620"+"</td><td>"+9000000+"</td>"+"<td>"+""+"</td>"+"</tr>");
				out.println("<tr><td align=\"center\">"+3+"</td><td>"+"Lumia 720"+"</td><td>"+10000000+"</td>"+"<td>"+""+"</td>"+"</tr>");
				out.println("<tr><td align=\"center\">"+4+"</td><td>"+"Lumia 920"+"</td><td>"+11000000+"</td>"+"<td>"+""+"</td>"+"</tr>");
			}
			if (hang.startsWith("Asus")) {
				out.println("<tr><td align=\"center\">"+1+"</td><td>"+"Zenfone 4"+"</td><td>"+3000000+"</td>"+"<td>"+""+"</td>"+"</tr>");
				out.println("<tr><td align=\"center\">"+2+"</td><td>"+"Zenfone 5"+"</td><td>"+3500000+"</td>"+"<td>"+""+"</td>"+"</tr>");
				out.println("<tr><td align=\"center\">"+3+"</td><td>"+"Zenfone 6"+"</td><td>"+5000000+"</td>"+"<td>"+""+"</td>"+"</tr>");
				out.println("<tr><td align=\"center\">"+4+"</td><td>"+"Zenfone 2"+"</td><td>"+5500000+"</td>"+"<td>"+""+"</td>"+"</tr>");
			}
			out.println("");
			out.println("");
			out.println("</table>");
			out.println("");	
			out.println("</form>");
			out.println("</body>");
			out.println("</html>");
		} 
		finally {
			out.println("</html>");
			out.close();
		}
	}
}